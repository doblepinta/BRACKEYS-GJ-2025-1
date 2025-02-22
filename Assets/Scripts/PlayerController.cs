using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed = 2f;

    public Animator anim;

    public bool extinguisher = false;
    public float range = 2f;

    public GameObject extinguisherGO;

    public Transform extinguisherPartToRotate;

    private Camera cam;
    public float camSpeed = 0.05f;
    public float camMaxValue = 5f;

    public bool leveled = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = Camera.main;
    }
    IEnumerator CamCoroutine()
    {
        while (cam.orthographicSize <= camMaxValue)
        {
            cam.orthographicSize += camSpeed;
            yield return new WaitForSeconds(0.05f);
        }
        if(FindFirstObjectByType<GameManager>().level == 1)
        {
            FindFirstObjectByType<LevelChanger>().FadeToLevel(2);
        }
        else if (FindFirstObjectByType<GameManager>().level == 2)
        {
            FindFirstObjectByType<LevelChanger>().FadeToLevel(3);
        }
        else if (FindFirstObjectByType<GameManager>().level == 3)
        {
            FindFirstObjectByType<LevelChanger>().FadeToLevel(4);
        }
        else if (FindFirstObjectByType<GameManager>().level == 4)
        {
            FindFirstObjectByType<LevelChanger>().FadeToLevel(5);
        }
        else if (FindFirstObjectByType<GameManager>().level == 5)
        {
            FindFirstObjectByType<LevelChanger>().FadeToLevel(6);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (FindFirstObjectByType<GameManager>().levelComplete && !leveled)
        {
            leveled = true;
            StartCoroutine("CamCoroutine");
            return;
        }

        if (Input.GetMouseButton(0))
        {
            anim.SetBool("extinguisher", true);
            anim.SetBool("isWalking", false);
            extinguisher = true;

            extinguisherGO.SetActive(true);


            // Vector3 touchPos = Input.mousePosition;
            //  Vector3 touchDownWorldPos = cam.ScreenToWorldPoint(touchPos);
            // Debug.Log("touch down mouse pos: " + touchPos + " world pos: " + touchDownWorldPos);


            Vector3 point = cam.ScreenToWorldPoint(Input.mousePosition);


            Vector3 dir = (point - transform.position).normalized;

            Quaternion lookRotation = Quaternion.LookRotation(dir, Vector3.forward);


            Vector3 rotation = lookRotation.eulerAngles;
            //Debug.Log(rotation);
            // Vector3 rotation = Quaternion.Lerp(extinguisherPartToRotate.rotation, lookRotation, turnSpeed * Time.deltaTime).eulerAngles;

            rotation.z *= -1; 
            extinguisherPartToRotate.eulerAngles = new Vector3 (0f, 0f, rotation.z);

            return;
        }
        else
        {
            anim.SetBool("extinguisher", false);
            extinguisher = false;
            extinguisherGO.SetActive(false);
        }
        bool move = false;
        if (Input.GetAxisRaw("Vertical") == 1)
        {
            if (!extinguisher)
            {
                transform.Translate(Vector3.up * speed * Time.fixedDeltaTime);
                anim.SetFloat("y", 1);
                anim.SetFloat("x", 0);
                anim.SetBool("isWalking", true);
                move = true;
            }
        }
        if (Input.GetAxisRaw("Vertical") == -1)
        {
            if (!extinguisher)
            {
                transform.Translate(Vector3.down * speed * Time.fixedDeltaTime);
                anim.SetFloat("y", -1);
                anim.SetFloat("x", 0);
                anim.SetBool("isWalking", true);
                move = true;
            }

        }
        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            if (!extinguisher)
            {
                transform.Translate(Vector3.right * speed * Time.fixedDeltaTime);
                anim.SetFloat("x", 1);
                anim.SetFloat("y", 0);
                anim.SetBool("isWalking", true);
                move = true;
            }
        }
        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            if (!extinguisher)
            {
                transform.Translate(Vector3.left * speed * Time.fixedDeltaTime);
                anim.SetFloat("x", -1);
                anim.SetFloat("y", 0);
                anim.SetBool("isWalking", true);
                move = true;
            }
        }
        if (!move)
        {
            anim.SetBool("isWalking", false);
        }
    }
}

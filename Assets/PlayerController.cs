using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 2f;

    public Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        bool move = false;
        if (Input.GetAxisRaw("Vertical") == 1)
        {
            transform.Translate(Vector3.up * speed * Time.fixedDeltaTime);
            anim.SetFloat("y", 1);
            anim.SetFloat("x", 0);
            anim.SetBool("isWalking", true);
            move = true;
        }
        if (Input.GetAxisRaw("Vertical") == -1)
        {
            transform.Translate(Vector3.down * speed * Time.fixedDeltaTime);
            anim.SetFloat("y", -1);
            anim.SetFloat("x", 0);
            anim.SetBool("isWalking", true);
            move = true;
        }
        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            transform.Translate(Vector3.right * speed * Time.fixedDeltaTime);
            anim.SetFloat("x", 1);
            anim.SetFloat("y", 0);
            anim.SetBool("isWalking", true);
            move = true;
        }
        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            transform.Translate(Vector3.left * speed * Time.fixedDeltaTime);
            anim.SetFloat("x", -1);
            anim.SetFloat("y", 0);
            anim.SetBool("isWalking", true);
            move = true;
        }
        if (!move)
        {
            anim.SetBool("isWalking", false);
        }
    }
}

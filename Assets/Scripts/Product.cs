using UnityEngine;
using System.Collections;

public class Product : MonoBehaviour
{

    public bool onFire = false;
    public float life = 1f;
    public float fireDamage = 0.05f;

    public GameObject fireParticlePrefab;

    public float counter = 0;
    public float counterInc = 0.1f;
    
    public bool onMovement = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //OnMovement();
        Destroy(this.gameObject,20f);
    }

    public void OnMovement()
    {
        StopCoroutine("OnMovementCoroutine");
        StartCoroutine("OnMovementCoroutine");
    }
    IEnumerator OnMovementCoroutine()
    {
        yield return new WaitForSeconds(2f);
        if (!onMovement)
        {
            Destroy(this.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {

        if (counter >= 1)
        {
            onFire = false;
            life = 1;
            counter = 0;
            CancelInvoke("Fire");

            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            GetComponent<SpriteRenderer>().sortingOrder = 2;

            GetComponent<Renderer>().material.color = Color.white;

            Transform[] fireParticles = new Transform[transform.childCount];

            for (int i = 0; i <fireParticles.Length; i++)
            {
                Destroy( transform.GetChild(i).gameObject);

            }
        }

        if (onFire)
        {
            life -= fireDamage;
            GetComponent<Renderer>().material.color = new Color(1, life, life);

            if (life <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
    private void OnMouseOver()
    {
        if (Vector3.Distance(transform.position, FindFirstObjectByType<PlayerController>().transform.position)< FindFirstObjectByType<PlayerController>().range)
        {
            if (Input.GetMouseButton(0))
            {
                counter += counterInc;
            }
        }
        Debug.Log(Vector3.Distance(transform.position, FindFirstObjectByType<PlayerController>().transform.position));
    }

    public void StartFire()
    {
        onFire = true;
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        GetComponent<SpriteRenderer>().sortingOrder = 3;
        InvokeRepeating("Fire", 0, 0.5f);
    }

    public void Fire()
    {
        float randomX = Random.Range(-0.2f, 0.2f);
        float randomY = Random.Range(-0.2f, 0.2f);

        GameObject fireParticle = (GameObject)Instantiate(fireParticlePrefab, transform.position + new Vector3(randomX, randomY, 0), transform.rotation, this.gameObject.transform);
        Destroy(fireParticle, 1f);
    }
}

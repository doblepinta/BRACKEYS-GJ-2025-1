using UnityEngine;

public class Product : MonoBehaviour
{

    public bool onFire = false;
    public float life = 1f;
    public float fireDamage = 0.05f;

    public GameObject fireParticlePrefab;

    public float counter = 0;
    public float counterInc = 0.1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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


        if (transform.position.y < -5f)
        {
            Destroy(this.gameObject);
        }
    }

    public void OnMouseDown()
    {
        counter += counterInc;
    }

    public void StartFire()
    {
        onFire = true;
        InvokeRepeating("Fire", 0, 0.5f);
    }

    public void Fire()
    {
        float randomX = Random.Range(-0.25f, 0.25f);
        float randomY = Random.Range(-0.25f, 0.25f);

        GameObject fireParticle = (GameObject)Instantiate(fireParticlePrefab, transform.position + new Vector3(randomX, randomY, 0), transform.rotation, this.gameObject.transform);
        Destroy(fireParticle, 1f);
    }
}

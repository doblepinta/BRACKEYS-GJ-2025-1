using UnityEngine;
using System.Collections;

public class Machine : MonoBehaviour
{
    public GameObject fireParticlePrefab;

    public float counter = 0;


    public bool onFire = false;
    public float life = 1f;
    public float fireDamage = 0.05f;

    public float fireRateMachine = 10f;

    public Transform fireParticleHolder;



    public GameObject productPrefab;
    public Transform spawnPos;

    public Transform productHolder;

    public float timeBetweenProducts = 3f;

    public bool active = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    public void StartMachine()
    {
        active = true;
        StartCoroutine("SpawnCoroutine");

        StartCoroutine("FireMachine");

        counter = 0;
        life = 1;
    }
    IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            SpawnProduct();

            yield return new WaitForSeconds(timeBetweenProducts);
        }
    }

    public void SpawnProduct()
    {

        GameObject product = (GameObject)Instantiate(productPrefab, spawnPos.position, spawnPos.rotation, productHolder);
    }


    public void TurnOnMachine(int cost)
    {
        if (FindFirstObjectByType<GameManager>().boxCounter >= cost)
        {
            FindFirstObjectByType<GameManager>().boxCounter -= cost;
            FindFirstObjectByType<GameManager>().boxCounterText.text = FindFirstObjectByType<GameManager>().boxCounter.ToString();
            StartMachine();
            transform.GetChild(0).GetComponent<SpriteRenderer>().color = Color.white;

            FindFirstObjectByType<GameManager>().AddMachine();
        }
    }
    IEnumerator FireMachine()
    {
        while (!FindFirstObjectByType<GameManager>().levelComplete)
        {
            yield return new WaitForSeconds(Random.Range(0, fireRateMachine));
            if (!onFire && !FindFirstObjectByType<GameManager>().levelComplete)
            {
                StartFire();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!active)
        {
            return;
        }

        if (counter >= 1 && onFire == true)
        {
            OffFire();
        }

        if (onFire)
        {
           // Debug.Log(life);
            life -= fireDamage;
            transform.GetChild(0).GetComponent<Renderer>().material.color = new Color(1, life, life);

            if (life <= 0)
            {
                FindFirstObjectByType<GameManager>().DestroyedMachine();
                Destroy(fireParticleHolder.gameObject);
                Destroy(this.gameObject);
            }
        }
    }

    public void OffFire()
    {
        onFire = false;
      //  FindFirstObjectByType<GameManager>().RestOnFire();
        life = 1;
        counter = 0;
        CancelInvoke("Fire");

        transform.GetChild(0).GetComponent<Renderer>().material.color = Color.white;

        Transform[] fireParticles = new Transform[fireParticleHolder.childCount];

        for (int i = 0; i < fireParticles.Length; i++)
        {
            Destroy(fireParticleHolder.GetChild(i).gameObject);

        }
    }
    private void OnMouseOver()
    {
        Debug.Log("OnMouseOver");
        if (Vector3.Distance(transform.position, FindFirstObjectByType<PlayerController>().transform.position) < FindFirstObjectByType<PlayerController>().range)
        {
            if (Input.GetMouseButton(0))
            {
                counter += FindFirstObjectByType<GameManager>().counterInc;
            }
        }
       // Debug.Log(Vector3.Distance(transform.position, FindFirstObjectByType<PlayerController>().transform.position));
    }
    public void StartFire()
    {
        counter = 0;
        life = 1;
        onFire = true;
        FindFirstObjectByType<GameManager>().AddMachineOnFire();
       // GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
       // GetComponent<SpriteRenderer>().sortingOrder = 3;
        InvokeRepeating("Fire", 0, 0.5f);
    }
    public void Fire()
    {

        float randomX = Random.Range(-.1f, .1f);
        float randomY = Random.Range(-.1f, 1f);

        GameObject fireParticle = (GameObject)Instantiate(fireParticlePrefab, transform.position + new Vector3(randomX, randomY, 0), transform.rotation);
        Destroy(fireParticle, 1f);
    }
}

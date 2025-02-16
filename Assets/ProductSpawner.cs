using UnityEngine;
using System.Collections;

public class ProductSpawner : MonoBehaviour
{

    public GameObject productPrefab;

    public Transform spawnPos;
    public Transform productHolder;

    public float timeBetweenProducts = 1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine("SpawnCoroutine");
    }

    // Update is called once per frame
    void Update()
    {
        
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
}

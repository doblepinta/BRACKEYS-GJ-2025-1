using UnityEngine;
using System.Collections;

public class ProductSpawner : MonoBehaviour
{

    public GameObject productPrefab;

    public Transform [] spawnPos;
    public float[] spawnDelay;

    public Transform productHolder;

    public float timeBetweenProducts = 1f;


    public bool machineB_Opened = false;
    public GameObject machineB_GO;
    public GameObject machineA_BlockB;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine("SpawnCoroutine");
        machineB_GO.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenMachineA()
    {
        if (!machineB_Opened)
        {
            machineB_Opened = true;
            machineB_GO.SetActive(true);
            machineA_BlockB.SetActive(false);
        }
    }
    IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnDelay[0]);
            SpawnProduct(0);

            if (machineB_Opened)
            {
                //yield return new WaitForSeconds(spawnDelay[1]);
                SpawnProduct(1);
            }

            yield return new WaitForSeconds(timeBetweenProducts);
        }
    }

    public void SpawnProduct(int route)
    {

        GameObject product = (GameObject)Instantiate(productPrefab, spawnPos[route].position, spawnPos[route].rotation, productHolder);
    }
}

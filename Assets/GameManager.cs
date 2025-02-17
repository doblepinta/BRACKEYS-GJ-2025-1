using UnityEngine;
using System.Collections;
using TMPro;

public class GameManager : MonoBehaviour
{

    public string productTag = "Product";

    public float fireRate = 2f;

    public int counter = 0;
    public TextMeshProUGUI counterText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        counterText.text = counter.ToString();
        StartCoroutine("FireCoroutine");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void AddCounter()
    {
        counter++;
        counterText.text = counter.ToString();
    }

    IEnumerator FireCoroutine()
    {
        yield return new WaitForSeconds(3f);
        while (true)
        {
            RandomFire();
            yield return new WaitForSeconds(fireRate);
        }
    }

    public void RandomFire()
    {
        GameObject[] products = GameObject.FindGameObjectsWithTag(productTag);
        int index = Random.Range(0, products.Length);
        products[index].GetComponent<Product>().StartFire();

    }
}

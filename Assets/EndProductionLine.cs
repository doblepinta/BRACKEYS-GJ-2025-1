using UnityEngine;

public class EndProductionLine : MonoBehaviour
{
    public string productTag = "Product";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == productTag)
        {
            Destroy(other.gameObject, .5f);
            //Add counter

            if (!other.GetComponent<Product>().onFire)
            {
                FindFirstObjectByType<GameManager>().AddCounter();
            }
        }
    }
}

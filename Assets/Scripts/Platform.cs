using UnityEngine;


public enum Dir
{
    Up,
    Down,
    Left,
    Right
}
public class Platform : MonoBehaviour
{
    public float conveyorBeltSpeed = 10f;

    public string productTag = "Product";
    public Dir dir;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == productTag)
        {
            if (other.gameObject.GetComponent<Product>().onFire)
            {
                return; 
            }
            if(dir == Dir.Up)
            {
                other.transform.Translate(Vector3.up * conveyorBeltSpeed * Time.fixedDeltaTime);
            }
            else if (dir == Dir.Down)
            {
                other.transform.Translate(Vector3.down * conveyorBeltSpeed * Time.fixedDeltaTime);
            }
            else if (dir == Dir.Right)
            {
                other.transform.Translate(Vector3.right * conveyorBeltSpeed * Time.fixedDeltaTime);
            }
            else if (dir == Dir.Left)
            {
                other.transform.Translate(Vector3.left * conveyorBeltSpeed * Time.fixedDeltaTime);
            }
        }
    }
   /* private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == productTag)
        {
            other.gameObject.GetComponent<Product>().onMovement = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == productTag)
        {
            other.gameObject.GetComponent<Product>().onMovement = false;

            if (other.gameObject != null)
            {
                other.gameObject.GetComponent<Product>().OnMovement();
            }

        }
    }*/
}

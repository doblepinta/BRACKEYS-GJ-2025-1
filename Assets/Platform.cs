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
            if(dir == Dir.Up)
            {
                other.transform.Translate(Vector3.up * conveyorBeltSpeed * Time.deltaTime);
            }
            else if (dir == Dir.Down)
            {
                other.transform.Translate(Vector3.down * conveyorBeltSpeed * Time.deltaTime);
            }
            else if (dir == Dir.Right)
            {
                other.transform.Translate(Vector3.right * conveyorBeltSpeed * Time.deltaTime);
            }
            else if (dir == Dir.Left)
            {
                other.transform.Translate(Vector3.left * conveyorBeltSpeed * Time.deltaTime);
            }
        }
    }
}

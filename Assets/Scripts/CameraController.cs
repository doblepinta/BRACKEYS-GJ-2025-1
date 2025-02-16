using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float panSpeed = 10f;

    public float minX, maxX;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.mousePosition.x > (Screen.width * .95) && Input.mousePosition.x < (Screen.width * 1))
        {
            if (transform.position.x <= maxX)
            {
                transform.Translate(Vector3.right * panSpeed * Time.deltaTime);
            }
        }
        else if (Input.mousePosition.x > (Screen.width * 0) && Input.mousePosition.x < (Screen.width * 0.05))
        {
            if (transform.position.x >= minX)
            {
                transform.Translate(Vector3.left * panSpeed * Time.deltaTime);
            }
        }

    }
}

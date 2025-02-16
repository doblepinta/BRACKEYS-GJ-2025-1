using UnityEngine;
using UnityEngine.UI;

public class ConveyorBeltController : MonoBehaviour
{

    public float conveyorBeltSpeed = 10f;

    public string productTag = "Product";
    
    public Slider slider;

    public float minSpeed, maxSpeed;

    public float startSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        slider.maxValue = maxSpeed;
        slider.minValue = minSpeed;
        slider.value = startSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        conveyorBeltSpeed = slider.value;
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == productTag)
        {
            other.transform.Translate(Vector3.right * conveyorBeltSpeed * Time.deltaTime);
        }
    }
}

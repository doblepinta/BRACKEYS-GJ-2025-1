using UnityEngine;

public class AudioController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        FindFirstObjectByType<AudioManager>().Stop("Theme");
        FindFirstObjectByType<AudioManager>().Play("GameThemeCalm");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

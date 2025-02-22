using UnityEngine.Audio;
using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

    public Sound[] sounds;

    public static AudioManager instance;

    private double soundController = 1;

    void Awake()
    {

        DontDestroyOnLoad(gameObject);

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volumen;
            s.source.pitch = s.pitch;

            s.source.loop = s.loop;
        }
    }
    private void Start()
    {
        Play("Theme");
        //Play("BackgroundMenu"); 
    }

    public void Restart()
    {
        foreach (Sound s in sounds)
        {
            s.source.Stop();
        }
        Play("MenuTheme");
        //Play("BackgroundMenu");
    }

    public void ChangeTheme(string name)
    {
        Sound s = System.Array.Find(sounds, sound => sound.name == "MenuTheme");
        
        Play(name);
        ThemeChanger(s);
    }

    IEnumerator VolumeOpen(Sound s)
    {
        float volumeCounter = 0;
        while (volumeCounter < 1)
        {
            yield return new WaitForSeconds(0.01f);
            volumeCounter = +1 / 100;

            s.volumen = volumeCounter;
        }
    }

    IEnumerator ThemeChanger(Sound s)
    {
        float volumeCounter =1; 
        while (volumeCounter > 0)
        {
            volumeCounter = -1 / 100;
            s.volumen = volumeCounter;
            yield return new WaitForSeconds(0.01f);
        }
        s.source.Stop();
    }

    public void Play (string name)
    {
        Sound s = System.Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();
        VolumeOpen(s);
    }
    public void Stop(string name)
    {
        Sound s = System.Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Stop();
        VolumeOpen(s);
    }

    public void ManagerVolume( float vol)
    {
        foreach (Sound s in sounds)
        {
            s.source.volume = vol;
        }
    }

    public void SoundController()
    {
        if (soundController == 1)
        {
            soundController = 0;
            ManagerVolume(0);
        }
        else if (soundController ==0)
        {
            soundController = 0.5;
            ManagerVolume(1/2);
        }
        else if (soundController == 0.5)
        {
            soundController = 1;
            ManagerVolume(1);
        }
    }
}

using UnityEngine;
using System.Collections;
using TMPro;

public class GameManager : MonoBehaviour
{

    public string productTag = "Product";

    public float fireRate = 2f;

    public float counterInc = 0.1f;
    public TextMeshProUGUI counterIncText;

    public int machineOnFire = 0;
    public int level;
    public int machines = 1;
    public int destroyedMachine = 0;


    public int boxCounter = 0;
    public TextMeshProUGUI boxCounterText;


    public bool levelComplete = false;
    public bool intense = false;

    public Machine[] startMachines;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        boxCounterText.text = boxCounter.ToString();
        StartCoroutine("FireCoroutine");

        counterIncText.text = "LEVEL: " + (counterInc * 10).ToString();

        foreach (Machine machine in startMachines)
        {
            machine.StartMachine();
        }
    }

    public void AddMachine()
    {
        machines++;
        if (level == 1)
        {
            if (machines == 3)
            {
                levelComplete = true;
            }
        }
        else if (level == 2)
        {
            if (machines == 3)
            {
                levelComplete = true;
            }
        }
        else if (level == 3)
        {
            if (machines == 4)
            {
                levelComplete = true;
            }
        } 
        else if (level == 4)
        {
            if (machines == 6)
            {
                levelComplete = true;
            }
        }
        else if (level == 5)
        {
            if (machines == 9)
            {
                levelComplete = true;
            }
        }

        
        foreach (Machine machine in FindObjectsOfType<Machine>())
        {
            machine.OffFire();
        }
    }

    public void DestroyedMachine()
    {
        destroyedMachine++; 
        if (level == 1)
        {
            FindFirstObjectByType<LevelChanger>().FadeToLevel(1);
        }
        else if (level == 2)
        {
            FindFirstObjectByType<LevelChanger>().FadeToLevel(2);
        }
        else if (level == 3)
        {
            FindFirstObjectByType<LevelChanger>().FadeToLevel(3);
        }
        else if (level == 4)
        {
            FindFirstObjectByType<LevelChanger>().FadeToLevel(4);
        }
        else if (level == 5)
        {
            FindFirstObjectByType<LevelChanger>().FadeToLevel(5);
        }

    }
    public void IncLevelUp()
    {
        if(counterInc < 1)
        {
            counterInc += 0.05f;
            counterIncText.text = "EXTINGUISHER LEVEL: " + (counterInc * 20).ToString();
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }


    public void AddCounter()
    {
        boxCounter++;
        boxCounterText.text = boxCounter.ToString();
    }
    public void AddMachineOnFire ()
    {
        machineOnFire++;
        Debug.Log(machineOnFire);
        if (level == 1)
        {
            if (machineOnFire == 2)
            {
                FindFirstObjectByType<AudioManager>().Stop("GameThemeCalm");
                FindFirstObjectByType<AudioManager>().Play("GameThemeIntense");
                intense = true;
            }
        }
        else if (level == 2)
        {
            if (machineOnFire == 2)
            {
                FindFirstObjectByType<AudioManager>().Stop("GameThemeCalm");
                FindFirstObjectByType<AudioManager>().Play("GameThemeIntense");
                intense = true;
            }
        }
        else if (level == 3)
        {
            if (machineOnFire == 2)
            {
                FindFirstObjectByType<AudioManager>().Stop("GameThemeCalm");
                FindFirstObjectByType<AudioManager>().Play("GameThemeIntense");
                intense = true;
            }
        }
        else if (level == 4)
        {
            if (machineOnFire == 3)
            {
                FindFirstObjectByType<AudioManager>().Stop("GameThemeCalm");
                FindFirstObjectByType<AudioManager>().Play("GameThemeIntense");
                intense = true;
            }
        }
        else if (level == 5)
        {
            if (machineOnFire == 4)
            {
                FindFirstObjectByType<AudioManager>().Stop("GameThemeCalm");
                FindFirstObjectByType<AudioManager>().Play("GameThemeIntense");
                intense = true;
            }
        }
    }
    public void RestOnFire()
    {
        machineOnFire--;
        if (level == 1)
        {
            if (machineOnFire == 0 && intense)
            {
                FindFirstObjectByType<AudioManager>().Stop("GameThemeIntense");
                FindFirstObjectByType<AudioManager>().Play("GameThemeCalm");
                intense = false;
            }
        }
        else if (level == 2)
        {
            if (machineOnFire == 0 && intense)
            {
                FindFirstObjectByType<AudioManager>().Stop("GameThemeIntense");
                FindFirstObjectByType<AudioManager>().Play("GameThemeCalm");
                intense = false;
            }
        }
        else if (level == 3)
        {
            if (machineOnFire == 0 && intense)
            {
                FindFirstObjectByType<AudioManager>().Stop("GameThemeIntense");
                FindFirstObjectByType<AudioManager>().Play("GameThemeCalm");
                intense = false;
            }
        }
        else if (level == 4)
        {
            if (machineOnFire == 0 && intense)
            {
                FindFirstObjectByType<AudioManager>().Stop("GameThemeIntense");
                FindFirstObjectByType<AudioManager>().Play("GameThemeCalm");
                intense = false;
            }
        }
        else if (level == 5)
        {
            if (machineOnFire == 0 && intense)
            {
                FindFirstObjectByType<AudioManager>().Stop("GameThemeIntense");
                FindFirstObjectByType<AudioManager>().Play("GameThemeCalm");
                intense = false;
            }
        }

    }

    IEnumerator FireCoroutine()
    {
        yield return new WaitForSeconds(3f);
        while (!levelComplete)
        {
            RandomFire();
            yield return new WaitForSeconds(fireRate);
        }
    }

    public void RandomFire()
    {
        GameObject[] products = GameObject.FindGameObjectsWithTag(productTag);

        if (products.Length > 0)
        {
            int index = Random.Range(0, products.Length);
            products[index].GetComponent<Product>().StartFire();
        }
    }
}

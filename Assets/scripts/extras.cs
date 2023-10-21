using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class extras : MonoBehaviour
{
    public sounds sounds;
    public GameObject starter;
    // Start is called before the first frame update
    void Start()
    {
        sounds = GetComponent<sounds>();
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (sounds != null)
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                sounds.PlayMusic();
            }

            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            { 
                sounds.PlayMusic(); 
            }
        }
        
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D))
        {
            sounds.StopMusic();
        }
    }

    public void start()
    {
        SceneManager.LoadScene("Level (1)");
    }

    public void stop()
    {
        Application.Quit();
    }

    public void Continue()
    {
        Time.timeScale = 1.0f;
        starter.SetActive(false);
    }

    public void pause()
    {
        starter.SetActive(true);
        Time.timeScale = 0f;
    }

}

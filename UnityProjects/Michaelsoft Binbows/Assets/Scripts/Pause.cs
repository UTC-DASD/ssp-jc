using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    
   [SerializeField] private List<GameObject> pauseMenuButtons;
   bool isPaused = false;

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetButtonDown("Cancel"))
        {
            PauseUnpause(ref isPaused);
        }  

    }

    public void ResumeButton()

    {
        PauseUnpause(ref isPaused);
    }

    public void QuitButton()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    private void PauseUnpause(ref bool pauseState)
    {

        if(!pauseState)
        {
            Time.timeScale = 0.0f;
            pauseState = true;
            Cursor.lockState = CursorLockMode.None;

            foreach (GameObject button in pauseMenuButtons)
            {
                button.SetActive(true);
            }

        }

    else
    {
        Time.timeScale = 1.0f;
        pauseState = false;

        foreach (GameObject button in pauseMenuButtons)
        {
            button.SetActive(false);
        }
    }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private List<GameObject> StartMenuButtons;

    public void QuitButton()
    {
        Debug.Log("P");
        Application.Quit();
    }
    public void StartButton()
    {
        SceneManager.LoadScene(0);
    }
}

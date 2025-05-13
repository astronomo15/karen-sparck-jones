using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void MenuBack()
    {
        SceneManager.LoadScene("Menu");
    }
    public void PlayButton()
    {
        SceneManager.LoadScene("PA");
    }
    public void QuitButton()
    {
        Application.Quit();
        Debug.Log("Saindo...");
    }

    public void ReplayButton()
    {
        Time.timeScale = 1;
    }
}
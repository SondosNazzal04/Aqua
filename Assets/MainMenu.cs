using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void PlayLevel1()
    {
        SceneManager.LoadScene("level1");
    }
    public void PlayLevel2()
    {
        SceneManager.LoadScene("level2");
    }
    public void exitButton()
    {
        Application.Quit();
        Debug.Log("Exit");
    }
}

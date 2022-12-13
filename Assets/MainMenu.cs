using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject settingsPanel;
    public GameObject ExitPanel;

    public void StartGame() 
    {
        SceneManager.LoadScene(1);

    }

    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }

   public void ExitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void OpenExit()
    {
        ExitPanel.SetActive(true);

    }

    public void CloseExit()
    {
        ExitPanel.SetActive(false);

    }
}

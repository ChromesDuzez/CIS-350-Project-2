/*
* Devun Schneider
* CIS 350 - Trash Pick-Up Simulator
* This script manages the changing of scenes throughout the menus
*/

using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            Time.timeScale = 1.0f;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
    public void LoadScene(string sceneName)
    {
        Debug.Log("SceneLoader");
        Debug.Log("sceneName to load: " + sceneName);
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    //Zach Wilson -> so that the start button can send the player to the tutorial scene first if the player has not been yet
    public void StartGame(string sceneName)
    {
        if(GlobalSettings.hasSeenTutorial)
        {
            Debug.Log("SceneLoader");
            Debug.Log("sceneName to load: " + sceneName);
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            try
            {
                GlobalSettings.hasSeenTutorial = true; 
                Debug.Log("SceneLoader");
                Debug.Log("sceneName to load: " + GlobalSettings.tutorialScene);
                if(SceneManager.GetSceneByName(GlobalSettings.tutorialScene).IsValid())
                {
                    SceneManager.LoadScene(GlobalSettings.tutorialScene);
                }
                else
                {
                    throw new UnityException("Tutorial Scene Not Found!");
                }
            }
            catch
            {
                GlobalSettings.hasSeenTutorial = false;
                Debug.Log("SceneLoader Failed to find Tutorial Scene: " + GlobalSettings.tutorialScene);
                Debug.Log("SceneLoader");
                Debug.Log("sceneName to load: " + sceneName);
                SceneManager.LoadScene(sceneName);
            }
        }
    }
}
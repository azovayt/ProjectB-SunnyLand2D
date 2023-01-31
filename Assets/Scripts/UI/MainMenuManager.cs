using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public string sceneName;

    public void GamePlay(){
        SceneManager.LoadScene(sceneName);
    }
    public void ExitGame(){
        Application.Quit();
    }
}

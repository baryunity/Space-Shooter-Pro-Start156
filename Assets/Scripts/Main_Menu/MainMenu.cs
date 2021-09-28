using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadGame()
    {
        //print("LoadGame 1");
        SceneManager.LoadScene(1);      // Game Scene
        //print("LoadGame 22");
    }

    public void LoadSinglePlayerGame()
    {
        print("Single Player Game Loading...");
        SceneManager.LoadScene(1);      // Single Player Game Scene
    }

    public void LoadCoOpMode()
    {
        print("Co-Op Mode Loading...");
        SceneManager.LoadScene(2);      // Co-Op Mode Game Scene
    }

}

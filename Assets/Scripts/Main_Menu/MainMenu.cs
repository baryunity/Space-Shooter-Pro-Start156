using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadGame()      // Probably unused at this point    //FOO
    {
        //print("LoadGame 1");
        SceneManager.LoadScene(1);      // Game Scene
        //print("LoadGame 22");
    }

    public void LoadSinglePlayerGame()
    {
        print("Single Player Game Loading...");
        SceneManager.LoadScene("Single_Player");    // Single Player Game Scene (1)
    }

    public void LoadCoOpMode()
    {
        print("Co-Op Mode Loading...");
        SceneManager.LoadScene("Co-Op_Mode");       // Co-Op Mode Game Scene (2)
    }

    public void ResetBestScore()
    {
        PlayerPrefs.SetInt("HighScore", 0);
        // Should do reset confirmation of some kind    // TODO
    }

}

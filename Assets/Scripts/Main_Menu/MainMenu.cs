using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadGame()
    {
        print("LoadGame 11");
        SceneManager.LoadScene(1);      // Game Scene
        print("LoadGame 222");

        //string compName = "";
        //compName = EditorGUILayout.TextField("Company Name:", compName);
        //print(compName);
    }
}

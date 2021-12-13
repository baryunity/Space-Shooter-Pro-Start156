using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isCoopMode = false;
    [SerializeField]
    private bool _isGameOver = false;
    private UIManager _uiManager;
    private SpawnManager _spawnManager;
    private bool oneShot = true;

    private void Start()
    {
        if (oneShot)
        {
            print("2021 12 12 - 1800 - " + (isCoopMode ? "Coop Mode" : "Single Player Mode"));
            oneShot = false; 
        }
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        if (_uiManager == null)
            Debug.LogError("GameManager: UIManager is NULL");
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        if (_spawnManager == null)
            Debug.LogError("GameManager: SpawnManager is NULL");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && _isGameOver)
        {
            SceneManager.LoadScene(0); 
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            oneShot = true;
            GameOver();
            SceneManager.LoadScene("Main_Menu");  
            print("Quit!");
            Application.Quit();
        }
        /// _spawnManager.StartSpawning();

        if (_isGameOver)
        {
            // Supposed to make space key restart new game in current mode
            if (Input.GetKeyDown(KeyCode.Space))
            {
                print("SPACE SPACE SPACE SPACE ==========");     ///FOO
                if (! isCoopMode)
                {
                    ///Instantiate(player, Vector3.zero, Quaternion.identity);
                }
                _isGameOver = false;
                ///_uiManager.HideTitleScreen();
                _spawnManager.StartSpawning();
            }
        }
    }

    public void GameOver()
    {
        _isGameOver = true;
    }

    public bool getCoopMode()
    {
        return isCoopMode;
    }

}

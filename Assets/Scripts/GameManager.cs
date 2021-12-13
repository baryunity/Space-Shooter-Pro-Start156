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
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject _coopPlayers;
    [SerializeField]
    private GameObject _pauseMenuPanel;

    private void Start()
    {
        if (oneShot)
        {
            print("2021 12 12 - 1930 - " + (isCoopMode ? "Coop Mode" : "Single Player Mode"));
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
        // _spawnManager.StartSpawning();

        if (_isGameOver)
        {
            // Supposed to make space key restart new game in current mode
            if (Input.GetKeyDown(KeyCode.Space))
            {
                print("SPACE SPACE SPACE SPACE ==========");     ///FOO 
                if (! isCoopMode)
                {
                    print("Instantiate Single Player =====");     ///FOO 
                    Instantiate(player, Vector3.zero, Quaternion.identity);
                }
                else if (isCoopMode)
                {
                    print("Instantiate Coop Players =====");
                    Instantiate(_coopPlayers, Vector3.zero, Quaternion.identity);
                }
                _isGameOver = false;
                ///_uiManager.HideTitleScreen();
                _spawnManager.StartSpawning();
            }
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            _pauseMenuPanel.SetActive(true);
            Time.timeScale = 0;
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

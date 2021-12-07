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

    private void Start()
    {
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
            SceneManager.LoadScene(0);      // Current Game Scene ("Game" = 1)
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            print("Quit!");
            Application.Quit();
        }
        /// _spawnManager.StartSpawning();
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

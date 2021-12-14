using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private Text _bestScoreText;
    [SerializeField]
    private Image _LivesImg;
    [SerializeField]
    private Sprite[] _liveSprites;
    [SerializeField]
    private Text _gameOverText;
    [SerializeField]
    private Text _restartText;
    [SerializeField]
    private GameObject _pauseMenuPanel;
    private GameManager _gameManager;
    private int _scoreCopy;
    private static int _bestScore;

    // Start is called before the first frame update
    void Start()
    {
        _scoreText.text = "Score: " + 0;
        _bestScoreText.text = "Best: " + _bestScore;
        _gameOverText.gameObject.SetActive(false);
        _gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();

        if (_gameManager == null)
            Debug.LogError("GameManager is NULL");
    }

    public void UpdateScore(int playerScore)
    {
        _scoreCopy = playerScore;
        _scoreText.text = "Score: " + playerScore;
    }

    public void CheckForBestScore()
    {
        if (_scoreCopy > _bestScore)
        {
            _bestScore = _scoreCopy;
            _bestScoreText.text = "Best: " + _bestScore;
        }
    }

    public void UpdateLives(int currentLives)
    {
        print("Player lives = " + currentLives);
        _LivesImg.sprite = _liveSprites[currentLives];

        if (currentLives == 0)
            GameOverSequence();
    }

    void GameOverSequence()
    {
        _gameManager.GameOver();
        _gameOverText.gameObject.SetActive(true);
        _restartText.gameObject.SetActive(true);
        StartCoroutine(GameOverFlickerRoutine());
    }

    IEnumerator GameOverFlickerRoutine()
    {
        while (true)
        {
            _gameOverText.text = "GAME OVER";
            yield return new WaitForSeconds(0.5f);
            _gameOverText.text = "";
            yield return new WaitForSeconds(0.5f);
        }
    }

    public void ResumePlay() 
    {
        _gameManager.ResumeGame();
    }

    public void BackToMainMenu()
    {
//      oneShot = true;
//      GameOver();
        SceneManager.LoadScene("Main_Menu");
    }

}

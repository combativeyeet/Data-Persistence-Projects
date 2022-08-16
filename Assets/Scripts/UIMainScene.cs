using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class UIMainScene : MonoBehaviour
{
    public static UIMainScene Instance { get; private set; }
    public Text playerNameText;
    public Text highScoreText;


    private void Awake()
    {
        Instance = this;

        if (MainManager.Instance != null)
        {
            SetPlayerText(MainManager.Instance.username);
            highScoreText.text = ($"High Score: " + MainManager.Instance.highScoreUser + " - " + MainManager.Instance.highScore);
        }
    }
    private void OnDestroy()
    {
        Instance = null;
    }

    void SetPlayerText (string username)
    {
        if (username != null)
        {
            playerNameText.GetComponent<UnityEngine.UI.Text>().text = ($"Player: " + username);
        }
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadHighscoreOnStart()
    {
        MainManager.Instance.LoadHighscore();
        highScoreText.text = ($"High Score: " + MainManager.Instance.highScoreUser + " - " + MainManager.Instance.highScore);
    }
}

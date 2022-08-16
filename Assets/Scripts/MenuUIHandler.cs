using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField usernameInput;
    public Text highScoreText;
    public Button startButton;

    public void SetUsername(string newName)
    {
        MainManager.Instance.username = newName;
    }

    void Start()
    {
        startButton.interactable = false;

        usernameInput.onValueChanged.AddListener(delegate { SetUsername(usernameInput.text); });
        if (MainManager.Instance.username != null)
        {
            usernameInput.GetComponent<TMP_InputField>().text = MainManager.Instance.username;
        }
        LoadHighscoreOnStart();
    }

    private void Update()
    {
        if (MainManager.Instance.username != null && MainManager.Instance.username != "")
        {
            startButton.interactable = true;
        }
        else
        {
            startButton.interactable = false;
        }
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadHighscoreOnStart()
    {
        MainManager.Instance.LoadHighscore();
        highScoreText.text = ($"High Score: " + MainManager.Instance.highScoreUser + " - " + MainManager.Instance.highScore); 
    }

    public void Exit()
    {
# if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameplayController : MonoBehaviour
{
    public static gameplayController instance;

    [SerializeField]
    private Text scoreText, endScore, bestScore, gameOverText;

    [SerializeField]
    private Button restartGameButton, instructionsButton;

    [SerializeField]
    private GameObject pausePanel, playerDeadPanel;

    [SerializeField]
    private GameObject[] birds;

    [SerializeField]
    private Sprite[] medals;

    [SerializeField]
    private Image medalImage;


    void Awake()
    {
        MakeInstance();
        Time.timeScale = 0f;

    }

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void PauseGame() {
        
        if (BirdScript.instance != null) //to check if the game started and we got a bird in the game
        {
            if(BirdScript.instance.isAlive)
            {
                pausePanel.SetActive(true);
                gameOverText.gameObject.SetActive(false);
                endScore.text = "" + BirdScript.instance.score; // or we can say BirdScript.instance.score.ToString
                bestScore.text = "" + gameController.instance.GetHighScore();
                Time.timeScale = 0f;
                restartGameButton.onClick.RemoveAllListeners(); //if we don't remove all listeners, we will have each listener that we added previously
                restartGameButton.onClick.AddListener(() => ResumeGame());

            }

        }
            
                
        }

    public void GoToMenuButton()
    {
        SceneFader.instance.FadeIn("MainMenu");
    }

    public void RestartGame()
    {
        //SceneFader.instance.FadeIn(Application.loadedLevelName); //gameplay level? outdated
          


        //SceneFader.instance.FadeIn(LoadScene(loadedlevelName));
        SceneFader.instance.FadeIn(SceneManager.GetActiveScene().name);
    }


    public void ResumeGame()
    {
        pausePanel.SetActive(false); 
        Time.timeScale = 1f;

    }

    public void PlayGame()
    {
        scoreText.gameObject.SetActive(true);
        birds[gameController.instance.GetSelectedBird()].SetActive(true);
        instructionsButton.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void SetScore(int Score)
    {
        scoreText.text = "" + Score; 
    }


    public void PlayerDiedShowScore(int Score)
    {
        //pausePanel.SetActive(true); //removed the pause panel because the pause panel had the button to resume rather than restart. We need to restart when we die
        playerDeadPanel.SetActive(true);

        gameOverText.gameObject.SetActive(true);
        scoreText.gameObject.SetActive(false);

        endScore.text = "" + Score;

        if (Score > gameController.instance.GetHighScore())
        {
            gameController.instance.SetHighScore(Score);
        }

        bestScore.text = "" + gameController.instance.GetHighScore();

        if (Score <= 20)
        {
            
            medalImage.sprite = medals[0];
        }

        else if(Score>20 && Score < 40)
        {
            medalImage.sprite = medals[1];

            if (gameController.instance.IsGreenBirdUnlocked() == 0)
            {
                gameController.instance.unlockGreenBird();
            }

        }

        else
        {
            medalImage.sprite = medals[2]; //gold medal

            if (gameController.instance.IsGreenBirdUnlocked() == 0)
            {
                gameController.instance.unlockGreenBird();
            }



            if (gameController.instance.IsRedBirdUnlocked() == 0)
            {
                gameController.instance.unlockRedBird();
            }

        }

        restartGameButton.onClick.RemoveAllListeners();
        restartGameButton.onClick.AddListener(() => RestartGame());


    }


}

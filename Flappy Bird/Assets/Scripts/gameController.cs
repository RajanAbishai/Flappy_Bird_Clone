using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour
{
    public static gameController instance; //reference to our class
    private const string HIGH_SCORE= "High Score";
    private const string SELECTED_BIRD = "Selected Bird";

    private const string GREEN_BIRD = "Green Bird";
    private const string RED_BIRD = "Red Bird";


    private void Awake()
    {
        makeSingleTon();
        isTheGameStartedForTheFirstTime();
        //PlayerPrefs.DeleteAll(); //to delete all the unlocked birds and set them to 0
    }
    void Start()
    {
        
    }

    
    void makeSingleTon()
    {
        if (instance != null) // if we already have an instance, destroy the game object that's holding this script
        {

            Destroy(gameObject);
            DontDestroyOnLoad(gameObject);
        }
        else { //if we don't have an instance, we are going to make this script that instance.. and not destroy the game object
         // This is done because when you go from Scene 1 to Scene 2 and then, go back to Scene 1, you will have 2 game controllers.
            
            instance = this;
            DontDestroyOnLoad(gameObject);
        
        }


            
    }

    void isTheGameStartedForTheFirstTime() //We use player preferences which allows us to store data in a key-value pair
    {
        if (!PlayerPrefs.HasKey("isTheGameStartedForTheFirstTime"))
        {
            PlayerPrefs.SetInt(HIGH_SCORE, 0);
            PlayerPrefs.SetInt(SELECTED_BIRD, 0);
            PlayerPrefs.SetInt(GREEN_BIRD, 1); //unlocking
            PlayerPrefs.SetInt(RED_BIRD, 1); //unlocking
            PlayerPrefs.SetInt("isTheGameStartedForTheFirstTime", 0); // the value is not important. What's important is that we're storing this key
            /* so that the next time when we ask PlayerPrefs whether we have that key, it returns true.. which means the key is there and so, don't
            reinitialize our variables because our player can play the game, get a high score and unlock the green or the red bird.. and we will
            reset those values and nobody wants that
            */
        }
        else
        {

        }
    }

        public void SetHighScore(int score)
        {
            PlayerPrefs.SetInt(HIGH_SCORE, score);
        }

        public int GetHighScore()
        {
            return PlayerPrefs.GetInt(HIGH_SCORE); //returns the current high score when we call this function
        }

        public void SetSelectedBird(int selectedBird)
        {
            PlayerPrefs.SetInt(SELECTED_BIRD, selectedBird);
        }

        public int GetSelectedBird()
        {
            return PlayerPrefs.GetInt(SELECTED_BIRD);
        }


        public void unlockGreenBird()
        {
            PlayerPrefs.SetInt(GREEN_BIRD, 1);
        }

        public int IsGreenBirdUnlocked()
        {
            return PlayerPrefs.GetInt(GREEN_BIRD);
        }

        public void unlockRedBird()
        {
            PlayerPrefs.SetInt(RED_BIRD, 1);
        }

        public int IsRedBirdUnlocked()
        {
            return PlayerPrefs.GetInt(RED_BIRD);
        }


}  // Class






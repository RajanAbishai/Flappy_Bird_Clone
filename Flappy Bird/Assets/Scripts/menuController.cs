using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuController : MonoBehaviour
{
    public static menuController instance;

    [SerializeField]
    private GameObject[] birds;

    private bool isGreenBirdUnlocked, isRedBirdUnlocked;


    void Awake()
    {
        makeInstance();
    }


    private void Start()
    {
        birds[gameController.instance.GetSelectedBird()].SetActive(true);
        checkIfBirdsAreUnlocked();
    }

    void makeInstance() {
        if (instance == null)
        {
            instance = this;
        }
            
                
                
    }

    void checkIfBirdsAreUnlocked()
    {
        if (gameController.instance.IsRedBirdUnlocked() == 1) //retrieving the player prefs value
        {
            isRedBirdUnlocked = true;
        }

        if (gameController.instance.IsGreenBirdUnlocked() == 1)
        {
            isGreenBirdUnlocked = true;
        }
    }

    public void playGame()
    {
        SceneFader.instance.FadeIn("Gameplay");
    }




    public void changeBird()
    {
        //print(" selected bird is " +gameController.instance.GetSelectedBird());

        if (gameController.instance.GetSelectedBird() == 0) //blue bird is selected.. it's in the 0th index
        {
            

            if (isGreenBirdUnlocked)
            {
                
                birds[0].SetActive(false);
                gameController.instance.SetSelectedBird(1); //this is the green bird.. 1st index

                birds[gameController.instance.GetSelectedBird()].SetActive(true);
                print(" selected bird is " + gameController.instance.GetSelectedBird()); //disable later

            }
        }

        else if (gameController.instance.GetSelectedBird() == 1)
        {
            

            if (isRedBirdUnlocked)
            {
                
                birds[1].SetActive(false);
                gameController.instance.SetSelectedBird(2);

                birds[gameController.instance.GetSelectedBird()].SetActive(true);
                print(" selected bird is " + gameController.instance.GetSelectedBird()); //disable later
            }
            else

            //if red is not unlocked, select the blue bird
            {
                print("green bird since red is not unlocked");
                birds[1].SetActive(false);
                gameController.instance.SetSelectedBird(0);

                birds[gameController.instance.GetSelectedBird()].SetActive(true);
                print(" selected bird is " + gameController.instance.GetSelectedBird()); //disable later

            }


        }


         else if (gameController.instance.GetSelectedBird() == 2) // meaning that our red bird is selected

           {

            birds[2].SetActive(false);  // deacitvate red bird in the scene
            gameController.instance.SetSelectedBird(0);  //selected bird will be the blue bird
            birds[gameController.instance.GetSelectedBird()].SetActive(true);
            print(" selected bird is " + gameController.instance.GetSelectedBird()); //disable later

        }


    }



}

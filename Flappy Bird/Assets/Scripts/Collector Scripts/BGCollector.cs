using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGCollector : MonoBehaviour
{


    private GameObject[] backgrounds;
    private GameObject[] grounds;


    private float lastBGX;
    private float lastGroundX;

    // Start is called before the first frame update
    void Awake()
    {
        backgrounds = GameObject.FindGameObjectsWithTag(TagManager.BACKGROUND_TAG);
        grounds = GameObject.FindGameObjectsWithTag(TagManager.GROUND_TAG);

        lastBGX = backgrounds[0].transform.position.x; //last BGX will be the first background the BG collector collides with
        lastGroundX = grounds[0].transform.position.x; //last Ground will be the first ground the BG collector collides with

        /*We are going to loop through our arrays and compare the position of our backgrounds and grounds and assign them to our lastBGX
         and lastGroundX*/

        for (int i= 1; i < backgrounds.Length; i++)
        {
            if (lastBGX < backgrounds[i].transform.position.x)
            {
                lastBGX = backgrounds[i].transform.position.x; //reassign the position
            }

        }



        for (int i = 1; i < grounds.Length; i++)
        {
            if (lastGroundX < grounds[i].transform.position.x)
            {
                lastGroundX = grounds[i].transform.position.x; //reassign the position
            }

        }






    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == TagManager.BACKGROUND_TAG)
        {
            Vector3 temp = target.transform.position;
            float width = ((BoxCollider2D)target).size.x;

            temp.x = lastBGX + width; //width of the background (like BGday)

            target.transform.position = temp;

            lastBGX = temp.x;
        }

        else if (target.tag == TagManager.GROUND_TAG)
            {
                Vector3 temp = target.transform.position;
                float width = ((BoxCollider2D)target).size.x;

                temp.x = lastGroundX + width; //width of the ground 

                target.transform.position = temp;

                lastGroundX = temp.x;
            }


    }



}

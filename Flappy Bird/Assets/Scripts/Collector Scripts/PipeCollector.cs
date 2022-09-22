using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeCollector : MonoBehaviour
{

    private GameObject[] pipeHolders;
    private float distance = 2.5f;
    private float lastPipeX;

    /*pipemin and max are going to be for the y axis. Basically to decide the range where the pipe can spawn?*/
    private float pipeMin=-1.5f; 
    private float pipeMax=2.4f;

    private void Awake()
    {
        pipeHolders = GameObject.FindGameObjectsWithTag(TagManager.PIPE_HOLDER_TAG);

        for(int i = 0; i < pipeHolders.Length; i++)
        {
            Vector3 temp = pipeHolders[i].transform.position;
            temp.y = Random.Range(pipeMin, pipeMax);
            pipeHolders[i].transform.position = temp;
        }
        
        lastPipeX = pipeHolders[0].transform.position.x;


        for (int i = 1; i < pipeHolders.Length; i++)
        {
            if (lastPipeX < pipeHolders[i].transform.position.x)
            {
                lastPipeX = pipeHolders[i].transform.position.x;
            }

        }




    }


    

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == TagManager.PIPE_HOLDER_TAG)
        {
            print("Pipe collector collided with the pipe holder"); 
            Vector3 temp = target.transform.position;

            temp.x = lastPipeX+distance;
            temp.y = Random.Range(pipeMin, pipeMax);

            target.transform.position = temp;

            lastPipeX = temp.x; //to re-assign the last position X to the variable
        }

         if (target.tag == TagManager.PIPE_TAG)
        {
            print("collided with pipe");
        }

    }

    

}

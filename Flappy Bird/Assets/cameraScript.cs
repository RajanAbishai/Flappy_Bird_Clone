using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{

    public static float offsetX;

    
    void Start()
    {
        
    }

    
    void Update()
    {
        if(BirdScript.instance!=null) //we have the bird inside of the game
        {
            if (BirdScript.instance.isAlive)
            {
                moveTheCamera();
                
            }
        }


    }

    void moveTheCamera()
    {
        Vector3 temp = transform.position;
        temp.x = BirdScript.instance.getPositionX()+offsetX;

        transform.position = temp;
    }


}
 
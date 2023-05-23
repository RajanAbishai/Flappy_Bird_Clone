using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class myCoroutine
{

    public static IEnumerator WaitForRealSeconds(float time)
    {

        float start = Time.realtimeSinceStartup; // real time since startup

        while (Time.realtimeSinceStartup < (start + time))
        {
            yield return null; // for each second, it will skip one frame


        }
        


    }




} //class

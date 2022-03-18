using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FluteSing : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (CheckChildren())
            {
                //play music
                print("playingMusic");
            }
        }
    }

    private bool CheckChildren()
    {
        for (int i = 0; i< gameObject.transform.childCount; i++)
        {
            if(!gameObject.transform.GetChild(i).gameObject.activeInHierarchy)
            {
                return false;
            }
        }
        
        return true;
    }
}


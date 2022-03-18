using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Flute : MonoBehaviour
{
    public GameObject flutePart;
    private void Start()
    {
    flutePart.SetActive(false);
    }


    public void RunInteractCode()
    {
        flutePart.SetActive(true);
       Destroy(gameObject);
    }
}

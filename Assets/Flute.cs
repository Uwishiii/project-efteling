using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Flute : MonoBehaviour
{
    //var dropDown = myEnum.Item1;  // this public var should appear as a drop down
    public enum FlutePart
    {
        Base, Neck, Tip
    }

    public FlutePart flutePart;
    private GameObject player;
    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    public void RunInteractCode()
    {
       player.transform.Find(flutePart.ToString()).gameObject.SetActive(true);
       Destroy(gameObject);
    }
}

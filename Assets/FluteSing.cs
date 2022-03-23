using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class FluteSing : MonoBehaviour
{
    public GameObject Tulip;
    public Transform[] TulipPos;

    public GameObject SingBox;
    private bool placeTulip = true;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (CheckChildren())
            {
                //play music
                SingBox.SetActive(true);

                if (placeTulip)
                {
                    placeTulip = false;
                    int pos = Random.Range(0, TulipPos.Length);
                    Instantiate(Tulip, TulipPos[pos].position, quaternion.identity);
                    StartCoroutine(WaitForTulip());
                }
            }
        }
        else
        {
            SingBox.SetActive(false);
        }
    }

    private IEnumerator WaitForTulip()
    {
        yield return new WaitForSeconds(0.5f);
        placeTulip = true;
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


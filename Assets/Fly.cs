using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    public Transform location;

    private void Update()
    {
        transform.position += new Vector3(0, 0, 1);
    }
}

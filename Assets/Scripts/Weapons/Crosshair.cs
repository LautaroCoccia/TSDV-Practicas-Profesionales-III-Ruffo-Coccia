﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    [SerializeField] GameObject crosshair;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        crosshair.transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, crosshair.transform.position.z);
    }
}

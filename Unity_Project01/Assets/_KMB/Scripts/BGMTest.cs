﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            BGMMgr.instance.PlayBGM("bgm1");
        }
        if (Input.GetKeyDown("2"))
        {
            BGMMgr.instance.PlayBGM("bgm2");
        }
        if (Input.GetKeyDown("3"))
        {
            BGMMgr.instance.CrossFadeBGM("bgm1", 3.0f);
        }
        if (Input.GetKeyDown("4"))
        {
            BGMMgr.instance.CrossFadeBGM("bgm2", 3.0f);
        }
    }
}

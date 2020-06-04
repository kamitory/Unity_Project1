using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFire : MonoBehaviour
{
    public GameObject player;
    public GameObject bulletFactory;
    
    public float fireTime = 1.0f;
    public float curTime = 0.0f;
    public float fireTime1 = 1.5f;
    public float curTime1 = 0.0f;
    public int bulletMax = 10;

    // Update is called once per frame
    void Update()
    {
        AutoFire1();
        AutoFire2();
    }


    void AutoFire1()
    {
        curTime += Time.deltaTime;
        if (curTime > fireTime && player != null)
        {
            GameObject bullet = Instantiate(bulletFactory);
            bullet.transform.position = transform.position;
            Vector3 dir = player.transform.position - transform.position;
            dir.Normalize();
            bullet.transform.up = dir;
            curTime = 0.0f;

        }
    }
    private void AutoFire2()
    {
        curTime1 += Time.deltaTime;
        if (curTime1 > fireTime1 && player != null)
        {
            for (int i = 0; i < bulletMax; i++)
            {
                GameObject bullet = Instantiate(bulletFactory);
                bullet.transform.position = transform.position;
                float angle = 360.0f / bulletMax;
                bullet.transform.eulerAngles = new Vector3(0,0, i * angle);
            }
                curTime1 = 0.0f;

        }
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    float curTime = 0f;
    bool left = true;
    bool down = true;
    float speed = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        curTime += Time.deltaTime;
        if(curTime > 4f) { Destroy(gameObject); }
        if(left == true)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if (down == true) 
        {
            transform.Translate(Vector3.down * (speed+1f) * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.up * (speed+1f) * Time.deltaTime);
        }


        if( transform.position.x < -2.5f)
        {
            left = false;
        }
        else if(transform.position.x >2.5f)
        {
            left = true;
        }
        if(transform.position.y > 5.7f)
        {
            down = true;
        }
        else if (transform.position.y <-3.7f)
        {
            down = false;
        }

    }
}

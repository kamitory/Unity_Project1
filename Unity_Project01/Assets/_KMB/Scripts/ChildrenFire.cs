using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildrenFire : MonoBehaviour
{
    public GameObject bulletFactory;
    //public float fireTime = 3.0f;
    private float fireTime = 2.0f;
    public float curTime = 5.0f;
    private int _count = 0;

    public int count
    {
        get { return _count; }
        set { _count = value; }
    }


    // Update is called once per frame
    void Update()
    {
        curTime += Time.deltaTime;
        if (curTime > fireTime)
        {
            Fire();
        }

    }

    void Fire()
    {
        bulletFactory.GetComponentInChildren<SpriteRenderer>().size=new Vector2(0.5f,1.5f);
        GameObject bullet = Instantiate(bulletFactory);
        bullet.transform.position = transform.position;
        bulletFactory.GetComponentInChildren<SpriteRenderer>().size = new Vector2(1f, 3f);

        curTime = 0f;
        fireTime = Random.Range(1f, 2f);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //아래로이동
        transform.Translate(Vector3.down*speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //자신도삭제 충동대상도삭제
        //Destroy(gameObject,1.0f);     //1초뒤에 삭제
        Destroy(gameObject);
        Destroy(collision.gameObject); //충돌한대상이 collision이다
    }
}

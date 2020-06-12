﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed = 8.0f;

    public GameObject fxFactory;
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
        //Destroy(gameObject);
        //Destroy(collision.gameObject); //충돌한대상이 collision이다
        if(!collision.gameObject.name.Contains("DestroyZone") && !(collision.gameObject.layer==LayerMask.NameToLayer("Laser")))  collision.gameObject.SetActive(false);
        gameObject.SetActive(false);

        ShowEffect();
        //점수추가
        ScoreManager.Instance.AddScore();
        Debug.Log(collision.transform.name);
    }

    void ShowEffect()
    {
        GameObject fx = Instantiate(fxFactory);
        fx.transform.position = transform.position;
        Destroy(fx,1.0f);     //1초뒤에 삭제
    }

}

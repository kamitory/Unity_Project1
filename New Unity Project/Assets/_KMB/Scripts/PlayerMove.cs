using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5.0f; //이동속도
    public Vector2 margin; //뷰포트좌표는 0.0f~1.0f 사이의 값        

    // Start is called before the first frame update
    void Start()
    {
        margin = new Vector2(0.08f, 0.05f);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    //플레이어 이동
    private void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        transform.Translate(h * speed * Time.deltaTime, v * speed * Time.deltaTime, 0);

        //Vector3 dir = Vector3.right * h + Vector3.up * v;
        Vector3 dir = new Vector3(h, v, 0);
        dir.Normalize();
        transform.Translate(dir * speed * Time.deltaTime);
        //위치 = 현재위치+(방향*시간)
        // p1 = p0 *vt;
        //transform.position = transform.position + (dir * speed * Time.deltaTime);
        //transform.position += dir * speed * Time.deltaTime;

        //===========================================================================================


        //Vector3 position = transform.position;
        //position.x = Mathf.Clamp(position.x, -2.3f, 2.3f);
        //position.y = Mathf.Clamp(position.y, -3.5f, 5.5f);
        //transform.position = position;

        //===========================================================================================
        //if ( transform.position.x < -2.3f)
        //{
        //transform.position = new Vector3(-2.3f, transform.position.y, transform.position.z);
        //}
        //else if (transform.position.x > 2.3f)
        //{
        //    transform.position = new Vector3(2.3f, transform.position.y, transform.position.z);
        //}
        //
        //if( transform.position.y > 5.5f)
        //{
        //    transform.position = new Vector3(transform.position.x, 5.5f, transform.position.z);
        //
        //}
        //else if (transform.position.y < -3.5f)
        //{
        //    transform.position = new Vector3(transform.position.x, -3.5f, transform.position.z);
        //}

        //===========================================================================================
        //메인카메라의 뷰포트를 가져와서 처리
        //스크린좌표 : 좌하단 (0,0), 우상단(maxX,maxY)
        //뷰포트좌표 : 좌하단 (0,0), 우상단(1.0f,1.0f)
        Vector3 position = Camera.main.WorldToViewportPoint(transform.position);
        //position.x = Mathf.Clamp(position.x, 0.0f, 1.0f);
        //position.y = Mathf.Clamp(position.y, 0.0f, 1.0f);
        position.x = Mathf.Clamp(position.x, 0.0f + margin.x, 1.0f - margin.x);
        position.y = Mathf.Clamp(position.y, 0.0f + margin.y, 1.0f - margin.y);
        transform.position = Camera.main.ViewportToWorldPoint(position);

    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{

    public GameObject bulletFactory;    //총알 프리팹
    public GameObject firePoint;        //총알 발사위치

    private float curTime;
    private float removeTime = 2.0f;
    LineRenderer lr;

    private void Start()
    {
        lr = GetComponent<LineRenderer>();  
        //중요!   게임오브젝트는 활성 비활성화 -> SetActive() 함수
        //      컴포넌트는 enabled
    }
    // Update is called once per frame
    void Update()
    {
        //Fire();
        FireRay();

        if (lr.enabled) ShowRay();
    }


    private void Fire()
    {
        //마우스 왼쪽 버튼 or 왼쪽 컨트롤 키
        if(Input.GetButtonDown("Fire1"))
        {
            //총알공장(총알프리팹)에서 총알을 무한대로 찍어낼 수 있다.
            //Instantiate() 함수로 프리팹 파일을 게임오브젝트로 만든다.

            //총알 게임오브젝트 생성
            GameObject bullet = Instantiate(bulletFactory);
            //총알 오브젝트의 위치 지정
            //bullet.transform.position = transform.position;
            bullet.transform.position = firePoint.transform.position;
        }
    }

    private void FireRay()
    {
       if(Input.GetButtonDown("Fire1"))
        {
            RaycastHit hitInfo;
            curTime = 0.0f;
            lr.enabled = true;
            //라인 시작점, 끝점
            lr.SetPosition(0, transform.position);
            //if (Physics.Raycast(transform.position,transform.up, out hitInfo, 10,1<<LayerMask.NameToLayer("Boss")))
            //{
            //    lr.SetPosition(1, hitInfo.point); 
            //}
            //    else
            //{
            //    lr.SetPosition(1, transform.position + Vector3.up * 10);
            //}

            //Ray로 충돌처리
            Ray ray = new Ray(transform.position, Vector3.up);
            //레이 캐스트힛 위에있음
            if (Physics.Raycast(ray, out hitInfo))
            {
                lr.SetPosition(1, hitInfo.point); 
                //if(hitInfo.collider.name != "Top")
                if(hitInfo.collider.name.Contains("Enemy"))
                {
                    Destroy(hitInfo.collider.gameObject);
                }
            }
            else
            {
                lr.SetPosition(1, transform.position + Vector3.up * 10);
            }
        }

       
    }
    private void ShowRay()
    {

        curTime += Time.deltaTime;
        if (curTime > removeTime)
        {
            lr.enabled = false;
        }

    }
}

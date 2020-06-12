using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{

    public GameObject bulletFactory;    //총알 프리팹
    public GameObject firePoint;        //총알 발사위치
    public GameObject laser;

    private float curTime;
    private float removeTime = 1.0f;
    private int fireIndex = 0;
    //LineRenderer lr;
    private float laserSize = 0;
    private AudioSource audio;

    //오브젝트풀링에 사용할 최대총알수
    private int poolSize = 10;
    
    //오브젝트 풀

    //1.배열
    GameObject[] bulletPool;

    private void Start()
    {
        //lr = GetComponent<LineRenderer>();
        //중요!   게임오브젝트는 활성 비활성화 -> SetActive() 함수
        //      컴포넌트는 enabled

        laser = Instantiate(laser);
        
        //오디오 소스 컴포넌트
        audio = GetComponent<AudioSource>();
        //오브젝트 풀링 초기화
        InitObjectPooling();
        ChargeLaser();
    }

    private void InitObjectPooling()
    {
        //1.배열
        bulletPool = new GameObject[poolSize];
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletFactory);
            bullet.SetActive(false);
            bulletPool[i] = bullet;
        }
    }

    // Update is called once per frame
    void Update()
    {
        curTime += Time.deltaTime;

        //Fire();
        //FireRay();
        ChargeLaser();
        
        //if (lr.enabled) ShowRay();
    }


    public void Fire()
    {
        //마우스 왼쪽 버튼 or 왼쪽 컨트롤 키
        if(Input.GetButtonDown("Fire1"))
        {
            //1. 배열 오브젝트 풀링으로 총알발사
            bulletPool[fireIndex].SetActive(true);
            bulletPool[fireIndex].transform.position = firePoint.transform.position;
            bulletPool[fireIndex].transform.up = firePoint.transform.up;
            fireIndex++;
            if (fireIndex > poolSize) fireIndex = 0;

            

          /*  //총알공장(총알프리팹)에서 총알을 무한대로 찍어낼 수 있다.
            //Instantiate() 함수로 프리팹 파일을 게임오브젝트로 만든다.

            //총알 게임오브젝트 생성
            GameObject bullet = Instantiate(bulletFactory);
            //총알 오브젝트의 위치 지정
            //bullet.transform.position = transform.position;
            bullet.transform.position = firePoint.transform.position;*/
        }
    }

    public void FireRay()
    {
       if(Input.GetButtonDown("Fire1") && curTime > removeTime)
        {
            // //레이저 사운드 재생
            // audio.Play();
            // curTime = 0.0f;
            // lr.enabled = true;
            // //라인 시작점, 끝점
            // lr.SetPosition(0, transform.position);
            // //if (Physics.Raycast(transform.position,transform.up, out hitInfo, 10,1<<LayerMask.NameToLayer("Boss")))
            // //{
            // //    lr.SetPosition(1, hitInfo.point); 
            // //}
            // //    else
            // //{
            // //    lr.SetPosition(1, transform.position + Vector3.up * 10);
            // //}
        }

        //Ray로 충돌처리
        if (curTime < removeTime)
        {
           // RaycastHit hitInfo;
           // Ray ray = new Ray(lr.GetPosition(0), Vector3.up);
           // //레이 캐스트힛 위에있음
           // if (Physics.Raycast(ray, out hitInfo))
           // {
           //     //lr.SetPosition(1, transform.position + Vector3.up * 10);
           //     lr.SetPosition(1, lr.GetPosition(0) + Vector3.up * 10);
           //
           //     //lr.SetPosition(1, hitInfo.point); 
           //     //if(hitInfo.collider.name != "Top")
           //     if (hitInfo.collider.name.Contains("Enemy"))
           //     {
           //         Destroy(hitInfo.collider.gameObject);
           //     }
           // }
           // else
           // {
           //     lr.SetPosition(1, transform.position + Vector3.up * 10);
           // }
        }
       
    }
    private void ShowRay()
    {
        
        if (curTime > removeTime)
        {
            //lr.enabled = false;
        }

    }
    public void OnFireButtonClick()
    {
        //1. 배열 오브젝트 풀링으로 총알발사
        bulletPool[fireIndex].SetActive(true);
        bulletPool[fireIndex].transform.position = firePoint.transform.position;
        bulletPool[fireIndex].transform.up = firePoint.transform.up;
        fireIndex++;
        if (fireIndex >= poolSize) fireIndex = 0;

        //총알공장(총알프리팹)에서 총알을 무한대로 찍어낼 수 있다.
        //Instantiate() 함수로 프리팹 파일을 게임오브젝트로 만든다.

        //총알 게임오브젝트 생성
        // GameObject bullet = Instantiate(bulletFactory);
        //총알 오브젝트의 위치 지정
        //bullet.transform.position = transform.position;
        // bullet.transform.position = firePoint.transform.position;

        //SceneMgr.Instance.loadScene("StartScene");
    }
    public void OnLaserButtonClick()
    {
        if (curTime > 2)
        {
            laser.transform.localScale = new Vector3(laserSize / 5, 0.3f, laserSize / 5);
            laser.GetComponent<CapsuleCollider>().radius = laserSize * 2;
            laser.SetActive(true);


            curTime = 0.0f;
            audio.Play();
        }
       
        //Ray로 충돌처리
        //if (curTime < removeTime)
        //{
            // RaycastHit hitInfo;
            // Ray ray = new Ray(lr.GetPosition(0), Vector3.up);
            // //레이 캐스트힛 위에있음
            // if (Physics.Raycast(ray, out hitInfo))
            // {
            //     //lr.SetPosition(1, transform.position + Vector3.up * 10);
            //     lr.SetPosition(1, lr.GetPosition(0) + Vector3.up * 10);
            // 
            //     //lr.SetPosition(1, hitInfo.point); 
            //     //if(hitInfo.collider.name != "Top")
            //     if (hitInfo.collider.name.Contains("Enemy"))
            //     {
            //         hitInfo.collider.gameObject.SetActive(false);
            //     }
            // }
            // else
            // {
            //     lr.SetPosition(1, transform.position + Vector3.up * 10);
            // }
        //}

    }
    private void ChargeLaser()
    {
        laser.transform.position = new Vector3(firePoint.transform.position.x - 0.03f, firePoint.transform.position.y, firePoint.transform.position.z);

        if (Input.GetButton("Fire1"))
        {

            laserSize += Time.deltaTime / 2;

            if (laserSize > 1.5f) { laserSize = 1.5f; }
            Debug.Log(laserSize);
        }
        if (Input.GetButtonUp("Fire1"))
        {
            laserSize = 0.0f;
        }

        if( curTime >2.0f && laser.activeSelf)
        {
            laser.SetActive(false);
        }

    }
}

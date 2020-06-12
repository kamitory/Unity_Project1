//using System; //이게있으면 랜덤함수 사용불가
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    //에너미매니저의 역할
    //에너미 프리팹을 찍어낸다
    //에너미 스폰타임
    //에너미 스폰위치

    public GameObject enemyFactory;     //프리팹을받아옴
    public GameObject spawnPoint;       //스폰될위치
    public GameObject[] spawnPoints;       //스폰될위치
    private float spawnTime = 1.0f;                    //스폰쿨타임
    private float curTime = 0.0f;                      //스폰누적타임
    private float globalTime = 0.0f;                      //글로벌타임


    private int poolSize = 25;
    private int enemyIdx = 0;

    private GameObject[] enemyPool;

    // Update is called once per frame
    private void Start()
    {
        //오브젝트풀링
        enemyPool = new GameObject[poolSize];
        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemy = Instantiate(enemyFactory);
            enemy.SetActive(false);
            enemyPool[i] = enemy;
        }
    }
    void Update()
    {
        globalTime += Time.deltaTime;
        //에너미 생성
        spawnEnemy();
    }

    private void spawnEnemy()
    {
        //몇초에 한번씩 이벤트 발동
        //시간누적타임으로 계산
        //게임에서 자주이용
        curTime += Time.deltaTime;
        //if(curTime > spawnTime)
        //{
        //    //누적된 시간을 초기화
        //    curTime = 0.0f;
        //    spawnTime = Random.Range(0.5f, 2.0f);
        //    //에너미 생성
        //    GameObject enemy = Instantiate(enemyFactory);
        //    //enemy.transform.position = spawnPoint.transform.position;
        //    //enemy.transform.position = spawnPoint.transform.position;
        //    int index = Random.Range(0, spawnPoints.Length);
        //    //enemy.transform.position = transform.GetChild(index).position;
        //    enemy.transform.position = spawnPoints[index].transform.position;
        //}


        if (curTime > spawnTime)
        {
            curTime = 0.0f;
            int index = Random.Range(0, spawnPoints.Length);
            int index2 = Random.Range(0, spawnPoints.Length);

            while (index == index2)
            {     
                index2 = Random.Range(0, spawnPoints.Length);
            }
            

            for (int i = 0; i < spawnPoints.Length; i++)
            {
                if (i == index) continue;   
                if (i == index2 && globalTime < 15.0f) continue;   
                enemyPool[enemyIdx].SetActive(true);
                enemyPool[enemyIdx].transform.position = spawnPoints[i].transform.position;
                //enemyPool[enemyIdx].transform.up = spawnPoints[index].transform.position;
                enemyIdx++;
                if (enemyIdx >= poolSize) enemyIdx = 0;
            }
        }
    }
}
  
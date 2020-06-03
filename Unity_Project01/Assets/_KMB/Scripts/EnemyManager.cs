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
    float spawnTime = 1.0f;                    //스폰쿨타임
    float curTime = 0.0f;                      //스폰누적타임
    
    // Update is called once per frame
    void Update()
    {
        //에너미 생성
        spawnEnemy();
    }

    private void spawnEnemy()
    {
        //몇초에 한번씩 이벤트 발동
        //시간누적타임으로 계산
        //게임에서 자주이용
        curTime += Time.deltaTime;
        if(curTime > spawnTime)
        {
            //누적된 시간을 초기화
            curTime = 0.0f;
            spawnTime = Random.Range(0.5f, 2.0f);
            //에너미 생성
            GameObject enemy = Instantiate(enemyFactory);
            enemy.transform.position = spawnPoint.transform.position;
            //enemy.transform.position = spawnPoint.transform.position;
            int index = Random.Range(0, spawnPoints.Length);
            //enemy.transform.position = transform.GetChild(index).position;
            enemy.transform.position = spawnPoints[index].transform.position;
        }
    }
}

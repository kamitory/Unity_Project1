using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    public GameObject enemyManager;
    public GameObject boss;
    public GameObject Player;

    float curtime = 0f;
    float SceneTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        curtime += Time.deltaTime;
        
        if(curtime >30f)
        {
            enemyManager.SetActive(false);
        }

        if( curtime > 33f && boss.transform.position.y == 7)
        {
            boss.SetActive(true);
        }

        if( Player.activeSelf == false)
        {
            SceneMgr.Instance.loadScene("StartScene");
        }

        if (boss.activeSelf == true) 
        {
            SceneTime = curtime;
        }

        if (SceneTime != 0f && curtime > SceneTime + 3f)
        {
            SceneMgr.Instance.loadScene("StartScene");
        }
    }

}

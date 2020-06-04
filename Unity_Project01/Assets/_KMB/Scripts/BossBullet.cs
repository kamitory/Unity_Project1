using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public GameObject player;
    public float speed = 10.0f;

    private Vector3 dir;
    private void Start()
    {
        dir = player.transform.position - transform.position;
        dir.Normalize();
    }
    // Update is called once per frame
    void Update()
    {
        
        transform.Translate( dir* speed * Time.deltaTime);
    }
}

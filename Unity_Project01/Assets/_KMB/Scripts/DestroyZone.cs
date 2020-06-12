using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        //이곳에서 트리거에 감지됨 오브젝트 제거하기 (총알, 에너미)
        //Destroy(other.gameObject);

        if(other.gameObject.name.Contains("Bullet"))
        {
            other.gameObject.SetActive(false);
        }
        if(other.gameObject.name.Contains("Enemy"))
        {
            other.gameObject.SetActive(false);
        }
    }


}
        
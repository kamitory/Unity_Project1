using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EBullet : MonoBehaviour
{
    //총알클래스 하는 일
    //플레이어가 발사 버튼을 누르면
    //총알이 생성된 후 발사하고 싶은 방향(위)으로 움직인다.

    public float speed = 10.0f;


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //자신도삭제 충동대상도삭제
        //Destroy(gameObject,1.0f);     //1초뒤에 삭제
        //Destroy(gameObject);
        //Destroy(collision.gameObject); //충돌한대상이 collision이다
        if (!collision.gameObject.name.Contains("DestroyZone") && !(collision.gameObject.layer == LayerMask.NameToLayer("Laser")))
        {
            Destroy(gameObject);
            collision.gameObject.SetActive(false);
        }
        if(collision.gameObject.layer == LayerMask.NameToLayer("Laser"))
        {
            Destroy(gameObject);
        }





    }
    //카메라 화면밖으로 나가서 보이지 않게 되면
    //호출되는 이벤트 함수
    //private void OnBecameInvisible()
    //{
    //    Destroy(gameObject);
    //}

}

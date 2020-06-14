using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private float bossHp = 10f;

    public GameObject fxFactory;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if( transform.position.y>4)
        {
            transform.Translate(Vector3.down * Time.deltaTime);
        }
        
        if( bossHp < 0f)
        {
            gameObject.SetActive(false);
            //Destroy(gameObject);
            ShowEffect();
        }
        
    }



    private void OnCollisionEnter(Collision collision)
    {
        //자신도삭제 충동대상도삭제
        //Destroy(gameObject,1.0f);     //1초뒤에 삭제
        //Destroy(gameObject);
        //Destroy(collision.gameObject); //충돌한대상이 collision이다
    
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            bossHp -= 0.2f;
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("Laser"))
        {
            bossHp -= collision.gameObject.transform.lossyScale.x;
        ScoreManager.Instance.AddScore(20);
        }
        if (!collision.gameObject.name.Contains("DestroyZone") && !(collision.gameObject.layer == LayerMask.NameToLayer("Laser"))) collision.gameObject.SetActive(false);
    
    
    
    
        //ShowEffect();
        //점수추가
        ScoreManager.Instance.AddScore(5);
        //Debug.Log(collision.transform.name);
    }

    void ShowEffect()
    {
        GameObject fx = Instantiate(fxFactory);
        fx.transform.position = transform.position;
        Destroy(fx, 3.0f);     

    }

}

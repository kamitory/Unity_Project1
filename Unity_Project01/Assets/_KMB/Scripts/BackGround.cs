using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    private MeshRenderer backGround;
    private Vector2 offset;
    public float speed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        backGround = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        offset.y += speed * Time.deltaTime;
        backGround.material.SetTextureOffset("_MainTex", offset);
    }
}

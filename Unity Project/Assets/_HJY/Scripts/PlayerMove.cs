using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // player Move _ input
    private Rigidbody playerRigidbody;
    //move speed
    public float speed = 5f;


    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       // float h = Input.GetAxis("Horizontal"); // -1 ~ 1 사이의 값을 반환함. 
       // float v = Input.GetAxis("Vertical");

       // //transform.Translate(h * speed * Time.deltaTime, v * speed * Time.deltaTime, 0);
       // Vector3 dir = Vector3.right * h + Vector3.up * v;
       // //dir.Normalize(); 벡터의 정규화
       //transform.Translate(dir * speed * Time.deltaTime);

       // //중요
       // //p=p0+vt;
       // // 새로운위치 = 현재위치 +(방향 * 시간)
       // //transform.position = transform.position + dir * speed * Time.deltaTime;
       // //transform.position += dir * speed * Time.deltaTime;
       // //유니티에서 기존에 제공하는 물리법칙 대신 직접 조종하여 극적인 장면을 연출하기 위해 사용

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        float xSpeed = h * speed;
        float zSpeed = v * speed;


        playerRigidbody.velocity = new Vector3(xSpeed, 0f, zSpeed);

    }
}

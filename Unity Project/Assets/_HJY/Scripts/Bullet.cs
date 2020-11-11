using System.Collections;
using System.Collections.Generic;
//using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //총알클래스 하는 일 
    //플레이어가 발사 버튼을 누르면 총알이 생성되고, 발사하고 싶은 방향으로 움직인다. 
    // Start is called before the first frame update

    public float speed = 5f;


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);   
    }

 
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
        //gameObject => 이 아이도 자주 사용하는 거라 소문자로 만들어져 있음. 
    }
    
}

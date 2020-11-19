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
        //1. 배열
        //gameObject.SetActive(false);


        //Destroy(gameObject);
        //gameObject.name.contains("bullet")
        //위와 같이 네임의 콘테인스를 써서 이프문을 사용하면 불렛이라는 이름이 포함된 모든걸 포함한다는 의미이다.

        //gameObject => 이 아이도 자주 사용하는 거라 소문자로 만들어져 있음. 


        //레이어로 충돌체찾기
        //if(other.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        //{
        //    other.gameObject.SetActive(false);
        //      //플레이어 게임오브젝트의 플레이어파이어 컴포넌트에 bulletPool 속성을 찾는다.
        //}
        //2. 리스트
        //gameObject.SetActive(false);
        //PlayerFire playerFire = GameObject.Find("Player").GetComponent<PlayerFire>(); //컴포넌트만 받아올수도있음.
        //playerFire.bulletPool.Add(gameObject);

        // 충돌된 오브젝트가 총알이라면 총알풀에 추가한다.
        //총알 오브젝트는 비활성화시킨다.

        gameObject.SetActive(false);
        if (GameObject.Find("Player") != null)
        {
            PlayerFire playerFire = GameObject.Find("Player").GetComponent<PlayerFire>(); //컴포넌트만 받아올수도있음.
            playerFire.bulletPool.Enqueue(gameObject);
        }
    
    
    }   
    
}

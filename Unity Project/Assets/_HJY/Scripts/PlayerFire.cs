using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletFactory;    //bullet prefab
    public GameObject firePoint;        //bullet position
    public GameObject subPlayerL;
    public GameObject subPlayerR;

    

    private void Start()
    {
        subPlayerL.SetActive(false);
        subPlayerR.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            switch (subPlayerL.activeSelf)
            {
                case true:
                    subPlayerL.SetActive(false);
                    subPlayerR.SetActive(false);
                    break;

                case false:
                    subPlayerL.SetActive(true);
                    subPlayerR.SetActive(true);
                    break;
            }
        }
        //if (Input.GetKeyDown(KeyCode.Space) && !isActive)
        //{
        //    isActive = true; 
        //    subPlayer.SetActive(isActive); 
        //}
        //else if (Input.GetKeyDown(KeyCode.Space) && isActive)
        //{ 
        //    isActive = false;
        //    subPlayer.SetActive(isActive); 
        //}


        Fire(); 
    }

    private void Fire()
    {
        
            //마우스 왼쪽버튼 또는 왼쪽컨트롤키
            if (Input.GetButtonDown("Fire1"))
        {
            //총알공장(총알프리팹)에서 총알을 무한대로 찍어낼 수 있다. 
            //Instantiate() 함수로 프리팹 파일을 게임오브젝트로 만든다.

            //총알 게임오브젝트 생성
            GameObject bullet = Instantiate(bulletFactory);
            //총알 오브젝트의 위치 지정
            //bullet.transform.position = transform.position;
            bullet.transform.position = firePoint.transform.position;
        }

        //getMouseButton(0 , 1 , 2) 3개의 숫자중 하나를 누르면 된다. 0 = 왼쪽버튼/ 1 = 오른쪽버튼 / 2=휠버튼
    }

    //나중에는 디스트로이존을 만들어서 그곳과 충돌되면 사라지도록 만들 예정임
    //카메라 화면밖으로 나가서 보이지않게 되면 호출되는 이벤트함수 
    //유니티 내부에는 On으로 시작되는 함수는 전부 이벤트 함수들이다. 
    
}

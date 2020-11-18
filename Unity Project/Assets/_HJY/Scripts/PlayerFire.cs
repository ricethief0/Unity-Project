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
    public AudioSource audio123;
    public AudioClip[] audioClips;

    public LayerMask layerMask;

    //레이저를 발사하기 위해서는 라인렌더러가 필요하다.
    //레이져와 충돌은 Raycast를 사용해서 판별한다.
    //라인렌더러는 라인만 ㄱ려주는 컴포넌트
    //선은 최소 2개의 점이 필요하다.(시작점, 끝점)
    LineRenderer lr;
    //일정시간동안 레이져 보여주기
    public float rayShowTime = 0.3f;
    float timer = 0f;




    //오브젝트풀링
    //오브젝트 풀링에 사용할 최대 총알 갯수
    int poolSize = 5;
    int fireIndex = 0;

    //1.배열
    //GameObject[] bulletPool;

    //2.리스트
    //public List<GameObject> bulletPool;

    //3.큐
    public Queue<GameObject> bulletPool;


    private void Start()
    {
        audio123 =  GetComponent<AudioSource>();
        
        subPlayerL.SetActive(false);
        subPlayerR.SetActive(false);

        InitObjectPooling();
        //라인렌더러 컴포넌트 추가.
        lr = GetComponent<LineRenderer>();
    }

    private void InitObjectPooling()
    {
        //1.배열
        //bulletPool = new GameObject[poolsize];
        //for(int i=0; i<poolsize; i++)
        //{
        //    GameObject bullet = Instantiate(bulletFactory);
        //    bullet.SetActive(false);
        //    bulletPool[i] = bullet;
        //}

        //2.리스트
        //bulletPool = new List<GameObject>();
        //for (int i = 0; i < poolSize; i++)
        //{
        //    GameObject bullet = Instantiate(bulletFactory);
        //    bullet.SetActive(false);
        //    bulletPool.Add(bullet);
        //}

        //3.큐
        bulletPool = new Queue<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletFactory);
            bullet.SetActive(false);
            bulletPool.Enqueue(bullet); //Enqueue  = add와 같은거 Dequeue = remove와 같은거
        }
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
        if(lr.enabled)  ShowRay();
    }

    private void ShowRay()
    {
        timer += Time.deltaTime;
        if(timer > rayShowTime)
        {
            lr.enabled = false;
            timer = 0f;
        }
    }

    private void Fire()
    {
        
            //마우스 왼쪽버튼 또는 왼쪽컨트롤키
            if (Input.GetButtonDown("Fire1"))
        {
            //총알공장(총알프리팹)에서 총알을 무한대로 찍어낼 수 있다. 
            //Instantiate() 함수로 프리팹 파일을 게임오브젝트로 만든다.

            audio123.Play(); //sound play

            //1. 배열 오브젝트풀링으로 총알발사
            //bulletPool[fireIndex].SetActive(true);
            //bulletPool[fireIndex].transform.position = firePoint.transform.position;
            //bulletPool[fireIndex].transform.up = firePoint.transform.up;

            //fireIndex++;

            //if (fireIndex >= poolSize) fireIndex = 0;


            //2. 리스트 오브젝트 풀링으로 총알발사 <배열모드 따라서, 다 사용했을경우 커패시터를 늘려주지 못함.>
            //bulletPool[fireIndex].SetActive(true);
            //bulletPool[fireIndex].transform.position = firePoint.transform.position;
            //bulletPool[fireIndex].transform.up = firePoint.transform.up;

            //fireIndex++;

            //if (fireIndex >= poolSize) fireIndex = 0;


            //3. 리스트 오브젝트풀링으로 총알발사(진짜 오브젝트풀링)
            //if(bulletPool.Count > 0)
            //{
            //    GameObject bullet = bulletPool[0];

            //    bullet.SetActive(true);
            //    bullet.transform.position = firePoint.transform.position;
            //    bullet.transform.up = firePoint.transform.up;

            //    //오브젝트 풀에서 빼준다.
            //    bulletPool.Remove(bullet);
            //}
            //else // 오브젝트 풀링 안이 비어있는 상태, 따라서 오브젝트 풀에 커패시터를 늘려줘야함.
            //{
            //    GameObject bullet = Instantiate(bulletFactory);
            //    bullet.SetActive(false);
            //    //오브젝트 풀에 추가한다.
            //    bulletPool.Add(bullet);
            //}


            //4. 큐 오브젝트
            if (bulletPool.Count > 0)
            {
                GameObject bullet = bulletPool.Dequeue();

                bullet.SetActive(true);
                bullet.transform.position = firePoint.transform.position;
                bullet.transform.up = firePoint.transform.up;

                
            }
            else // 오브젝트 풀링 안이 비어있는 상태, 따라서 오브젝트 풀에 커패시터를 늘려줘야함.
            {
                GameObject bullet = Instantiate(bulletFactory);
                bullet.SetActive(false);
                //오브젝트 풀에 추가한다.
                bulletPool.Enqueue(bullet);
            }
            //총알 게임오브젝트 생성
            // GameObject bullet = Instantiate(bulletFactory);
            //총알 오브젝트의 위치 지정
            //bullet.transform.position = transform.position;
            // bullet.transform.position = firePoint.transform.position;
        }
           
        //getMouseButton(0 , 1 , 2) 3개의 숫자중 하나를 누르면 된다. 0 = 왼쪽버튼/ 1 = 오른쪽버튼 / 2=휠버튼
    }

    public void OnFireButtonClick()
    {
        //라인렌더러 컴포넌트 활성화
        lr.enabled = true; // setActive 는 게임오브젝트 활성화/비활성화    enabled는 컴포넌트 활성화/비활성화
        lr.SetPosition(0, firePoint.transform.position);
        lr.SetPosition(1, firePoint.transform.position + Vector3.forward * 20);

        //Ray로 충돌처리
        Ray ray = new Ray(firePoint.transform.position, Vector3.forward);

        RaycastHit hitInfo; //Ray와 충돌된 오브젝트의 정보를 받아온다.
        //Ray랑 충돌된 오브젝트가 있냐?
        if(Physics.Raycast(ray, out hitInfo/*, layerMask*/)) //reference 와 out이 존재함.
        {
            //레이져의 끝점 지점
            if(hitInfo.transform.tag.Contains("Bullet")==false)
             lr.SetPosition(1, hitInfo.point); // 만약충돌된게 있으면 끝점을 거기까지만 하겠다는 것
           
            //충돌된 오브젝트 모두지우기
            //Destroy(hitInfo.collider.gameObject);
            //디스트로이존의 탑과는 충돌처리가 되지 않도록 해야한다.
            //if(hitInfo.collider.name != "Top")
            //{
            //    Destroy(hitInfo.collider.gameObject);
            //}

            //충돌된 에너미 오브젝트 삭제
            //프리팹으로 만든 오브젝트는 생성될 때 클론으로 생성된다.
            //Contains("Enemy") => Enemy(clone);
            if(hitInfo.collider.tag =="Enemy")
            {
                Destroy(hitInfo.collider.gameObject);
            }
        }
    }

    //나중에는 디스트로이존을 만들어서 그곳과 충돌되면 사라지도록 만들 예정임
    //카메라 화면밖으로 나가서 보이지않게 되면 호출되는 이벤트함수 
    //유니티 내부에는 On으로 시작되는 함수는 전부 이벤트 함수들이다. 

}

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player_study : MonoBehaviour
{
    public float speed= 5f;

    public Vector2 margin; // 뷰포트좌표는 (0,0) ~ (1,1) 사이의 값을 사용한다.
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v);

        transform.Translate(dir * Time.deltaTime * speed);
           

        MoveInScreen();
    }
    private void MoveInScreen()
    {
        //// if (transform.position.x > 2.5) transform.position.x = 2.5f;
        ////아래와 같이 벡터3 변수를 만들어서 트랜스폼의 포지션벡터값을 대입 후 연산에서 다시 트랜스폼에 넣어주는걸 캐싱이라고 한다. 
        //Vector3 position = transform.position; // 값을 변경하기 위한 임시변수
        ////if (position.x > 2.5f) position.x = 2.5f; // 임시변수를 통해 수정
        ////if (position.x < -2.5f) position.x = -2.5f; // 임시변수를 통해 수정
        ////transform.position = position; // 수정한 임시변수를 원래 트랜스폼 포지션에 대입하여 값을 수정.
        //// 위에 보다 아래꺼가 더 효율이 좋다 .
        //position.x = Mathf.Clamp(position.x, -2.3f, 2.3f); // clamp는 들어온 값이 최대 최저의 범위 밖에 있으면 최저 혹은 최대값으로 값이 적용된다.
        //position.y = Mathf.Clamp(position.y, -3.5f, 5.5f); // clamp는 들어온 값이 최대 최저의 범위 밖에 있으면 최저 혹은 최대값으로 값이 적용된다.
        //transform.position = position;


        // 3. mainCamera의 뷰포트를 가져와서 처리한다.
        // 스크린좌표 : 모니터해상도 픽셀단위
        // 뷰포트좌표 : 카메라의 사각뿔 끝에 있는 사각형 왼쪽하단(0,0) / 우측상단(1,1)의 값을 갖고 판단함.
        // UV좌표 : 화면 텍스트, 2D 이미지를 표시하기 위한 좌표계로 텍스쳐좌표계라고도 한다. 좌상단(0,0) / 우하단(1,1)의 값이다.
        // UV좌표랑 뷰포트 좌표랑 좌표를 판단하는 값이 다름.





        Vector3 position = Camera.main.WorldToViewportPoint(transform.position);
        position.x = Mathf.Clamp(position.x, 0f + margin.x, 1f - margin.x);
        position.y = Mathf.Clamp(position.y, 0f + margin.y, 1f - margin.y);
        transform.position = Camera.main.ViewportToWorldPoint(position);

    }
}

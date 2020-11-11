using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tail : MonoBehaviour
{


    /*
    2D에서 지렁이 만들 때 
    꼬랑지가 머리를 따라다니게 해보자.
    꼬랑지가 타켓 (플레이어)의 위치를 알고 있어야한다.   


    타겟의 방향을 구하고 싶으면 벡터의 뺄셈을 이용하면 된다. 
방향 = 타겟의벡터 - 자기자신의 벡터 ( 이렇게 하면 바로 타겟의 위치에 위치함으로 추가 연산을 해줘야한다.)

벡터의 뺄셈 연산을 하게 되면 꼭 노멀라이즈를 해줘야한다. (단위벡터)

      
     */
    public GameObject target;   //플레이어 게임오브젝트
    public float speed = 3f;    //꼬랑지속도


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //타겟 방향 구하기 (벡터의 뺄셈)
        //방향 = 타겟 - 자기자신

        Vector3 dir = target.transform.position - transform.position;
        dir.Normalize(); // 방향만 정해줄꺼기 때문에 노멀라이즈를 해줘서 값을 1로 만들어준다.
        transform.Translate(dir * speed * Time.deltaTime);
        
    }
}

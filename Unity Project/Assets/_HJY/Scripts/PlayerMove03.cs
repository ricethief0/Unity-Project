using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove03 : MonoBehaviour
{
    //속력
    public float speed = 5.0f;
    private Rigidbody playerRigidBody;
    private float cameraWidth; 
    private float cameraHeight;
    private float playerHalfWidth;
    private float playerHalfHeight;
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();

        cameraHeight = Camera.main.orthographicSize;
        cameraWidth = cameraHeight * Screen.width / Screen.height;

        Vector3 colSize = GetComponent<Collider>().bounds.extents;  // 콜라이더의 정보를 통해 박스의 충돌범위의 절반을 가져온다.
        playerHalfHeight = colSize.z; // z축의 절반 크기를 변수의 넣어줌. 
        playerHalfWidth = colSize.x; // x축의 절반크기를 변수의 넣어줌. 
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = Vector3.right * h + Vector3.forward * v;

        Vector3 movePosition = transform.position + dir.normalized * speed * Time.deltaTime;
        movePosition.x = Mathf.Clamp(movePosition.x, -cameraWidth + playerHalfWidth, cameraWidth - playerHalfWidth);
        movePosition.z = Mathf.Clamp(movePosition.z, -cameraHeight + playerHalfHeight, cameraHeight - playerHalfHeight);

        transform.position = movePosition;




        //Vector3 vec = Camera.main.WorldToViewportPoint(transform.position);
        //if (vec.x < 0f) vec.x = 0f;
        //if (vec.x > 1f) vec.x = 1f;
        //if (vec.y < 0f) vec.y = 0f;
        //if (vec.y > 1f) vec.y = 1f;
        //transform.position = Camera.main.ViewportToWorldPoint(vec);


    }
    
}

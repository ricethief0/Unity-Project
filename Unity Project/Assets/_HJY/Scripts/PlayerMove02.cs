using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove02 : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 5f;
    public GameObject otherGameObject;
    private Rigidbody playerRigidbody;
    void Start()
    {
        //otherGameObject = GetComponent<GameObject>();
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 velocity2 = transform.position;

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        float xSpeed = h * speed;
        float zSpeed = v * speed;

        playerRigidbody.velocity = new Vector3(xSpeed, 0f, zSpeed);

        if (transform.position.x+0.5f >= otherGameObject.transform.localScale.x/2 && xSpeed >0)
        {
           playerRigidbody.velocity = new Vector3(0f, 0f, 0f);
        }
        if (transform.position.x-1f <= otherGameObject.transform.localScale.x / 2*-1 && xSpeed < 0)
        {
            playerRigidbody.velocity = new Vector3(0f, 0f, 0f);
        }
        if (transform.position.z +1f >= otherGameObject.transform.localScale.y / 2  && zSpeed > 0)
        {
            playerRigidbody.velocity = new Vector3(0f, 0f, 0f);
        }
        if (transform.position.z - 0.5f <= otherGameObject.transform.localScale.y / 2*-1 && zSpeed < 0)
        {
            playerRigidbody.velocity = new Vector3(0f, 0f, 0f);
        }
    }
}

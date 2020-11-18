using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] float speed = 5f;
     GameObject target;
    private Vector3 dir;
    private void Start()
    {
        //target = GameObject.Find("Player");
        target = GameObject.FindGameObjectWithTag("Player");
        dir = target.transform.position - transform.position;
        dir.Normalize();
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(dir * speed * Time.deltaTime);
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag =="Player")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            SceneMgr.Instance.LoadScene("StartScene");
        }

    }
}

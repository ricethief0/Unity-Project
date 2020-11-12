using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class EnemyFire : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float fireTimeMin =0f;
    [SerializeField] float fireTimeMax =1f;
    float fireTime;
    float curTime = 0f;

   
    void Start()
    {
        

        fireTime = Random.Range(fireTimeMin, fireTimeMax);
    }

    // Update is called once per frame
    void Update()
    {
        curTime += Time.deltaTime;
        if (curTime > fireTime && GameObject.Find("Player"))
        {

            GameObject Bullet = Instantiate(bulletPrefab);
            Bullet.transform.position = transform.position;
            curTime = 0f;
            fireTime = Random.Range(fireTimeMin, fireTimeMax);
        }
        
    }


}

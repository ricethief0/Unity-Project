using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFire : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] GameObject target;
    [SerializeField] float atkTimeMin = 1f;
    [SerializeField] float atkTimeMax = 3f;
    [SerializeField] int hp;
    [SerializeField] int bulletCount;
    float atkTime;
    float curTime = 0f;

    
    void Start()
    {
        atkTime = Random.Range(atkTimeMin, atkTimeMax);
    }

    // Update is called once per frame
    void Update()
    {
        curTime += Time.deltaTime;
        if (curTime >= atkTime)
        {
            if (target != null)
            {
                if (Random.Range(0, 2) == 0)
                    fire01();
                else
                    fire02();
            }
            
        }
    }

    private void fire02()
    {
       

            for (int i = 1; i <= bulletCount; i++)
            {
                GameObject bullet = Instantiate(bulletPrefab);
                bullet.transform.position = transform.position;
                bullet.transform.rotation = Quaternion.Euler(Vector3.up * 360/bulletCount * i);
            }

        curTime = 0f;
        atkTime = Random.Range(atkTimeMin, atkTimeMax);



    }

    private void fire01()
    {
        GameObject bullet = Instantiate(bulletPrefab);
        bullet.transform.position = transform.position;
    
        Vector3 dir = target.transform.position - bullet.transform.position;
        dir.Normalize();
        bullet.transform.rotation = Quaternion.Euler(dir);
        bullet.transform.forward = dir;
        curTime = 0f;
        atkTime = Random.Range(atkTimeMin, atkTimeMax);

    }

    private void OnTriggerEnter(Collider other)
    {
        hp--;
            Destroy(other.gameObject);
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}

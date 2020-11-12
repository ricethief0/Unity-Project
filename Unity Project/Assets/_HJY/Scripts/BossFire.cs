using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFire : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float atkTimeMin = 1f;
    [SerializeField] float atkTimeMax = 3f;
    [SerializeField] int hp;
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
        if(curTime >= atkTime)
        {
            
            for(int i=1; i<= 36; i++)
            {
                GameObject bullet = Instantiate(bulletPrefab);
                bullet.transform.position = transform.position;
                bullet.transform.rotation = Quaternion.Euler(Vector3.up * 10*i); 
            }
            

            curTime = 0f;
            atkTime = Random.Range(atkTimeMin, atkTimeMax);

        }
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

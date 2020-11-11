using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubPlayerFire : MonoBehaviour
{
    [SerializeField] GameObject bulletFactory;    //bullet prefab
    [SerializeField] GameObject firePoint;        //bullet position
    [SerializeField] float fireTime;
    int lastTime;


    private void Awake()
    {
        lastTime = 1;
        //fireTime = 1f;
    }

    private void Start()
    {
        // Invoke("Fire", fireTime);
    }

    void Update()
    {

        Fire();
    }

    private void Fire()
    {
        //print(Time.time);
        if (Time.time > lastTime)
        {
            GameObject bullet = Instantiate(bulletFactory);
            bullet.transform.position = firePoint.transform.position;
            lastTime = (int)(Time.time + fireTime);
        }
        // GameObject bullet = Instantiate(bulletFactory);
        // bullet.transform.position = firePoint.transform.position;
        // Invoke("Fire", fireTime);
    }




}

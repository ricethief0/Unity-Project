using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone : MonoBehaviour
{
    public GameObject clone1234;
    [SerializeField] GameObject bulletFactory;
    [SerializeField] float fireTime = 1f;
    [SerializeField] float curTime = 0f;



    private void Update()
    {
        CreateClone();
        AutoFire();
    }

    private void AutoFire()
    {
        if(clone1234.activeSelf)
        {
            curTime += Time.deltaTime;
            if(curTime > fireTime)
            {
                curTime = 0f;
                //GameObject bullet = Instantiate(bulletFactory);
                //bullet.transform.position = GameObject.Find("sub1").transform.position;
                //bullet.transform.position = clone.transform.Find("sub1").position;
                //bullet.transform.position = clone.transform.GetChild(0).position;

                //GameObject[] bullet = new GameObject[2];
                GameObject[] bullet = new GameObject[clone1234.transform.childCount];

                for(int i=0; i<clone1234.transform.childCount; i++)
                {
                    bullet[i] = Instantiate(bulletFactory);
                    bullet[i].transform.position = clone1234.transform.GetChild(i).position;
                }
            }
        }
    }

    private void CreateClone()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            // clone.SetActive(true);
            if (clone1234.activeSelf) clone1234.SetActive(false);
            else clone1234.SetActive(true);
        }
    }

}

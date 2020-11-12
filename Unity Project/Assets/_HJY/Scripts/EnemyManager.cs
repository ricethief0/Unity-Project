using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    [SerializeField] float appearTimeMin = 1f;
    [SerializeField] float appearTimeMax = 3f;
    [SerializeField] GameObject enemyPrefab;
    float appearTime;
    float curTime = 0f;
    float cameraWidth;
    //enemyManager
    //random position enemy appear 
    


    // Start is called before the first frame update
    void Start()
    {
        appearTime = Random.Range(appearTimeMin, appearTimeMax);
        cameraWidth = Camera.main.orthographicSize * Screen.width / Screen.height;
    }

    // Update is called once per frame
    void Update()
    {
        curTime += Time.deltaTime;
        if(curTime >appearTime)
        {
            GameObject enemy = Instantiate(enemyPrefab);
            float halfWidth = enemy.transform.localScale.x *0.5f;
            enemy.transform.position = new Vector3(Random.Range(-cameraWidth + halfWidth, cameraWidth - halfWidth), 
                enemy.transform.position.y, enemy.transform.position.z) ;
            appearTime = Random.Range(appearTimeMin, appearTimeMax);
            curTime = 0f;
        }
    }
}

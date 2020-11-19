using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{
    float timer=10f;
    public Text timeText;
    //[SerializeField] float restartTime = 10f;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneMgr.Instance.LoadScene("GameScene");
        }

        timer -= Time.deltaTime;
        timeText.text = ""+(int)timer;
        if(timer<=0)
        {
            SceneMgr.Instance.LoadScene("StartScene");
        }
    }
}

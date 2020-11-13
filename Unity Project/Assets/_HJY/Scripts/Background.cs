using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    // Start is called before the first frame update

    //mashrenderer -> material -> offset 

    Material mat;
    public float scrollSpeed = 0.1f;


    void Start()
    {
        //material은 렌더러 컴포너ㄴ트 안에 속성으로 붙어있따.
        mat = GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        BackgroundScroll();
    }

    private void BackgroundScroll()
    {
        //메테리얼의 메인텍스쳐 오프셋은 벡터2로 만들어져있다.
        //스프라이트 이기 때문에 vector2로 만들어져있따.
        Vector2 offset = mat.mainTextureOffset;
        //offset.y값만 보정해주면 된다.
        offset.Set(0, offset.y + (scrollSpeed * Time.deltaTime));
        //다시 메테리얼 오프셋에 담는다.
        mat.mainTextureOffset = offset;
        
    }
}

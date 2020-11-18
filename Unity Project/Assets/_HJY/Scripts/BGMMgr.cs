using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMMgr : MonoBehaviour
{

    public static BGMMgr Instance;

    private void Awake()
    {
        if (Instance)
        {
            DestroyImmediate(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    //Dictionary ( c++ map과 같은 존재 0

    Dictionary<string, AudioClip> bgmTable;
    AudioSource audioMain;  
    AudioSource audioSub;

    [Range(0, 1f)] //다음에 올 변수를 레인지안의 값인 min과 max 사이로 제약을 걸떄 사용하는 어튜리뷰트
    public float mastarVolume = 1f;

    // [] 어튜리뷰트에 대해서 공부하기.

    float volumeMain = 0f;
    float volumeSub = 0f;
    float crossFadeTime = 3f;



    // 유니티 라이프 사이클 순서
    //Awake()-> Start() -> Update() -> LateUpdate()

    void Start()
    {
        bgmTable = new Dictionary<string, AudioClip>();
        //add Audio source code 
        audioMain = gameObject.AddComponent<AudioSource>();
        audioSub = gameObject.AddComponent<AudioSource>();

        //오디오 소스 볼륨 0으로 초기화
        audioMain.volume = 0f;
        audioSub.volume = 0f;

    }

    // Update is called once per frame
    void Update()
    {
        //브금이 플레이중일 때 메인볼륨은 올리고 서브볼륨은내린다.
        if(audioMain.isPlaying)
        {
            if (volumeMain < 1.0f)
            {
                volumeMain += Time.deltaTime / crossFadeTime;
                if(volumeMain >1f)
                {
                    volumeMain = 1f;
                }
            }
            if(volumeSub>0f)
            {
                volumeSub -= Time.deltaTime / crossFadeTime;
                if(volumeSub<=0f)
                {
                    volumeSub = 0f;
                    audioSub.Stop();
                }
            }

        }
        audioMain.volume = volumeMain * mastarVolume;
        audioSub.volume = volumeSub * mastarVolume;
    }

    //BGM play
    public void PlayBGM(string bgmName)
    {
        //딕셔너리 안에 브금이 없으면 리소스 폴더에서 찾아서 새로 추가하기.
        if(bgmTable.ContainsKey(bgmName)==false)
        {
            //유니티엔진에서 특별한 기능의 리소스 폴더가 존재함.
            //어디서든 파일을 로드할 수 있다.. 
            //스펠링주의
            //리소스 폴더가 존재하면 여러개여도 상관없고 폴더경로도 상관없다.
            //Resources/BGM/폴더안의 오디오 클립을 찾는다.
            AudioClip bgm = (AudioClip)Resources.Load("BGM/" + bgmName);
            //AudioClip bgm1 = Resources.Load("BGM/" + bgmName) as AudioClip;  이거는 위에꺼랑 같은건데 위에꺼를 더 선호함.

            //리소스폴더에 bgm이없다면 딕셔너리에 추가하지 말고 그냥 리턴하고 나온다. 
            //오디오 파일이 없으니 재생할 수 없다. 
            if (bgm == null) return;

            //딕셔너리에 bgmName의 키값으로 bgm을 추가한다.
            bgmTable.Add(bgmName, bgm);

        }

        //메인오디오의 클립에 새로운 오디오 클립을 연결한다.
        audioMain.clip = bgmTable[bgmName];
        //메인오디오로 플레이하기
        audioMain.Play();

        //볼륨값 세팅
        volumeMain = 1f;
        volumeSub = 0f;

    }

    //브금 크로스fade play
    public void CrossFadeBGM(string bgmName, float cfTime = 3f)
    {

        if (bgmTable.ContainsKey(bgmName) == false)
        {
           
            AudioClip bgm = (AudioClip)Resources.Load("BGM/" + bgmName);
           
            if (bgm == null) return;

            bgmTable.Add(bgmName, bgm);

        }

        //크로스 페이드 타임세팅
        crossFadeTime = cfTime;
        
        //메인 오디오에서 플레이되고 있는걸 서브오디오로 변경
        AudioSource temp = audioMain;
        audioMain = audioSub;
        audioSub = temp;

        //볼륨값 스위칭
        float tempVolume = volumeMain;
        volumeMain = volumeSub;
        volumeSub = tempVolume;

        //메인오디오의 클립에 새로운 오디오 클립을 연결한다.
        audioMain.clip = bgmTable[bgmName];
        audioMain.Play();

        volumeMain = 1f;
        volumeSub = 0f;
    }
}

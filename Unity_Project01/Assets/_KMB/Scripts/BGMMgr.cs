using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMMgr : MonoBehaviour
{
    //BGMMgr 싱글톤
    //모든씬에서 이용
    public static BGMMgr instance;
    private void Awake()
    {
        if(instance)
        {
            DestroyImmediate(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    Dictionary<string, AudioClip> bgmTable; //BGM파일들을 담아놓을 딕셔너리(STL map)

    AudioSource audioMain;                      //메인오디오
    AudioSource audioSub;                       //서브오디오

    [Range(0, 1.0f)]                            //[]로 만들어져있는 attribute라고 하고 인스펙터창 값을 0~1로고정
    public float masterVolume = 1.0f;           //마스터 불륨은 0~1
    float volumeMain = 0.0f;                    //메인오디오 불륨
    float volumeSub = 0.0f;                     //서브오디오 불륨
    float crossFadeTime = 5.0f;                 //크로스페이드 타임 5초

    private void Start()
    {
        //BGM테이블 생성
        bgmTable = new Dictionary<string, AudioClip>();
        //오디오 소스 코드로 추가
        audioMain = gameObject.AddComponent<AudioSource>();
        audioSub = gameObject.AddComponent<AudioSource>();
        //오디오 소스 불륨 0으로 초기홯
        audioMain.volume = 0.0f;
        audioSub.volume = 0.0f;

    }

    private void Update()
    {
        //BGM이 플레이중일때 메인불륨은 올리고 서브불륨은 내림
        if(audioMain.isPlaying)
        {
            //메인오디오 불륨올리기
            if(volumeMain < 1.0f)
            {
                volumeMain += Time.deltaTime / crossFadeTime;
                if (volumeMain >= 1.0f) volumeMain = 1.0f;
            }
            //서브오디오 불륨내리기
            if(volumeSub > 0.0f)
            {
                volumeSub -= Time.deltaTime / crossFadeTime;
                if( volumeSub <= 0.0f)
                {
                    volumeSub = 0.0f;
                    //서브오디오정지
                    audioSub.Stop();
                }
            }
        }

        //불륨조정
        audioMain.volume = volumeMain * masterVolume;
        audioSub.volume = volumeSub * masterVolume;
    }

    //BGM플레이
    public void PlayBGM(string bgmName)
    {
        //딕셔너리 안에 브금이없으면 리소스폴더에서 찾아서 새로추가
        if(bgmTable.ContainsKey(bgmName)==false)
        {
            //유니티엔진에서 특별한 기능의 Resources 폴더가 존재
            //어디서든 파일을 로드가 가능
            //단 정확한 이름이어야함

            //Resources/BGM/ 폴더안에서 오디오클립을 찾는다
            AudioClip bgm = (AudioClip)Resources.Load("BGM/" + bgmName);
            //AudioClip bgm = Resources.Load("BGM/" + bgmName) as AudioClip;

            //리소스폴더에 bgm이 없다면 그냥 리턴하고 나온다
            //오디오파일이 없으니 재생불가
            if (bgm == null) return;

            //딕셔너리에 bgmName의 키값으로 bgm을 추가
            bgmTable.Add(bgmName, bgm);

        }

        //메인오디오의 클립에 새로운 오디오클립은 연결
        audioMain.clip = bgmTable[bgmName];
        //메인오디오 플레이하기
        audioMain.Play();

        //불륨값 세팅
        volumeMain = 1.0f;
        volumeSub = 0.0f;

    }

    //브금 크로스페이드 플레이
    public void CrossFadeBGM(string bgmName, float cfTime = 1.0f)
    { 
        //딕셔너리 안에 브금이없으면 리소스폴더에서 찾아서 새로추가
        if (bgmTable.ContainsKey(bgmName) == false)
        {
            //유니티엔진에서 특별한 기능의 Resources 폴더가 존재
            //어디서든 파일을 로드가 가능
            //단 정확한 이름이어야함

            //Resources/BGM/ 폴더안에서 오디오클립을 찾는다
            AudioClip bgm = (AudioClip)Resources.Load("BGM/" + bgmName);
            //AudioClip bgm = Resources.Load("BGM/" + bgmName) as AudioClip;

            //리소스폴더에 bgm이 없다면 그냥 리턴하고 나온다
            //오디오파일이 없으니 재생불가
            if (bgm == null) return;

            //딕셔너리에 bgmName의 키값으로 bgm을 추가
            bgmTable.Add(bgmName, bgm);

        }
        //크로스페이드 타임
        crossFadeTime = cfTime;

        //메인오디오에서 플레이 되고있는것을 서브오디오로 변경
        AudioSource temp = audioMain;
        audioMain = audioSub;
        audioSub = temp;

        //불륨값도 스위칭
        float tempVolume = volumeMain;
        volumeMain = volumeSub;
        volumeSub = tempVolume;

        //메인오디오의 클립에 새로운 오디오 클립을 연결
        audioMain.clip = bgmTable[bgmName];
        //메인오디오 플레이 하기
        audioMain.Play();

    }

    public void PauseBGM()
    {
        audioMain.Pause();
    }
    public void ReS()
    {
        //audioMain.
    }
}

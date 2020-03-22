using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    public static TitleManager instance;

    public GameObject Logo; //버닝 다이아몬드 로고
    public GameObject Logo1; //닭둘기의
    public GameObject Logo2; //모험
    public GameObject Logo3; //위대하지않음
    public GameObject Logo4; //전체

    public GameObject Background; //터치관련
    public BoxCollider2D box;
    public GameObject Logo_txt; //BURNING DIAMOND GAMES
    public GameObject Logo_txt2;
    public GameObject Version_txt; //버전
    public GameObject Touch; //Touch to STart
    public GameObject GooglePlay_Login;
    public GameObject GooglePlay_Logout;
    public GameObject Guest_Login;

    public GameObject Guest_Warning;

    private AudioSource source;
    public AudioClip Water;
    public AudioClip MainTheme;
    public AudioClip SmallShot;
    public AudioClip BigShot;
    public AudioClip Coin;

    public float ShakeAmount;
    public float ShakeTime;

    void Awake()
    {
        instance = this;

        source = gameObject.GetComponent<AudioSource>();
        box = Background.GetComponent<BoxCollider2D>();

        Logo.SetActive(false);
        Logo1.SetActive(false);
        Logo2.SetActive(false);
        Logo3.SetActive(false);
        Logo4.SetActive(false);

        Background.SetActive(false);
        Logo_txt.SetActive(false);
        Logo_txt2.SetActive(false);
        Version_txt.SetActive(false);
        Touch.SetActive(false);
        GooglePlay_Login.SetActive(false);
        GooglePlay_Logout.SetActive(false);
        Guest_Login.SetActive(false);

        Guest_Warning.SetActive(false);

    }
    void Start()
    {
        box.enabled = false;


        StartCoroutine(LogoStart());
    }

    IEnumerator LogoStart()
    {
        Logo.SetActive(true);
        Logo_txt.SetActive(true);
        source.PlayOneShot(Water, 1f);
        yield return new WaitForSeconds(2.5f);
        EffectManager.instance.SFX_On();
        source.Stop();
        Background.SetActive(true);
        Logo.SetActive(false);
        Logo_txt.SetActive(false);
        Logo1.SetActive(true);
        source.PlayOneShot(SmallShot, 0.75f);
        StartCoroutine(Shake(ShakeAmount,ShakeTime));
        yield return new WaitForSeconds(0.6f);
        Logo2.SetActive(true);
        source.PlayOneShot(SmallShot, 0.75f);
        StartCoroutine(Shake(ShakeAmount, ShakeTime));
        yield return new WaitForSeconds(0.6f);
        Logo3.SetActive(true);
        source.PlayOneShot(BigShot, 1f);
        StartCoroutine(Shake(ShakeAmount, ShakeTime));
        yield return new WaitForSeconds(0.2f);
        source.clip = MainTheme;
        source.Play();
        yield return new WaitForSeconds(0.5f);
        Touch.GetComponent<UILabel>().color = new Color(0, 0, 0, 1);
        Touch.SetActive(true);
        Version_txt.SetActive(true);
        Logo_txt2.SetActive(true);
        StartCoroutine(Touch_Wait());
        yield return new WaitForSeconds(0.1f);
        box.enabled = true;

    }

    IEnumerator Touch_Wait()
    {
        if(Touch.activeSelf == true)
        {
            Touch.GetComponent<UILabel>().color = new Color(0, 0, 0, 1);
            yield return new WaitForSeconds(0.5f);
            Touch.GetComponent<UILabel>().color = new Color(0, 0, 0, 0);
            yield return new WaitForSeconds(0.5f);
            StartCoroutine(Touch_Wait());
        }
        else
        {
            yield break;
        }
    }

    IEnumerator Shake(float ShakeAmount,float ShakeTime )
    {
        float timer = 0;
        while(timer <= ShakeTime)
        {
            Camera.main.transform.position = (Vector3)Random.insideUnitCircle * ShakeAmount;
            timer += Time.deltaTime;
            yield return null;
        }
        Camera.main.transform.position = new Vector3(0f, 0f, 0f);
    }

    public void TouchGo()
    {
        box.enabled = false;

        int a = PlayerPrefs.GetInt("Login");
        switch (a)
        {
            case 1:
                Guset_Go();
                break;

            case 2:
                Login_GooglePlay();
                break;

            default:
                Touch.SetActive(false);
                Logo_txt2.SetActive(false);
                StartCoroutine(TouchGo_Wait());
                break;
        }
    }

    public void TouchNo()
    {
        box.enabled = false;
        Touch.SetActive(false);
        Logo_txt2.SetActive(false);

        GooglePlay_Login.SetActive(false);
        Guest_Login.SetActive(false);
    }

    IEnumerator TouchGo_Wait()
    {
        GooglePlay_Login.SetActive(true);
        yield return new WaitForSeconds(0.25f);
        //GooglePlay_Logout.SetActive(true);
        //yield return new WaitForSeconds(0.25f);
        Guest_Login.SetActive(true);
    }

    public void Login_GooglePlay()
    {
        GooglePlayManager.instance.OnLogin();
    }

    public void Login_GooglePlay_Fail()
    {
        StartCoroutine(TouchGo_Wait());
    }

    public void Login_Guest()
    {
        Guest_Warning.SetActive(true);
    }

    public void Exit()
    {
        Guest_Warning.SetActive(false);
    }

    public void Guset_Go()
    {
        int a = PlayerPrefs.GetInt("Tutorial");
        if (a > 0)
        {
            SystemManager.instance.ThreeGo();
        }
        else
        {
            PlayerPrefs.SetInt("Login", 1);
            SystemManager.instance.TwoGo();
        }
    }

    public void GooglePlay_Go()
    {
        int a = PlayerPrefs.GetInt("Tutorial");
        if(a > 0)
        {
            SystemManager.instance.ThreeGo();
        }
        else
        {
            SystemManager.instance.TwoGo();
        }
    }

    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (box.enabled == true)
                {
                    EffectManager.instance.onClick();
                    TouchGo();
                }
            }
        }
    }

}

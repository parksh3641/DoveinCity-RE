using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public static TutorialManager instance;

    public Transform Dove;
    private Vector3 Dove_Which;
    public GameObject Default_Map;
    public GameObject Default_Notion;

    private bool Player_State;
    private float Default_Hp;
    private float DoveHp;

    public UILabel Continuetxt;

    public GameObject Dove_Notion;
    public UILabel Dove_Notion_txt;

    public GameObject HeartWindow;
    public UISprite Heart_Filter;

    private bool Skill_Value;
    private bool Skill_Use;
    public GameObject SkillWindow;
    public UISprite Skill_Filter;
    public GameObject FeverWindow;
    public GameObject WeatherWindow;
    public GameObject OptionBtn;
    public GameObject OptionWindow;

    public GameObject TimerWindow;
    public UILabel Timer_txt;
    private int Timer;

    //프리팹
    private int Eagle_Index;
    private int Item_Index;
    private int Building_Index;
    private int White_Index;

    public GameObject Dove_Eagle;
    public GameObject Item;
    public GameObject Building;
    public GameObject Dove_White;

    public Transform[] Eagle_Point;
    public List<GameObject> Enemy_Eagle = new List<GameObject>();
    public List<GameObject> Object_Item = new List<GameObject>();
    public List<GameObject> Object_Building = new List<GameObject>();
    public List<GameObject> Enemy_White = new List<GameObject>();

    public List<GameObject> Object_Reset = new List<GameObject>();



    //튜토리얼 창
    private int tutorial = 0;
    public GameObject TutorialWindow;
    public UILabel Tutorial_txt;
    public GameObject Tutorial_Right_Btn;
    public GameObject Tutorial_Left_Btn;
    public GameObject Tutorial_Exit;

    //튜토리얼1 - 이동
    public GameObject Tutorial_1;
    public GameObject Tutorial_1_Dove;
    public UISprite Tutorial_1_Dove_sp;
    public UISprite Tutorial_1_Dove_Shadow_sp;

    public GameObject Tutorial_1_Right;
    public GameObject Tutorial_1_Left;
    private bool Tutorial_1_Right_Move;
    private bool Tutorial_1_Left_Move;

    public GameObject Tutorial_HeartWindow;
    public UISprite Tutorial_Filter;
    public GameObject Tutorial_Hp_Notion;

    //튜토리얼1 - 퀘스트
    private bool Tutorial_1_Quest;
    public GameObject Tutorial_1_Quest_Right;
    public GameObject Tutorial_1_Quest_Left;


    //튜토리얼2 - 하트 관리
    private int Tutorial_2_Value;
    public GameObject Tutorial_2;
    public GameObject Tutorial_2_Dove;
    public UISprite Tutorial_2_Dove_sp;
    public UISprite Tutorial_2_Dove_Shadow_sp;
    public GameObject Tutorial_2_Dove_Die;
    public GameObject Tutorial_2_Heart;

    public GameObject Tutorial_2_Eagle;
    public UISprite Tutorial_2_Eagle_sp;
    public UISprite Tutorial_2_Eagle_Shadow_sp;

    private bool Tutorial_2_Dove_State;
    private bool Tutorial_2_Heart_Up;
    private bool Tutorial_2_Eagle_Up;
    private bool Tutorial_Map_Move;

    //튜토리얼3 - 스킬 사용
    public GameObject Tutorial_3;
    public GameObject Tutorial_3_Dove;
    public UISprite Tutorial_3_Dove_sp;
    public UISprite Tutorial_3_Dove_Shadow_sp;
    private float Tutorial_3_Dove_Size;
    private float Tutorial_3_Shadow_Size;

    public GameObject Tutorial_3_Dove_Skill;
    public UISprite Tutorial_3_Dove_Skill_sp;
    public UISprite Tutorial_3_Dove_Skill_Shadow_sp;

    public GameObject Tutorial_3_Building;

    private bool Tutorial_3_Skill_Value;
    private float Tutorial_3_Skill_Time;
    public GameObject Tutorial_3_Skill;
    public UISprite Tutorial_3_Skill_Filter;

    public GameObject Skill_Arrow;

    //튜토리얼4 - 날씨
    public GameObject Tutorial_4;
    public GameObject Tutorial_4_Dove;
    public UISprite Tutorial_4_Dove_sp;
    public UISprite Tutorial_4_Dove_Shadow_sp;

    public GameObject Tutorial_4_White;
    public UISprite Tutorial_4_White_sp;
    public UISprite Tutorial_4_White_Shadow_sp;

    public GameObject Tutorial_4_Sun;
    public GameObject Tutorial_4_Moon;
    public GameObject Tutorial_4_Night;

    public GameObject Tutorial_4_InGame_Night;

    private bool Tutorial_4_sun;
    private bool Tutorial_4_night;

    //언어
    private string[] Tutorial_Title;

    public float speed = 0.2f;

    private string[] Black = { "black_1", "black_2", "black_3", "black_4", "black_5", "black_6" };
    private string[] White = { "White_1", "White_2", "White_3", "White_4", "White_5", "White_6" };
    private string[] Eagle = { "Eagle_1", "Eagle_2", "Eagle_3", "Eagle_4", "Eagle_5", "Eagle_6" };

    private int Music_OnOff;

    private AudioSource source;

    public AudioSource boast;

    void Awake()
    {
        instance = this;
        source = GetComponent<AudioSource>();

        Player_State = true;

        Default_Notion.SetActive(false);

        HeartWindow.SetActive(false);
        SkillWindow.SetActive(false);
        FeverWindow.SetActive(false);
        WeatherWindow.SetActive(false);
        OptionWindow.SetActive(false);
        TimerWindow.SetActive(false);

        Skill_Value = false;
        Skill_Filter.fillAmount = 0;
        Skill_Use = false;

        Continuetxt.enabled = false;
        Dove_Notion.SetActive(false);

        Eagle_Point = GameObject.Find("Enemy_Points").GetComponentsInChildren<Transform>();

        boast.enabled = false;

        //튜토리얼 기본 설정
        tutorial = 0;
        TutorialWindow.SetActive(false);
        Tutorial_Right_Btn.SetActive(false);
        Tutorial_Left_Btn.SetActive(false);

        //튜토리얼1
        Tutorial_1.SetActive(false);
        Tutorial_2_Dove.SetActive(false);

        Tutorial_1_Quest = false;
        Tutorial_1_Quest_Right.SetActive(false);
        Tutorial_1_Quest_Left.SetActive(false);

        //튜토리얼2
        Tutorial_2_Value = 0;
        Tutorial_2.SetActive(false);
        Tutorial_2_Dove.SetActive(false);
        Tutorial_2_Dove_Die.SetActive(false);

        Tutorial_2_Heart.SetActive(false);
        Tutorial_2_Eagle.SetActive(false);
        Tutorial_Hp_Notion.SetActive(false);

        Tutorial_2_Dove_State = true;
        Tutorial_2_Heart_Up = false;
        Tutorial_2_Eagle_Up = false;
        Tutorial_Map_Move = false;

        //튜토리얼3
        Tutorial_3.SetActive(false);
        Tutorial_3_Dove.SetActive(false);
        Tutorial_3_Dove_Skill.SetActive(false);

        Tutorial_3_Building.SetActive(false);

        Skill_Arrow.SetActive(false);

        //튜토리얼4
        Tutorial_4.SetActive(false);
        Tutorial_4_White.SetActive(false);

        Tutorial_4_Sun.SetActive(false);
        Tutorial_4_Moon.SetActive(false);
        Tutorial_4_Night.SetActive(false);

        Tutorial_4_sun = false;
        Tutorial_4_night = false;

        Tutorial_4_InGame_Night.SetActive(false);

        Language_Setting();
    }
    void Object_Create()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject a = Instantiate(Dove_Eagle);
            a.name = "Enemy_Eagle_" + i.ToString();
            a.GetComponent<EnemyCtrl>().Tutorial_Change();
            a.SetActive(false);
            Enemy_Eagle.Add(a);
        }
        for (int i = 0; i < 1; i++)
        {
            GameObject a = Instantiate(Item);
            a.name = "Item_" + i.ToString();
            a.GetComponent<ItemCtrl>().Tutorial_Change();
            a.SetActive(false);
            Object_Item.Add(a);
        }
        for (int i = 0; i < 3; i++)
        {
            GameObject a = Instantiate(Building);
            a.name = "Building_" + i.ToString();
            a.GetComponent<BuildingCtrl>().Tutorial_Change();
            a.SetActive(false);
            Object_Building.Add(a);
        }
        for (int i = 0; i < 3; i++)
        {
            GameObject a = Instantiate(Dove_White);
            a.name = "Enemy_White_" + i.ToString();
            a.GetComponent<EnemyCtrl>().Tutorial_Change();
            a.SetActive(false);
            Enemy_White.Add(a);
        }
    }

    void Start()
    {
        Object_Create();
        TutorialTouch.instance.Move_Off();

        StartCoroutine(Continue_Count());
        //tutorial = 2;
        //Tutorial_Start();

        int a = PlayerPrefs.GetInt("Tutorial");
        if (a > 0)
        {
            OptionBtn.SetActive(true);
        }
        else
        {
            //OptionBtn.SetActive(false);
            OptionBtn.SetActive(true);
        }

        Music_OnOff = SystemManager.instance.Music_OnOff;
        DefaultOption();
    }

    void OnApplicationPause(bool pause) //앱이 꺼질때
    {
        if (pause)
        {
            if (OptionWindow.activeSelf == false && TutorialWindow.activeSelf == false)
            {
                Option();
            }
        }
        else
        {

        }
    }

    void DefaultOption()
    {
        if (Music_OnOff == 0)
        {
            Music_OnOff = 0;
            source.enabled = false;
        }
        else
        {
            Music_OnOff = 1;
            source.enabled = true;
        }
    }

    void Language_Setting()
    {
        int a = PlayerPrefs.GetInt("Language");

        switch (a)
        {
            case 0:
                Tutorial_Title = LanguageManager.instance.Tutorial_Title_Korean;
                break;
            case 1:
                Tutorial_Title = LanguageManager.instance.Tutorial_Title_English;
                break;
            case 2:
                Tutorial_Title = LanguageManager.instance.Tutorial_Title_Chinese;
                break;
            case 3:
                Tutorial_Title = LanguageManager.instance.Tutorial_Title_Japanese;
                break;
        }
    }

    void Click()
    {
        EffectManager.instance.onClick();
    }
    void Coin()
    {
        EffectManager.instance.Coin_Plus();
    }
    void Bang()
    {
        EffectManager.instance.Bang();
    }
    void Die()
    {
        EffectManager.instance.GameOver();
    }
    void Yeah()
    {
        EffectManager.instance.Yeah();
    }

    void Skill_On()
    {
        boast.enabled = true;
        boast.Play();
        Skill_Use = true;
    }
    void Skill_Off()
    {
        boast.enabled = false;
        Skill_Use = false;
    }

    public void Default_Notion_Open(string text, int number) //0 = 빨강, 1 = 파랑, 2 = 초록, 3 = 노랑, else 검정
    {
        Default_Notion.SetActive(false);
        Default_Notion.SetActive(true);
        Default_Notion.GetComponent<UILabel>().text = text;
        switch (number)
        {
            case 0:
                Default_Notion.GetComponent<UILabel>().color = new Color(1, 0, 0, 1); //빨강
                break;
            case 1:
                Default_Notion.GetComponent<UILabel>().color = new Color(0, 0, 1, 1); //파랑
                break;
            case 2:
                Default_Notion.GetComponent<UILabel>().color = new Color(0, 1, 0, 1); //초록
                break;
            case 3:
                Default_Notion.GetComponent<UILabel>().color = new Color(1, 1, 0, 1); //노랑
                break;
            case 4:
                Default_Notion.GetComponent<UILabel>().color = new Color(1, 1, 1, 1); //흰
                break;
            default:
                Default_Notion.GetComponent<UILabel>().color = new Color(0, 0, 0, 1); //검
                break;
        }
    }


    IEnumerator Continue_Count()
    {
        yield return new WaitForSeconds(1.5f);
        Continuetxt.enabled = true;
        Continuetxt.color = new Color(0, 0, 1, 1);
        Continuetxt.text = "3";
        yield return new WaitForSeconds(1f);
        Continuetxt.color = new Color(0, 1, 0, 1);
        Continuetxt.text = "2";
        yield return new WaitForSeconds(1f);
        Continuetxt.color = new Color(1, 1, 0, 1);
        Continuetxt.text = "1";
        yield return new WaitForSeconds(1f);
        Continuetxt.color = new Color(1, 0, 0, 1);
        Continuetxt.text = "Go!";
        yield return new WaitForSeconds(1f);
        Continuetxt.enabled = false;
        Tutorial_Start();
    }
    IEnumerator Tutorial_Start_Wait()
    {
        Default_Notion_Open(Tutorial_Title[1], 2);
        Yeah();
        for (int i = 0; i < Object_Reset.Count; i++)
        {
            Object_Reset[i].SetActive(false);
        }
        Object_Reset.Clear();
        TutorialTouch.instance.Move_Off();
        yield return new WaitForSeconds(1.5f);
        Tutorial_Start();
    }

    void Tutorial_Start()
    {
        Click();
        TutorialWindow.SetActive(true);
        tutorial += 1;
        TutorialTouch.instance.Move_Off();

        //초기화
        Tutorial_1.SetActive(false);
        Tutorial_2.SetActive(false);
        Tutorial_3.SetActive(false);
        Tutorial_4.SetActive(false);

        Tutorial_Exit.SetActive(false);
        Tutorial_Right_Btn.SetActive(false);
        Tutorial_Left_Btn.SetActive(false);

        Tutorial_HeartWindow.SetActive(false);

        switch (tutorial)
        {
            case 1:
                Tutorial_txt.text = Tutorial_Title[0]+" "+tutorial.ToString();
                Tutorial_Exit.SetActive(true);

                Tutorial_1.SetActive(true);
                Tutorial_1_Dove.SetActive(true);

                Tutorial_1_Dove_sp.color = new Color(1, 1, 1, 1);
                Tutorial_1_Dove_Shadow_sp.color = new Color(0, 0, 0, 0.5f);

                StartCoroutine(Flying(Tutorial_1_Dove_sp, Black, 0.05f));
                StartCoroutine(Flying(Tutorial_1_Dove_Shadow_sp, Black, 0.05f));

                StartCoroutine(Tutorial_1_Setting(1f));
                break;
            case 2:
                Tutorial_txt.text = Tutorial_Title[0] + " " + tutorial.ToString()+"-1";
                Tutorial_Right_Btn.SetActive(true);

                Tutorial_2_Value = 0;
                Tutorial_2.SetActive(true);
                Tutorial_2_Dove.SetActive(true);

                Tutorial_2_Dove_sp.color = new Color(1, 1, 1, 1);
                Tutorial_2_Dove_Shadow_sp.color = new Color(0, 0, 0, 0.5f);

                StartCoroutine(Flying(Tutorial_2_Dove_sp, Black, 0.05f));
                StartCoroutine(Flying(Tutorial_2_Dove_Shadow_sp, Black, 0.05f));

                DoveHp = 100;
                Tutorial_Filter.fillAmount = 1;
                Tutorial_HeartWindow.SetActive(true);

                StartCoroutine(Hp_Down(5));

                StartCoroutine(Tutorial_2_Setting(2));
                break;
            case 3:
                Tutorial_txt.text = Tutorial_Title[0] + " " + tutorial.ToString();
                Tutorial_Exit.SetActive(true);

                Tutorial_3.SetActive(true);
                Tutorial_3_Dove.SetActive(true);

                Tutorial_3_Dove_sp.color = new Color(1, 1, 1, 1);
                Tutorial_3_Dove_Shadow_sp.color = new Color(0, 0, 0, 0.5f);

                StartCoroutine(Flying(Tutorial_3_Dove_sp, Black, 0.05f));
                StartCoroutine(Flying(Tutorial_3_Dove_Shadow_sp, Black, 0.05f));

                Tutorial_3_Skill.SetActive(true);
                Tutorial_3_Skill_Time = 5;
                Tutorial_3_Skill_Filter.fillAmount = 0;

                StartCoroutine(Tutorial_3_Setting(2));
                break;
            case 4:
                Tutorial_txt.text = Tutorial_Title[0] + " " + tutorial.ToString();
                Tutorial_Exit.SetActive(true);

                Tutorial_4.SetActive(true);
                Tutorial_4_Dove.SetActive(true);

                DoveHp = 100;
                Tutorial_Filter.fillAmount = 1;
                Tutorial_HeartWindow.SetActive(true);

                Tutorial_4_Dove_sp.color = new Color(1, 1, 1, 1);
                Tutorial_4_Dove_Shadow_sp.color = new Color(0, 0, 0, 0.5f);

                StartCoroutine(Flying(Tutorial_4_Dove_sp, Black, 0.05f));
                StartCoroutine(Flying(Tutorial_4_Dove_Shadow_sp, Black, 0.05f));

                Tutorial_4_White_sp.color = new Color(1, 1, 1, 1);
                Tutorial_4_White_Shadow_sp.color = new Color(0, 0, 0, 0.5f);

                StartCoroutine(Flying(Tutorial_4_White_sp, White, 0.05f));
                StartCoroutine(Flying(Tutorial_4_White_Shadow_sp, White, 0.05f));

                StartCoroutine(Tutorial_4_Setting(2));
                break;
            case 5: //튜토리얼 완료
                GooglePlayManager.instance.UnlockAchievement_1();
                SelectGo();
                break;
            case 6:
                break;
            case 7:
                break;
        }
    }

    public void Right_Btn()
    {
        if(tutorial == 2)
        {
            if(Tutorial_2_Value == 0)
            {
                Tutorial_txt.text = Tutorial_Title[0] + " " + tutorial.ToString() + "-2";
                Tutorial_2_Value = 1;
                Tutorial_2_Reset();
                Tutorial_Exit.SetActive(true);
            }
        }
        Tutorial_Right_Btn.SetActive(false);
        Tutorial_Left_Btn.SetActive(true);
    }
    public void Left_Btn()
    {
        if (tutorial == 2)
        {
            if (Tutorial_2_Value == 1)
            {
                Tutorial_txt.text = Tutorial_Title[0] + " " + tutorial.ToString() + "-1";
                Tutorial_2_Value = 0;
                Tutorial_2_Reset();
            }
        }

        Tutorial_Right_Btn.SetActive(true);
        Tutorial_Left_Btn.SetActive(false);
    }
    public void Option()
    {
        OptionWindow.SetActive(true);
        Time.timeScale = 0.0f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }
    public void Continue()
    {
        OptionWindow.SetActive(false);
        Time.timeScale = 1.0f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }

    public void SelectGo()
    {
        Time.timeScale = 1.0f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;

        int a = PlayerPrefs.GetInt("Tutorial");
        if (a == 0)
        {
            PlayerPrefs.SetInt("Tutorial", 1);
        }
        else
        {
            AdmobBannerAd.instance.Banner_Ads_Show();
        }
        SystemManager.instance.ThreeGo();
    }

    public void Exit()
    {
        Dove.transform.localPosition = new Vector2(0, -4f);

        Default_Map.transform.position = new Vector3(0, 0, 0);

        TutorialWindow.SetActive(false);

        TutorialTouch.instance.Move_On();
        StopAllCoroutines();

        switch(tutorial)
        {
            case 1:
                Tutorial_1_Quest_Right.SetActive(true);
                Tutorial_1_Quest_Left.SetActive(true);
                break;
            case 2:
                Tutorial_Map_Move = true;

                Tutorial_2_Heart.SetActive(false);
                Tutorial_2_Eagle.SetActive(false);

                HeartWindow.SetActive(true);
                Default_Hp = 100;
                Heart_Filter.fillAmount = 1;
                StartCoroutine(InGame_Hp_Down(5));

                Eagle_Index = 0;
                Item_Index = 0;
                StartCoroutine(Tutorial_2_InGame(3));

                Timer = 20;
                Timer_txt.text = Timer.ToString();
                TimerWindow.SetActive(true);
                StartCoroutine(Tutorial_Timer(1));
                break;
            case 3:
                Tutorial_Map_Move = true;

                Tutorial_3_Building.SetActive(false);

                SkillWindow.SetActive(true);
                Skill_Value = false;
                Skill_Filter.fillAmount = 1;
                Skill_Arrow.SetActive(false);

                HeartWindow.SetActive(true);
                Default_Hp = 100;
                Heart_Filter.fillAmount = 1;
                StartCoroutine(InGame_Hp_Down(5));

                Timer = 12;
                Timer_txt.text = Timer.ToString();
                TimerWindow.SetActive(true);
                StartCoroutine(Tutorial_Timer(1));

                Building_Index = 0;
                StartCoroutine(Tutorial_3_InGame(3));
                break;
            case 4:
                Tutorial_Map_Move = true;

                Tutorial_4_White.SetActive(false);

                SkillWindow.SetActive(true);
                Skill_Filter.fillAmount = 1;
                WeatherWindow.SetActive(true);

                HeartWindow.SetActive(true);
                Default_Hp = 100;
                Heart_Filter.fillAmount = 1;
                StartCoroutine(InGame_Hp_Down(5));

                White_Index = 0;
                StartCoroutine(Tutorial_4_InGame(2));

                Timer = 22;
                Timer_txt.text = Timer.ToString();
                TimerWindow.SetActive(true);
                StartCoroutine(Tutorial_Timer(1));

                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                break;
        }
    }

    public void Skill_Btn()
    {
        if(Player_State == true &&Skill_Value == true)
        {
            Skill_Value = false;
            Skill_Arrow.SetActive(false);
            Skill_Filter.fillAmount = 1;
            StartCoroutine(Skill_CoolTime(Skill_Filter));
            TutorialDove.instance.Skill_On();
            Skill_On();
        }
        else
        {
            LanguageManager.instance.Yet_Skill_Notion();
        }
    }

    IEnumerator Flying(UISprite sprite, string[] a, float CoolTime)
    {
        sprite.spriteName = a[0];
        yield return new WaitForSeconds(CoolTime);
        sprite.spriteName = a[1];
        yield return new WaitForSeconds(CoolTime);
        sprite.spriteName = a[2];
        yield return new WaitForSeconds(CoolTime);
        sprite.spriteName = a[3];
        yield return new WaitForSeconds(CoolTime);
        sprite.spriteName = a[4];
        yield return new WaitForSeconds(CoolTime);
        sprite.spriteName = a[5];
        yield return new WaitForSeconds(CoolTime);
        sprite.spriteName = a[4];
        yield return new WaitForSeconds(CoolTime);
        sprite.spriteName = a[3];
        yield return new WaitForSeconds(CoolTime);
        sprite.spriteName = a[2];
        yield return new WaitForSeconds(CoolTime);
        sprite.spriteName = a[1];
        yield return new WaitForSeconds(CoolTime);
        StartCoroutine(Flying(sprite, a, CoolTime));
    }

    void Enemy_Create_Eagle()
    {
        if (Eagle_Index > Enemy_Eagle.Count - 1)
        {
            Eagle_Index = 0;
        }

        GameObject monster = Enemy_Eagle[Eagle_Index];
        if (!monster.activeSelf)
        {
            int idx = Random.Range(1, Eagle_Point.Length);

            monster.transform.position = Eagle_Point[idx].position + new Vector3(0, 0, 2);
            monster.SetActive(true);
            Object_Reset.Add(monster);

            Eagle_Index += 1;
        }
    }
    void Object_Create_Item()
    {
        if (Item_Index > Object_Item.Count - 1)
        {
            Item_Index = 0;
        }

        GameObject monster = Object_Item[Item_Index];
        if (!monster.activeSelf)
        {
            int idx = Random.Range(1, Eagle_Point.Length);

            monster.transform.position = Eagle_Point[idx].position;
            monster.transform.parent = Default_Map.transform;
            monster.SetActive(true);
            Object_Reset.Add(monster);

            Item_Index += 1;
        }
    }

    void Enemy_Create_White()
    {
        if (White_Index > Enemy_White.Count - 1)
        {
            White_Index = 0;
        }

        GameObject monster = Enemy_White[White_Index];
        if (!monster.activeSelf)
        {
            int idx = Random.Range(1, Eagle_Point.Length);

            monster.transform.position = Eagle_Point[idx].position + new Vector3(0, 0, 2);
            monster.SetActive(true);
            Object_Reset.Add(monster);

            White_Index += 1;
        }
    }

    void Object_Create_Building(int number)
    {
        if (Building_Index > Object_Building.Count - 1)
        {
            Building_Index = 0;
        }
        GameObject monster = Object_Building[Building_Index];

        if (!monster.activeSelf)
        {
            monster.transform.position = Eagle_Point[number].position + new Vector3(0, 0, 6);
            monster.transform.parent = Default_Map.transform;
            monster.SetActive(true);
            Object_Reset.Add(monster);

            Building_Index += 1;
        }
    }

    IEnumerator InGame_Hp_Down(int number)
    {
        yield return new WaitForSeconds(1f);
        if (Default_Hp > 1)
        {
            if (Tutorial_Map_Move == true)
            {
                if (Skill_Use == false)
                {
                    Default_Hp -= number;
                    Heart_Filter.fillAmount = Default_Hp * 0.01f;
                }
            }
            else
            {
                yield break;
            }
        }
        else
        {
            Default_Hp = 0;
            Heart_Filter.fillAmount = 0;

            if (Player_State == true)
            {
                Player_State = false;
                Player_Die();
            }
        }
        StartCoroutine(InGame_Hp_Down(number));
    }
    public void InGame_Hp_Plus(int number)
    {
        Coin();
#if UNITY_ANDROID || UNITY_IPHONE
        Dove_Notion.transform.localPosition = new Vector3(Dove_Which.x * 1f, Dove_Which.y, 0) + new Vector3(0f, -340f, 0);
#endif

#if UNITY_EDITOR
        Dove_Notion.transform.localPosition = new Vector3(Dove_Which.x * 2f, Dove_Which.y, 0) + new Vector3(0f, -340f, 0);
#endif

        Dove_Notion.SetActive(false);
        Dove_Notion_txt.GetComponent<UILabel>().text = Tutorial_Title[2]+" + " + number;
        Dove_Notion.SetActive(true);

        if (Default_Hp + number >= 100)
        {
            Default_Hp = 100;
            Heart_Filter.fillAmount = Default_Hp * 0.01f;
        }
        else
        {
            Default_Hp += number;
            Heart_Filter.fillAmount = Default_Hp * 0.01f;
        }
    }
    public void InGame_Hp_Minus(int number)
    {
        Bang();
#if UNITY_ANDROID || UNITY_IPHONE
        Dove_Notion.transform.localPosition = new Vector3(Dove_Which.x * 1f, Dove_Which.y, 0) + new Vector3(0f, -340f, 0);
#endif

#if UNITY_EDITOR
        Dove_Notion.transform.localPosition = new Vector3(Dove_Which.x * 2f, Dove_Which.y, 0) + new Vector3(0f, -340f, 0);
#endif

        Dove_Notion.SetActive(false);
        Dove_Notion_txt.GetComponent<UILabel>().text = Tutorial_Title[2] + " - " + number;
        Dove_Notion.SetActive(true);

        TutorialCam.instance.Hp_Minus(3);
        TutorialDove.instance.Hit();

        if (Default_Hp - number <= 0)
        {
            Default_Hp = 0;
            Heart_Filter.fillAmount = 0;

            if(Player_State == true)
            {
                Player_State = false;
                Player_Die();
            }
        }
        else
        {
            Default_Hp -= number;
            Heart_Filter.fillAmount = Default_Hp * 0.01f;
        }
    }

    void Player_Die()
    {
        Die();
        Default_Notion_Open(Tutorial_Title[3], 0);
        TutorialDove.instance.Player_Die();
        TutorialTouch.instance.Move_Off();

        Timer = 0;
        TimerWindow.SetActive(false);

        StartCoroutine(Player_Alive_Wait());
    }
    IEnumerator Player_Alive_Wait()
    {
        yield return new WaitForSeconds(4);
        TutorialDove.instance.Player_Alive();
        Player_State = true;

        for (int i = 0; i < Object_Reset.Count; i++)
        {
            Object_Reset[i].SetActive(false);
        }
        Object_Reset.Clear();

        Exit();
    }

    IEnumerator Tutorial_Timer(int number)
    {
        yield return new WaitForSeconds(1f);
        if (Timer > 0)
        {
            Timer -= number;
            Timer_txt.text = Timer.ToString();
        }
        else
        {
            if (Default_Hp > 0)
            {
                Tutorial_Map_Move = false;
                TimerWindow.SetActive(false);

                StartCoroutine(Tutorial_Start_Wait());
                yield break;
            }
        }
        StartCoroutine(Tutorial_Timer(number));
    }


    //튜토리얼1
    IEnumerator Tutorial_1_Setting(float CoolTime)
    {
        yield return new WaitForSeconds(CoolTime);
        Click();
        Tutorial_1_Right.transform.localScale = new Vector3(0.90f, 0.90f, 1);
        Tutorial_1_Right_Move = true;
        yield return new WaitForSeconds(CoolTime);
        Tutorial_1_Right.transform.localScale = new Vector3(1, 1, 1);
        Tutorial_1_Right_Move = false;
        yield return new WaitForSeconds(CoolTime);
        Click();
        Tutorial_1_Left.transform.localScale = new Vector3(0.90f, 0.90f, 1);
        Tutorial_1_Left_Move = true;
        yield return new WaitForSeconds(CoolTime);
        Tutorial_1_Left.transform.localScale = new Vector3(1, 1, 1);
        Tutorial_1_Left_Move = false;
        yield return new WaitForSeconds(CoolTime);
        Click();
        Tutorial_1_Left.transform.localScale = new Vector3(0.90f, 0.90f, 1);
        Tutorial_1_Left_Move = true;
        yield return new WaitForSeconds(CoolTime);
        Tutorial_1_Left.transform.localScale = new Vector3(1, 1, 1);
        Tutorial_1_Left_Move = false;
        yield return new WaitForSeconds(CoolTime);
        Click();
        Tutorial_1_Right.transform.localScale = new Vector3(0.90f, 0.90f, 1);
        Tutorial_1_Right_Move = true;
        yield return new WaitForSeconds(CoolTime);
        Tutorial_1_Right.transform.localScale = new Vector3(1, 1, 1);
        Tutorial_1_Right_Move = false;
        StartCoroutine(Tutorial_1_Setting(CoolTime));
    }


    //튜토리얼2
    void Tutorial_2_Reset()
    {
        StopAllCoroutines();

        StartCoroutine(Flying(Tutorial_2_Dove_sp, Black, 0.05f));
        StartCoroutine(Flying(Tutorial_2_Dove_Shadow_sp, Black, 0.05f));

        StartCoroutine(Flying(Tutorial_2_Eagle_sp, Eagle, 0.05f));
        StartCoroutine(Flying(Tutorial_2_Eagle_Shadow_sp, Eagle, 0.05f));

        Tutorial_2_Dove_sp.color = new Color(1, 1, 1, 1);
        Tutorial_2_Dove_Shadow_sp.color = new Color(0, 0, 0, 0.5f);

        Tutorial_Hp_Notion.SetActive(false);

        Tutorial_2_Heart.SetActive(false);
        Tutorial_2_Eagle.SetActive(false);

        Tutorial_2_Heart.transform.localPosition = new Vector3(0, 250, 0);
        Tutorial_2_Eagle.transform.localPosition = new Vector3(0, 250, 0);

        Tutorial_2_Dove_State = true;

        DoveHp = 100;
        Tutorial_Filter.fillAmount = 1;
        StartCoroutine(Hp_Down(5));
        StartCoroutine(Tutorial_2_Setting(2));
    }
    IEnumerator Tutorial_2_Setting(float CoolTime)
    {
        yield return new WaitForSeconds(CoolTime);
        Tutorial_2_Heart_Up = false;
        Tutorial_2_Eagle_Up = false;

        if (Tutorial_2_Value == 0)
        {
            if (Tutorial_2_Dove_State == true)
            {
                Tutorial_2_Heart.transform.localPosition = new Vector3(0, 250, 0);
                Tutorial_2_Heart.SetActive(true);
            }
        }
        else
        {
            if (Tutorial_2_Dove_State == true)
            {
                Tutorial_2_Eagle.transform.localPosition = new Vector3(0, 250, 0);
                Tutorial_2_Eagle.SetActive(true);
            }
        }
    }

    IEnumerator Hp_Down(int number)
    {
        yield return new WaitForSeconds(1f);
        if(DoveHp > 1)
        {
            DoveHp -= number;
            Tutorial_Filter.fillAmount = DoveHp * 0.01f;
        }
        else
        {
            DoveHp = 0;
            Tutorial_Filter.fillAmount = 0;
            if (Tutorial_2_Dove_State == true)
            {
                Tutorial_2_Dove_State = false;
                StartCoroutine(Dove_Resurrect_Wait());
            }
        }

        StartCoroutine(Hp_Down(number));
    }
    void Hp_Plus(int number)
    {
        Coin();
        Tutorial_Hp_Notion.SetActive(false);
        Tutorial_Hp_Notion.GetComponent<UILabel>().text = Tutorial_Title[2] + " + " + number;
        Tutorial_Hp_Notion.SetActive(true);

        if (DoveHp + number >= 100)
        {
            DoveHp = 100;
            Tutorial_Filter.fillAmount = DoveHp * 0.01f;
        }
        else
        {
            DoveHp += number;
            Tutorial_Filter.fillAmount = DoveHp * 0.01f;
        }

        StartCoroutine(Tutorial_2_Setting(2));
    }
    void Hp_Minus(int number)
    {
        Bang();
        Tutorial_Hp_Notion.SetActive(false);
        Tutorial_Hp_Notion.GetComponent<UILabel>().text = Tutorial_Title[2] + " - " + number;
        Tutorial_Hp_Notion.SetActive(true);

        if (DoveHp - number <= 0)
        {
            DoveHp = 0;
            Tutorial_Filter.fillAmount = 0;
            if(Tutorial_2_Dove_State == true)
            {
                Tutorial_2_Dove_State = false;
                StartCoroutine(Dove_Resurrect_Wait());
            }
        }
        else
        {
            DoveHp -= number;
            Tutorial_Filter.fillAmount = DoveHp * 0.01f;
        }

        if(Tutorial_2_Dove.activeSelf == true)
        {
            StartCoroutine(Invincibel_Wait(Tutorial_2_Dove_sp, Tutorial_2_Dove_Shadow_sp));
        }
        if (Tutorial_4_Dove.activeSelf == true)
        {
            StartCoroutine(Invincibel_Wait(Tutorial_4_Dove_sp, Tutorial_4_Dove_Shadow_sp));
        }
        StartCoroutine(Tutorial_2_Setting(2));
    }
    IEnumerator Dove_Resurrect_Wait()
    {
        Tutorial_2_Eagle.SetActive(false);
        Tutorial_Hp_Notion.SetActive(false);
        Tutorial_Hp_Notion.GetComponent<UILabel>().text = "You Died";
        Tutorial_Hp_Notion.SetActive(true);

        Tutorial_2_Dove.SetActive(false);
        Tutorial_2_Dove_Die.SetActive(true);

        yield return new WaitForSeconds(2f);

        Tutorial_2_Dove.SetActive(true);
        Tutorial_2_Dove_Die.SetActive(false);

        Tutorial_2_Dove_State = true;
        Tutorial_2_Reset();
    }
    IEnumerator Invincibel_Wait(UISprite Main_sp,UISprite Shadow_sp)
    {
        for(int i = 0;i< 4;i++)
        {
            Main_sp.color = new Color(1, 1, 1, 0.5f);
            Shadow_sp.color = new Color(0, 0, 0, 0.25f);
            yield return new WaitForSeconds(0.15f);
            Main_sp.color = new Color(1, 1, 1, 1);
            Shadow_sp.color = new Color(0, 0, 0, 0.5f);
            yield return new WaitForSeconds(0.15f);
        }
    }

    //튜토리얼2  - 인게임
    IEnumerator Tutorial_2_InGame(float CoolTime)
    {
        yield return new WaitForSeconds(CoolTime);
        if(Player_State != true)
        {
            yield break;
        }
        Enemy_Create_Eagle();
        yield return new WaitForSeconds(CoolTime);
        if (Player_State != true)
        {
            yield break;
        }
        Enemy_Create_Eagle();
        yield return new WaitForSeconds(CoolTime);
        if (Player_State != true)
        {
            yield break;
        }
        Enemy_Create_Eagle();
        yield return new WaitForSeconds(CoolTime);
        if (Player_State != true)
        {
            yield break;
        }
        Enemy_Create_Eagle();
        yield return new WaitForSeconds(CoolTime);
        if (Player_State != true)
        {
            yield break;
        }
        Object_Create_Item();
    }


    //튜토리얼3
    void Tutorial_3_Reset()
    {
        Tutorial_3_Skill_Filter.fillAmount = 0;
        StartCoroutine(Tutorial_3_Setting(2));
    }
    IEnumerator Tutorial_3_Setting(float CoolTime)
    {
        yield return new WaitForSeconds(CoolTime);
        Tutorial_3_Skill.transform.localScale = new Vector2(0.65f, 0.65f);

        yield return new WaitForSeconds(0.25f);
        Click();
        Tutorial_3_Skill.transform.localScale = new Vector2(0.7f, 0.7f);
        Tutorial_3_Skill_Filter.fillAmount = 1;
        StartCoroutine(Skill_CoolTime(Tutorial_3_Skill_Filter));
        Tutorial_3_Skill_On();

        yield return new WaitForSeconds(1f);
        Tutorial_3_Building.transform.localPosition = new Vector3(0, 250, 0);
        Tutorial_3_Building.SetActive(true);
        yield return new WaitForSeconds(CoolTime * 2);
        Tutorial_3_Reset();
    }
    IEnumerator Skill_CoolTime(UISprite Filter)
    {
        while (Filter.fillAmount > 0)
        {
            Filter.fillAmount -= 1 * Time.smoothDeltaTime / Tutorial_3_Skill_Time;
            yield return null;
        }

        TutorialDove.instance.Skill_Off();
        Skill_Off();

        yield break;
    }


    void Tutorial_3_Skill_On()
    {
        Tutorial_3_Dove.SetActive(false);
        Tutorial_3_Dove_Skill.SetActive(true);

        Tutorial_3_Skill_Value = true;
        Tutorial_3_Dove_Size = 1.3f;
        Tutorial_3_Shadow_Size = 0.8f;
        StartCoroutine(Size_Up());
        StartCoroutine(Size_Wait());
    }
    IEnumerator Size_Wait()
    {
        yield return new WaitForSeconds(Tutorial_3_Skill_Time / 2);
        Tutorial_3_Skill_Value = false;
    }
    IEnumerator Size_Up()
    {
        if (Tutorial_3_Skill_Value == true)
        {
            if (Tutorial_3_Dove_Size <= 2.6f)
            {
                Tutorial_3_Dove_Size += 0.0039f;
                Tutorial_3_Shadow_Size -= 0.00195f;
            }
        }
        else
        {
            StartCoroutine(Size_Down());
            yield break;
        }
        Tutorial_3_Dove_Skill_sp.transform.localScale = new Vector3(Tutorial_3_Dove_Size, Tutorial_3_Dove_Size, 1);
        Tutorial_3_Dove_Skill_Shadow_sp.transform.localScale = new Vector3(Tutorial_3_Shadow_Size, Tutorial_3_Shadow_Size, 1);
        yield return new WaitForSeconds(0.01f);
        StartCoroutine(Size_Up());
    }
    IEnumerator Size_Down()
    {
        if (Tutorial_3_Dove_Size >= 1.3f)
        {
            Tutorial_3_Dove_Size -= 0.0039f;
            Tutorial_3_Shadow_Size += 0.00195f;
        }
        else
        {
            Tutorial_3_Dove_Size = 1.3f;
            Tutorial_3_Shadow_Size = 0.8f;
            Tutorial_3_Dove_Skill_sp.transform.localScale = new Vector3(Tutorial_3_Dove_Size, Tutorial_3_Dove_Size, 1);
            Tutorial_3_Dove_Skill_Shadow_sp.transform.localScale = new Vector3(Tutorial_3_Shadow_Size, Tutorial_3_Shadow_Size, 1);

            Tutorial_3_Dove.SetActive(true);
            Tutorial_3_Dove_Skill.SetActive(false);
            yield break;
        }
        Tutorial_3_Dove_Skill_sp.transform.localScale = new Vector3(Tutorial_3_Dove_Size, Tutorial_3_Dove_Size, 1);
        Tutorial_3_Dove_Skill_Shadow_sp.transform.localScale = new Vector3(Tutorial_3_Shadow_Size, Tutorial_3_Shadow_Size, 1);
        yield return new WaitForSeconds(0.01f);
        StartCoroutine(Size_Down());
    }


    //튜토리얼3 - 인게임
    IEnumerator Tutorial_3_InGame(float CoolTime)
    {
        yield return new WaitForSeconds(CoolTime);
        if (Player_State != true)
        {
            yield break;
        }
        Object_Create_Building(1);
        Object_Create_Building(3);
        //yield return new WaitForSeconds(1);
        LanguageManager.instance.CoolTime_Skill_Notion();
        Skill_Filter.fillAmount = 0;
        Skill_Value = true;
        Skill_Arrow.SetActive(true);
    }


    //튜토리얼4
    IEnumerator Tutorial_4_Setting(float CoolTime)
    {
        Tutorial_4_sun = true;

        Tutorial_4_Sun.SetActive(true);
        Tutorial_4_Moon.SetActive(false);
        Tutorial_4_Night.SetActive(false);

        yield return new WaitForSeconds(CoolTime * 0.5f);
        Tutorial_4_White.transform.localPosition = new Vector3(0, 250, 0);
        Tutorial_4_White.SetActive(true);

        yield return new WaitForSeconds(CoolTime * 2f);
        Tutorial_4_night = true;

        Tutorial_4_Sun.SetActive(false);
        Tutorial_4_Moon.SetActive(true);
        Tutorial_4_Night.SetActive(true);

        yield return new WaitForSeconds(CoolTime * 0.5f);
        Tutorial_4_White.transform.localPosition = new Vector3(0, 250, 0);
        Tutorial_4_White.SetActive(true);

        yield return new WaitForSeconds(CoolTime * 2f);
        StartCoroutine(Tutorial_4_Setting(CoolTime));
    }

    //튜토리얼4 - 인게임
    IEnumerator Tutorial_4_InGame(float CoolTime)
    {
        Tutorial_4_InGame_Night.SetActive(false);
        WeatherWindow.GetComponent<UISprite>().spriteName = "Sun";
        TutorialDove.instance.Weather_Sun();
        StartCoroutine(Weather_Sun());
        yield return new WaitForSeconds(CoolTime);
        if (Player_State != true)
        {
            yield break;
        }
        Enemy_Create_White();
        yield return new WaitForSeconds(CoolTime);
        if (Player_State != true)
        {
            yield break;
        }
        Enemy_Create_White();
        yield return new WaitForSeconds(CoolTime);
        if (Player_State != true)
        {
            yield break;
        }
        Enemy_Create_White();
        yield return new WaitForSeconds(CoolTime * 2);
        Tutorial_4_InGame_Night.SetActive(true);
        WeatherWindow.GetComponent<UISprite>().spriteName = "Moon";
        TutorialDove.instance.Weather_Moon();
        StartCoroutine(Weather_Moon());
        yield return new WaitForSeconds(CoolTime);
        if (Player_State != true)
        {
            yield break;
        }
        Enemy_Create_White();
        yield return new WaitForSeconds(CoolTime);
        if (Player_State != true)
        {
            yield break;
        }
        Enemy_Create_White();
        yield return new WaitForSeconds(CoolTime);
        if (Player_State != true)
        {
            yield break;
        }
        Enemy_Create_White();
        yield return new WaitForSeconds(CoolTime);
    }

    IEnumerator Weather_Sun()
    {
        LanguageManager.instance.Weather_Sun_Notion();
        yield return new WaitForSeconds(2.5f);
        LanguageManager.instance.Weather_Weak_Notion();
    }

    IEnumerator Weather_Moon()
    {
        LanguageManager.instance.Weather_Night_Notion();
        yield return new WaitForSeconds(2.5f);
        LanguageManager.instance.Weather_Strong_Notion();
    }



    void Update()
    {
#if UNITY_ANDROID || UNITY_IPHONE
        Dove_Which = Camera.main.WorldToScreenPoint(Dove.transform.localPosition) + new Vector3(-540.0f, -576.0f, 0);
#endif

#if UNITY_EDITOR
        Dove_Which = Camera.main.WorldToScreenPoint(Dove.transform.localPosition) + new Vector3(-256f, -273.3f, 0);
#endif
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (TutorialWindow.activeSelf == true)
                {
                    EffectManager.instance.onClick();
                    Exit();
                }
            }
        }

        if (tutorial == 1)
        {
            if (Tutorial_1_Right_Move == true)
            {
                Tutorial_1_Dove.transform.Translate(speed * Time.deltaTime, 0, 0);
            }
            else if (Tutorial_1_Left_Move == true)
            {
                Tutorial_1_Dove.transform.Translate(-speed * Time.deltaTime, 0, 0);
            }

            if (TutorialTouch.instance.Dove.transform.position.x >= 0.45f)
            {
                if (Tutorial_1_Quest_Right.activeSelf == true)
                {
                    Coin();
                    Tutorial_1_Quest_Right.SetActive(false);
                }
                else if (Tutorial_1_Quest_Left.activeSelf == false && Tutorial_1_Quest == false)
                {
                    Tutorial_1_Quest = true;
                    StartCoroutine(Tutorial_Start_Wait());
                }
            }

            if (TutorialTouch.instance.Dove.transform.position.x <= -0.45f)
            {
                if (Tutorial_1_Quest_Left.activeSelf == true)
                {
                    Coin();
                    Tutorial_1_Quest_Left.SetActive(false);
                }
                else if (Tutorial_1_Quest_Right.activeSelf == false && Tutorial_1_Quest == false)
                {
                    Tutorial_1_Quest = true;
                    StartCoroutine(Tutorial_Start_Wait());
                }
            }
        }
        else if (tutorial == 2)
        {
            if (Tutorial_2_Heart.activeSelf == true)
            {
                Tutorial_2_Heart.transform.Translate(0, -speed * Time.deltaTime, 0);
            }

            if (Tutorial_2_Eagle.activeSelf == true)
            {
                Tutorial_2_Eagle.transform.Translate(0, speed * Time.deltaTime, 0);
            }

            if (Tutorial_2_Heart.transform.localPosition.y <= 0f)
            {
                if (Tutorial_2_Value == 0 && Tutorial_2_Heart_Up == false)
                {
                    Tutorial_2_Heart_Up = true;
                    Tutorial_2_Heart.SetActive(false);
                    Hp_Plus(25);
                }
                else
                {
                    Tutorial_2_Heart.SetActive(false);
                }
            }

            if (Tutorial_2_Eagle.transform.localPosition.y <= 0f)
            {
                if (Tutorial_2_Value == 1 && Tutorial_2_Eagle_Up == false)
                {
                    Tutorial_2_Eagle_Up = true;
                    Tutorial_2_Eagle.SetActive(false);
                    Hp_Minus(20);
                }
                else
                {
                    Tutorial_2_Eagle.SetActive(false);
                }
            }
        }
        else if (tutorial == 3)
        {
            if (Tutorial_3_Building.activeSelf == true)
            {
                Tutorial_3_Building.transform.Translate(0, -speed * Time.deltaTime, 0);
            }

            if (Tutorial_3_Building.transform.localPosition.y <= -250f)
            {
                Tutorial_3_Building.SetActive(false);
            }
        }
        else if (tutorial == 4)
        {
            if (Tutorial_4_White.activeSelf == true)
            {
                Tutorial_4_White.transform.Translate(0, speed * Time.deltaTime, 0);
            }

            if (Tutorial_4_White.transform.localPosition.y <= 0f)
            {
                if(Tutorial_4_sun == true)
                {
                    Tutorial_4_sun = false;
                    Hp_Minus(10);
                }

                if(Tutorial_4_night == true)
                {
                    Tutorial_4_night = false;
                    Hp_Plus(10);
                }

                Tutorial_4_White.transform.localPosition = new Vector3(0, 250, 0);
                Tutorial_4_White.SetActive(false);
            }
        }

        if (Tutorial_Map_Move == true && Player_State == true)
        {
            Default_Map.transform.Translate(0, -0.5f * Time.deltaTime, 0);
        }

        if(Default_Map.transform.position.y <= -6f)
        {
            Default_Map.transform.position = new Vector3(0, 4.25f, 0);
        }
    }
}

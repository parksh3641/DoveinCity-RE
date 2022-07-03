using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager2 : MonoBehaviour
{
    public static GameManager2 instance = null;

    private bool Player_State;
    private bool Start_Value;

    private bool Talk_Value;
    private bool Hidden_Value;

    private int Mandu_Index;
    private int Stone_Index;

    public GameObject Mandu;
    public GameObject Stone;

    private int DoveChoice;

    //날씨

    public UISprite Weather_Sprite;
    public UISprite Weather_Sprite_Shadow;
    private int Save_Weather_Value = 0;
    public int Weather_Value; //0 = 낮, 1 = 밤, 2 = 비
    public float Weather_Cycle_Value; //날씨가 변경되는 값
    private float Weather_Point;

    public GameObject Dark;
    private UISprite Dark_Sprite;
    private float Dark_Value;
    private int Dark_Max_Alpha = 80;

    public GameObject Rain;
    private ParticleSystem Rain_Particle;
    private float Rain_Value = 0;
    public int Rain_Max_Value = 50;

    public GameObject Item1_Notion;
    public GameObject Item2_Notion;


    private string item1 = "하트";
    private string item2 = "다이아";
    private string item3 = "도라의 깃털";
    private string item4 = "자석";
    private string item5 = "미니 포션";
    private string item6 = "기압계";
    private string item7 = "해킹툴";
    private string item8 = "시간의 모래시계";
    private string item9 = "Fire";
    private string item10 = "디스코 뮤직박스";

    public UISprite Item1;
    public UISprite Item2;

    private int Item_Value; //어떤 아이템인지 구별
    private int Item1_Value;
    private int Item2_Value;

    public float Item1_Time; //시간 저장용
    public float Item2_Time;
    public float Item1_Time_Min = 0;
    public float Item2_Time_Min = 0;

    public bool Item1_Use; //자리 있는지
    public bool Item2_Use;

    public UILabel Item1_txt;
    public UILabel Item2_txt;

    //피버모드
    private bool fever;

    //설정값
    private float Item_Time;
    private float Item_Down_Speed;

    public List<string> List_Item = new List<string>();

    public List<GameObject> Object_Mandu = new List<GameObject>();
    public List<GameObject> Object_Stone = new List<GameObject>();

    public List<GameObject> Enemy_Reset = new List<GameObject>();

    void Awake()
    {
        instance = this;

        Dark_Sprite = Dark.GetComponent<UISprite>(); //초기화
        Dark_Sprite.color = new Color(0, 0, 0, 0);

        Rain_Particle = Rain.GetComponent<ParticleSystem>();
        var emisson = Rain_Particle.emission;
        emisson.rateOverTime = 0;

        Player_State = true;
        Talk_Value = false;
        Hidden_Value = false;
        fever = false;

        Weather_Value = 0;
        Weather_Point = 0;

        Dark.SetActive(false);
        Rain.SetActive(false);

        Item1_Notion.SetActive(false);
        Item2_Notion.SetActive(false);

        Item_Value = 0;

        Item1_Use = false;
        Item2_Use = false;

        Item_Down_Speed = 1.0f;

        Item1.enabled = false;
        Item2.enabled = false;
        Item1_txt.text = " ";
        Item2_txt.text = " ";

        List_Item.Add(item1);
        List_Item.Add(item2);
        List_Item.Add(item3);
        List_Item.Add(item4);
        List_Item.Add(item5);
        List_Item.Add(item6);
        List_Item.Add(item7);
        List_Item.Add(item8);
        List_Item.Add(item9);
        List_Item.Add(item10);

        PlayerPrefs.SetInt("Item_Magnet", 0);
        PlayerPrefs.SetInt("Item_Hourglass", 0);
        PlayerPrefs.SetInt("Item_Disco", 0);

        for (int i = 0; i < 20; i++) //만두
        {
            GameObject mandu = Instantiate(Mandu);
            mandu.name = "Mandu_" + i.ToString();
            mandu.SetActive(false);
            Object_Mandu.Add(mandu);
        }

        for (int i = 0; i < 20; i++) //돌
        {
            GameObject stone = Instantiate(Stone);
            stone.name = "Stone_" + i.ToString();
            stone.SetActive(false);
            Object_Stone.Add(stone);
        }

        Item_Reset();
    }
    void Start()
    {
        DoveChoice = SystemManager.instance.DoveChoice;
        Weather_Cycle_Value = SystemManager.instance.Weather_Cycle_Value;
        Item_Time = SystemManager.instance.Item_Time;

        Weather_Change(Weather_Value, 1);

        StartCoroutine(Start_Wait(2.0f));
    }

    IEnumerator Start_Wait(float number)
    {
        Start_Value = false;
        yield return new WaitForSeconds(number);
        Start_Value = true;
    }

    void Hidden_Clear()
    {
        for (int i = 0; i < Enemy_Reset.Count; i++)
        {
            Enemy_Reset[i].SetActive(false);
        }
        Enemy_Reset.Clear();
    }

    void OnEnable()
    {
        GameManager.Player_Die += Player_Die;
        GameManager.Player_Alive += Player_Alive;
        GameManager.Talk_In += Talk_In;
        GameManager.Talk_Out += Talk_Out;
        GameManager.Under_In += Hidden_Clear;
        GameManager.Castle_In += Hidden_Clear;
    }

    void OnDisable()
    {
        GameManager.Player_Die -= Player_Die;
        GameManager.Player_Alive -= Player_Alive;
        GameManager.Talk_In -= Talk_In;
        GameManager.Talk_Out -= Talk_Out;
        GameManager.Under_In -= Hidden_Clear;
        GameManager.Castle_In -= Hidden_Clear;
    }

    public void WeatherChange()
    {
        Weather_Point = 0;

        int a = UnityEngine.Random.Range(0, 3);
        if (Weather_Value == a)
        {
            Weather_Change(a, 1);
        }
        else
        {
            Weather_Change(a, 0);
        }
    }

    void Player_Die()
    {
        try
        {
            Player_State = false;
            Item_Reset();
        }
        catch (NullReferenceException ie)
        {
            print(ie.Message);

            GameManager.Player_Die += Player_Die;

            Player_State = false;
            Item_Reset();
        }
    }
    void Player_Alive()
    {
        try
        {
            Player_State = true;
        }
        catch (NullReferenceException ie)
        {
            print(ie.Message);

            GameManager.Player_Alive += Player_Alive;

            Player_State = true;
        }
    }

    void Talk_In()
    {
        try
        {
            Talk_Value = true;
        }
        catch (NullReferenceException ie)
        {
            print(ie.Message);

            GameManager.Talk_In += Talk_In;

            Talk_Value = true;
        }
    }
    void Talk_Out()
    {
        try
        {
            Talk_Value = false;
        }
        catch (NullReferenceException ie)
        {
            print(ie.Message);

            GameManager.Talk_Out += Talk_Out;

            Talk_Value = false;
        }
    }

    public void Hidden_In(int number)
    {
        try
        {
            Item_Reset();

            Hidden_Value = true;
            Save_Weather_Value = Weather_Value;

            StartCoroutine(Hidden_In_Wait(number));
        }
        catch (NullReferenceException ie)
        {
            print(ie.Message);

            Item_Reset();

            Hidden_Value = true;
            Save_Weather_Value = Weather_Value;

            StartCoroutine(Hidden_In_Wait(number));
        }
    }

    IEnumerator Hidden_In_Wait(int number)
    {
        yield return new WaitForSeconds(3);
        if (number == 1)
        {
            Weather_Change(1,1);
        }
        else if (number == 2)
        {
            Weather_Change(0,1);
        }

    }
    public void Hidden_Out()
    {
        try
        {
            Hidden_Value = false;

            StartCoroutine(Hidden_Out_Wait());
        }
        catch (NullReferenceException ie)
        {
            print(ie.Message);

            Hidden_Value = false;

            StartCoroutine(Hidden_Out_Wait());
        }
    }

    IEnumerator Hidden_Out_Wait()
    {
        yield return new WaitForSeconds(3);
        Weather_Change(Save_Weather_Value, 1);

    }

    public void Fever_On()
    {
        fever = true;

        Item_Reset();
    }

    public void Fever_Off()
    {
        fever = false;
    }



    public void Object_Create_Mandu(Vector3 Point)
    {
        if (Mandu_Index > Object_Mandu.Count - 1)
        {
            Mandu_Index = 0;
        }
        GameObject monster = Object_Mandu[Mandu_Index];

        if (!monster.activeSelf)
        {
            monster.transform.position = Point + new Vector3(0, 0, -2);
            monster.SetActive(true);
            Enemy_Reset.Add(monster);
        }

        Mandu_Index += 1;
    }

    public void Object_Create_Stone(Vector3 Point)
    {
        if (Stone_Index > Object_Stone.Count - 1)
        {
            Stone_Index = 0;
        }
        GameObject monster = Object_Stone[Stone_Index];

        if (!monster.activeSelf)
        {
            monster.transform.position = Point + new Vector3(0, 0, -2);
            monster.SetActive(true);
            Enemy_Reset.Add(monster);
        }
        else
        {
            Debug.Log("생성이 안됩니다");
        }
        Stone_Index += 1;
    }


    //개발자 옵션
    public void Magnet_Item() 
    {
        Item_Use(3);
    }
    public void Minipoiton_Item()
    {
        Item_Use(4);
    }
    public void Barometer_Item()
    {
        Item_Use(5);
    }
    public void Hacktool_Item()
    {
        Item_Use(6);
    }
    public void Hourglass_Item()
    {
        Item_Use(7);
    }
    public void FeverMode_Item()
    {
        Item_Use(8);
    }

    public void Discomusicbox_Item()
    {
        Item_Use(9);
    }

    //날씨
    public void Weather_Sun()
    {
        Weather_Change(0,0);
    }
    public void Weather_Dark()
    {
        Weather_Change(1,0);
    }
    public void Weather_Rain()
    {
        Weather_Change(2,0);
    }


    void Item_Reset()
    {
        if(Item1_Value >= 0)
        {
            Item_End_Spread(Item1_Value);

            Item1_Time = 0;
            Item1_Value = 0;
            Item1_Use = false;
            Item1_txt.color = new Color(1, 1, 1, 1);
            Item1_txt.text = " ";
            Item1.enabled = false;
        }

        if (Item2_Value >= 0)
        {
            Item_End_Spread(Item2_Value);

            Item2_Time = 0;
            Item2_Value = 0;
            Item2_Use = false;
            Item2_txt.color = new Color(1, 1, 1, 1);
            Item2_txt.text = " ";
            Item2.enabled = false;
        }
    }

    void Item_Use_Spread(int number) //아이템 사용 전세계 전파
    {
        if (number == 3)
        {
            PlayerPrefs.SetInt("Item_Magnet", 1);
        }
        else if (number == 4)
        {
            DoveCtrl.instance.Minipoiton_In();
            DoveTouch.instance.Minipoiton_In();
            SkillManager.instance.Minipoiton_In();
        }
        else if (number == 5)
        {
            //즉시 적용이라 없습니다.
        }
        else if (number == 6)
        {
            GameManager.instance.Hacktool_In();
        }
        else if (number == 7)
        {
            PlayerPrefs.SetInt("Item_Hourglass", 1);
        }
        else if (number == 8)
        {
            //즉시 적용이라 없습니다.
        }
        else if (number == 9)
        {
            EffectManager.instance.Disco_Song_On();
        }
        else
        {
            return;
        }
    }
    void Item_End_Spread(int number) //아이템 사용 끝 전세계 전파
    {
        if (number == 3)
        {
            PlayerPrefs.SetInt("Item_Magnet", 0);
        }
        else if (number == 4)
        {
            DoveCtrl.instance.Minipoiton_Out();
            DoveTouch.instance.Minipoiton_Out();
            SkillManager.instance.Minipoiton_Out();
        }
        else if (number == 5)
        {
            //즉시 적용이라 없습니다.
        }
        else if (number == 6)
        {
            GameManager.instance.Hacktool_Out();
        }
        else if (number == 7)
        {
            PlayerPrefs.SetInt("Item_Hourglass", 0);
        }
        else if (number == 8)
        {
            //즉시 적용이라 없습니다.
        }
        else if (number == 9)
        {
            EffectManager.instance.Disco_Song_Off();
        }
        else
        {
            return;
        }
    }

    public void Item_Use(int number) //0,1,2, //3 자석, 4 미니포션, 5 기압계, 6 해킹툴, 7 시간의 모래시계, 8 디스코 뮤직박스(히든)
    {
        if (Start_Value == true)
        {
            Item_Value = number;

            //업적 - 아이템 획득
            int a = PlayerPrefs.GetInt("Achieve_Item");
            a += 1;
            PlayerPrefs.SetInt("Achieve_Item", a);

            if (fever != true)
            {
                if (Item1_Value == Item_Value)
                {
                    Item1_txt.color = new Color(1, 1, 1, 1);

                    Item1_Time += Item_Time + 1;
                    Item1_Notion.GetComponent<UILabel>().text = "+" + Item_Time.ToString();
                    Item1_Notion.SetActive(true);
                }
                else if (Item2_Value == Item_Value)
                {
                    Item2_txt.color = new Color(1, 1, 1, 1);

                    Item2_Time += Item_Time + 1;
                    Item2_Notion.GetComponent<UILabel>().text = "+" + Item_Time.ToString();
                    Item2_Notion.SetActive(true);
                }
                else
                {
                    if (Item_Value == 5) //기압계 즉시 적용
                    {
                        Barometer_Change();
                    }
                    else if (Item_Value == 8) //피버모드 즉시 적용
                    {
                        LanguageManager.instance.Get_Item_Notion();
                        GameManager.instance.Fever_Plus();
                    }
                    else
                    {
                        Item_Use_Check();
                        if (Item1_Use == false || Item2_Use == false)
                        {
                            LanguageManager.instance.Get_Item_Notion();
                        }
                    }
                }
            }
            else
            {
                Debug.Log("피버모드에서는 아이템을 사용할 수 없습니다.");
            }
        }
        else
        {
            Debug.Log("로딩중입니다.");
        }
    }


    void Item_Use_Check()
    {
        if (Item1_Use == false)
        {
            Item1_Time = Item_Time;

            Item1_Value = Item_Value;
            Item_Use_Spread(Item1_Value);

            Item1_Use = true;
            Item1.enabled = true;

            Item1.spriteName = List_Item[Item_Value];

            StartCoroutine(Item1_Timer());
        }
        else if (Item2_Use == false)
        {
            Item2_Time = Item_Time;

            Item2_Value = Item_Value;
            Item_Use_Spread(Item2_Value);

            Item2_Use = true;
            Item2.enabled = true;

            Item2.spriteName = List_Item[Item_Value];

            StartCoroutine(Item2_Timer());
        }
        else
        {
            LanguageManager.instance.Not_Item2_Notion();
        }
    }



    IEnumerator Item1_Timer()
    {
        if (Item1_Time >= 60)
        {
            Item1_Time_Min = Item1_Time / 60;
            Item1_txt.text = (int)Item1_Time_Min + ":" + (Item1_Time - (60 * (int)Item1_Time_Min)).ToString();
        }
        else
        {
            if (Item1_Time >= 10)
            {
                Item1_txt.text = "0:" + Item1_Time.ToString();
            }
            else
            {
                Item1_txt.text = "0:0" + Item1_Time.ToString();
            }
        }

        yield return new WaitForSeconds(Item_Down_Speed);

        if (Item1_Time <= 0)
        {
            if (Item1_Value >= 0)
            {
                Item_End_Spread(Item1_Value);

                Item1_Time = 0;
                Item1_Value = 0;
                Item1_Use = false;
                Item1_txt.color = new Color(1, 1, 1, 1);
                Item1_txt.text = " ";
                Item1.enabled = false;

                if (Item1_Use == false && Item2_Use == true) //스킬2보다 스킬1이 먼저 끝났을 경우 위치 교체
                {
                    Item1_Time = Item2_Time;
                    Item1_Value = Item2_Value;
                    Item1_txt.color = new Color(1, 1, 1, 1);

                    Item1_Use = true;
                    Item1.enabled = true;
                    Item1.spriteName = List_Item[Item2_Value];
                    Item2_Value = 0;

                    if (Item2_Value >= 0)
                    {
                        Item_End_Spread(Item2_Value);

                        Item2_Time = 0;
                        Item2_Value = 0;
                        Item2_Use = false;
                        Item2_txt.text = " ";
                        Item2_txt.color = new Color(1, 1, 1, 1);
                        Item2.enabled = false;
                    }
                }
                else
                {
                    yield break;
                }
            }
        }
        else
        {
            if (Talk_Value == false)
            {
                Item1_Time -= 1;
                if (Item1_Time <= 3)
                {
                    Item1_txt.color = new Color(1, 0, 0, 1);
                }
                else
                {
                    Item1_txt.color = new Color(1, 1, 1, 1);
                }
            }
        }
        StartCoroutine(Item1_Timer());
    }
    IEnumerator Item2_Timer()
    {
        if (Item2_Time >= 60)
        {
            Item2_Time_Min = Item2_Time / 60;
            Item2_txt.text = (int)Item2_Time_Min + ":" + (Item2_Time - (60 * (int)Item2_Time_Min)).ToString();
        }
        else
        {
            if (Item2_Time >= 10)
            {
                Item2_txt.text = "0:" + Item2_Time.ToString();
            }
            else
            {
                Item2_txt.text = "0:0" + Item2_Time.ToString();
            }
        }

        yield return new WaitForSeconds(Item_Down_Speed);

        if (Item2_Time <= 0)
        {
            if (Item2_Value >= 0)
            {
                Item_End_Spread(Item2_Value);

                Item2_Time = 0;
                Item2_Value = 0;
                Item2_Use = false;
                Item2_txt.text = " ";
                Item2_txt.color = new Color(1, 1, 1, 1);
                Item2.enabled = false;

                yield break;
            }
        }
        else
        {
            if (Talk_Value == false)
            {
                Item2_Time -= 1;
                if (Item2_Time <= 3)
                {
                    Item2_txt.color = new Color(1, 0, 0, 1);
                }
                else
                {
                    Item2_txt.color = new Color(1, 1, 1, 1);
                }
            }
        }

        StartCoroutine(Item2_Timer());
    }




    void Weather_Change(int number, int hidden) //hidden 0 = 멘트 출력 / 1 = 출력X
    {
        if(hidden == 0)
        {
            //업적 - 날씨 변경
            int a = PlayerPrefs.GetInt("Achieve_Weather");
            a += 1;
            PlayerPrefs.SetInt("Achieve_Weather", a);
        }

        StopAllCoroutines();

        if(Item1_Time > 0)
        {
            StartCoroutine(Item1_Timer());
        }
        if(Item2_Time > 0)
        {
            StartCoroutine(Item2_Timer());
        }

        Weather_Value = number;
        Weather_Point = 0;

        if (number == 0)
        {
            Weather_Sprite.spriteName = "Sun";
            Weather_Sprite_Shadow.spriteName = "Sun";
            //Debug.Log("낮");
            StartCoroutine(Weather_Dark_Down());
            StartCoroutine(Weather_Rain_Down());

            DoveCtrl.instance.Weather_Sun();
        }
        else if(number == 1)
        {
            Weather_Sprite.spriteName = "Moon";
            Weather_Sprite_Shadow.spriteName = "Moon";
            //Debug.Log("밤");
            Dark.SetActive(true);
            StartCoroutine(Weather_Dark_Up(Dark_Max_Alpha));
            StartCoroutine(Weather_Rain_Down());

            DoveCtrl.instance.Weather_Dark();
        }
        else if (number == 2)
        {
            Weather_Sprite.spriteName = "Rain";
            Weather_Sprite_Shadow.spriteName = "Rain";
            //Debug.Log("비");
            EffectManager.instance.Rain_Song_On();

            Rain.SetActive(true);

            StartCoroutine(Weather_Dark_Down());

            StartCoroutine(Weather_Rain_Up(Rain_Max_Value));
            DoveCtrl.instance.Weather_Rain();
        }

        if(hidden == 0)
        {
            StartCoroutine(Dove_Weather_Talk(number));
        }

        StartCoroutine(Weathering());
    }

    void Barometer_Change() //자신에게 유리한 날씨로 변경
    {
        if(Weather_Value == 0)
        {
            if (DoveChoice == 1)
            {
                Weather_Change(1,0); //낮에서 밤으로 변경
            }
            else if (DoveChoice == 2)
            {
                //효과 없음
            }
            else if (DoveChoice == 3)
            {
                Weather_Change(2,0); //낮에서 비로 변경
            }
            else if (DoveChoice == 4)
            {
                //효과 없음
            }
        }
        else if(Weather_Value == 1)
        {
            if (DoveChoice == 1)
            {
                //효과 없음
            }
            else if (DoveChoice == 2)
            {
                Weather_Change(0,0); //밤에서 낮으로 변경
            }
            else if (DoveChoice == 3)
            {
                Weather_Change(2,0); //밤에서 비로 변경
            }
            else if (DoveChoice == 4)
            {
                Weather_Change(0,0); //밤에서 낮으로 변경
            }
        }
        else if(Weather_Value == 2)
        {
            if (DoveChoice == 1)
            {
                Weather_Change(1,0); //낮에서 밤으로 변경
            }
            else if (DoveChoice == 2)
            {
                Weather_Change(0,0); //비에서 밤낮으로 변경
            }
            else if (DoveChoice == 3)
            {
                //효과없음
            }
            else if (DoveChoice == 4)
            {
                Weather_Change(0,0); //비에서 낮으로 변경
            }
        }
    }

    IEnumerator Dove_Weather_Talk(int number)
    {
        if (number == 0)
        {
            yield return new WaitForSeconds(0.5f);
            LanguageManager.instance.Weather_Sun_Notion();
            yield return new WaitForSeconds(2.5f);
            if (DoveChoice == 1)
            {
                LanguageManager.instance.Weather_Weak_Notion();
            }
            else if (DoveChoice == 2)
            {
                LanguageManager.instance.Weather_Strong_Notion();
            }
            else if (DoveChoice == 3)
            {
                LanguageManager.instance.Weather_Weak_Notion();
            }
            else if (DoveChoice == 4)
            {
                LanguageManager.instance.Weather_Sun_Dora_Notion();
            }
        }
        else if (number == 1)
        {
            yield return new WaitForSeconds(0.5f);
            LanguageManager.instance.Weather_Night_Notion();
            yield return new WaitForSeconds(2.5f);
            if (DoveChoice == 1)
            {
                LanguageManager.instance.Weather_Strong_Notion();
            }
            else if (DoveChoice == 2)
            {
                LanguageManager.instance.Weather_Weak_Notion();
            }
            else if (DoveChoice == 3)
            {
                LanguageManager.instance.Weather_Weak_Notion();
            }
            else if (DoveChoice == 4)
            {
                LanguageManager.instance.Weather_Weak_Notion();
            }
        }
        else if (number == 2)
        {
            yield return new WaitForSeconds(0.5f);
            LanguageManager.instance.Weather_Rain_Notion();
            yield return new WaitForSeconds(2.5f);
            if (DoveChoice == 1)
            {
                LanguageManager.instance.Weather_Weak_Notion();
            }
            else if (DoveChoice == 2)
            {
                LanguageManager.instance.Weather_Weak_Notion();
            }
            else if (DoveChoice == 3)
            {
                LanguageManager.instance.Weather_Strong_Notion();
            }
            else if (DoveChoice == 4)
            {
                LanguageManager.instance.Weather_Weak_Notion();
            }
        }
    }


    IEnumerator Weather_Dark_Up(int number)
    {
        if(Dark_Value <= number)
        {
            Dark_Value += 3f;
        }
        else
        {
            yield break;
        }
        Dark_Sprite.color = new Color(0, 0, 0, (Dark_Value / 255));
        yield return new WaitForSeconds(0.05f);
        StartCoroutine(Weather_Dark_Up(number));
    }
    IEnumerator Weather_Dark_Down()
    {
        if (Dark_Value >= 0)
        {
            Dark_Value -= 3f;
        }
        else
        {
            Dark.SetActive(false);
            yield break;
        }
        Dark_Sprite.color = new Color(0, 0, 0, (Dark_Value / 255));
        yield return new WaitForSeconds(0.05f);
        StartCoroutine(Weather_Dark_Down());
    }

    IEnumerator Weather_Rain_Up(int number)
    {
        var emisson = Rain_Particle.emission;
        if(Rain_Value <= number)
        {
            Rain_Value += 1;
        }
        else
        {
            yield break;
        }
        emisson.rateOverTime = Rain_Value;
        yield return new WaitForSeconds(0.05f);
        StartCoroutine(Weather_Rain_Up(number));
    }
    IEnumerator Weather_Rain_Down()
    {
        if (Hidden_Value == false)
        {
            var emisson = Rain_Particle.emission;
            if (Rain_Value >= 0)
            {
                Rain_Value -= 1;
            }
            else
            {
                yield return new WaitForSeconds(1);
                EffectManager.instance.Rain_Song_Off();
                yield return new WaitForSeconds(1);
                Rain.SetActive(false);
                yield break;
            }
            emisson.rateOverTime = Rain_Value;
            yield return new WaitForSeconds(0.05f);
            StartCoroutine(Weather_Rain_Down());
        }
        else
        {
            EffectManager.instance.Rain_Song_Off();
            Rain.SetActive(false);
        }
    }

    IEnumerator Weathering()
    {
        if(Weather_Point >= Weather_Cycle_Value)
        {
            WeatherChange();
            //Debug.Log("날씨 변경");
        }

        yield return new WaitForSeconds(1f);

        if (Player_State == true && Talk_Value == false && Hidden_Value == false)
        {
            Weather_Point += 1;
        }

        StartCoroutine(Weathering());
    }

}

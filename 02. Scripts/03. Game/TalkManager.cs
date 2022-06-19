using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TalkManager : MonoBehaviour
{
    public static TalkManager instance = null;

    private int BD_Coin;
    private int BD_Diamond;
    private int BD_Dora_Feather;
    private int Language;

    public UISprite Main_Sprite;

    public UILabel Main_Name_txt;
    public UILabel Main_txt;
    public UILabel Main2_txt;

    public GameObject First_Button;
    public GameObject Second_Button;
    public GameObject Third_Button;

    public UILabel First_Button_txt;
    public UILabel Second_Button_txt;
    public UILabel Third_Button_txt;

    public GameObject Next_Button;
    public GameObject Box_Window;
    public UISprite Box_sprite;
    public UILabel Box_label;

    private string[] Box_Present;

    public UISprite Shadow_sprite;

    //파티클
    public ParticleSystem Box_System;

    private bool God;
    private bool Mole;

    private int God_Talk_Index;
    private int Mole_Talk_Index;

    private int God_Value;
    private int Mole_Value;
    private int Mole_Value2;

    private bool Choice_State;
    private int Item_Value;

    //게임
    private float Default_Hp;

    private float Talk_Delay = 0.04f;

    //대화
    private List<string> Main_God = new List<string>();
    private List<string> Main_Mole1 = new List<string>();
    private List<string> Main_Mole2 = new List<string>();
    private List<string> Main_God_Present = new List<string>();
    private List<string> Main_Mole_Present = new List<string>();
    private List<string> Main_Talk_Name = new List<string>();

    void Awake()
    {
        instance = this;

        First_Button.SetActive(false);
        Second_Button.SetActive(false);
        Third_Button.SetActive(false);
        Box_Window.SetActive(false);

        God_Value = 0;
        Mole_Value = 0;
        Mole_Value2 = 0;

        Box_System.Stop();

        Language = PlayerPrefs.GetInt("Language");
    }
    void Start()
    {
        Default_Hp = SystemManager.instance.Default_Hp;

        Language_Setting();
    }

    public void Language_Setting()
    {
        int a = PlayerPrefs.GetInt("Language");
        switch (a)
        {
            case 1:
                for (int i = 0; i < LanguageManager.instance.Main_God_Korean.Length; i++)
                {
                    string b = LanguageManager.instance.Main_God_Korean[i];
                    Main_God.Add(b);
                }
                for (int i = 0; i < LanguageManager.instance.Main_Mole1_Korean.Length; i++)
                {
                    string b = LanguageManager.instance.Main_Mole1_Korean[i];
                    Main_Mole1.Add(b);
                }
                for (int i = 0; i < LanguageManager.instance.Main_Mole2_Korean.Length; i++)
                {
                    string b = LanguageManager.instance.Main_Mole2_Korean[i];
                    Main_Mole2.Add(b);
                }
                for (int i = 0; i < LanguageManager.instance.Main_God_Present_Korean.Length; i++)
                {
                    string b = LanguageManager.instance.Main_God_Present_Korean[i];
                    Main_God_Present.Add(b);
                }
                for (int i = 0; i < LanguageManager.instance.Main_Mole_Present_Korean.Length; i++)
                {
                    string b = LanguageManager.instance.Main_Mole_Present_Korean[i];
                    Main_Mole_Present.Add(b);
                }
                for (int i = 0; i < LanguageManager.instance.Main_Talk_Name_Korean.Length; i++)
                {
                    string b = LanguageManager.instance.Main_Talk_Name_Korean[i];
                    Main_Talk_Name.Add(b);
                }
                Box_Present = LanguageManager.instance.Box_Present_Korean;

                Talk_Delay = 0.03f;
                break;
            case 2:
                for (int i = 0; i < LanguageManager.instance.Main_God_English.Length; i++)
                {
                    string b = LanguageManager.instance.Main_God_English[i];
                    Main_God.Add(b);
                }
                for (int i = 0; i < LanguageManager.instance.Main_Mole1_English.Length; i++)
                {
                    string b = LanguageManager.instance.Main_Mole1_English[i];
                    Main_Mole1.Add(b);
                }
                for (int i = 0; i < LanguageManager.instance.Main_Mole2_English.Length; i++)
                {
                    string b = LanguageManager.instance.Main_Mole2_English[i];
                    Main_Mole2.Add(b);
                }
                for (int i = 0; i < LanguageManager.instance.Main_God_Present_English.Length; i++)
                {
                    string b = LanguageManager.instance.Main_God_Present_English[i];
                    Main_God_Present.Add(b);
                }
                for (int i = 0; i < LanguageManager.instance.Main_Mole_Present_English.Length; i++)
                {
                    string b = LanguageManager.instance.Main_Mole_Present_English[i];
                    Main_Mole_Present.Add(b);
                }
                for (int i = 0; i < LanguageManager.instance.Main_Talk_Name_English.Length; i++)
                {
                    string b = LanguageManager.instance.Main_Talk_Name_English[i];
                    Main_Talk_Name.Add(b);
                }
                Box_Present = LanguageManager.instance.Box_Present_English;

                Talk_Delay = 0.015f;
                break;
            case 3:
                for (int i = 0; i < LanguageManager.instance.Main_God_Chinese.Length; i++)
                {
                    string b = LanguageManager.instance.Main_God_Chinese[i];
                    Main_God.Add(b);
                }
                for (int i = 0; i < LanguageManager.instance.Main_Mole1_Chinese.Length; i++)
                {
                    string b = LanguageManager.instance.Main_Mole1_Chinese[i];
                    Main_Mole1.Add(b);
                }
                for (int i = 0; i < LanguageManager.instance.Main_Mole2_Chinese.Length; i++)
                {
                    string b = LanguageManager.instance.Main_Mole2_Chinese[i];
                    Main_Mole2.Add(b);
                }
                for (int i = 0; i < LanguageManager.instance.Main_God_Present_Chinese.Length; i++)
                {
                    string b = LanguageManager.instance.Main_God_Present_Chinese[i];
                    Main_God_Present.Add(b);
                }
                for (int i = 0; i < LanguageManager.instance.Main_Mole_Present_Chinese.Length; i++)
                {
                    string b = LanguageManager.instance.Main_Mole_Present_Chinese[i];
                    Main_Mole_Present.Add(b);
                }
                for (int i = 0; i < LanguageManager.instance.Main_Talk_Name_Chinese.Length; i++)
                {
                    string b = LanguageManager.instance.Main_Talk_Name_Chinese[i];
                    Main_Talk_Name.Add(b);
                }
                Box_Present = LanguageManager.instance.Box_Present_Chinese;

                Talk_Delay = 0.03f;
                break;
            case 4:
                for (int i = 0; i < LanguageManager.instance.Main_God_Japanese.Length; i++)
                {
                    string b = LanguageManager.instance.Main_God_Japanese[i];
                    Main_God.Add(b);
                }
                for (int i = 0; i < LanguageManager.instance.Main_Mole1_Japanese.Length; i++)
                {
                    string b = LanguageManager.instance.Main_Mole1_Japanese[i];
                    Main_Mole1.Add(b);
                }
                for (int i = 0; i < LanguageManager.instance.Main_Mole2_Japanese.Length; i++)
                {
                    string b = LanguageManager.instance.Main_Mole2_Japanese[i];
                    Main_Mole2.Add(b);
                }
                for (int i = 0; i < LanguageManager.instance.Main_God_Present_Japanese.Length; i++)
                {
                    string b = LanguageManager.instance.Main_God_Present_Japanese[i];
                    Main_God_Present.Add(b);
                }
                for (int i = 0; i < LanguageManager.instance.Main_Mole_Present_Japanese.Length; i++)
                {
                    string b = LanguageManager.instance.Main_Mole_Present_Japanese[i];
                    Main_Mole_Present.Add(b);
                }
                for (int i = 0; i < LanguageManager.instance.Main_Talk_Name_Japanese.Length; i++)
                {
                    string b = LanguageManager.instance.Main_Talk_Name_Japanese[i];
                    Main_Talk_Name.Add(b);
                }
                Box_Present = LanguageManager.instance.Box_Present_Japanese;

                Talk_Delay = 0.03f;
                break;
        }
    }

    public void Renewal(int number)
    {
        //업적 - NPC 대화
        int a = PlayerPrefs.GetInt("Achieve_Npc");
        a += 1;
        PlayerPrefs.SetInt("Achieve_Npc", a);

        BD_Coin = SystemManager.instance.BD_Coin;
        BD_Diamond = SystemManager.instance.BD_Diamond;
        BD_Dora_Feather = SystemManager.instance.BD_Dora_Feather;

        Item_Value = 0;
        Choice_State = false;

        if(number == 0)
        {
            God_Talk_Index = 0;
            God = true;
            Mole = false;
            God_Value = UnityEngine.Random.Range(1, 2);
            God_Talk();
        }
        else
        {
            Mole_Talk_Index = 0;
            God = false;
            Mole = true;
            Mole_Value = UnityEngine.Random.Range(1, 5);
            Mole_Talk();
        }
    }

    void Talk_End()
    {
        Button_Down();

        if(Item_Value == 1)
        {
            int Hp = Mathf.RoundToInt(Default_Hp * 0.25f);
            GameManager.instance.Hp_Plus(Hp);
        }
        else if(Item_Value == 2)
        {
            int Hp = Mathf.RoundToInt(Default_Hp * 0.5f);
            GameManager.instance.Hp_Plus(Hp);
        }
        else if(Item_Value == 3)
        {
            int Hp = Mathf.RoundToInt(Default_Hp * 0.75f);
            GameManager.instance.Hp_Plus(Hp);
        }
        else if (Item_Value == 4)
        {
            int Hp = Mathf.RoundToInt(Default_Hp * 1f);
            GameManager.instance.Hp_Plus(Hp);
        }
        else if (Item_Value >= 5)
        {
            GameManager2.instance.Item_Use(Item_Value - 2);
        }

        Box_System.Stop();
    }


    IEnumerator Talking(List<string> str, int number, int btn)
    {
        Next_Button.SetActive(false);

        string Text = str[number];
        string[] Replace_Text = new string[Text.Length];

        Main_txt.text = "";
        Main2_txt.text = "";
        for (int i =0;i<Replace_Text.Length;i++)
        {
            Replace_Text[i] = Text.Substring(i, 1);
        }

        for (int i = 0; i < Replace_Text.Length; i++)
        {
            switch(Language)
            {
                case 0:
                    Main_txt.text += Replace_Text[i];
                    break;
                case 1:
                    if (i < 38)
                    {
                        Main_txt.text += Replace_Text[i];
                    }
                    else
                    {
                        Main2_txt.text += Replace_Text[i];
                    }
                    break;
                case 2:
                    Main_txt.text += Replace_Text[i];
                    break;
                case 3:
                    if (i < 22)
                    {
                        Main_txt.text += Replace_Text[i];
                    }
                    else
                    {
                        Main2_txt.text += Replace_Text[i];
                    }
                    break;
            }

            if(i % 3 == 0)
            {
                EffectManager.instance.Talk();
            }

            yield return new WaitForSeconds(Talk_Delay);
        }
        if(btn == 0)
        {
            Next_Button.SetActive(true);
        }
    }


    void God_Talk()
    {
        try
        {
            Main_Sprite.spriteName = "산신령_UI";
            Main_Sprite.width = 500;
            Main_Sprite.height = 887;
            Main_Sprite.transform.localPosition = new Vector3(-280, 418, 0);
            Main_Name_txt.text = Main_Talk_Name[0];

            StartCoroutine(Talking(Main_God, 0, 0));
            //Main_txt.text = "야생의 산신령이 대화를 걸어왔다!";
        }
        catch (NullReferenceException ie)
        {
            print(ie.Message);

            StopAllCoroutines();

            Main_Sprite.spriteName = "산신령_UI";
            Main_Sprite.width = 500;
            Main_Sprite.height = 887;
            Main_Sprite.transform.localPosition = new Vector3(-280, 418, 0);
            Main_Name_txt.text = Main_Talk_Name[0];

            StartCoroutine(Talking(Main_God, 0, 0));
            //Main_txt.text = "야생의 산신령이 대화를 걸어왔다!";
        }
    }
    void Mole_Talk()
    {
        try
        {
            Main_Sprite.spriteName = "Mole_5";
            Main_Sprite.width = 500;
            Main_Sprite.height = 416;
            Main_Sprite.transform.localPosition = new Vector3(-280, 468, 0);
            Mole_Talk_Index = 0;
            Main_Name_txt.text = Main_Talk_Name[1];

            StartCoroutine(Talking(Main_Mole1, 0, 0));
            //Main_txt.text = "야생의 두더지가 대화를 걸어왔다!";
        }
        catch (NullReferenceException ie)
        {
            print(ie.Message);

            StopAllCoroutines();

            Main_Sprite.spriteName = "Mole_5";
            Main_Sprite.width = 500;
            Main_Sprite.height = 416;
            Main_Sprite.transform.localPosition = new Vector3(-280, 468, 0);
            Mole_Talk_Index = 0;
            Main_Name_txt.text = Main_Talk_Name[1];

            StartCoroutine(Talking(Main_Mole1, 0, 0));
            //Main_txt.text = "야생의 두더지가 대화를 걸어왔다!";
        }
    }



    public void Next_Talk()
    {
        if(God == true)
        {
            if(God_Talk_Index == 0)
            {
                if (God_Value == 1)
                {
                    StartCoroutine(Talking(Main_God, 1,1));
                    //Main_txt.text = "원하는 상자를 골라보거라. 선물을 하나 주마.";
                    First_Button_txt.text = Main_God_Present[0];
                    Second_Button_txt.text = Main_God_Present[1];
                    Third_Button_txt.text = Main_God_Present[2];
                    StartCoroutine(Button_Animation());
                    God_Talk_Index += 1;
                }
            }
            else if(God_Talk_Index == 1)
            {
                if (God_Value == 1)
                {
                    StartCoroutine(Talking(Main_God, 2,0));
                    //Main_txt.text = "허허허 그 선물이 마음에 들겠구나.";
                    God_Talk_Index += 1;
                }

            }
            else if (God_Talk_Index == 2)
            {
                if (God_Value == 1)
                {
                    StartCoroutine(Talking(Main_God, 3,0));
                    //Main_txt.text = "(산신령은 구름 속으로 유유히 사라졌다.)";
                    God_Talk_Index += 1;
                }
            }
            else if (God_Talk_Index == 3)
            {
                if (God_Value == 1)
                {
                    GameManager.instance.Talk_End();
                    Talk_End();
                }
            }

        }
        else if(Mole  == true)
        {
            if (Mole_Talk_Index == 0)
            {
                if (Mole_Value != 4)
                {
                    StartCoroutine(Talking(Main_Mole1, 1,1));
                    //Main_txt.text = "지하세계 한 번 가볼래?";
                    First_Button_txt.text = Main_Mole_Present[0];
                    Second_Button_txt.text = Main_Mole_Present[1];
                    Third_Button_txt.text = Main_Mole_Present[2];
                    StartCoroutine(Button_Animation());
                    Mole_Talk_Index += 1;
                }
                else
                {
                    StartCoroutine(Talking(Main_Mole2, 0,1));
                    //Main_txt.text = "나 쓰다듬어줄래?";
                    First_Button_txt.text = Main_Mole_Present[0];
                    Second_Button_txt.text = Main_Mole_Present[1];
                    Third_Button_txt.text = Main_Mole_Present[2];
                    StartCoroutine(Button_Animation());
                    Mole_Talk_Index += 1;
                }
            }
            else if (Mole_Talk_Index == 1)
            {
                if (Mole_Value != 4)
                {
                    if (Mole_Value2 == 0)
                    {
                        GameManager.instance.UnderUp();
                        Talk_End();
                    }
                    else
                    {
                        GameManager.instance.Talk_End();
                        Talk_End();
                    }
                }
                else
                {
                    if(Mole_Value2 == 0)
                    {
                        Mole_Talk_Index += 1;
                        StartCoroutine(Talking(Main_Mole1, 4,0));
                        //Main_txt.text = "(아무 일도 일어나지 않았다.)";
                    }
                    else
                    {
                        Mole_Talk_Index += 1;
                        StartCoroutine(Talking(Main_Mole2, 2,0));
                        //Main_txt.text = "(두더지를 쓰다듬자 몸이 이상하다.)";
                    }
                }
            }
            else if (Mole_Talk_Index == 2)
            {
                if (Mole_Value2 == 0)
                {
                    GameManager.instance.Talk_End();
                    Talk_End();
                }
                else
                {
                    GameManager.instance.Mole_Die();
                    GameManager.instance.Talk_End();
                    Talk_End();
                }
            }
        }
    }
    IEnumerator Button_Animation()
    {
        yield return new WaitForSeconds(0.3f);
        First_Button.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        Second_Button.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        Third_Button.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        Choice_State = true;
    }

    public void First_Choice()
    {
        if(God == true)
        {
            if(Choice_State == true)
            {
                if(God_Value == 1)
                {
                    Button_Down();
                    Box_Open(10,5,35,50);
                }
                else if(God_Value == 2)
                {

                }
            }
        }
        else if(Mole == true)
        {
            if (Choice_State == true)
            {
                if (Mole_Value != 4)
                {
                    StartCoroutine(Talking(Main_Mole1, 2,0));
                    //Main_txt.text = "좋아. 그럼 지하세계로 보내줄께.";
                    Button_Down();
                }
                else
                {
                    Mole_Value2 = 1;
                    StartCoroutine(Talking(Main_Mole2, 1,0));
                    //Main_txt.text = "이상한 느낌이다.";
                    Button_Down();
                }
            }
        }
    }
    public void Second_Choice()
    {
        if (God == true)
        {
            if (Choice_State == true)
            {
                if (God_Value == 1)
                {
                    Button_Down();
                    Box_Open(10,5,35,50);
                }
                else if (God_Value == 2)
                {

                }
            }
        }
        else if (Mole == true)
        {
            if (Choice_State == true)
            {
                if (Mole_Value != 4)
                {
                    StartCoroutine(Talking(Main_Mole1, 2,0));
                    //Main_txt.text = "좋아. 그럼 지하세계로 보내줄께.";
                    Button_Down();
                }
                else
                {
                    Mole_Value2 = 1;
                    StartCoroutine(Talking(Main_Mole2, 1,0));
                    //Main_txt.text = "이상한 느낌이다.";
                    Button_Down();
                }
            }
        }
    }
    public void Third_Choice()
    {
        if (God == true)
        {
            if (Choice_State == true)
            {
                if (God_Value == 1)
                {
                    Button_Down();
                    Box_Open(10,5,35,50);
                }
                else if (God_Value == 2)
                {

                }
            }
        }
        else if (Mole == true)
        {
            if (Choice_State == true)
            {
                if (Mole_Value != 4)
                {
                    Mole_Value2 = 1;
                    StartCoroutine(Talking(Main_Mole1, 3,0));
                    //Main_txt.text = "싫어? 그러면 어쩔 수 없지.";
                    Button_Down();
                }
                else
                {
                    Mole_Value2 = 0;
                    StartCoroutine(Talking(Main_Mole2, 1,0));
                    //Main_txt.text = "이상한 느낌이다.";
                    Button_Down();
                }
            }
        }
    }
    void Button_Down()
    {
        First_Button.SetActive(false);
        Second_Button.SetActive(false);
        Third_Button.SetActive(false);
    }

    void Box_Open(int number1, int number2, int number3, int number4)
    {
        Box_Window.SetActive(true);
        Box_System.Play();

        Box_label.color = new Color(0, 0, 0, 1);


        int i = UnityEngine.Random.Range(0, 100);
        if(i >= 100 - number1)
        {
            Box_System.Stop();
            //Debug.Log("아무일도 일어나지 않았다.");

            Box_sprite.spriteName = "산신령_UI";
            Shadow_sprite.spriteName = "산신령_UI";

            Box_label.text = Box_Present[0];

            EffectManager.instance.Dove_Select();

        }
        else if(i >= 100 - number1 - number2) //75~90
        {
            //Debug.Log("도라의 깃털 획득");

            Box_sprite.spriteName = "도라의 깃털";
            Shadow_sprite.spriteName = "도라의 깃털";

            int j = UnityEngine.Random.Range(2, 5);
            Box_label.text = "+" + j.ToString();

            GameManager.instance.Dora_Feather_Plus(j);
            EffectManager.instance.Box_Open_3();
        }
        else if (i >= 100 - number1 - number2 - number3) //50~75
        {
            int j = UnityEngine.Random.Range(0, 100);
            if(j >= 20)
            {
                //Debug.Log("골드 획득");

                Box_sprite.spriteName = "Coin_1";
                Shadow_sprite.spriteName = "Coin_1";

                int k = UnityEngine.Random.Range(1000, 2001);
                Box_label.text = "+" + k.ToString();

                GameManager.instance.Coin_Plus(k);
                EffectManager.instance.Box_Open_1();
            }
            else
            {
                //Debug.Log("다이아 획득");

                Box_sprite.spriteName = "다이아";
                Shadow_sprite.spriteName = "다이아";

                int k = UnityEngine.Random.Range(5, 16);
                Box_label.text = "+" + k.ToString();

                GameManager.instance.Diamond_Plus(k);
                EffectManager.instance.Box_Open_2();
            }
        }
        else if (i >= 100 - number1 - number2 - number3 - number4) //0~50
        {
            //Debug.Log("하트 아이템 획득");
            int j = UnityEngine.Random.Range(0, 100);
            if(j >= 75)
            {
                Box_sprite.spriteName = "하트";
                Shadow_sprite.spriteName = "하트";
                Box_label.color = new Color(1, 0, 0, 1);

                int k = UnityEngine.Random.Range(1, 5);
                if(k == 1)
                {
                    //Debug.Log("Hp 25% 회복");
                    Box_label.text = "Hp 25%";
                    EffectManager.instance.Box_Open_1();
                    Item_Value = 1;
                }
                else if(k == 2)
                {
                    //Debug.Log("Hp 50% 회복");
                    Box_label.text = "Hp 50%";
                    EffectManager.instance.Box_Open_2();
                    Item_Value = 2;
                }
                else if(k == 3)
                {
                    //Debug.Log("Hp 75% 회복");
                    Box_label.text = "Hp 75%";
                    EffectManager.instance.Box_Open_2();
                    Item_Value = 3;
                }
                else
                {
                    //Debug.Log("Hp 100% 회복");
                    Box_label.text = "Hp 100%";
                    EffectManager.instance.Box_Open_3();
                    Item_Value = 4;
                }
            }
            else if(j >= 60)
            {
                //Debug.Log("자석 획득");
                Box_sprite.spriteName = "자석";
                Shadow_sprite.spriteName = "자석";

                Box_label.text = Box_Present[1];
                EffectManager.instance.Box_Open_2();
                Item_Value = 5;
            }
            else if (j >= 45)
            {
                //Debug.Log("미니포션 획득");
                Box_sprite.spriteName = "미니 포션";
                Shadow_sprite.spriteName = "미니 포션";

                Box_label.text = Box_Present[2];
                EffectManager.instance.Box_Open_2();
                Item_Value = 6;
            }
            else if (j >= 30)
            {
                //Debug.Log("기압계 획득");
                Box_sprite.spriteName = "기압계";
                Shadow_sprite.spriteName = "기압계";

                Box_label.text = Box_Present[3];
                EffectManager.instance.Box_Open_2();
                Item_Value = 7;
            }
            else if (j >= 15)
            {
                //Debug.Log("해킹툴 획득");
                Box_sprite.spriteName = "해킹툴";
                Shadow_sprite.spriteName = "해킹툴";

                Box_label.text = Box_Present[4];
                EffectManager.instance.Box_Open_2();
                Item_Value = 8;
            }
            else if (j >= 0)
            {
                //Debug.Log("시간의 모래시계 획득");
                Box_sprite.spriteName = "시간의 모래시계";
                Shadow_sprite.spriteName = "시간의 모래시계";

                Box_label.text = Box_Present[5];
                EffectManager.instance.Box_Open_2();
                Item_Value = 9;
            }
        }
    }

    public void Box_Window_Close()
    {
        Box_Window.SetActive(false);
        Box_System.Stop();
        Next_Talk();
    }
}

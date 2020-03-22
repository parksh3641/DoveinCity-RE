using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectManager : MonoBehaviour
{
    public static SelectManager instance;

    public int Choice;
    private bool Exit_Value;
    private int DoveChoice;

    public GameObject Alarm_Renewal;

    public GameObject DoveWindow;
    public GameObject OptionWindow;
    public GameObject LanguageWindow;

    public GameObject Check_Korean;
    public GameObject Check_English;
    public GameObject Check_Chinese;
    public GameObject Check_Japanese;

    public GameObject DoveOptionWindow;
    public GameObject AchieveWindow;
    public GameObject ShopWindow;
    public GameObject IncubatorWindow;

    public GameObject CupoonWindow;
    public GameObject NicknameWindow;

    public GameObject AidWindow;
    public GameObject BookWindow;
    public GameObject RecordWindow;

    public GameObject CreditWindow;
    public GameObject HelpWindow;

    public GameObject GameEndWindow;
    public GameObject GameRatingWindow;

    public GameObject Detail_Egg_Info;
    public GameObject Detail_Score_Info;
    public GameObject Detail_Rank_Info;

    public GameObject TutorialWindow;


    public static int WindowValue;

    //돈
    public int BD_Coin;
    public int BD_Diamond;
    public int BD_Feather;
    public UILabel BD_Coin_txt;
    public UILabel BD_Dia_txt;
    public UILabel BD_Feather_txt;

    //메인_UI (닉네임, 최고 점수, 등급)
    private string Nickname = "";
    public UILabel Nickname_txt;

    public UILabel HighScore_txt;

    public UILabel Detail_Black_HighScore_txt;
    public UILabel Detail_White_HighScore_txt;
    public UILabel Detail_Eagle_HighScore_txt;
    public UILabel Detail_Dora_HighScore_txt;
    public UILabel Detail_HighScore_txt;

    public UILabel Detail_Black_Rank_txt;
    public UILabel Detail_White_Rank_txt;
    public UILabel Detail_Eagle_Rank_txt;
    public UILabel Detail_Dora_Rank_txt;

    private int[] Detail_Number = new int[4];
    private int[] Detail_Rank_Number = { 1, 1, 1, 1 };


    private int AllScore;
    public int HighScore;
    private int Black_HighScore;
    private int White_HighScore;
    private int Eagle_HighScore;
    private int Dora_HighScore;

    public GameObject Shadow_D;
    public GameObject Shadow_C;
    public GameObject Shadow_B;
    public GameObject Shadow_A;
    public GameObject Shadow_S;

    private int Rank;
    public UILabel Rank_txt;

    private string[] Rank_Number = { "Rank D", "Rank C", "Rank B", "Rank A", "Rank S" };

    //설정
    public UISprite Music_sprite;
    public UISprite SFX_sprite;
    public UISprite Vibration_sprite;
    public UISprite GooglePlay_sprite;

    public UILabel Music_txt;
    public UILabel SFX_txt;
    public UILabel Vibration_txt;
    public UILabel GooglePlay_txt;

    private int Music_OnOff;
    public int SFX_OnOff;
    private int Vibration_OnOff;
    private bool Vibration;

    //화살표
    public GameObject Egg_Arrow;
    public GameObject Coin_Arrow;
    public UIScrollBar Bar;

    //게임시작
    public GameObject GameStartWindow;

    public UILabel Hard_txt;
    private int BD_Hard_Ticket;

    private int Level;


    //배경화면
    public UISprite Main_Background;
    public float speed;

    private AudioSource source;
    public AudioClip shop;
    public AudioClip credit;

    void Awake()
    {
        source = gameObject.GetComponent<AudioSource>();

        DoveChoice = PlayerPrefs.GetInt("DoveChoice");
        Background_Change();

        Level = 0;

        instance = this;

        Black_HighScore = PlayerPrefs.GetInt("Black_HighScore");
        White_HighScore = PlayerPrefs.GetInt("White_HighScore");
        Eagle_HighScore = PlayerPrefs.GetInt("Eagle_HighScore");
        Dora_HighScore = PlayerPrefs.GetInt("Dora_HighScore");

        Detail_Black_HighScore_txt.text = Black_HighScore.ToString();
        Detail_White_HighScore_txt.text = White_HighScore.ToString();
        Detail_Eagle_HighScore_txt.text = Eagle_HighScore.ToString();
        Detail_Dora_HighScore_txt.text = Dora_HighScore.ToString();

        Detail_Number[0] = Black_HighScore;
        Detail_Number[1] = White_HighScore;
        Detail_Number[2] = Eagle_HighScore;
        Detail_Number[3] = Dora_HighScore;

        Equals_Score();

        Alarm_Renewal.SetActive(false);

        DoveWindow.SetActive(false);
        OptionWindow.SetActive(false);
        LanguageWindow.SetActive(false);
        DoveOptionWindow.SetActive(false);
        AchieveWindow.SetActive(false);
        ShopWindow.SetActive(false);
        IncubatorWindow.SetActive(false);
        GameStartWindow.SetActive(false);
        CupoonWindow.SetActive(false);
        AidWindow.SetActive(false);
        NicknameWindow.SetActive(false);
        BookWindow.SetActive(false);
        CreditWindow.SetActive(false);
        HelpWindow.SetActive(false);
        RecordWindow.SetActive(false);

        GameEndWindow.SetActive(false);
        GameRatingWindow.SetActive(false);

        Detail_Score_Info.SetActive(false);
        Detail_Rank_Info.SetActive(false);
        Detail_Egg_Info.SetActive(false);

        TutorialWindow.SetActive(false);

        Egg_Arrow.SetActive(false);
        Coin_Arrow.SetActive(false);

    }

    void Start()
    {
        GooglePlayManager.instance.Value = 1;

        Music_OnOff = SystemManager.instance.Music_OnOff;
        SFX_OnOff = SystemManager.instance.SFX_OnOff;
        Vibration_OnOff = SystemManager.instance.Vibration_OnOff;
        DefaultOption();

        AllScore = PlayerPrefs.GetInt("AllScore");
        int a = PlayerPrefs.GetInt("AllScore_Save");
        if (AllScore >= 10000 && a == 0)
        {
            WindowValue = 18;
            GameRatingWindow.SetActive(true);
            PlayerPrefs.SetInt("AllScore_Save", 1);
        }

        int b = PlayerPrefs.GetInt("Tutorial");
        if (b == 1)
        {
            WindowValue = 20;
            TutorialWindow.SetActive(true);
            NicknameManager.instance.Renewal();
        }

        Alarm_Renewal.SetActive(true);

        HighScore = PlayerPrefs.GetInt("HighScore");
        GooglePlayManager.instance.Leaderboard_Renewal();

        AdmobScreenAd.instance.Count_Up();

        StartCoroutine(Renewal_Money());
    }

    public void Background_Change()
    {
        int a = Random.Range(0, 2);
        switch (a)
        {
            case 0:
                Main_Background.spriteName = "Cloud";
                break;
            case 1:
                Main_Background.spriteName = "Night";
                break;
        }
    }

    public void Background_Change2()
    {
        DoveChoice = PlayerPrefs.GetInt("DoveChoice");
        switch (DoveChoice)
        {
            case 1:
                Main_Background.GetComponent<UISprite>().color = new Color(1, 1, 1);
                break;
            case 2:
                Main_Background.GetComponent<UISprite>().color = new Color(1, 200 / 255f, 1);
                break;
            case 3:
                Main_Background.GetComponent<UISprite>().color = new Color(0, 200 / 255f, 1);
                break;
            case 4:
                Main_Background.GetComponent<UISprite>().color = new Color(1, 1, 0);
                break;
        }
    }

    void Equals_Score()
    {
        for(int i = 0;i<Detail_Number.Length;i++)
        {
            for(int j =0;j<Detail_Number.Length;j++)
            {
                if(Detail_Number[i]<Detail_Number[j])
                {
                    Detail_Rank_Number[i]++;
                }
            }
        }

        if(Detail_Number[0] > 0)
        {
            Detail_Black_Rank_txt.text = Detail_Rank_Number[0].ToString();
        }
        else
        {
            Detail_Black_Rank_txt.text = "-";
            Detail_Rank_Number[0] = 0;
        }

        if (Detail_Number[1] > 0)
        {
            Detail_White_Rank_txt.text = Detail_Rank_Number[1].ToString();
        }
        else
        {
            Detail_White_Rank_txt.text = "-";
            Detail_Rank_Number[1] = 0;
        }

        if (Detail_Number[2] > 0)
        {
            Detail_Eagle_Rank_txt.text = Detail_Rank_Number[2].ToString();
        }
        else
        {
            Detail_Eagle_Rank_txt.text = "-";
            Detail_Rank_Number[2] = 0;
        }

        if (Detail_Number[3] > 0)
        {
            Detail_Dora_Rank_txt.text = Detail_Rank_Number[3].ToString();
        }
        else
        {
            Detail_Dora_Rank_txt.text = "-";
            Detail_Rank_Number[3] = 0;
        }

        Txt_Color(Detail_Black_Rank_txt, Detail_Rank_Number[0]);
        Txt_Color(Detail_White_Rank_txt, Detail_Rank_Number[1]);
        Txt_Color(Detail_Eagle_Rank_txt, Detail_Rank_Number[2]);
        Txt_Color(Detail_Dora_Rank_txt, Detail_Rank_Number[3]);
    }

    void Txt_Color(UILabel label,int number)
    {
        switch(number)
        {
            case 1:
                label.color = new Color(1, 0, 0);
                break;
            case 2:
                label.color = new Color(1, 150 / 255f, 0);
                break;
            case 3:
                label.color = new Color(1, 1, 0);
                break;
            default:
                label.color = new Color(1, 1, 1);
                break;

        }
    }

    IEnumerator Renewal_Money()
    {
        BD_Coin = PlayerPrefs.GetInt("BD_Coin", 0);
        BD_Diamond = PlayerPrefs.GetInt("BD_Diamond", 0);
        BD_Feather = PlayerPrefs.GetInt("BD_Dora_Feather", 0);
        if(BD_Coin > 9999999)
        {
            BD_Coin = 9999999;
            PlayerPrefs.SetInt("BD_Coin", BD_Coin);
        }

        if (BD_Diamond > 9999)
        {
            BD_Diamond = 9999;
            PlayerPrefs.SetInt("BD_Diamond", BD_Diamond);
        }

        if (BD_Feather > 999)
        {
            BD_Feather = 999;
            PlayerPrefs.SetInt("BD_Dora_Feather", BD_Feather);
        }
        BD_Coin_txt.text = BD_Coin.ToString();
        BD_Dia_txt.text = BD_Diamond.ToString();
        BD_Feather_txt.text = BD_Feather.ToString();
        BD_Hard_Ticket = PlayerPrefs.GetInt("BD_Hard_Ticket");

        Hard_txt.text = "X " + BD_Hard_Ticket.ToString();

        Nickname = PlayerPrefs.GetString("Nickname");
        Nickname_txt.text = Nickname;

        HighScore = PlayerPrefs.GetInt("HighScore");
        HighScore_txt.text = HighScore.ToString();
        Detail_HighScore_txt.text = HighScore.ToString();

        Rank = PlayerPrefs.GetInt("Rank");
        Rank_txt.text = Rank_Number[Rank];
        switch(Rank)
        {
            case 0:
                Rank_txt.color = new Color(1, 0.5f, 0);
                break;
            case 1:
                Rank_txt.color = new Color(1, 1, 0);
                break;
            case 2:
                Rank_txt.color = new Color(0, 1, 0);
                break;
            case 3:
                Rank_txt.color = new Color(1, 0, 0);
                break;
            case 4:
                Rank_txt.color = new Color(1, 0, 1);
                break;

        }

        yield return new WaitForSeconds(0.2f);
        StartCoroutine(Renewal_Money());
    }

    public void Tutorial_Go()
    {
        if(WindowValue == 7)
        {
            Exit();
            SystemManager.instance.TwoGo();
            AdmobBannerAd.instance.Banner_Ads_Hide();
        }
    } //튜토리얼 가기


    public void Muitlplay()
    {
        Exit();
        SystemManager.instance.FiveGo();
    }

    public void GameStart() //난이도 선택 창 열기 0번
    {
        if (WindowValue == 0)
        {
            WindowValue = 7;
            GameStartWindow.SetActive(true);
        }
    }

    public void GameStart_Easy()
    {
        Level = 0;
        PlayerPrefs.SetInt("Level", 0);
        Exit();
        AidWindowOpen();
    }

    public void GameStart_Noraml()
    {
        Level = 1;
        PlayerPrefs.SetInt("Level", 1);
        Exit();
        AidWindowOpen();
    }

    public void GameStart_Hard()
    {
        if (BD_Hard_Ticket > 0)
        {
            Level = 2;
            PlayerPrefs.SetInt("Level", 2);
            Exit();
            AidWindowOpen();
        }
        else
        {
            LanguageManager.instance.Low_Ticket_Notion();
        }
    }

    public void GameStart_Aid() //조력자 선택 창에서 게임 시작
    {
        if (Level == 2)
        {
            BD_Hard_Ticket -= 1;
            PlayerPrefs.SetInt("BD_Hard_Ticket", BD_Hard_Ticket);
        }
        Exit();
        Exit();
        SystemManager.instance.SixGo();
    }

    public void DoveWindowOpen() //비둘기 창 열기 1번
    {
        if (WindowValue == 0)
        {
            WindowValue = 1;
            DoveOptionWindow.SetActive(false);
            DoveWindow.SetActive(true);
            NestManager.instance.Language_Setting();
        }
    }

    public void OptionWindowOpen() //옵션 창 열기 2번
    {
        if (WindowValue == 0)
        {
            WindowValue = 2;
            OptionWindow.SetActive(true);
        }
    }

    public void LanguageOpen()
    {
        if (WindowValue == 2)
        {
            WindowValue = 3;
            LanguageWindow.SetActive(true);

            int a = PlayerPrefs.GetInt("Language");
            if (a == 0)
            {
                Check_Korean.SetActive(true);
                Check_English.SetActive(false);
                Check_Chinese.SetActive(false);
                Check_Japanese.SetActive(false);
            }
            else if (a == 1)
            {
                Check_Korean.SetActive(false);
                Check_English.SetActive(true);
                Check_Chinese.SetActive(false);
                Check_Japanese.SetActive(false);
            }
            else if (a == 2)
            {
                Check_Korean.SetActive(false);
                Check_English.SetActive(false);
                Check_Chinese.SetActive(true);
                Check_Japanese.SetActive(false);
            }
            else if (a == 3)
            {
                Check_Korean.SetActive(false);
                Check_English.SetActive(false);
                Check_Chinese.SetActive(false);
                Check_Japanese.SetActive(true);
            }
        }
    } //언어 설정 창 열기 3번

    //4번 비둘기 상세 창

    public void AchieveWindowOpen() //업적 창 열기 5번
    {
        if (WindowValue == 0)
        {
            WindowValue = 5;
            AchieveWindow.SetActive(true);
        }
    }

    public void ShopWindowOpen() //상점 창 열기 6번
    {
        if (WindowValue == 0)
        {
            WindowValue = 6;
            ShopWindow.SetActive(true);
        }
    }

    public void CupoonOpen() //쿠폰 창 열기 8번
    {
        if (WindowValue == 2)
        {
            WindowValue = 8;
            CupoonWindow.SetActive(true);
            CupoonManager.instance.Renewal();
        }
    }


    public void AidWindowOpen() //조력자 창 열기 9번
    {
        if (WindowValue == 0)
        {
            WindowValue = 9;
            AidWindow.SetActive(true);
        }
    }

    public void Detail_Score() //점수 상세 창 열기 10번
    {
        if (WindowValue == 0)
        {
            WindowValue = 10;
            Detail_Score_Info.SetActive(true);
            GooglePlayManager.instance.ShowLeaderboardUI();
        }
    }

    public void Detail_Egg() //알 확률 창 열기 11번
    {
        if (WindowValue == 6)
        {
            WindowValue = 11;
            Detail_Egg_Info.SetActive(true);
        }
    }

    public void NicknameWindowOpen() //이름 변경 창 열기 12번
    {
        if (WindowValue == 2)
        {
            WindowValue = 12;
            NicknameWindow.SetActive(true);
            NicknameManager.instance.Renewal();
        }
    }

    public void Detail_Rank() //랭크 점수 상세 창 열기 13번
    {
        if (WindowValue == 0)
        {
            WindowValue = 13;
            Detail_Rank_Info.SetActive(true);

            Shadow_D.SetActive(false);
            Shadow_C.SetActive(false);
            Shadow_B.SetActive(false);
            Shadow_A.SetActive(false);
            Shadow_S.SetActive(false);

            switch (Rank)
            {
                case 0:
                    Shadow_D.SetActive(true);
                    break;
                case 1:
                    Shadow_C.SetActive(true);
                    break;
                case 2:
                    Shadow_B.SetActive(true);
                    break;
                case 3:
                    Shadow_A.SetActive(true);
                    break;
                case 4:
                    Shadow_S.SetActive(true);
                    break;

            }
        }
    }

    public void BookWindowOpen() //도감 창 열기 14번
    {
        if (WindowValue == 0)
        {
            WindowValue = 14;
            BookWindow.SetActive(true);
        }
    }

    public void CreditWindowOpen() //크레딧 창 열기 15번
    {
        if (WindowValue == 2)
        {
            WindowValue = 15;
            CreditWindow.SetActive(true);
            source.clip = credit;
            source.Play();
        }
    }

    public void HelpWindowOpen() //도움말 창 열기 16번
    {
        if (WindowValue == 2)
        {
            WindowValue = 16;
            HelpWindow.SetActive(true);
        }
    }

    //게임 종료창 17번 / 평가 창 18번

    public void RecordWindowOpen() //기록 창 열기 19번
    {
        if (WindowValue == 0)
        {
            WindowValue = 19;
            RecordWindow.SetActive(true);
        }
    }

    public void GameEnd_Yes()
    {
        Exit();
        Application.Quit();
    }

    public void Blog_URL()
    {
        Application.OpenURL("http://m.blog.naver.com/burningdiamond");
    }

    public void Google_URL()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.unity3d.doveincity");
        GameRatingWindow.SetActive(false);
    }
    public void Google_URL_Reward()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.unity3d.doveincity");
        Exit();
        LanguageManager.instance.Success_Reward_Notion();
        BD_Diamond += 200;
        PlayerPrefs.SetInt("BD_Diamond", BD_Diamond);
    }

    public void ShopGo() // 둥지에서 상점 넘어가기
    {
        DoveOptionWindow.SetActive(false);
        DoveWindow.SetActive(false);

        WindowValue = 6;
        ShopWindow.SetActive(true);
        Egg_Arrow.SetActive(true);
    }

    public void ShopGo2() //코인 다이아 클릭시 상점 넘어가기
    {
        WindowValue = 6;
        ShopWindow.SetActive(true);
        Coin_Arrow.SetActive(true);
        Bar.value = 1;
    }

    public void DefaultOption()
    {
        if (Music_OnOff == 0)
        {
            Music_OnOff = 0;
            Music_sprite.color = new Color(1f, 0f, 0f, 1f);
            Music_txt.text = LanguageManager.instance.Off;
            source.enabled = false;
        }
        else
        {
            Music_OnOff = 1;
            Music_sprite.color = new Color(0f, 1f, 0f, 1f);
            Music_txt.text = LanguageManager.instance.On;
            source.enabled = true;
        }

        if (SFX_OnOff == 0)
        {
            SFX_OnOff = 0;
            SFX_sprite.color = new Color(1f, 0f, 0f, 1f);
            SFX_txt.text = LanguageManager.instance.Off;

        }
        else
        {
            SFX_OnOff = 1;
            SFX_sprite.color = new Color(0f, 1f, 0f, 1f);
            SFX_txt.text = LanguageManager.instance.On;
        }

        if (Vibration_OnOff == 0)
        {
            Vibration_OnOff = 0;
            Vibration_sprite.color = new Color(1f, 0f, 0f, 1f);
            Vibration_txt.text = LanguageManager.instance.Off;
            Vibration = false;
        }
        else
        {
            Vibration_OnOff = 1;
            Vibration_sprite.color = new Color(0f, 1f, 0f, 1f);
            Vibration_txt.text = LanguageManager.instance.On;
            Vibration = true;
        }

        if(GooglePlayManager.instance.Login == true)
        {
            GooglePlay_sprite.color = new Color(0f, 1f, 0f, 1f);
            GooglePlay_txt.text = LanguageManager.instance.On;
        }
        else
        {
            GooglePlay_sprite.color = new Color(1f, 0f, 0f, 1f);
            GooglePlay_txt.text = LanguageManager.instance.Off;
        }

    }

    public void MusicOnOff() //음악
    {
        if (Music_OnOff == 0)
        {
            Music_OnOff = 1;
            Music_sprite.color = new Color(0f, 1f, 0f, 1f);
            Music_txt.text = LanguageManager.instance.On;
            source.enabled = true;
        }
        else
        {
            Music_OnOff = 0;
            Music_sprite.color = new Color(1f, 0f, 0f, 1f);
            Music_txt.text = LanguageManager.instance.Off;
            source.enabled = false;
        }
        PlayerPrefs.SetInt("Music_Onoff", Music_OnOff);
    }
    public void SFXOnOff() //효과음
    {
        if (SFX_OnOff == 0)
        {
            SFX_OnOff = 1;
            SFX_sprite.color = new Color(0f, 1f, 0f, 1f);
            SFX_txt.text = LanguageManager.instance.On;
            EffectManager.instance.SFX_On();

        }
        else
        {
            SFX_OnOff = 0;
            SFX_sprite.color = new Color(1f, 0f, 0f, 1f);
            SFX_txt.text = LanguageManager.instance.Off;
            EffectManager.instance.SFX_Off();
        }
        PlayerPrefs.SetInt("SFX_Onoff", SFX_OnOff);
    }
    public void VibrationOnOff() //진동
    {
        if (Vibration_OnOff == 0)
        {
            Vibration_OnOff = 1;
            Vibration_sprite.color = new Color(0f, 1f, 0f, 1f);
            Vibration_txt.text = LanguageManager.instance.On;
            Vibration = true;
        }
        else
        {
            Vibration_OnOff = 0;
            Vibration_sprite.color = new Color(1f, 0f, 0f, 1f);
            Vibration_txt.text = LanguageManager.instance.Off;
            Vibration = false;
        }
        PlayerPrefs.SetInt("Vibration_Onoff", Vibration_OnOff);
    }

    public void GooglePlayOnOff() //구글플레이 온오프
    {
        if (GooglePlayManager.instance.Login == true)
        {
            GooglePlayManager.instance.OnLogOut();
        }
        else
        {
            GooglePlayManager.instance.OnLogin();
        }
    }


    //비둘기 창
    public void DoveOne() //구구 선택
    {
        WindowValue = 4;
        Choice = 1;
        DoveOptionWindow.SetActive(true);
        NestManager.instance.Open();
    }
    public void DoveTwo() //루루 선택
    {
        WindowValue = 4;
        Choice = 2;
        DoveOptionWindow.SetActive(true);
        NestManager.instance.Open();
    }
    public void DoveThree()
    {
        WindowValue = 4;
        Choice = 3;
        DoveOptionWindow.SetActive(true);
        NestManager.instance.Open();
    }
    public void DoveFour()
    {
        WindowValue = 4;
        Choice = 4;
        DoveOptionWindow.SetActive(true);
        NestManager.instance.Open();
    }

    //종료

    public void Arrow_Stop()
    {
        Egg_Arrow.SetActive(false);
        Coin_Arrow.SetActive(false);
    }

    public void Exit()
    {
        if (WindowValue == 0)
        {
            WindowValue = 17;
            GameEndWindow.SetActive(true);
        }
        else if (WindowValue == 1)
        {
            WindowValue = 0;
            DoveWindow.SetActive(false);
        }
        else if (WindowValue == 2)
        {
            WindowValue = 0;
            OptionWindow.SetActive(false);
        }
        else if (WindowValue == 3) //언어
        {
            WindowValue = 2;
            LanguageWindow.SetActive(false);
        }
        else if (WindowValue == 4)
        {
            WindowValue = 1;
            DoveOptionWindow.SetActive(false);

            NestManager.instance.Nest_Box_Up.SetActive(true);
            NestManager.instance.Nest_Box_Down.SetActive(true);
        }
        else if (WindowValue == 5)
        {
            WindowValue = 0;
            AchieveWindow.SetActive(false);
        }
        else if (WindowValue == 6)
        {
            WindowValue = 0;
            ShopWindow.SetActive(false);
            ShopManager.instance.Shop_Effect_Stop();
            IncubatorWindow.SetActive(false);
            Egg_Arrow.SetActive(false);
            Coin_Arrow.SetActive(false);
        }
        else if (WindowValue == 7)
        {
            WindowValue = 0;
            GameStartWindow.SetActive(false);
        }
        else if (WindowValue == 8) //쿠폰
        {
            WindowValue = 2;
            CupoonWindow.SetActive(false);
            CupoonManager.instance.Effect_Stop();
        }
        else if (WindowValue == 9)
        {
            WindowValue = 7;
            AidWindow.SetActive(false);
            GameStartWindow.SetActive(true);
        }
        else if (WindowValue == 10)
        {
            WindowValue = 0;
            Detail_Score_Info.SetActive(false);
        }
        else if (WindowValue == 11)
        {
            WindowValue = 6;
            Detail_Egg_Info.SetActive(false);
        }
        else if (WindowValue == 12)
        {
            WindowValue = 2;
            NicknameWindow.SetActive(false);
        }
        else if (WindowValue == 13)
        {
            WindowValue = 0;
            Detail_Rank_Info.SetActive(false);
        }
        else if (WindowValue == 14)
        {
            WindowValue = 0;
            BookWindow.SetActive(false);
        }
        else if (WindowValue == 15)
        {
            WindowValue = 2;
            CreditWindow.SetActive(false);
            source.clip = shop;
            source.Play();
        }
        else if (WindowValue == 16)
        {
            WindowValue = 2;
            HelpWindow.SetActive(false);
        }
        else if (WindowValue == 17)
        {
            WindowValue = 0;
            GameEndWindow.SetActive(false);
        }
        else if (WindowValue == 18)
        {
            WindowValue = 0;
            GameRatingWindow.SetActive(false);
        }
        else if (WindowValue == 19)
        {
            WindowValue = 0;
            RecordWindow.SetActive(false);
        }
        else if (WindowValue == 20)
        {
            WindowValue = 0;
            TutorialWindow.SetActive(false);
        }
    }

    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if(WindowValue !=20)
                {
                    EffectManager.instance.onClick();
                    Exit();
                }
            }
        }
    }
}

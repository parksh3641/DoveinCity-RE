using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Record : MonoBehaviour
{
    public int Value = 0; //1번째부터 기록, 최근 기록이 생기면 2번째로 내려감.

    private UISprite Main_Background;

    public UILabel Main_Number_txt;
    public UILabel Main_Name_txt;
    public UISprite Main_sp;

    public UILabel Level_txt;
    public UILabel Stage_txt;
    public UILabel Score_txt;
    public UILabel AliveTime_txt;
    public UILabel Dead_txt;

    public UILabel Level_Detail_txt;
    public UILabel Stage_Detail_txt;
    public UILabel Score_Detail_txt;
    public UILabel AliveTime_Detail_txt;
    public UILabel Dead_Detail_txt;

    private int Dove; //비둘기 종류(중심) 이게 0이면 모든게 없는걸로 간주.
    private int Level; //0 쉬움, 1 보통, 2 어려움
    private int Stage;
    private int Score;
    private int AliveTime;
    private int Dead;

    private int Language; //0부터

    private string[] Main_sp_Number = { "black_4", "White_4", "Eagle_4", "Dora_4" };

    private List<string> Record_Main = new List<string>();
    private List<string> Record_Name = new List<string>();
    private List<string> Record_Level = new List<string>();
    private List<string> Record_Dead = new List<string>();


    private string[] Black = { "black_1", "black_2", "black_3", "black_4", "black_5", "black_6" };
    private string[] White = { "White_1", "White_2", "White_3", "White_4", "White_5", "White_6" };
    private string[] Eagle = { "Eagle_1", "Eagle_2", "Eagle_3", "Eagle_4", "Eagle_5", "Eagle_6" };
    private string[] Dora = { "Dora_1", "Dora_2", "Dora_3", "Dora_4", "Dora_5", "Dora_6" };

    private int a, b = 0;

    private float Cooltime;

    void Awake()
    {
        Main_Background = GetComponent<UISprite>();
    }
    void Start()
    {
        Cooltime = SystemManager.instance.SelectDoveCooltime;
    }

    void Reset_Record()
    {
        for(int i = 0;i<5;i++)
        {
            PlayerPrefs.SetInt("Dove_" + i.ToString(), 0);
            PlayerPrefs.SetInt("Level_" + i.ToString(), 0);
            PlayerPrefs.SetInt("Stage_" + i.ToString(), 0);
            PlayerPrefs.SetInt("Score_" + i.ToString(), 0);
            PlayerPrefs.SetInt("AliveTime_" + i.ToString(), 0);
            PlayerPrefs.SetInt("Dead_" + i.ToString(), 0);
        }
    }

    public void Language_Setting()
    {
        if (Record_Main.Count > 0)
        {
            Record_Main.Clear();
            Record_Name.Clear();
            Record_Level.Clear();
            Record_Dead.Clear();

        }
        int a = PlayerPrefs.GetInt("Language");
        switch (a)
        {
            case 1:
                for (int i = 0; i < LanguageManager.instance.Record_Main_Korean.Length; i++)
                {
                    string b = LanguageManager.instance.Record_Main_Korean[i];
                    Record_Main.Add(b);
                }
                for (int i = 0; i < LanguageManager.instance.Record_Name_Korean.Length; i++)
                {
                    string b = LanguageManager.instance.Record_Name_Korean[i];
                    Record_Name.Add(b);
                }
                for (int i = 0; i < LanguageManager.instance.Record_Level_Korean.Length; i++)
                {
                    string b = LanguageManager.instance.Record_Level_Korean[i];
                    Record_Level.Add(b);
                }
                for (int i = 0; i < LanguageManager.instance.Book_Dead_Korean.Length; i++)
                {
                    string b = LanguageManager.instance.Book_Dead_Korean[i];
                    Record_Dead.Add(b);
                }
                break;
            case 2:
                for (int i = 0; i < LanguageManager.instance.Record_Main_English.Length; i++)
                {
                    string b = LanguageManager.instance.Record_Main_English[i];
                    Record_Main.Add(b);
                }
                for (int i = 0; i < LanguageManager.instance.Record_Name_English.Length; i++)
                {
                    string b = LanguageManager.instance.Record_Name_English[i];
                    Record_Name.Add(b);
                }
                for (int i = 0; i < LanguageManager.instance.Record_Level_English.Length; i++)
                {
                    string b = LanguageManager.instance.Record_Level_English[i];
                    Record_Level.Add(b);
                }
                for (int i = 0; i < LanguageManager.instance.Book_Dead_English.Length; i++)
                {
                    string b = LanguageManager.instance.Book_Dead_English[i];
                    Record_Dead.Add(b);
                }
                break;
            case 3:
                for (int i = 0; i < LanguageManager.instance.Record_Main_Chinese.Length; i++)
                {
                    string b = LanguageManager.instance.Record_Main_Chinese[i];
                    Record_Main.Add(b);
                }
                for (int i = 0; i < LanguageManager.instance.Record_Name_Chinese.Length; i++)
                {
                    string b = LanguageManager.instance.Record_Name_Chinese[i];
                    Record_Name.Add(b);
                }
                for (int i = 0; i < LanguageManager.instance.Record_Level_Chinese.Length; i++)
                {
                    string b = LanguageManager.instance.Record_Level_Chinese[i];
                    Record_Level.Add(b);
                }
                for (int i = 0; i < LanguageManager.instance.Book_Dead_Chinese.Length; i++)
                {
                    string b = LanguageManager.instance.Book_Dead_Chinese[i];
                    Record_Dead.Add(b);
                }
                break;
            case 4:
                for (int i = 0; i < LanguageManager.instance.Record_Main_Japanese.Length; i++)
                {
                    string b = LanguageManager.instance.Record_Main_Japanese[i];
                    Record_Main.Add(b);
                }
                for (int i = 0; i < LanguageManager.instance.Record_Name_Japanese.Length; i++)
                {
                    string b = LanguageManager.instance.Record_Name_Japanese[i];
                    Record_Name.Add(b);
                }
                for (int i = 0; i < LanguageManager.instance.Record_Level_Japanese.Length; i++)
                {
                    string b = LanguageManager.instance.Record_Level_Japanese[i];
                    Record_Level.Add(b);
                }
                for (int i = 0; i < LanguageManager.instance.Book_Dead_Japanese.Length; i++)
                {
                    string b = LanguageManager.instance.Book_Dead_Japanese[i];
                    Record_Dead.Add(b);
                }
                break;
        }

        Language_Change();

    }

    void Language_Change()
    {
        Level_txt.text = Record_Main[0];
        Stage_txt.text = Record_Main[1];
        Score_txt.text = Record_Main[2];
        AliveTime_txt.text = Record_Main[3];
        Dead_txt.text = Record_Main[4];

        if (Dove != 0)
        {
            Main_Name_txt.text = Record_Name[Dove - 1];

            Main_sp.spriteName = Main_sp_Number[Dove - 1];
            Level_Detail_txt.text = Record_Level[Level];
            Stage_Detail_txt.text = Stage.ToString();
            Score_Detail_txt.text = Score.ToString();
            TimeExChange();
            Dead_Detail_txt.text = Record_Dead[Dead];
        }
        else
        {
            Main_sp.enabled = false;
            Main_Name_txt.text = " ";
            Level_Detail_txt.text = "-";
            Stage_Detail_txt.text = "-";
            Score_Detail_txt.text = "-";
            AliveTime_Detail_txt.text = "-";
            Dead_Detail_txt.text = "-";
        }
    }

    void OnEnable() //생존시간 변환시켜야됨.
    {
        Main_Number_txt.text = Value.ToString();

        Dove = PlayerPrefs.GetInt("Dove_" + Value.ToString());

        Level = PlayerPrefs.GetInt("Level_" + Value.ToString());
        Stage = PlayerPrefs.GetInt("Stage_" + Value.ToString());
        Score = PlayerPrefs.GetInt("Score_" + Value.ToString());
        AliveTime = PlayerPrefs.GetInt("AliveTime_" + Value.ToString());
        Dead = PlayerPrefs.GetInt("Dead_" + Value.ToString());

        switch (Dove)
        {
            case 1:
                Main_Background.color = new Color(1, 1, 1);
                StartCoroutine(Flying(Main_sp, Black));
                break;
            case 2:
                Main_Background.color = new Color(1, 200 / 255f, 1);
                StartCoroutine(Flying(Main_sp, White));
                break;
            case 3:
                Main_Background.color = new Color(0, 200 / 255f, 1);
                StartCoroutine(Flying(Main_sp, Eagle));
                break;
            case 4:
                Main_Background.color = new Color(1, 1, 0);
                StartCoroutine(Flying(Main_sp, Dora));
                break;
            default:
                break;
        }

        switch (Level)
        {
            case 0:
                Level_Detail_txt.color = new Color(0, 1, 0);
                break;
            case 1:
                Level_Detail_txt.color = new Color(0, 1, 1);
                break;
            case 2:
                Level_Detail_txt.color = new Color(1, 0, 0);
                break;
            default:
                break;
        }

        Language_Setting();
    }

    void OnDisable()
    {

    }

    void TimeExChange()
    {
        a = AliveTime;
        b = 0;

        while (a >= 60)
        {
            a -= 60;
            b += 1;
        }

        AliveTime_Detail_txt.text = b.ToString() + ":" + a.ToString();
    }

    IEnumerator Flying(UISprite sprite, string[] a)
    {
        sprite.spriteName = a[0];
        yield return new WaitForSeconds(Cooltime);
        sprite.spriteName = a[1];
        yield return new WaitForSeconds(Cooltime);
        sprite.spriteName = a[2];
        yield return new WaitForSeconds(Cooltime);
        sprite.spriteName = a[3];
        yield return new WaitForSeconds(Cooltime);
        sprite.spriteName = a[4];
        yield return new WaitForSeconds(Cooltime);
        sprite.spriteName = a[5];
        yield return new WaitForSeconds(Cooltime);
        sprite.spriteName = a[4];
        yield return new WaitForSeconds(Cooltime);
        sprite.spriteName = a[3];
        yield return new WaitForSeconds(Cooltime);
        sprite.spriteName = a[2];
        yield return new WaitForSeconds(Cooltime);
        sprite.spriteName = a[1];
        yield return new WaitForSeconds(Cooltime);
        StartCoroutine(Flying(sprite, a));
    }
}

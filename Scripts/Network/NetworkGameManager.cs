using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkGameManager : MonoBehaviour
{
    public static NetworkGameManager instance;

    public Transform Player;

    private int Window_Value;
    public GameObject NestWindow;

    public GameObject White_Rocked;
    public GameObject Eagle_Rocked;
    public GameObject Dora_Rocked;

    private int Network_Choice;

    public UISprite Black_sprite;
    public UISprite White_sprite;
    public UISprite Eagle_sprite;
    public UISprite Dora_sprite;

    private string[] Black = { "black_1", "black_2", "black_3", "black_4", "black_5", "black_6" };
    private string[] White = { "White_1", "White_2", "White_3", "White_4", "White_5", "White_6" };
    private string[] Eagle = { "Eagle_1", "Eagle_2", "Eagle_3", "Eagle_4", "Eagle_5", "Eagle_6" };
    private string[] Dora = { "Dora_1", "Dora_2", "Dora_3", "Dora_4", "Dora_5", "Dora_6" };

    public GameObject Black_arrow;
    public GameObject White_arrow;
    public GameObject Eagle_arrow;
    public GameObject Dora_arrow;

    private float Cooltime;

    //알 발사
    private bool Attack = true;


    //보스
    public GameObject Boss_Hp;
    public UISprite Boss_Hp_Filter;
    public UILabel Boss_Hp_txt;

    public UILabel Boss_Level_txt;
    public UILabel Boss_Count_txt;

    private int Boss_Level = 0; //쉬움 보통 어려움 크레이지1 2 3 4 - 전멸할 경우 난이도 내려감
    private int Boss_Kind = 0; //보스 종류
    private int Boss_Hp_Value = 0;

    private int Boss_Count_m = 0;
    private int Boss_Count_s = 0;


    //알림
    public GameObject Boss; //보스
    public GameObject Boss_Notion;
    public UILabel Boss_txt;
    private UISprite Boss_notion;
    private bool Boss_Value; //한번 켜지면 다시 안 꺼짐
    private bool Boss_Blink;
    private bool Boss_Blink_Up;
    private float Boss_Alpha;


    void Awake()
    {
        instance = this;

        Window_Value = 0;
        NestWindow.SetActive(false);

        Boss_Hp.SetActive(false);

        Boss_Notion.SetActive(false);
        Boss_notion = Boss_Notion.GetComponent<UISprite>();
    }

    void Start()
    {
        Boss_Level_txt_Setting();
        Boss_Count_m = 0;
        Boss_Count_s = 10;
        StartCoroutine(Boss_Count());

        Cooltime = SystemManager.instance.SelectDoveCooltime;

        Black_arrow.SetActive(false);
        White_arrow.SetActive(false);
        Eagle_arrow.SetActive(false);
        Dora_arrow.SetActive(false);

        Network_Choice = PlayerPrefs.GetInt("Network_Choice");
        Default_Option(Network_Choice);
    }

    void Boss_Level_txt_Setting()
    {
        switch (Boss_Level)
        {
            case 0:
                Boss_Level_txt.text = "난이도 : 쉬움";
                break;
            case 1:
                Boss_Level_txt.text = "난이도 : 보통";
                break;
            case 2:
                Boss_Level_txt.text = "난이도 : 어려움";
                break;
            case 3:
                Boss_Level_txt.text = "난이도 : 매우 어려움";
                break;
            case 4:
                Boss_Level_txt.text = "난이도 : 크레이지";
                break;
            default:
                Boss_Level_txt.text = "난이도 : 클리어";
                break;
        }
    }

    void Boss_Hp_Setting(int value)
    {
        switch(Boss_Level)
        {
            case 0:
                Boss_Hp_Value = 100 + (100 * PhotonNetwork.CurrentRoom.PlayerCount);
                break;
            case 1:
                Boss_Hp_Value = 200 + (200 * PhotonNetwork.CurrentRoom.PlayerCount);
                break;
            case 2:
                Boss_Hp_Value = 300 + (300 * PhotonNetwork.CurrentRoom.PlayerCount);
                break;
            case 3:
                Boss_Hp_Value = 400 + (400 * PhotonNetwork.CurrentRoom.PlayerCount);
                break;
            case 4:
                Boss_Hp_Value = 500 + (500 * PhotonNetwork.CurrentRoom.PlayerCount);
                break;
            default:
                break;
        }
    }

    IEnumerator Boss_Count()
    {
        yield return new WaitForSeconds(1f);
        if(Boss_Count_s > 0)
        {
            Boss_Count_s -= 1;
        }
        else
        {
            if(Boss_Count_m > 0)
            {
                Boss_Count_m -= 1;
                Boss_Count_s = 59;
            }
            else
            {
                Debug.Log("보스 출현");
                Boss_Coming();
                Boss_Hp.SetActive(true);
                yield break;
            }
        }

        string second = "";

        if (Boss_Count_s < 10)
        {
            second = "0" + Boss_Count_s.ToString();
        }
        else
        {
            second = Boss_Count_s.ToString();
        }

        Boss_Count_txt.text = "보스 출현까지 " + Boss_Count_m + ":" + second;

        StartCoroutine(Boss_Count());
    }


    public void Boss_Coming()
    {
        if (Boss_Value == false)
        {
            Boss_Value = true;
            Boss_Blink = true;
            Boss_Notion.SetActive(true);
            EffectManager.instance.Warning_On();
            StartCoroutine(Notion_Cooltime(5.4f));

            Boss_Alpha = 0;
            Boss_notion.color = new Color(1, 1, 1, 0);
            Boss_Blink_Up = true;
            StartCoroutine(Notion_Blink());

            //보스 출현
            //Boss.SetActive(true);
            Boss_Level_txt.text = "";
            Boss_Count_txt.text = "";
            Boss_Hp_Setting(Boss_Kind);
        }
    }
    IEnumerator Notion_Blink()
    {
        if (Boss_Blink == true)
        {
            if (Boss_Blink_Up == true)
            {
                if (Boss_Alpha >= 0)
                {
                    Boss_Alpha -= (255 / 50);
                }
                else
                {
                    Boss_Blink_Up = false;
                }
            }
            else
            {
                if (Boss_Alpha <= 255)
                {
                    Boss_Alpha += (255 / 50);
                }
                else
                {
                    Boss_Blink_Up = true;
                }
            }

            Boss_notion.color = new Color(1, 1, 1, Boss_Alpha / 255f);
        }
        else
        {
            yield break;
        }
        yield return new WaitForSeconds(0.01f);
        StartCoroutine(Notion_Blink());
    }
    IEnumerator Notion_Cooltime(float number)
    {
        yield return new WaitForSeconds(number);
        Boss_Blink = false;
        Boss_Notion.SetActive(false);
        EffectManager.instance.Warning_Off();
    }

    public void Attack_Btn()
    {
        if (Attack == true)
        {
            var Object = PhotonNetwork.Instantiate("DoveEgg_Attack", new Vector3(-6,6,2), Quaternion.identity);
            Object.transform.position = Player.position;

            Attack = false;
            StartCoroutine(Attack_Delay());
        }
    }

    IEnumerator Attack_Delay()
    {
        yield return new WaitForSeconds(0.25f);
        Attack = true;
    }


    //둥지
    void Default_Option(int number)
    {
        Black_arrow.SetActive(false);
        White_arrow.SetActive(false);
        Eagle_arrow.SetActive(false);
        Dora_arrow.SetActive(false);

        switch (number)
        {
            case 0:
                Black_arrow.SetActive(true);
                PlayerPrefs.SetInt("Network_Choice", 0);
                break;
            case 1:
                White_arrow.SetActive(true);
                PlayerPrefs.SetInt("Network_Choice", 1);
                break;
            case 2:
                Eagle_arrow.SetActive(true);
                PlayerPrefs.SetInt("Network_Choice", 2);
                break;
            case 3:
                Dora_arrow.SetActive(true);
                PlayerPrefs.SetInt("Network_Choice", 3);
                break;
        }
    }
    public void Renewal()
    {
        int a = PlayerPrefs.GetInt("BD_White");
        int b = PlayerPrefs.GetInt("BD_Eagle");
        int c = PlayerPrefs.GetInt("BD_Dora");

        Dove_Rocked(White_Rocked, a);
        Dove_Rocked(Eagle_Rocked, b);
        Dove_Rocked(Dora_Rocked, c);

        StartCoroutine(Flying(Black_sprite, Black));
        StartCoroutine(Flying(White_sprite, White));
        StartCoroutine(Flying(Eagle_sprite, Eagle));
        StartCoroutine(Flying(Dora_sprite, Dora));
    }

    public void Dove_Rocked(GameObject rock, int number)
    {
        if(number == 0)
        {
            rock.SetActive(true);
        }
        else
        {
            rock.SetActive(false);
        }
    }

    public void Nest_Open()
    {
        if(Window_Value == 0)
        {
            Window_Value = 1;
            NestWindow.SetActive(true);
            Renewal();
        }
    }

    public void Exit()
    {
        if(Window_Value == 1)
        {
            Window_Value = 0;
            NestWindow.SetActive(false);
        }
    }

    public void Select_Black()
    {
        Default_Option(0);
    }

    public void Select_White()
    {
        Default_Option(1);
    }

    public void Select_Eagle()
    {
        Default_Option(2);
    }

    public void Select_Dora()
    {
        Default_Option(3);
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

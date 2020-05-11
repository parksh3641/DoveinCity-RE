using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    public static ProgressManager instance;

    private int AllScore;

    public UIScrollView Scroll;

    public UISprite Fillter;
    public GameObject Progress_Which;
    public UILabel AllScore_txt;

    public GameObject Owl_Arrow;
    public GameObject Duck_Arrow;

    public ProgressItem[] progressitem; //수동으로 넣었음


    public UILabel[] Label_Bar;

    private int[] Label_Bar_Number = { 0, 2500, 5000, 7500, 10000, 12500, 15000, 17500, 20000, 22500, 25000, 27500, 30000, 35000, 40000, 45000, 50000, 55000, 60000, 65000, 70000, 75000, 80000, 85000, 90000 };

    private int a, b, c = 0;

    void Awake()
    {
        instance = this;

        Owl_Arrow.SetActive(false);
        Duck_Arrow.SetActive(false);


        Label_Bar = GameObject.Find("Label_Bar").GetComponentsInChildren<UILabel>();

        for (int i = 0;i<Label_Bar.Length;i++)
        {
            Label_Bar[i].text = Label_Bar_Number[i].ToString();
        }

    }

    void Start()
    {
        Renewal();
    }

    public void Progress_Owl_Go()
    {
        SelectManager.instance.Exit();
        SelectManager.instance.Exit();

        Owl_Arrow.SetActive(true);
        StartCoroutine(Wait(Owl_Arrow));

        Scroll.SetDragAmount(0.2622439f, 0, false);
    }

    public void Progress_Duck_Go()
    {
        SelectManager.instance.Exit();
        SelectManager.instance.Exit();

        Duck_Arrow.SetActive(true);
        StartCoroutine(Wait(Duck_Arrow));

        Scroll.SetDragAmount(0.731122f, 0, false);
    }

    IEnumerator Wait(GameObject a)
    {
        yield return new WaitForSeconds(5f);
        a.SetActive(false);
    }

    public void Reset_Progress()
    {
        for(int i = 0;i<99;i++)
        {
            PlayerPrefs.SetInt("Box_Number_" + i, 0);
        }

        PlayerPrefs.SetInt("BD_Owl", 0);
        PlayerPrefs.SetInt("BD_Duck", 0);
        PlayerPrefs.SetInt("Rank", 0);

        Score_Check();
        Renewal();
    }

    public void Renewal()
    {
        AllScore = PlayerPrefs.GetInt("AllScore");
        if(AllScore >= 90000)
        {
            AllScore = 90000;
        }
        AllScore_txt.text = AllScore.ToString();
        Score_Check();

        Progress_Which.transform.localPosition = new Vector3(-420, -680);

        a = 0;
        b = 0;
        c = 0;

        if (AllScore < 30000)
        {
            StartCoroutine(Filter_Low());
        }
        else
        {
            AllScore -= 30000;
            StartCoroutine(Filter_High());
        }
    }

    void Score_Check()
    {
        for(int i = 0;i< progressitem.Length;i++)
        {
            if(AllScore >= Label_Bar_Number[i+1])
            {
                progressitem[i].Item_Open();
            }
            else
            {
                progressitem[i].Item_Close();
            }
        }
    }

    IEnumerator Filter_Low()
    {
        if (AllScore > 2500)
        {
            a += 1;
            AllScore -= 2500;
        }
        else
        {
            if (AllScore > 500)
            {
                b += 1;
                AllScore -= 500;
            }
            else
            {
                if(AllScore > 50)
                {
                    c += 1;
                    AllScore -= 50;
                }
                else
                {
                    Fillter.fillAmount = 0.02f + (a * 0.04f) + (b * 0.008f) + (c * 0.0008f);
                    Progress_Which.transform.localPosition = new Vector3(-420 + (a * 120) + (b * 24) + (c * 2.4f), -680);
                    float d = Progress_Which.transform.localPosition.x / 2050;
                    Scroll.SetDragAmount(d, 0, false);
                    yield break;
                }
            }
        }
        yield return new WaitForSeconds(0.01f);
        StartCoroutine(Filter_Low());
    }

    IEnumerator Filter_High()
    {
        if (AllScore > 5000)
        {
            a += 1;
            AllScore -= 5000;
        }
        else
        {
            if (AllScore > 500)
            {
                b += 1;
                AllScore -= 500;
            }
            else
            {
                if(AllScore > 50)
                {
                    c += 1;
                    AllScore -= 50;
                }
                else
                {
                    Fillter.fillAmount = 0.5f + (a * 0.04f) + (b * 0.004f) + (c * 0.0004f);
                    Progress_Which.transform.localPosition = new Vector3(1020 + (a * 120) + (b * 12) + (c * 1.2f), -680);
                    float d = Progress_Which.transform.localPosition.x / 2050;
                    Scroll.SetDragAmount(d, 0, false);
                    yield break;
                }
            }
        }
        yield return new WaitForSeconds(0.01f);
        StartCoroutine(Filter_High());
    }
}

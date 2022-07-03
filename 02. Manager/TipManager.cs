using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipManager : MonoBehaviour
{
    //통합
    private int Tip_Random = 0;

    public GameObject Tip_Weather;
    public GameObject Tip_Heart;
    public GameObject Tip_Common;


    //Tip - 날씨
    public UISprite Weather_sp;
    public UISprite Weather_Shadow_sp;

    private string[] Weahter_Number = { "Sun", "Moon", "Rain" };

    public GameObject Black_Up;
    public GameObject Black_Down;

    public GameObject White_Up;
    public GameObject White_Down;

    public GameObject Eagle_Up;
    public GameObject Eagle_Down;

    public GameObject Dora_Up;
    public GameObject Dora_Down;

    void Awake()
    {
        Tip_Weather.SetActive(false);
        Tip_Heart.SetActive(false);
    }


    void Start()
    {
        Renewal();
    }

    public void Renewal()
    {
        Tip_Weather.SetActive(false);
        Tip_Heart.SetActive(false);
        Tip_Common.SetActive(false);

        Tip_Random = Random.Range(0, 3);

        if (Tip_Random == 0)
        {
            Tip_Weather.SetActive(true);
            Tip_Weather_Open();
        }
        else if (Tip_Random  == 1)
        {
            Tip_Heart.SetActive(true);
        }
        else if (Tip_Random  == 2)
        {
            Tip_Common.SetActive(true);
        }
    }

    void Tip_Weather_Open()
    {
        int a = Random.Range(0, 3);

        Weather_sp.spriteName = Weahter_Number[a];
        Weather_Shadow_sp.spriteName = Weahter_Number[a];

        switch (a) //햇빛, 밤, 비
        {
            case 0:
                Black_Up.SetActive(false);
                Black_Down.SetActive(true);
                White_Up.SetActive(true);
                White_Down.SetActive(false);
                Eagle_Up.SetActive(false);
                Eagle_Down.SetActive(true);
                Dora_Up.SetActive(true);
                Dora_Down.SetActive(false);
                break;
            case 1:
                Black_Up.SetActive(true);
                Black_Down.SetActive(false);
                White_Up.SetActive(false);
                White_Down.SetActive(true);
                Eagle_Up.SetActive(false);
                Eagle_Down.SetActive(true);
                Dora_Up.SetActive(false);
                Dora_Down.SetActive(true);
                break;
            case 2:
                Black_Up.SetActive(false);
                Black_Down.SetActive(true);
                White_Up.SetActive(false);
                White_Down.SetActive(true);
                Eagle_Up.SetActive(true);
                Eagle_Down.SetActive(false);
                Dora_Up.SetActive(false);
                Dora_Down.SetActive(true);
                break;
        }
    }
}

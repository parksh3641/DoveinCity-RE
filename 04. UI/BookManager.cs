using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookManager : MonoBehaviour
{
    public int Value = 0; //0 기본, 1 알람 전용

    public static BookManager instance;

    public GameObject Book_Object_Background;
    public GameObject Book_Item_Background;
    public GameObject Book_Die_Background;

    public GameObject Book_Object;
    public GameObject Book_Item;
    public GameObject Book_Die;

    public GameObject EasterEgg_Human;
    public GameObject EasterEgg_Bird;

    private int Dead_;

    private string[] Dead_Number = { "Hungry", "Crash", "Throw", "Accident", "Miss", "Kidnap"};


    void Awake()
    {
        instance = this;

        if(Book_Object != null)
        {
            Book_Object.SetActive(true);
            Book_Item.SetActive(false);
            Book_Die.SetActive(false);

            Book_Object_Background.SetActive(false);
            Book_Item_Background.SetActive(true);
            Book_Die_Background.SetActive(true);
        }
    }

    void Start()
    {
        if (Value == 1)
        {
            for (int i = 0; i < Dead_Number.Length; i++)
            {
                Dead_ = PlayerPrefs.GetInt("Dead_" + Dead_Number[i]);

                Clear_Check(Dead_, i);
            }
        }
    }
    void OnEnable()
    {
        int a = PlayerPrefs.GetInt("2016041820161103");
        if (a == 1)
        {
            if(EasterEgg_Bird != null)
            {
                EasterEgg_Human.SetActive(true);
                EasterEgg_Bird.SetActive(true);
            }
        }
        else
        {
            if (EasterEgg_Bird != null)
            {
                EasterEgg_Human.SetActive(false);
                EasterEgg_Bird.SetActive(false);
            }
        }
    }
    public void Reset()
    {
        for (int i = 0; i < Dead_Number.Length; i++)
        {
            PlayerPrefs.SetInt("Dead_" + Dead_Number[i],0);
            PlayerPrefs.SetInt("Dead_Save_" + i,0);
        }
    }

    void Clear_Check(int number, int i)
    {
        int a = PlayerPrefs.GetInt("Dead_Save_" + i);
        if (number != 0)
        {
            if (a == 0)
            {
                PlayerPrefs.SetInt("Dead_Save_" + i, 1);
                AlarmManager.instance.Alarm_Plus_Book();
            }
        }
    }

    public void Object_Open()
    {
        Book_Object.SetActive(true);
        Book_Item.SetActive(false);
        Book_Die.SetActive(false);

        Book_Object_Background.SetActive(false);
        Book_Item_Background.SetActive(true);
        Book_Die_Background.SetActive(true);
    }

    public void Item_Open()
    {
        Book_Object.SetActive(false);
        Book_Item.SetActive(true);
        Book_Die.SetActive(false);

        Book_Object_Background.SetActive(true);
        Book_Item_Background.SetActive(false);
        Book_Die_Background.SetActive(true);
    }

    public void Die_Open()
    {
        Book_Object.SetActive(false);
        Book_Item.SetActive(false);
        Book_Die.SetActive(true);

        Book_Object_Background.SetActive(true);
        Book_Item_Background.SetActive(true);
        Book_Die_Background.SetActive(false);
    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmManager : MonoBehaviour
{
    public static AlarmManager instance;

    public GameObject Nest_Notion;
    public UILabel Nest_txt;

    public GameObject Achieve_Notion;
    public UILabel Achieve_txt;

    public GameObject Shop_Notion;
    public UILabel Shop_txt;

    public GameObject Book_Notion;
    public UILabel Book_txt;

    public GameObject Record_Notion;
    public UILabel Record_txt;

    public int Nest;
    public int Achieve;
    public int Shop;
    public int Book;
    public int Record;

    private int Nest_Save;
    private int Achieve_Save;
    private int Shop_Save;
    private int Book_Save;
    private int Record_Save;

    void Awake()
    {
        instance = this;

        Nest_Notion.SetActive(false);
        Achieve_Notion.SetActive(false);
        Shop_Notion.SetActive(false);
        Book_Notion.SetActive(false);
        Record_Notion.SetActive(false);

        Nest_Save = 0;
        Achieve_Save = 0;
        Shop_Save = 0;
        Book_Save = 0;
        Record_Save = 0;

        Nest = 0;
        Achieve = 0;
        Shop = 0;
        Book = 0;
        Record = 0;

    }

    void Start()
    {
        Renewal();
    }

    public void Reset()
    {
        PlayerPrefs.SetInt("Nest_Save",0);
        PlayerPrefs.SetInt("Achieve_Save",0);
        PlayerPrefs.SetInt("Shop_Save",0);
        PlayerPrefs.SetInt("Book_Save",0);
        PlayerPrefs.SetInt("Record_Save",0);

        Nest_Notion.SetActive(false);
        Achieve_Notion.SetActive(false);
        Shop_Notion.SetActive(false);
        Book_Notion.SetActive(false);
        Record_Notion.SetActive(false);

        Nest = 0;
        Achieve = 0;
        Shop = 0;
        Book = 0;
        Record = 0;
    }

    void Renewal()
    {
        Nest_Save = PlayerPrefs.GetInt("Nest_Save");
        Achieve_Save = PlayerPrefs.GetInt("Achieve_Save");
        Shop_Save = PlayerPrefs.GetInt("Shop_Save");
        Book_Save = PlayerPrefs.GetInt("Book_Save");
        Record_Save = PlayerPrefs.GetInt("Record_Save");

        Default_Nest(Nest_Save);
        Default_Achieve(Achieve_Save);
        Default_Shop(Shop_Save);
        Default_Book(Book_Save);
        Default_Record(Record_Save);
    }

    public void Default_Nest(int number)
    {
        if(number > 0)
        {
            Nest_Notion.SetActive(true);
        }
        Nest = number;
        Nest_txt.text = Nest.ToString();
    }

    public void Default_Achieve(int number)
    {
        if (number > 0)
        {
            Achieve_Notion.SetActive(true);
        }
        Achieve = number;
        Achieve_txt.text = Achieve.ToString();
    }

    public void Default_Shop(int number)
    {
        if (number > 0)
        {
            Shop_Notion.SetActive(true);
        }
        Shop = number;
        Shop_txt.text = Shop.ToString();
    }

    public void Default_Book(int number)
    {
        if (number > 0)
        {
            Book_Notion.SetActive(true);
        }
        Book = number;
        Book_txt.text = Book.ToString();
    }

    public void Default_Record(int number)
    {
        if (number > 0)
        {
            Record_Notion.SetActive(true);
        }
        Record = number;
        Record_txt.text = Record.ToString();
    }

    //


    public void Alarm_Plus_Nest()
    {
        Nest_Notion.SetActive(true);
        Nest_Save = PlayerPrefs.GetInt("Nest_Save");
        Nest_Save += 1;
        PlayerPrefs.SetInt("Nest_Save", Nest_Save);

        Nest += 1;
        Nest_txt.text = Nest.ToString();
        //Debug.Log("둥지 획득");
    }

    public void Alarm_Minus_Nest()
    {
        Nest_Save = PlayerPrefs.GetInt("Nest_Save");
        if(Nest_Save > 1)
        {
            Nest_Save -= 1;
        }
        else
        {
            Nest_Save = 0;
        }
        PlayerPrefs.SetInt("Nest_Save", Nest_Save);

        Nest -= 1;
        Nest_txt.text = Nest.ToString();
        if (Nest <= 0)
        {
            Nest_Notion.SetActive(false);
        }

        //Debug.Log("둥지 획득함");
    }

    public void Alarm_Plus_Achieve()
    {
        Achieve_Notion.SetActive(true);
        Achieve_Save = PlayerPrefs.GetInt("Achieve_Save");
        Achieve_Save += 1;
        PlayerPrefs.SetInt("Achieve_Save", Achieve_Save);

        Achieve += 1;
        Achieve_txt.text = Achieve.ToString();
        //Debug.Log("업적 획득");
    }

    public void Alarm_Minus_Achieve()
    {
        Achieve_Save = PlayerPrefs.GetInt("Achieve_Save");
        if (Achieve_Save > 1)
        {
            Achieve_Save -= 1;
        }
        else
        {
            Achieve_Save = 0;
        }
        PlayerPrefs.SetInt("Achieve_Save", Achieve_Save);

        Achieve -= 1;
        Achieve_txt.text = Achieve.ToString();
        if (Achieve <= 0)
        {
            Achieve_Notion.SetActive(false);
        }

        //Debug.Log("업적 획득함");
    }

    public void Alarm_Plus_Shop()
    {
        Shop_Notion.SetActive(true);
        Shop_Save = PlayerPrefs.GetInt("Shop_Save");
        Shop_Save += 1;
        PlayerPrefs.SetInt("Shop_Save", Shop_Save);

        Shop += 1;
        Shop_txt.text = Shop.ToString();
        //Debug.Log("상점 획득");
    }

    public void Alarm_Minus_Shop()
    {
        Shop_Save = PlayerPrefs.GetInt("Shop_Save");
        if (Shop_Save > 1)
        {
            Shop_Save -= 1;
        }
        else
        {
            Shop_Save = 0;
        }
        PlayerPrefs.SetInt("Shop_Save", Shop_Save);

        Shop -= 1;
        Shop_txt.text = Shop.ToString();
        if (Shop <= 0)
        {
            Shop_Notion.SetActive(false);
        }

        //Debug.Log("상점 획득함");
    }

    public void Alarm_Plus_Book()
    {
        Book_Notion.SetActive(true);
        Book_Save = PlayerPrefs.GetInt("Book_Save");
        Book_Save += 1;
        PlayerPrefs.SetInt("Book_Save", Book_Save);

        Book += 1;
        Book_txt.text = Book.ToString();
        //Debug.Log("도감 획득");
    }

    public void Alarm_Minus_Book()
    {
        Book_Save = PlayerPrefs.GetInt("Book_Save");
        if (Book_Save > 1)
        {
            Book_Save -= 1;
        }
        else
        {
            Book_Save = 0;
        }
        PlayerPrefs.SetInt("Book_Save", Book_Save);

        Book -= 1;
        Book_txt.text = Book.ToString();
        if (Book <= 0)
        {
            Book_Notion.SetActive(false);
        }

        //Debug.Log("도감 획득함");
    }

    public void Alarm_Plus_Record()
    {
        Record_Notion.SetActive(true);
        Record_Save = PlayerPrefs.GetInt("Record_Save");
        Record_Save += 1;
        PlayerPrefs.SetInt("Record_Save", Record_Save);

        Record += 1;
        Record_txt.text = Record.ToString();
        //Debug.Log("기록 획득");
    }

    public void Alarm_Minus_Record()
    {
        Record_Save = PlayerPrefs.GetInt("Record_Save");
        if (Record_Save > 1)
        {
            Record_Save -= 1;
        }
        else
        {
            Record_Save = 0;
        }
        PlayerPrefs.SetInt("Record_Save", Record_Save);

        Record -= 1;
        Record_txt.text = Record.ToString();
        if (Record <= 0)
        {
            Record_Notion.SetActive(false);
        }

        //Debug.Log("기록 획득함");
    }
}

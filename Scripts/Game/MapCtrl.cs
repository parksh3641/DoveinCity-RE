using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MapCtrl : MonoBehaviour
{
    public static MapCtrl instance;

    private int Check_Map_Number;
    //맵 종류
    public GameObject Main_Map_Sprite;
    public GameObject Defalut_Map;
    public Transform Default_Map_Transform;
    public GameObject Under_Map;
    public Transform Under_Map_Transform;
    public GameObject Castle_Map;
    public Transform Castle_Map_Transform;

    private Transform Player;

    public float Save_speed;
    public float speed;

    public float Plus_Speed;
    private float Skill_Speed;

    private bool Player_State;
    private bool Skill_Use;

    private float Car_Random_CoolTime;

    public Sprite Seoul1_1;
    public Sprite Seoul1_2;
    public Sprite Seoul1_3;
    public Sprite Seoul1_4;
    public Sprite Seoul2_1;
    public Sprite Seoul2_2;
    public Sprite Seoul2_3;
    public Sprite Seoul3_1;
    public Sprite Seoul3_2;
    public Sprite Seoul4_1;
    public Sprite Seoul4_2;
    public Sprite Seoul4_3;

    public int Index;

    public List<Sprite> Map_Sprite = new List<Sprite>();

    //차 생성

    public GameObject Front_Car;
    public GameObject Right_Car;
    public GameObject Left_Car;

    private int Front_Index;
    private int Front_Index_Save;
    private int Front_Index_Random;

    public List<GameObject> Object_Front_Car = new List<GameObject>();
    public List<GameObject> Object_Right_Car = new List<GameObject>();
    public List<GameObject> Object_Left_Car = new List<GameObject>();

    public Transform[] Front_Points;

    private bool Beach;

    //맵 생성
    public GameObject Map0;
    public GameObject Map1;
    public GameObject Map2;
    public GameObject Map3;
    public GameObject Map4;
    public GameObject Map5;

    public List<GameObject> Object_Map0 = new List<GameObject>();
    public List<GameObject> Object_Map1 = new List<GameObject>();
    public List<GameObject> Object_Map2 = new List<GameObject>();
    public List<GameObject> Object_Map3 = new List<GameObject>();
    public List<GameObject> Object_Map4 = new List<GameObject>();
    public List<GameObject> Object_Map5 = new List<GameObject>();

    public List<GameObject> Object_Map = new List<GameObject>();

    private int Map0_Index;
    private int Map1_Index;
    private int Map2_Index;
    private int Map3_Index;
    private int Map4_Index;
    private int Map5_Index;

    GameObject monster;

    private int[] Map_Control = { 0, 5, 1, 2, 1, 2, 3, 2, 1, 2, 2, 4, 0, 0, 0 };

    //대화
    private bool Talk_Value;

    //히든맵
    Vector3 Save_Which;

    private bool Under_Value;
    private bool Castle_Value;

    private bool Hidden_Go;

    private bool Sea_Song_Value;

    //단계 증가
    private bool Stage;

    //확률
    public int Random_Builing;
    public int Random_OliveTree;
    public int Random_Human;
    public int Random_Trash1;
    public int Random_Trash2;
    public int Random_Mole;
    public int Random_God;
    public int Random_Car;
    public int Random_Castle;
    public int Random_Ship;


    void Awake()
    {
        instance = this;

        Front_Points = GameObject.Find("Front_Points").GetComponentsInChildren<Transform>();
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        Defalut_Map.SetActive(true);
        Under_Map.SetActive(false);
        Castle_Map.SetActive(false);

        Talk_Value = false;

        Under_Value = false;
        Castle_Value = false;
        Hidden_Go = false;
        Sea_Song_Value = false;

        Front_Index = 0;
        Front_Index_Save = 0;
        Front_Index_Random = 0;

        Stage = false;

        //생성 확률
        Random_Builing = 50;
        Random_OliveTree = 100;
        Random_Human = 50;
        Random_Trash1 = 50;
        Random_Trash2 = 50;
        Random_Mole = 30;
        Random_God = 20;
        Random_Car = 50;
        Random_Castle = 100;
        Random_Ship = 50;

        Map_Sprite_Setting();
        Object_Create();

        Map0_Index = 0;
        Map1_Index = 0;
        Map2_Index = 0;
        Map3_Index = 0;
        Map4_Index = 0;
        Map5_Index = 0;

        Map_Create_Setting();

        Object_Map[0].GetComponent<SpriteRenderer>().sprite = Map_Sprite[11];
        Object_Map[1].GetComponent<SpriteRenderer>().sprite = Map_Sprite[10];
        Object_Map[11].GetComponent<SpriteRenderer>().sprite = Map_Sprite[9];
        Object_Map[12].GetComponent<SpriteRenderer>().sprite = Map_Sprite[11];
        Object_Map[13].GetComponent<SpriteRenderer>().sprite = Map_Sprite[11];
        Object_Map[14].GetComponent<SpriteRenderer>().sprite = Map_Sprite[10];

        Object_Map[0].SetActive(false);
        Object_Map[1].SetActive(false);
        Object_Map[2].SetActive(false);
        Object_Map[3].SetActive(false);
        Object_Map[4].SetActive(false);
        Object_Map[5].SetActive(false);
        Object_Map[6].SetActive(false);
        Object_Map[7].SetActive(false);
        Object_Map[8].SetActive(false);
        Object_Map[9].SetActive(false);
        Object_Map[10].SetActive(false);
        Object_Map[11].SetActive(false);
        Object_Map[12].SetActive(false);
        Object_Map[13].SetActive(false);
        Object_Map[14].SetActive(false);
    }

    void Map_Sprite_Setting()
    {
        Map_Sprite.Add(Seoul1_1);
        Map_Sprite.Add(Seoul1_2);
        Map_Sprite.Add(Seoul1_3);
        Map_Sprite.Add(Seoul1_4);
        Map_Sprite.Add(Seoul2_1);
        Map_Sprite.Add(Seoul2_2);
        Map_Sprite.Add(Seoul2_3);
        Map_Sprite.Add(Seoul3_1);
        Map_Sprite.Add(Seoul3_2);
        Map_Sprite.Add(Seoul4_1);
        Map_Sprite.Add(Seoul4_2);
        Map_Sprite.Add(Seoul4_3);
    }

    void Object_Create() //맵생성
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject f = Instantiate(Map0);
            f.name = "DefaultMap";
            f.gameObject.AddComponent<SeaCtrl>();
            f.SetActive(false);
            Object_Map0.Add(f);

            GameObject a = Instantiate(Map1);
            a.name = "Map1";
            a.SetActive(false);
            Object_Map1.Add(a);

            GameObject b = Instantiate(Map2);
            b.name = "Map2";
            b.SetActive(false);
            Object_Map2.Add(b);

            GameObject c = Instantiate(Map3);
            c.name = "Map3";
            c.SetActive(false);
            Object_Map3.Add(c);

            GameObject d = Instantiate(Map4);
            d.name = "Map4";
            d.SetActive(false);
            Object_Map4.Add(d);

            GameObject e = Instantiate(Map5);
            e.name = "Map4-2";
            e.SetActive(false);
            Object_Map5.Add(e);
        }


        for (int i = 0; i < 20; i++)
        {
            GameObject a = Instantiate(Front_Car);
            a.name = "Front_Car_" + i.ToString();
            a.SetActive(false);
            Object_Front_Car.Add(a);
        }

        for (int i = 0; i < 10; i++)
        {
            GameObject a = Instantiate(Right_Car);
            a.name = "Right_Car_" + i.ToString();
            a.SetActive(false);
            Object_Right_Car.Add(a);
        }

        for (int i = 0; i < 10; i++)
        {
            GameObject a = Instantiate(Left_Car);
            a.name = "Left_Car_" + i.ToString();
            a.SetActive(false);
            Object_Left_Car.Add(a);
        }
    }

    void Map_Create_Setting()
    {
        Vector3 main_pos = new Vector3(0, -30, 10);
        Vector3 sub_pos = new Vector3(0, 10, 0);

        for(int i = 0;i< Map_Control.Length;i++)
        {
            Map_Create(Map_Control[i], main_pos + (sub_pos * i));
        }
    }

    void Map_Create(int number, Vector3 pos)
    {
        switch (number)
        {
            case 0:
                monster = Object_Map0[Map0_Index];
                Map0_Index += 1;
                break;
            case 1:
                monster = Object_Map1[Map1_Index];
                Map1_Index += 1;
                break;
            case 2:
                monster = Object_Map2[Map2_Index];
                Map2_Index += 1;
                break;
            case 3:
                monster = Object_Map3[Map3_Index];
                Map3_Index += 1;
                break;
            case 4:
                monster = Object_Map4[Map4_Index];
                Map4_Index += 1;
                break;
            case 5:
                monster = Object_Map5[Map5_Index];
                Map5_Index += 1;
                break;
        }

        Map_Sprite_Change(monster.GetComponent<SpriteRenderer>(), number);

        monster.transform.parent = Main_Map_Sprite.transform;
        monster.transform.localPosition = pos;
        monster.SetActive(true);

        Object_Map.Add(monster);
    }



    void OnEnable()
    {
        GameManager.Player_Die += Player_Die;
        GameManager.Player_Alive += Player_Alive;
        SkillManager.Skill_In += Skill_In;
        SkillManager.Skill_Out += Skill_Out;
        GameManager.Talk_In += Talk_In;
        GameManager.Talk_Out += Talk_Out;
        GameManager.Under_In += Under_In;
        GameManager.Under_Out += Under_Out;
        GameManager.Castle_In += Castle_In;
        GameManager.Castle_Out += Castle_Out;

        speed = SystemManager.instance.Dove_Speed;
        Car_Random_CoolTime = SystemManager.instance.Car_Random_CoolTime;
        Skill_Speed = speed * 0.2f;
        Plus_Speed = 0;

        Defalut_Map.SetActive(true);
        Under_Map.SetActive(false);
        Castle_Map.SetActive(false);

        Player_State = true;
        Skill_Use = false;
        Beach = true;

        StartCoroutine(Map_Which_Check()); //앞으로 오는 차 생성 결정 및 바다소리 감지
        StartCoroutine(Object_Create_Front_Car());//앞으로 오는 차 생성
        Check_Map_Number = 0;
        StartCoroutine(Check_Map(0)); //맵 좌표에 따라 on off 시킴
    }

    void OnDisable()
    {
        GameManager.Player_Die -= Player_Die;
        GameManager.Player_Alive -= Player_Alive;
        SkillManager.Skill_In -= Skill_In;
        SkillManager.Skill_Out -= Skill_Out;
        GameManager.Talk_In -= Talk_In;
        GameManager.Talk_Out -= Talk_Out;
        GameManager.Under_In -= Under_In;
        GameManager.Under_Out -= Under_Out;
        GameManager.Castle_In -= Castle_In;
        GameManager.Castle_Out -= Castle_Out;

        StopAllCoroutines();
    }

    void Map_Sprite_Change(SpriteRenderer sp,int number)
    {
        int a = 0;
        switch(number)
        {
            case 0:
                a = 11;
                break;
            case 1:
                a = UnityEngine.Random.Range(0, 4);
                break;
            case 2:
                a = UnityEngine.Random.Range(4, 7);
                break;
            case 3:
                a = UnityEngine.Random.Range(7, 9);
                break;
            case 4:
                a = 9;
                break;
            case 5:
                a = 10;
                break;
        }
        sp.sprite = Map_Sprite[a];
    }

    public void Stage_Up()
    {
        speed = SystemManager.instance.Dove_Speed;

        for(int i = 0;i<Map_Control.Length;i++)
        {
            Map_Sprite_Change(Object_Map[i].GetComponent<SpriteRenderer>(), Map_Control[i]);
        }

        Percent_Up(4);
    }

    void Percent_Up(int number)
    {
        if (Random_Builing < 100)
        {
            Random_Builing += number;
        }

        if (Random_OliveTree < 100)
        {
            Random_OliveTree += number;
        }
        if (Random_Human < 100)
        {
            Random_Human += number;
        }
        if (Random_Trash1 < 100)
        {
            Random_Trash1 += number;
        }
        if (Random_Trash2 < 100)
        {
            Random_Trash2 += number;
        }
        if (Random_Mole < 100)
        {
            Random_Mole += number;
        }
        if (Random_God < 100)
        {
            Random_God += number;
        }
        if (Random_Car < 100)
        {
            Random_Car += number;
        }
        if (Random_Castle < 100)
        {
            Random_Castle += number;
        }
        if (Random_Ship < 100)
        {
            Random_Ship += number;
        }
    }

    IEnumerator Map_Which_Check()
    {
        if (Default_Map_Transform.localPosition.y <= 6.5f)
        {
            if (Sea_Song_Value == true)
            {
                Sea_Song_Value = false;
                EffectManager.instance.Sea_Song_Off();
                GameManager.instance.Wave_End();
                //Debug.Log("바다소리 정지");
            }
        }

        if (Default_Map_Transform.localPosition.y <= -1.5f)
        {
            if(Beach == true)
            {
                Beach = false;
                StartCoroutine(Check_Y());
                //Debug.Log("차 생성 시작");
                yield break;
            }
        }
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(Map_Which_Check());
    }

    IEnumerator Check_Y()
    {
        if (Default_Map_Transform.localPosition.y <= -90f)
        {
            if (Beach == false)
            {
                Beach = true;
                Stage = true; //단계 설정
                //Debug.Log("차 생성 멈춤");
            }
        }

        if (Default_Map_Transform.localPosition.y <= -103f)
        {
            if (Sea_Song_Value == false)
            {
                Sea_Song_Value = true;
                EffectManager.instance.Sea_Song_On();
                GameManager.instance.Wave_Start();
                //Debug.Log("바다 소리 시작");
            }
        }

        if (Default_Map_Transform.localPosition.y >= 0)
        {
            StartCoroutine(Map_Which_Check());
            yield break;
        }
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(Check_Y());
    }
    IEnumerator Object_Create_Front_Car()
    {
        if (Player_State == true)
        {
            if (Talk_Value == false && Under_Value == false && Castle_Value == false && Hidden_Go == false)
            {
                if (Beach == false)
                {
                    if (Front_Index > Object_Front_Car.Count - 1)
                    {
                        Front_Index = 0;
                    }
                    GameObject monster = Object_Front_Car[Front_Index];
                    if (!monster.activeSelf)
                    {
                        if (Front_Index_Save < 2)
                        {
                            Front_Index_Random = UnityEngine.Random.Range(1, 4);
                            Front_Index_Save += 1;
                        }
                        else
                        {
                            Front_Index_Random = UnityEngine.Random.Range(5, Front_Points.Length);

                            Front_Index_Save = 0;
                        }


                        monster.transform.position = Front_Points[Front_Index_Random].position + new Vector3(0, 0, 8f);
                        monster.SetActive(true);

                        Front_Index += 1;
                    }
                }
            }
        }
        else
        {
            yield break;
        }
        yield return new WaitForSeconds(UnityEngine.Random.Range(Car_Random_CoolTime * 0.5f, Car_Random_CoolTime * 0.75f));
        StartCoroutine(Object_Create_Front_Car());
    }

    IEnumerator Check_Map(int number) //여기가 문제임
    {
        if (Default_Map_Transform.localPosition.y <= number + 2)
        {
            if (Check_Map_Number == 0)
            {
                Check_Map_Number = 1;
                Object_Map[1].SetActive(true);
                Object_Map[2].SetActive(true);
                Object_Map[12].SetActive(false);
                Object_Map[13].SetActive(false);

                //Debug.Log(Check_Map_Number+"번이 발동되었습니다.");
            }
        }
        else
        {
            if (Check_Map_Number == 12)
            {
                Check_Map_Number = 0;
                Object_Map[1].SetActive(true);
                Object_Map[3].SetActive(false);
                Object_Map[4].SetActive(false);
                Object_Map[5].SetActive(false);
                Object_Map[6].SetActive(false);
                Object_Map[7].SetActive(false);
                Object_Map[8].SetActive(false);
                Object_Map[9].SetActive(false);
                Object_Map[10].SetActive(false);
                Object_Map[11].SetActive(false);
                Object_Map[12].SetActive(false);
                Object_Map[13].SetActive(false);
                Object_Map[14].SetActive(false);

                //Debug.Log(Check_Map_Number + "번이 발동되었습니다.");
            }
        }

        if (Default_Map_Transform.localPosition.y <= number - 8)
        {
            if (Check_Map_Number == 1)
            {
                Check_Map_Number = 2;
                Object_Map[3].SetActive(true);

                //Debug.Log(Check_Map_Number + "번이 발동되었습니다.");
            }
        }

        if (Default_Map_Transform.localPosition.y <= number - 18)
        {
            if (Check_Map_Number == 2)
            {
                Check_Map_Number = 3;
                Object_Map[1].SetActive(false);
                Object_Map[4].SetActive(true);

                //Debug.Log(Check_Map_Number + "번이 발동되었습니다.");
            }
        }


        if (Default_Map_Transform.localPosition.y <= number - 28)
        {
            if (Check_Map_Number == 3)
            {
                Check_Map_Number = 4;
                Object_Map[2].SetActive(false);
                Object_Map[5].SetActive(true);

                //Debug.Log(Check_Map_Number + "번이 발동되었습니다.");
            }
        }

        if (Default_Map_Transform.localPosition.y <= number - 38)
        {
            if (Check_Map_Number == 4)
            {
                Check_Map_Number = 5;
                Object_Map[3].SetActive(false);
                Object_Map[6].SetActive(true);

                //Debug.Log(Check_Map_Number + "번이 발동되었습니다.");
            }
        }

        if (Default_Map_Transform.localPosition.y <= number - 48)
        {
            if (Check_Map_Number == 5)
            {
                Check_Map_Number = 6;
                Object_Map[4].SetActive(false);
                Object_Map[7].SetActive(true);

                //Debug.Log(Check_Map_Number + "번이 발동되었습니다.");
            }
        }

        if (Default_Map_Transform.localPosition.y <= number - 58)
        {
            if (Check_Map_Number == 6)
            {
                Check_Map_Number = 7;
                Object_Map[5].SetActive(false);
                Object_Map[8].SetActive(true);

                //Debug.Log(Check_Map_Number + "번이 발동되었습니다.");
            }
        }

        if (Default_Map_Transform.localPosition.y <= number - 68)
        {
            if (Check_Map_Number == 7)
            {
                Check_Map_Number = 8;
                Object_Map[6].SetActive(false);
                Object_Map[9].SetActive(true);

                //Debug.Log(Check_Map_Number + "번이 발동되었습니다.");
            }
        }

        if (Default_Map_Transform.localPosition.y <= number - 78)
        {
            if (Check_Map_Number == 8)
            {
                Check_Map_Number = 9;
                Object_Map[7].SetActive(false);
                Object_Map[10].SetActive(true);

                //Debug.Log(Check_Map_Number + "번이 발동되었습니다.");
            }
        }

        if (Default_Map_Transform.localPosition.y <= number - 88)
        {
            if (Check_Map_Number == 9)
            {
                Check_Map_Number = 10;
                Object_Map[8].SetActive(false);
                Object_Map[11].SetActive(true);

                //Debug.Log(Check_Map_Number + "번이 발동되었습니다.");
            }
        }

        if (Default_Map_Transform.localPosition.y <= number - 98)
        {
            if (Check_Map_Number == 10)
            {
                Check_Map_Number = 11;
                Object_Map[9].SetActive(false);
                Object_Map[12].SetActive(true);

                //Debug.Log(Check_Map_Number + "번이 발동되었습니다.");
            }
        }

        if (Default_Map_Transform.localPosition.y <= number - 108)
        {
            if (Check_Map_Number == 11)
            {
                Check_Map_Number = 12;
                Object_Map[10].SetActive(false);
                Object_Map[13].SetActive(true);
                Object_Map[14].SetActive(true);
                Object_Map[0].SetActive(true);

                //Debug.Log(Check_Map_Number + "번이 발동되었습니다.");
            }
        }
        yield return new WaitForSeconds(0.75f);
        StartCoroutine(Check_Map(number));
    }



    void Player_Die()
    {
        try
        {
            Player_State = false;
            Skill_Use = false;

            Plus_Speed = 0;

            StopAllCoroutines();
        }
        catch (NullReferenceException ie)
        {
            print(ie.Message);

            Player_State = false;
            Skill_Use = false;

            Plus_Speed = 0;

            StopAllCoroutines();
        }
    }
    void Player_Alive()
    {
        try
        {
            Player_State = true;

            if (gameObject.activeSelf == true)
            {
                if (Beach == false)
                {
                    StartCoroutine(Object_Create_Front_Car());
                    StartCoroutine(Check_Y());
                    //Debug.Log("차 생성하는 범위입니다.");
                }
                else
                {
                    StartCoroutine(Map_Which_Check());
                    //Debug.Log("차 생성할수 없는 범위입니다.");
                }
                StartCoroutine(Check_Map(0));
            }
        }
        catch (NullReferenceException ie)
        {
            print(ie.Message);

            Player_State = true;

            if(gameObject.activeSelf == true)
            {
                StartCoroutine(Map_Which_Check());
                if (Beach == false)
                {
                    StartCoroutine(Object_Create_Front_Car());
                    //Debug.Log("차 생성하는 범위입니다.");
                }
                else
                {
                    //Debug.Log("차 생성할수 없는 범위입니다.");
                }
                StartCoroutine(Check_Map(0));
            }
        }
    }

    void Skill_In()
    {
        try
        {
            Skill_Use = true;
            Speed_Up();
        }
        catch (NullReferenceException ie)
        {
            print(ie.Message);

            SkillManager.Skill_In += Skill_In;

            Skill_Use = true;
            Speed_Up();
        }
    }
    void Skill_Out()
    {
        try
        {
            Skill_Use = false;
            Speed_Up();
        }
        catch (NullReferenceException ie)
        {
            print(ie.Message);

            SkillManager.Skill_Out += Skill_Out;
            Skill_Use = false;
            Speed_Up();

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

    void Under_In()
    {
        try
        {
            Under_Value = true;
            Save_Which = new Vector3(0, 0, 0);
            Save_Which = Default_Map_Transform.localPosition;

            StartCoroutine(Under_Wait());
        }
        catch (NullReferenceException ie)
        {
            print(ie.Message);

            GameManager.Under_In += Under_In;

            StopAllCoroutines();

            Under_Value = true;
            Save_Which = new Vector3(0, 0, 0);
            Save_Which = Default_Map_Transform.localPosition;

            StartCoroutine(Under_Wait());

            if (gameObject.activeSelf == true)
            {
                if (Beach == false)
                {
                    StartCoroutine(Object_Create_Front_Car());
                    StartCoroutine(Check_Y());
                    //Debug.Log("차 생성하는 범위입니다.");
                }
                else
                {
                    StartCoroutine(Map_Which_Check());
                    //Debug.Log("차 생성할수 없는 범위입니다.");
                }
                StartCoroutine(Check_Map(0));
            }
        }
    }
    void Under_Out()
    {
        try
        {
            Under_Value = false;
            StartCoroutine(Under_Wait());
        }
        catch (NullReferenceException ie)
        {
            print(ie.Message);

            GameManager.Under_Out += Under_Out;

            StopAllCoroutines();

            Under_Value = false;
            StartCoroutine(Under_Wait());

            if (gameObject.activeSelf == true)
            {
                if (Beach == false)
                {
                    StartCoroutine(Object_Create_Front_Car());
                    StartCoroutine(Check_Y());
                    //Debug.Log("차 생성하는 범위입니다.");
                }
                else
                {
                    StartCoroutine(Map_Which_Check());
                    //Debug.Log("차 생성할수 없는 범위입니다.");
                }
                StartCoroutine(Check_Map(0));
            }
        }
    }
    void Castle_In()
    {
        try
        {
            Castle_Value = true;
            Save_Which = new Vector3(0, 0, 0);
            Save_Which = Default_Map_Transform.localPosition + new Vector3(0, -1f, 0);

            StartCoroutine(Castle_Wait());
        }
        catch (NullReferenceException ie)
        {
            print(ie.Message);

            GameManager.Castle_In += Castle_In;

            StopAllCoroutines();

            Castle_Value = true;
            Save_Which = new Vector3(0, 0, 0);
            Save_Which = Default_Map_Transform.localPosition + new Vector3(0, -1f, 0);

            StartCoroutine(Castle_Wait());

            if (gameObject.activeSelf == true)
            {
                if (Beach == false)
                {
                    StartCoroutine(Object_Create_Front_Car());
                    StartCoroutine(Check_Y());
                    //Debug.Log("차 생성하는 범위입니다.");
                }
                else
                {
                    StartCoroutine(Map_Which_Check());
                    //Debug.Log("차 생성할수 없는 범위입니다.");
                }
                StartCoroutine(Check_Map(0));
            }

        }
    }
    void Castle_Out()
    {
        try
        {
            Castle_Value = false;
            StartCoroutine(Castle_Wait());
        }
        catch (NullReferenceException ie)
        {
            print(ie.Message);

            GameManager.Castle_Out += Castle_Out;

            StopAllCoroutines();

            Castle_Value = false;
            StartCoroutine(Castle_Wait());

            if (gameObject.activeSelf == true)
            {
                if (Beach == false)
                {
                    StartCoroutine(Object_Create_Front_Car());
                    StartCoroutine(Check_Y());
                    //Debug.Log("차 생성하는 범위입니다.");
                }
                else
                {
                    StartCoroutine(Map_Which_Check());
                    //Debug.Log("차 생성할수 없는 범위입니다.");
                }
                StartCoroutine(Check_Map(0));
            }
        }
    }

    IEnumerator Under_Wait()
    {
        yield return new WaitForSeconds(0.2f);
        Save_speed = speed;
        speed = 0;
        yield return new WaitForSeconds(2.6f);

        if (Under_Value == true)
        {
            Defalut_Map.SetActive(false);
            Under_Map.GetComponent<Transform>().localPosition = new Vector3(0, 4.5f, 0);
            Under_Map.SetActive(true);
        }
        else
        {
            Defalut_Map.GetComponent<Transform>().localPosition = new Vector3(0, Save_Which.y, 0);
            Defalut_Map.SetActive(true);
            Under_Map.SetActive(false);
        }

        yield return new WaitForSeconds(1f);
        speed = Save_speed;

        if(Under_Value == true)
        {
            Hidden_Go = true;
        }
        else
        {
            Hidden_Go = false;
        }

    }

    IEnumerator Castle_Wait()
    {
        yield return new WaitForSeconds(0.2f);
        Save_speed = speed;
        speed = 0;
        yield return new WaitForSeconds(2.6f);
        if (Castle_Value == true)
        {
            Defalut_Map.SetActive(false);
            Castle_Map.GetComponent<Transform>().localPosition = new Vector3(0, 3f, 0);
            Castle_Map.SetActive(true);
        }
        else
        {
            Defalut_Map.GetComponent<Transform>().localPosition = new Vector3(0, Save_Which.y, 0);
            Defalut_Map.SetActive(true);
            Castle_Map.SetActive(false);
        }

        yield return new WaitForSeconds(1f);
        speed = Save_speed;

        if (Castle_Value == true)
        {
            Hidden_Go = true;
        }
        else
        {
            Hidden_Go = false;
        }
    }


    void Speed_Up() //속도변화는 모두 여기서 처리
    {
        if (Skill_Use == true)
        {
            Plus_Speed = Skill_Speed;
        }
        else
        {
            Plus_Speed = 0;
        }
    }

    void Update()
    {
        if (Player_State == true && Talk_Value == false)
        {
            if(Hidden_Go != true)
            {
                Default_Map_Transform.Translate(0, -(speed + Plus_Speed) * Time.deltaTime, 0);
            }
            else
            {
                Under_Map_Transform.Translate(0, -0.5f * Time.deltaTime, 0);
                Castle_Map_Transform.Translate(0, -0.5f * Time.deltaTime, 0);
            }
        }

        if (Default_Map_Transform.localPosition.y <= -117f) ///맵 맨 위에서 맨 아래로 자연스럽게 보내주는 코드
        {
            Default_Map_Transform.localPosition = new Vector3(0, 17.075f, 0);
            if (Stage == true)
            {
                Stage = false;
                GameManager.instance.Stage_Up();
            }
        }
    }
}

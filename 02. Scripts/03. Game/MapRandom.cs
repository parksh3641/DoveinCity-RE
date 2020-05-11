using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MapRandom : MonoBehaviour
{
    public int Value = 0; //0은 아무것도 아님 맵1,2,3,4,4-2

    private SpriteRenderer Main_sp;

    private Transform[] Car_Points_1;
    private Transform[] Car_Points_2;
    private Transform[] Car_Points_3;
    private Transform[] Car_Points_4; //맵 4 바다로 진입하는 맵
    private Transform[] Car_Points_5; //맵 4-2 바다 에서 빠져나오는 맵

    private float Car_Random_CoolTime;

    public Transform[] Main_Car_Points;

    public Transform[] Building_Point;
    public Transform[] Olive_Point;
    public Transform[] God_Point;
    public Transform[] Castle_Point;
    public Transform[] Ship_Point;

    private string[] Sprite_Name = { "1-1", "1-2", "1-3", "1-4", "2-1", "2-2", "2-3", "3-1", "3-2", "4-1", "4-2", "4-3" };
    private int[] Map_Name = { 1, 1, 1, 1, 2, 2, 2, 3, 3, 4, 5, 0 };

    public int Map_Value = 0;

    //오브젝트 생성
    public GameObject Building;
    public GameObject OliveTree;
    public GameObject Human;
    public GameObject Trash1;
    public GameObject Trash2;
    public GameObject Mole;
    public GameObject God;

    public GameObject Car_Right;
    public GameObject Car_Left;

    public GameObject Castle;

    public GameObject Ship;

    //최대치 정하기
    private int Max_Building;
    private int Max_OliveTree;
    private int Max_Human;
    private int Max_Mole;
    private int Max_Trash1;
    private int Max_Trash2;
    private int Max_God;
    private int Max_Car_Right;
    private int Max_Car_Left;
    private int Max_Castle;
    private int Max_Ship;

    //인덱스
    private int Human_Index;
    private int Car_Right_Index;
    private int Car_Left_Index;

    //확률
    private int Random_Builing;
    private int Random_OliveTree;
    private int Random_Human;
    private int Random_Trash1;
    private int Random_Trash2;
    private int Random_Mole;
    private int Random_God;
    private int Random_Car;
    private int Random_Castle;
    private int Random_Ship;

    public List<GameObject> Object_Building = new List<GameObject>();
    public List<GameObject> Object_OliveTree = new List<GameObject>();
    public List<GameObject> Object_Human = new List<GameObject>();
    public List<GameObject> Object_Trash1 = new List<GameObject>();
    public List<GameObject> Object_Trash2 = new List<GameObject>();
    public List<GameObject> Object_Mole = new List<GameObject>();
    public List<GameObject> Object_God = new List<GameObject>();

    public List<GameObject> Object_Car_Right = new List<GameObject>();
    public List<GameObject> Object_Car_Left = new List<GameObject>();

    public List<GameObject> Object_Castle = new List<GameObject>();

    public List<GameObject> Object_Ship = new List<GameObject>();

    private List<GameObject> Object_Reset = new List<GameObject>();

    private bool Player_State;
    private bool Talk_Value;
    private bool Under_Value;
    private bool Castle_Value;

    void Awake()
    {
        Main_sp = GetComponent<SpriteRenderer>();
        Player_State = true;
        Talk_Value = false;
        Under_Value = false;
        Castle_Value = false;

        Car_Points_1 = transform.GetChild(0).gameObject.GetComponentsInChildren<Transform>();
        Car_Points_2 = transform.GetChild(1).gameObject.GetComponentsInChildren<Transform>();
        Car_Points_3 = transform.GetChild(2).gameObject.GetComponentsInChildren<Transform>();
        Car_Points_4 = transform.GetChild(3).gameObject.GetComponentsInChildren<Transform>();
        Car_Points_5 = transform.GetChild(4).gameObject.GetComponentsInChildren<Transform>();

        if(Value == 1)
        {
            Building_Point = transform.GetChild(5).GetComponentsInChildren<Transform>();
            Olive_Point = transform.GetChild(6).GetComponentsInChildren<Transform>();
        }
        else if(Value == 2)
        {
            Building_Point = transform.GetChild(5).GetComponentsInChildren<Transform>();
            God_Point = transform.GetChild(6).GetComponentsInChildren<Transform>();
        }
        else if (Value == 3)
        {
            Building_Point = transform.GetChild(5).GetComponentsInChildren<Transform>();
            Castle_Point = transform.GetChild(6).GetComponentsInChildren<Transform>();
        }
        else if (Value == 4)
        {
            Building_Point = transform.GetChild(5).GetComponentsInChildren<Transform>();
            Ship_Point = transform.GetChild(6).GetComponentsInChildren<Transform>();
        }
        else if (Value == 5)
        {
            Building_Point = transform.GetChild(5).GetComponentsInChildren<Transform>();
            God_Point = transform.GetChild(6).GetComponentsInChildren<Transform>();
        }

        Max_Building = 40;
        Max_OliveTree = 1;
        Max_Human = 80;
        Max_Trash1 = 10;
        Max_Trash2 = 10;
        Max_Mole = 2;
        Max_God = 5;
        Max_Car_Right = 15;
        Max_Car_Left = 15;
        Max_Castle = 1;
        Max_Ship = 8;

        Object_Create();
    }

    void Object_Create() //프리팹 미리 생성
    {
        for (int i = 0; i < Max_Building; i++) //건물
        {
            GameObject a = Instantiate(Building);
            a.name = "Building_" + i.ToString();
            a.SetActive(false);
            Object_Building.Add(a);
        }

        for (int i = 0; i < Max_OliveTree; i++) //올리브 나무
        {
            GameObject a = Instantiate(OliveTree);
            a.name = "OliveTree_" + i.ToString();
            a.SetActive(false);
            Object_OliveTree.Add(a);
        }

        for (int i = 0; i < Max_Human; i++) //사람
        {
            GameObject a = Instantiate(Human);
            a.name = "Human_" + i.ToString();
            a.SetActive(false);
            Object_Human.Add(a);
        }

        for (int i = 0; i < Max_Trash1; i++) //쓰레기통1
        {
            GameObject a = Instantiate(Trash1);
            a.name = "Trash1_" + i.ToString();
            a.SetActive(false);
            Object_Trash1.Add(a);
        }

        for (int i = 0; i < Max_Trash2; i++) //쓰레기통2
        {
            GameObject a = Instantiate(Trash2);
            a.name = "Trash2_" + i.ToString();
            a.SetActive(false);
            Object_Trash2.Add(a);
        }

        for (int i = 0; i < Max_Mole; i++) //두더지
        {
            GameObject a = Instantiate(Mole);
            a.name = "Mole_" + i.ToString();
            a.SetActive(false);
            Object_Mole.Add(a);
        }

        for (int i = 0; i < Max_Car_Right; i++) //자동차 오른쪽
        {
            GameObject a = Instantiate(Car_Right);
            a.name = "Car_Right_" + i.ToString();
            a.SetActive(false);
            Object_Car_Right.Add(a);
        }

        for (int i = 0; i < Max_Car_Left; i++) //자동자 왼쪽
        {
            GameObject a = Instantiate(Car_Left);
            a.name = "Car_Left_" + i.ToString();
            a.SetActive(false);
            Object_Car_Left.Add(a);
        }

        for (int i = 0; i < Max_God; i++) //산신령
        {
            GameObject a = Instantiate(God);
            a.name = "God_" + i.ToString();
            a.SetActive(false);
            Object_God.Add(a);
        }

        for (int i = 0; i < Max_Castle; i++) //숭례문
        {
            GameObject a = Instantiate(Castle);
            a.name = "Castle_" + i.ToString();
            a.SetActive(false);
            Object_Castle.Add(a);
        }

        for (int i = 0; i < Max_Ship; i++) //숭례문
        {
            GameObject a = Instantiate(Ship);
            a.name = "Ship_" + i.ToString();
            a.SetActive(false);
            Object_Ship.Add(a);
        }
    }

    void OnEnable()
    {
        GameManager.Player_Die += Player_Die;
        GameManager.Player_Alive += Player_Alive;
        GameManager.Talk_In += Talk_In;
        GameManager.Talk_Out += Talk_Out;
        GameManager.Under_In += Under_In;
        GameManager.Under_Out += Under_Out;
        GameManager.Castle_In += Castle_In;
        GameManager.Castle_Out += Castle_Out;

        for (int i = 0; i < Sprite_Name.Length; i++)
        {
            if (Main_sp.sprite.name.Equals(Sprite_Name[i]))
            {
                Map_Value = Map_Name[i];
            }
        }

        Car_Random_CoolTime = SystemManager.instance.Car_Random_CoolTime * 2;

        Human_Index = 0;
        Car_Right_Index = 0;
        Car_Left_Index = 0;

        Random_Builing = MapCtrl.instance.Random_Builing;
        Random_OliveTree = MapCtrl.instance.Random_OliveTree;
        Random_Human = MapCtrl.instance.Random_Human;
        Random_Trash1 = MapCtrl.instance.Random_Trash1;
        Random_Trash2 = MapCtrl.instance.Random_Trash2;
        Random_Mole = MapCtrl.instance.Random_Mole;
        Random_God = MapCtrl.instance.Random_God;
        Random_Car = MapCtrl.instance.Random_Car;
        Random_Castle = MapCtrl.instance.Random_Castle;
        Random_Ship = MapCtrl.instance.Random_Ship;

        Map_Check();

        if(Value == 1)
        {
            Create_Building();
            Create_OliveTree();
            Create_Human();
            Create_Mole();
            Create_Trash1();
            Create_Trash2();
        }
        else if(Value == 2)
        {
            Create_Building();
            Create_Human();
            Create_Mole();
            Create_Trash1();
            Create_Trash2();
            Create_God();
        }
        else if (Value == 3)
        {
            Create_Building();
            Create_Human();
            Create_Mole();
            Create_Trash1();
            Create_Trash2();
            Create_Castle();
        }
        else if (Value == 4)
        {
            Create_Building();
            Create_Human();
            Create_Mole();
            Create_Trash1();
            Create_Trash2();
            Create_Ship();
        }
        else if (Value == 5)
        {
            Create_Building();
            Create_Human();
            Create_Mole();
            Create_Trash1();
            Create_Trash2();
            Create_God();
        }


        StartCoroutine(Create_Car_Right());
        StartCoroutine(Create_Car_Left());
    }

    void OnDisable()
    {
        GameManager.Player_Die -= Player_Die;
        GameManager.Player_Alive -= Player_Alive;
        GameManager.Talk_In -= Talk_In;
        GameManager.Talk_Out -= Talk_Out;
        GameManager.Under_In -= Under_In;
        GameManager.Under_Out -= Under_Out;
        GameManager.Castle_In -= Castle_In;
        GameManager.Castle_Out -= Castle_Out;

        for (int i = 0; i < Object_Reset.Count; i++) //초기화
        {
            Object_Reset[i].SetActive(false);
        }
        Object_Reset.Clear();

        StopAllCoroutines();
    }

    void Player_Die()
    {
        try
        {
            Player_State = false;

            StopAllCoroutines();
        }
        catch (NullReferenceException ie)
        {
            print(ie.Message);

            GameManager.Player_Die += Player_Die;

            Player_State = false;

            StopAllCoroutines();

        }
    }
    void Player_Alive()
    {
        try
        {
            Player_State = true;

            if(gameObject.activeSelf == true)
            {
                StartCoroutine(Create_Car_Right());
                StartCoroutine(Create_Car_Left());
            }
        }
        catch (NullReferenceException ie)
        {
            print(ie.Message);

            GameManager.Player_Alive += Player_Alive;

            Player_State = true;

            if (gameObject.activeSelf == true)
            {
                StartCoroutine(Create_Car_Right());
                StartCoroutine(Create_Car_Left());
            }
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
        }
        catch (NullReferenceException ie)
        {
            print(ie.Message);

            GameManager.Under_In += Under_In;

            Under_Value = true;

        }
    }
    void Under_Out()
    {
        try
        {
            Under_Value = false;
        }
        catch (NullReferenceException ie)
        {
            print(ie.Message);

            GameManager.Under_Out += Under_Out;

            Under_Value = false;

        }
    }
    void Castle_In()
    {
        try
        {
            Castle_Value = true;
        }
        catch (NullReferenceException ie)
        {
            print(ie.Message);

            GameManager.Castle_In += Castle_In;

            Castle_Value = true;

        }
    }
    void Castle_Out()
    {
        try
        {
            Castle_Value = false;
        }
        catch (NullReferenceException ie)
        {
            print(ie.Message);

            GameManager.Castle_Out += Castle_Out;

            Castle_Value = false;

        }
    }

    void Map_Check()
    {
        if(Value == 1)
        {
            Main_Car_Points = Car_Points_1;
        }
        else if (Value == 2)
        {
            Main_Car_Points = Car_Points_2;
        }
        else if (Value == 3)
        {
            Main_Car_Points = Car_Points_3;
        }
        else if (Value == 4)
        {
            Main_Car_Points = Car_Points_4;
        }
        else if (Value == 5)
        {
            Main_Car_Points = Car_Points_5;
        }
    }

    void Create_Building()
    {
        for (int i = 0;i<Building_Point.Length - 1;i++)
        {
            int a = UnityEngine.Random.Range(0, 100);

            if (a <= Random_Builing)
            {
                GameObject monster = Object_Building[i];

                if (!monster.activeSelf)
                {
                    float x = UnityEngine.Random.Range(0, 0.1f); //오차범위
                    float y = UnityEngine.Random.Range(0, 0.1f);
                    Vector3 v3 = new Vector3(x, y, -4f);

                    monster.transform.parent = transform;
                    monster.transform.position = Building_Point[i + 1].position + v3;
                    monster.SetActive(true);
                    Object_Reset.Add(monster);
                }
            }
        }
    }

    void Create_OliveTree()
    {
        for (int i = 0; i < Olive_Point.Length -1; i++)
        {
            int a = UnityEngine.Random.Range(0, 100);

            if (a <= Random_OliveTree)
            {
                GameObject monster = Object_OliveTree[i];

                if (!monster.activeSelf)
                {
                    monster.transform.parent = transform;
                    monster.transform.position = Olive_Point[i + 1].position + new Vector3(0, 0, -6);
                    monster.SetActive(true);
                    Object_Reset.Add(monster);
                }
            }
        }
    }
    void Create_Human()
    {
        float y = 0;
        for (int i = 0; i < Object_Human.Count / 2; i++)
        {
            int a = UnityEngine.Random.Range(0, 100);

            if (a <= Random_Human)
            {
                if(Human_Index >= Max_Human)
                {
                    return;
                }
                GameObject monster = Object_Human[Human_Index];
                Human_Index += 1;
                GameObject monster2 = Object_Human[Human_Index];
                Human_Index += 1;

                int b = UnityEngine.Random.Range(0, 2);
                if(b == 0)
                {
                    y = UnityEngine.Random.Range(-10.5f, 0);
                }
                else
                {
                    y = UnityEngine.Random.Range(0, 10.5f);
                }

                if (!monster.activeSelf)
                {
                    float x = UnityEngine.Random.Range(-8.1f, 0); //오차범위
                    Vector3 v3 = new Vector3(x, y,-5f);

                    monster.transform.parent = transform;
                    monster.transform.localPosition = v3;
                    monster.SetActive(true);
                    Object_Reset.Add(monster);

                    Human_Index += 1;
                }

                if (!monster2.activeSelf)
                {
                    float x = UnityEngine.Random.Range(0, 8.1f); //오차범위
                    Vector3 v3 = new Vector3(x, y, -5f);

                    monster2.transform.parent = transform;
                    monster2.transform.localPosition = v3;
                    monster2.SetActive(true);
                    Object_Reset.Add(monster2);

                    Human_Index += 1;
                }
            }
        }
    }

    void Create_Mole()
    {
        for (int i = 0; i < Object_Mole.Count -1; i++)
        {
            int a = UnityEngine.Random.Range(0, 100);

            if (a <= Random_Mole)
            {
                GameObject monster = Object_Mole[i];
                GameObject monster2 = Object_Mole[i+1];

                if (!monster.activeSelf)
                {
                    float x = UnityEngine.Random.Range(-8.1f, 0f); //오차범위
                    float y = UnityEngine.Random.Range(-8.5f, 8.5f);
                    Vector3 v3 = new Vector3(x, y, -4f);

                    monster.transform.parent = transform;
                    monster.transform.localPosition = v3;
                    monster.SetActive(true);
                    Object_Reset.Add(monster);
                }

                if (!monster2.activeSelf)
                {
                    float x = UnityEngine.Random.Range(0, 8.1f); //오차범위
                    float y = UnityEngine.Random.Range(-8.5f, 8.5f);
                    Vector3 v3 = new Vector3(x, y, -4f);

                    monster2.transform.parent = transform;
                    monster2.transform.localPosition = v3;
                    monster2.SetActive(true);
                    Object_Reset.Add(monster2);
                }
            }
        }
    }

    void Create_Trash1()
    {
        for (int i = 0; i < Object_Trash1.Count; i++)
        {
            int a = UnityEngine.Random.Range(0, 100);

            if (a <= Random_Trash1)
            {
                GameObject monster = Object_Trash1[i];

                if (!monster.activeSelf)
                {
                    float x = UnityEngine.Random.Range(-8.1f, 0); //오차범위
                    float y = 0;
                    if (i % 2 == 0)
                    {
                        y = UnityEngine.Random.Range(-8.5f, 0);
                    }
                    else
                    {
                        y = UnityEngine.Random.Range(0, 8.5f);
                    }
                    Vector3 v3 = new Vector3(x, y, -5f);

                    monster.transform.parent = transform;
                    monster.transform.localPosition = v3;
                    monster.SetActive(true);
                    Object_Reset.Add(monster);
                }
            }
        }
    }
    void Create_Trash2()
    {
        for (int i = 0; i < Object_Trash2.Count; i++)
        {
            int a = UnityEngine.Random.Range(0, 100);

            if (a <= Random_Trash2)
            {
                GameObject monster = Object_Trash2[i];

                if (!monster.activeSelf)
                {
                    float x = UnityEngine.Random.Range(0, 8.1f); //오차범위
                    float y = 0;
                    if (i % 2 == 0)
                    {
                        y = UnityEngine.Random.Range(-8.5f, 0);
                    }
                    else
                    {
                        y = UnityEngine.Random.Range(0, 8.5f);
                    }
                    Vector3 v3 = new Vector3(x, y, -5f);

                    monster.transform.parent = transform;
                    monster.transform.localPosition = v3;
                    monster.SetActive(true);
                    Object_Reset.Add(monster);
                }
            }
        }
    }

    IEnumerator Create_Car_Right()
    {
        yield return new WaitForSeconds(UnityEngine.Random.Range(Car_Random_CoolTime * 0.5f, Car_Random_CoolTime * 1.0f));
        if (Player_State == true)
        {
            if (Talk_Value == false && Under_Value == false && Castle_Value == false)
            {
                if (Car_Right_Index > Object_Car_Right.Count - 1)
                {
                    Car_Right_Index = 0;
                }

                int a = UnityEngine.Random.Range(0, 100);

                if (a <= Random_Car)
                {
                    GameObject monster = Object_Car_Right[Car_Right_Index];

                    if (!monster.activeSelf)
                    {
                        int idx = UnityEngine.Random.Range(Main_Car_Points.Length / 2 +1, Main_Car_Points.Length);
                        Vector3 v3 = new Vector3(0, 0, -2f);

                        monster.transform.parent = transform;
                        monster.transform.localPosition = Main_Car_Points[idx].localPosition + v3;
                        monster.SetActive(true);
                        Object_Reset.Add(monster);

                        Car_Right_Index += 1;
                        //Debug.Log("오른쪽 차 생성");
                    }
                }
            }
        }
        else
        {
            yield break;
        }
        StartCoroutine(Create_Car_Right());
    }

    IEnumerator Create_Car_Left()
    {
        yield return new WaitForSeconds(UnityEngine.Random.Range(Car_Random_CoolTime * 0.5f, Car_Random_CoolTime * 1.0f));
        if (Player_State == true)
        {
            if (Talk_Value == false && Under_Value == false && Castle_Value == false)
            {
                if (Car_Left_Index > Object_Car_Left.Count - 1)
                {
                    Car_Left_Index = 0;
                }

                int a = UnityEngine.Random.Range(0, 100);

                if (a <= Random_Car)
                {
                    GameObject monster = Object_Car_Left[Car_Left_Index];

                    if (!monster.activeSelf)
                    {
                        int idx = UnityEngine.Random.Range(1, Main_Car_Points.Length / 2 + 1); //1부터 해야됨
                        Vector3 v3 = new Vector3(0, 0, -2f);

                        monster.transform.parent = transform;
                        monster.transform.localPosition = Main_Car_Points[idx].localPosition + v3;
                        monster.SetActive(true);
                        Object_Reset.Add(monster);

                        Car_Left_Index += 1;
                        //Debug.Log("왼쪽 차 생성");
                    }
                }
            }
        }
        else
        {
            yield break;
        }
        StartCoroutine(Create_Car_Left());
    }

    void Create_God()
    {
        for (int i = 0; i < Object_God.Count; i++)
        {
            int a = UnityEngine.Random.Range(0, 100);

            if (a <= Random_God)
            {
                GameObject monster = Object_God[i];

                if (!monster.activeSelf)
                {
                    Vector3 v3 = new Vector3(0, 0, -4f);

                    monster.transform.parent = transform;
                    monster.transform.position = God_Point[i + 1].position + v3;
                    monster.SetActive(true);
                    Object_Reset.Add(monster);
                }
            }
        }
    }

    void Create_Castle()
    {
        for (int i = 0; i < Castle_Point.Length -1; i++)
        {
            int a = UnityEngine.Random.Range(0, 100);

            if (a <= Random_Castle)
            {
                GameObject monster = Object_Castle[i];

                if (!monster.activeSelf)
                {
                    monster.transform.parent = transform;
                    monster.transform.position = Castle_Point[i + 1].position + new Vector3(0, 0, -11);
                    monster.SetActive(true);
                    Object_Reset.Add(monster);
                }
            }
        }
    }

    void Create_Ship()
    {
        for (int i = 0; i < Ship_Point.Length -1; i++)
        {
            int a = UnityEngine.Random.Range(0, 100);

            if (a <= Random_Ship)
            {
                GameObject monster = Object_Ship[i];

                if (!monster.activeSelf)
                {
                    monster.transform.parent = transform;
                    monster.transform.position = Ship_Point[i + 1].position + new Vector3(0, 0, -4f);
                    monster.SetActive(true);
                    Object_Reset.Add(monster);
                }
            }
        }
    }
}

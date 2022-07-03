using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderCtrl : MonoBehaviour
{
    public GameObject trans;
    public GameObject Mole;
    public GameObject Item;

    private int Mole_Value;
    private int Item_Value;

    public List<GameObject> Enemy_Mole = new List<GameObject>();
    public List<GameObject> Object_Item = new List<GameObject>();

    public List<GameObject> Under_Object = new List<GameObject>(); //초기화


    void Awake()
    {

        trans.GetComponent<Transform>();

        for (int i = 0; i < 40; i++)
        {
            GameObject Enemy_mole = Instantiate(Mole);
            Enemy_mole.name = "Enemy_Mole_" + i.ToString();
            Enemy_mole.SetActive(false);
            Enemy_Mole.Add(Enemy_mole);
        }

        for (int i = 0; i < 12; i++)
        {
            GameObject item = Instantiate(Item);
            item.name = "Item_" + i.ToString();
            item.SetActive(false);
            Object_Item.Add(item);
        }
    }

    void OnEnable()
    {
        Mole_Value = 0;
        Item_Value = 0;

        Create_Reward(-3,7.0f,3);
        Create_Points(-3f,0,3f,6f);
    }

    void OnDisable()
    {
        for (int i = 0; i < Under_Object.Count; i++)
        {
            Under_Object[i].SetActive(false);
        }
        Under_Object.Clear();
    }
    void Create_Reward(float Pos_x, float Pos_y, float Max_x)
    {
        float x = (Mathf.Abs(Pos_x) + Max_x) / (Object_Item.Count+1);

        float plus_x = x;

        for (int i = 0; i < Object_Item.Count; i++)
        {
            if (Item_Value > Object_Item.Count - 1)
            {
                Item_Value = 0;
            }

            GameObject monster = Object_Item[Item_Value];
            if (!monster.activeSelf)
            {
                monster.transform.parent = trans.transform;
                monster.transform.position = new Vector3(Pos_x + x, Pos_y, 6);
                monster.SetActive(true);
                Under_Object.Add(monster);

                Item_Value += 1;
                x += plus_x;
            }
        }
    }

    void Create_Points(float Start_Pos_x, float Start_Pos_y, float End_Pos_x, float End_Pos_y) //(-3 , 0) ~ (3 , 6.5)
    {
        int index = 0;
        for (int i = 0; i < Enemy_Mole.Count; i++)
        {
            if (Mole_Value > Enemy_Mole.Count - 1)
            {
                Mole_Value = 0;
            }

            GameObject monster = Enemy_Mole[Mole_Value];
            if (!monster.activeSelf)
            {
                float x1 = Random.Range(Start_Pos_x, 0);
                float x2 = Random.Range(0, End_Pos_x);
                float y = Random.Range(Start_Pos_y, End_Pos_y);
                monster.transform.parent = trans.transform;
                if(index %2 ==0)
                {
                    monster.transform.position = new Vector3(x1, y, 6);
                }
                else
                {
                    monster.transform.position = new Vector3(x2, y, 6);
                }
                monster.SetActive(true);
                Under_Object.Add(monster);

                Mole_Value += 1;
                index += 1;
            }
        }
    }
}

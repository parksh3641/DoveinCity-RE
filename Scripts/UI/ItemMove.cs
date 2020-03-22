using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMove : MonoBehaviour
{
    //아이템 생동감
    private Transform trans;
    private Coin Main_Coin;
    private int main = 0;
    private bool Main;
    private float CoolTime = 0.05f;



    void Awake()
    {
        trans = GetComponent<Transform>();
        main = 0;
        Main = false;
    }
    void OnEnable()
    {
        StartCoroutine(Item_Lively());
    }

    void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator Item_Lively()
    {
        if (Main == false)
        {
            if (main < 15)
            {
                main += 1;
            }
            else
            {
                Main = true;
            }
        }
        else
        {
            if (main > -15)
            {
                main -= 1;
            }
            else
            {
                Main = false;
            }
        }
        trans.rotation = Quaternion.Euler(0, 0, main);
        yield return new WaitForSeconds(CoolTime);
        StartCoroutine(Item_Lively());
    }
}

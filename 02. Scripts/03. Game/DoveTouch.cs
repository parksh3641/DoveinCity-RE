using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DoveTouch : MonoBehaviour
{
    public static DoveTouch instance;

    public GameObject Dove;

    private int posx = 0;
    private int posy = 0;

    public float Dove_Speed = 0;
    private float Upgrade_Move = 0;

    private bool Player_State;
    private bool Talk_Value;
    private bool Minipoiton;
    private bool Hidden_Value;
    private bool Hidden_Move_Value;

    void Awake()
    {
        instance = this;

        Player_State = true;
        Talk_Value = false;
        Minipoiton = false;

        Hidden_Value = false;
        Hidden_Move_Value = false;

        posx = Screen.width;
        posy = Screen.height;
    }

    void Start()
    {
        Dove_Speed = SystemManager.instance.Dove_Speed;
        Upgrade_Move = SystemManager.instance.Upgrade_Move;

        Dove_Speed = Dove_Speed + (Dove_Speed * (Upgrade_Move * 0.01f));
    }

    public void Stage_Up()
    {
        Dove_Speed = SystemManager.instance.Dove_Speed;
        Dove_Speed = Dove_Speed + (Dove_Speed * (Upgrade_Move * 0.01f));
    }

    void OnEnable()
    {
        GameManager.Player_Die += Player_Die;
        GameManager.Player_Alive += Player_Alive;
        GameManager.Talk_In += Talk_In;
        GameManager.Talk_Out += Talk_Out;
        GameManager.Under_In += Under_In;
        GameManager.Castle_In += Castle_In;
        GameManager.Castle_Out += Hidden_Out;
        GameManager.Under_Out += Hidden_Out;
    }

    void OnDisable()
    {
        GameManager.Player_Die -= Player_Die;
        GameManager.Player_Alive -= Player_Alive;
        GameManager.Talk_In -= Talk_In;
        GameManager.Talk_Out -= Talk_Out;
        GameManager.Under_In -= Under_In;
        GameManager.Castle_In -= Castle_In;
        GameManager.Castle_Out -= Hidden_Out;
        GameManager.Under_Out -= Hidden_Out;
    }

    void Player_Die()
    {
        try
        {
            Player_State = false;
            Talk_Value = false;
            Minipoiton = false;
        }
        catch (NullReferenceException ie)
        {
            print(ie.Message);

            GameManager.Player_Die += Player_Die;

            Player_State = false;
            Talk_Value = false;
            Minipoiton = false;
        }
    }
    void Player_Alive()
    {
        try
        {
            Player_State = true;
        }
        catch (NullReferenceException ie)
        {
            print(ie.Message);

            GameManager.Player_Alive += Player_Alive;

            Player_State = true;
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

    public void Minipoiton_In()
    {
        Minipoiton = true;
    }
    public void Minipoiton_Out()
    {
        Minipoiton = false;
    }

    void Under_In()
    {
        try
        {
            Hidden_Value = true;
            Hidden_Move_Value = true;

            Dove_Speed = 0.5f;

            StartCoroutine(Hidden_World_Wait());
        }
        catch (NullReferenceException ie)
        {
            print(ie.Message);

            GameManager.Under_In += Under_In;

            Hidden_Value = true;
            Hidden_Move_Value = true;

            Dove_Speed = 0.5f;

            StartCoroutine(Hidden_World_Wait());
        }
    }
    void Castle_In()
    {
        try
        {
            Hidden_Value = false;
            Hidden_Move_Value = true;

            Dove_Speed = 0.5f;

            StartCoroutine(Hidden_World_Wait());
        }
        catch (NullReferenceException ie)
        {
            print(ie.Message);

            GameManager.Castle_In += Castle_In;

            Hidden_Value = false;
            Hidden_Move_Value = true;

            Dove_Speed = 0.5f;

            StartCoroutine(Hidden_World_Wait());
        }

    }
    void Hidden_Out()
    {
        try
        {
            Hidden_Value = true;
            Hidden_Move_Value = true;

            Stage_Up();

            StartCoroutine(Hidden_World_Wait());
        }
        catch (NullReferenceException ie)
        {
            print(ie.Message);

            GameManager.Castle_Out += Hidden_Out;
            GameManager.Under_Out += Hidden_Out;

            Hidden_Value = true;
            Hidden_Move_Value = true;

            Stage_Up();

            StartCoroutine(Hidden_World_Wait());
        }
    }

    IEnumerator Hidden_World_Wait()
    {
        yield return new WaitForSeconds(3f);

        Hidden_Value = false;
        Hidden_Move_Value = false;
    }


    void Update()
    {
        if (Player_State == true && Talk_Value == false && Hidden_Value == false && Hidden_Move_Value == false)
        {
            if (Minipoiton == false)
            {
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    Dove.GetComponent<Transform>().Translate(Dove_Speed * 1.3f * Time.deltaTime, 0, 0);
                }
                else if (Input.GetKey(KeyCode.LeftArrow))
                {
                    Dove.GetComponent<Transform>().Translate(-Dove_Speed * 1.3f * Time.deltaTime, 0, 0);
                }
                else if (Input.GetKey(KeyCode.UpArrow))
                {
                    Dove.GetComponent<Transform>().Translate(0, Dove_Speed * 1.3f * Time.deltaTime, 0);
                }
                else if (Input.GetKey(KeyCode.DownArrow))
                {
                    Dove.GetComponent<Transform>().Translate(0, -Dove_Speed * 1.3f * Time.deltaTime, 0);
                }

                if (Input.touchCount > 0)
                {
                    Touch touch = Input.GetTouch(0);
                    Vector2 pos = touch.position;

                    if (pos.y > posy * 0.13f && pos.y < posy * 0.78f)
                    {
                        if (pos.x >= posx * 0.5f)
                        {
                            Dove.GetComponent<Transform>().Translate(Dove_Speed * 1.3f * Time.deltaTime, 0, 0);
                        }
                        else
                        {
                            Dove.GetComponent<Transform>().Translate(-Dove_Speed * 1.3f * Time.deltaTime, 0, 0);

                        }
                    }
                }
            }
            else
            {
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    Dove.GetComponent<Transform>().Translate(Dove_Speed * 1.5f * Time.deltaTime, 0, 0);
                }
                else if (Input.GetKey(KeyCode.LeftArrow))
                {
                    Dove.GetComponent<Transform>().Translate(-Dove_Speed * 1.5f * Time.deltaTime, 0, 0);
                }
                else if (Input.GetKey(KeyCode.UpArrow))
                {
                    Dove.GetComponent<Transform>().Translate(0, Dove_Speed * 1.5f * Time.deltaTime, 0);
                }
                else if (Input.GetKey(KeyCode.DownArrow))
                {
                    Dove.GetComponent<Transform>().Translate(0, -Dove_Speed * 1.5f * Time.deltaTime, 0);
                }

                if (Input.touchCount > 0)
                {
                    Touch touch = Input.GetTouch(0);
                    Vector2 pos = touch.position;

                    if (pos.y > posy * 0.13f && pos.y < posy * 0.78f)
                    {
                        if (pos.x >= posx * 0.5f)
                        {
                            Dove.GetComponent<Transform>().Translate(Dove_Speed * 1.5f * Time.deltaTime, 0, 0);
                        }
                        else
                        {
                            Dove.GetComponent<Transform>().Translate(-Dove_Speed * 1.5f * Time.deltaTime, 0, 0);

                        }
                    }
                }
            }
        }
        else
        {
            if (Hidden_Value == true)
            {
                Dove.GetComponent<Transform>().Translate(0, 0.5f * Time.deltaTime, 0);
            }
            else
            {
                Dove.GetComponent<Transform>().Translate(0, 0, 0);
            }
        }
    }
}

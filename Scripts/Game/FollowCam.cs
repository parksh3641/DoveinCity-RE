using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FollowCam : MonoBehaviour
{
    public static FollowCam instance;

    private bool Player_State;

    public Transform Dove;

    public float x = 0;
    public float y = 99;
    public float DoveWidth = 0;

    public float ShakeAmount;
    public float ShakeTime;

    private bool Shaking;

    private float Camera_Size;
    private float Skill_Time;

    private bool Skill_Use;

    private bool Cam_Value;
    private bool Under_Value;
    private bool Castle_Value;
    void Awake()
    {
        Dove = GameObject.FindWithTag("Player").GetComponent<Transform>();

        instance = this;
        Camera_Size = 1;
        Skill_Use = false;
        Cam_Value = false;
        Under_Value = false;
        Castle_Value = false;
    }

    void Start()
    {
        Player_State = true;

        ShakeAmount = SystemManager.instance.ShakeAmount;
        ShakeTime = SystemManager.instance.ShakeTime;

        Skill_Time = SystemManager.instance.Skill_Time;

    }
    void OnEnable()
    {
        SkillManager.Skill_In += Skill_In;
        GameManager.Player_Die += Player_Die;
        GameManager.Player_Alive += Player_Alive;
        GameManager.Under_In += Under_In;
        GameManager.Under_Out += Under_Out;
        GameManager.Castle_In += Castle_In;
        GameManager.Castle_Out += Castle_Out;
    }
    void OnDisable()
    {
        SkillManager.Skill_In -= Skill_In;
        GameManager.Player_Die -= Player_Die;
        GameManager.Player_Alive -= Player_Alive;
        GameManager.Under_In -= Under_In;
        GameManager.Under_Out -= Under_Out;
        GameManager.Castle_In -= Castle_In;
        GameManager.Castle_Out -= Castle_Out;
    }

    void Skill_In()
    {
        Skill_Use = true;
        StartCoroutine(Size_Up());
        StartCoroutine(Camera_Size_Wait());
    }

    void Player_Die()
    {
        try
        {
            Player_State = false;
        }
        catch (NullReferenceException ie)
        {
            print(ie.Message);

            GameManager.Player_Die += Player_Die;

            Player_State = false;

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

    void Under_In()
    {
        try
        {
            Cam_Value = true;

            Under_Value = true;
            StartCoroutine(Cam_Wait());
        }
        catch (NullReferenceException ie)
        {
            print(ie.Message);

            Cam_Value = true;

            GameManager.Under_In += Under_In;

            StopAllCoroutines();

            Under_Value = true;
            StartCoroutine(Cam_Wait());
        }
    }
    void Under_Out()
    {
        try
        {
            Cam_Value = true;

            Under_Value = false;
            StartCoroutine(Cam_Wait());
        }
        catch (NullReferenceException ie)
        {
            print(ie.Message);

            GameManager.Under_Out += Under_Out;

            StopAllCoroutines();

            Cam_Value = true;

            Under_Value = false;
            StartCoroutine(Cam_Wait());
        }
    }
    void Castle_In()
    {
        try
        {
            Cam_Value = true;

            Castle_Value = true;
            StartCoroutine(Cam_Wait());
        }
        catch (NullReferenceException ie)
        {
            print(ie.Message);

            GameManager.Castle_In += Castle_In;

            StopAllCoroutines();

            Cam_Value = true;

            Castle_Value = true;
            StartCoroutine(Cam_Wait());
        }
    }
    void Castle_Out()
    {
        try
        {
            Cam_Value = true;

            Castle_Value = false;
            StartCoroutine(Cam_Wait());
        }
        catch (NullReferenceException ie)
        {
            print(ie.Message);

            GameManager.Castle_Out += Castle_Out;

            StopAllCoroutines();

            Cam_Value = true;

            Castle_Value = false;
            StartCoroutine(Cam_Wait());
        }
    }

    IEnumerator Cam_Wait()
    {
        yield return new WaitForSeconds(3);
        Cam_Value = false;

        if(Under_Value == true || Castle_Value == true)
        {
            if(Under_Value == true)
            {
                x = 2.45f;
            }
            else if(Castle_Value == true)
            {
                x = 0.71f;
            }
        }
        else
        {
            x = 4.25f;
        }
    }



    public void Hp_Minus(int number)
    {
        Shaking = true;
        StartCoroutine(Shake(ShakeAmount * number, ShakeTime));
    }

    IEnumerator Shake(float ShakeAmount, float ShakeTime)
    {
        float timer = 0;
        while (timer <= ShakeTime)
        {
            Vector2 ShakePos = UnityEngine.Random.insideUnitCircle * ShakeAmount;

            transform.position += new Vector3(ShakePos.x,ShakePos.y,0);
            timer += Time.deltaTime;
            yield return null;
        }
        Shaking = false;
    }
    IEnumerator Camera_Size_Wait()
    {
        yield return new WaitForSeconds(Skill_Time / 2);
        Skill_Use = false;
    }
    IEnumerator Size_Up()
    {
        if (Player_State == true)
        {
            if (Skill_Use == true)
            {
                if (Camera_Size < 1.3f)
                {
                    Camera_Size += 0.001f;
                }
            }
            else
            {
                StartCoroutine(Size_Down());
                yield break;
            }
        }
        else
        {
            StartCoroutine(Size_Down());
            yield break;
        }
        Camera.main.orthographicSize = Camera_Size;
        yield return new WaitForSeconds(0.01f);
        StartCoroutine(Size_Up());
    }
    IEnumerator Size_Down()
    {
        if (Player_State == true)
        {
            if (Camera_Size >= 1)
            {
                Camera_Size -= 0.001f;
            }
            else
            {
                yield break;
            }
        }
        else
        {
            if (Camera_Size >= 1)
            {
                Camera_Size -= 0.008f;
            }
            else
            {
                Camera_Size = 1;
                yield break;
            }
        }
        Camera.main.orthographicSize = Camera_Size;
        yield return new WaitForSeconds(0.01f);
        StartCoroutine(Size_Down());
    }






    void LateUpdate()
    {
        if (Cam_Value == false)
        {
            if (Shaking == false)
            {
                transform.position = new Vector3(Mathf.Clamp(Dove.position.x, -x, x), Mathf.Clamp((Dove.position.y - DoveWidth), -y, y), -10);
            }
        }
    }
}

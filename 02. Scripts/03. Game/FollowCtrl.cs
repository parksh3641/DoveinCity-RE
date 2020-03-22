using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FollowCtrl : MonoBehaviour
{
    public static FollowCtrl instance;

    public int Value = 0;

    public enum FollowType
    {
        MoveTowards,
        Lerp
    }
    public FollowType Type = FollowType.MoveTowards;
    public FollowLine line;
    public float speed;
    public float MaxDistanceToGoal = 0.1f;

    private IEnumerator<Transform> _currentPoint;

    private bool Player_State;

    void Awake()
    {
        instance = this;
        Player_State = true;
    }
    public void Start()
    {
        if (line == null)
        {
            Debug.LogError("아무것도 할당되지 않았습니다", gameObject);
            return;
        }
        _currentPoint = line.GetPathEnumerator();
        _currentPoint.MoveNext();

        if (_currentPoint.Current == null)
            return;

        transform.position = _currentPoint.Current.position;
    }
    void OnEnable()
    {
        GameManager.Player_Die += Player_Die;
        GameManager.Player_Alive += Player_Alive;
        GameManager.Talk_In += Talk_In;
        GameManager.Talk_Out += Talk_Out;

        if (Value == 0)
        {
            speed = SystemManager.instance.Dove_Speed;
        }
        else
        {
            speed = SystemManager.instance.Dove_Speed * 0.35f;
        }
    }
    void OnDisable()
    {
        GameManager.Player_Die -= Player_Die;
        GameManager.Player_Alive -= Player_Alive;
        GameManager.Talk_In -= Talk_In;
        GameManager.Talk_Out -= Talk_Out;
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
    void Talk_In()
    {
        try
        {
            speed = 0;
        }
        catch (NullReferenceException ie)
        {
            print(ie.Message);

            GameManager.Talk_In += Talk_In;

            speed = 0;
        }
    }
    void Talk_Out()
    {
        try
        {
            if (Value == 0)
            {
                speed = SystemManager.instance.Dove_Speed;
            }
            else
            {
                speed = SystemManager.instance.Dove_Speed * 0.35f;
            }
        }
        catch (NullReferenceException ie)
        {
            print(ie.Message);

            GameManager.Talk_Out += Talk_Out;

            if (Value == 0)
            {
                speed = SystemManager.instance.Dove_Speed;
            }
            else
            {
                speed = SystemManager.instance.Dove_Speed * 0.35f;
            }
        }
    }

    public void Stage_Up()
    {
        if (Value == 0)
        {
            speed = SystemManager.instance.Dove_Speed;
        }
        else
        {
            speed = SystemManager.instance.Dove_Speed * 0.35f;
        }
    }

    public void Update()
    {
        if (Player_State == true)
        {
            if (_currentPoint == null || _currentPoint.Current == null)
                return;

            if (Type == FollowType.MoveTowards)
                transform.position = Vector3.MoveTowards(transform.position, _currentPoint.Current.position, Time.deltaTime * speed);
            else if (Type == FollowType.Lerp)
                transform.position = Vector3.Lerp(transform.position, _currentPoint.Current.position, Time.deltaTime * speed);

            var distanceSquard = (transform.position - _currentPoint.Current.position).sqrMagnitude;
            if (distanceSquard < MaxDistanceToGoal * MaxDistanceToGoal)
                _currentPoint.MoveNext();
        }
    }
}

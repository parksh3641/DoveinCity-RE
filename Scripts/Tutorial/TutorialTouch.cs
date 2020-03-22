using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTouch : MonoBehaviour
{
    public static TutorialTouch instance;

    public GameObject Dove;

    private int posx = 0;
    private int posy = 0;

    public float Dove_Speed = 0.5f;

    private bool Move_Value;
    private bool Pause_Value;

    void Awake()
    {
        instance = this;

        Pause_Value = false;
        Move_Value = false;

        posx = Screen.width;
        posy = Screen.height;
    }

    public void Move_On()
    {
        Move_Value = true;
    }
    public void Move_Off()
    {
        Move_Value = false;
    }


    public void Pause()
    {
        Pause_Value = true;
    }
    public void UnPause()
    {
        Pause_Value = false;
    }


    void Update()
    {
        if (Pause_Value == false && Move_Value == true)
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

                if (pos.y > posy * 0.13f && pos.y < posy * 0.92f)
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
    }
}

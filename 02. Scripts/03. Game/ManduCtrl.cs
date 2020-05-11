using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManduCtrl : MonoBehaviour
{
    private Transform Main_sp;
    private Transform Player;
    private CapsuleCollider2D box;

    private float Rotation_value = 600;
    private float x;

    public int Mandu_Check; //1 만두, 2 돌, 3 두더지

    public Transform trans;

    public int DoveChoice;
    private int Mandu_Hp;
    public int Stone_Damage;

    private float speed;
    private float Map_speed;

    private bool magnet;
    private bool hourglass;

    private float Angle;

    void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Main_sp = GetComponent<Transform>();
        box = GetComponent<CapsuleCollider2D>();
    }

    void Start()
    {
        DoveChoice = SystemManager.instance.DoveChoice;
        Mandu_Hp = SystemManager.instance.Mandu_Hp;
        Stone_Damage = SystemManager.instance.Stone_Damage;
    }

    void OnEnable()
    {
        Map_speed = SystemManager.instance.Dove_Speed;

        box.size = new Vector2(1f, 1f);

        if (Mandu_Check == 1 || Mandu_Check == 2) //만두, 돌
        {
            speed = Random.Range(SystemManager.instance.Dove_Speed * 1.0f, SystemManager.instance.Dove_Speed * 1.5f);
            Angle = Random.Range(-Map_speed * 0.5f, Map_speed * 0.25f);

            if (Mandu_Check == 1)
            {
                box.size = new Vector2(1.5f, 1.5f);
            }
        }
        else //지하세계 두더지
        {
            speed = Random.Range(SystemManager.instance.Dove_Speed * 0.8f, SystemManager.instance.Dove_Speed * 1.0f);
            Angle = Random.Range(-Map_speed * 1f, Map_speed * 1f);
            float x = Random.Range(0.07f, 0.13f);
            Main_sp.localScale = new Vector2(x, x);
        }

        Vector3 control = Player.position + new Vector3(0, Angle, 0); //각도 조절

        Vector2 relativePos = control - transform.position;
        float angle = Mathf.Atan2(relativePos.y, relativePos.x) * Mathf.Rad2Deg;
        transform.localRotation = Quaternion.Euler(0, 0, angle - 90);

        magnet = false;
        hourglass = false;

        StartCoroutine(Item_Check());
        StartCoroutine(Delete_Time());
    }
    void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator Item_Check()
    {
        int a = PlayerPrefs.GetInt("Item_Magnet");
        if(a == 1)
        {
            if(Mandu_Check == 1)
            {
                magnet = true;
            }
        }
        else
        {
            magnet = false;
        }

        int b = PlayerPrefs.GetInt("Item_Hourglass");

        if (b == 1)
        {
            hourglass = true;
        }
        else
        {
            hourglass = false;
        }
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(Item_Check());
    }

    IEnumerator Delete_Time()
    {
        yield return new WaitForSeconds(10f);
        gameObject.SetActive(false);
    }


    void Update()
    {
        x += Time.deltaTime * Rotation_value;
        trans.rotation = Quaternion.Euler(0, 0, x);

        if(magnet == false)
        {
            if(hourglass == true)
            {
                transform.Translate(0, speed * 0.7f * Time.deltaTime, 0);
            }
            else
            {
                transform.Translate(0, speed * Time.deltaTime, 0);
            }
        }
        else
        {
            if(Mandu_Check == 1)
            {
                Vector2 relativePos = Player.transform.position - transform.position;
                float angle = Mathf.Atan2(relativePos.y, relativePos.x) * Mathf.Rad2Deg;
                transform.localRotation = Quaternion.Euler(0, 0, angle - 90);
                transform.Translate(transform.up * speed * 1.5f * Time.deltaTime, Space.World);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            if (DoveChoice == 1 || DoveChoice == 3)
            {
                if (Mandu_Check == 2)
                {
                    GameManager.instance.Hp_Minus_Kind(1);
                    GameManager.instance.Hp_Minus(Stone_Damage);
                }
            }

            if(Mandu_Check == 3)
            {
                GameManager.instance.Hp_Minus_Kind(1);
                GameManager.instance.Hp_Minus(Stone_Damage);
            }
        }

        else if (coll.gameObject.tag == "Player2")
        {
            if (DoveChoice != 3)
            {
                if (Mandu_Check == 1)
                {
                    gameObject.SetActive(false);
                    if(DoveChoice != 4)
                    {
                        GameManager.instance.Hp_Plus(Mandu_Hp);
                    }
                    else
                    {
                        GameManager.instance.Hp_Plus(Mandu_Hp / 2);
                    }
                }
            }
        }

        if (GameManager.instance.fever == false)
        {
            if (coll.gameObject.tag == "Duck" && DoveCtrl.instance.Hit_Value == false)
            {
                if (Mandu_Check == 2 || Mandu_Check == 3)
                {
                    gameObject.SetActive(false);
                    GameManager.instance.Aid_Duck_Shield_Off();
                }
            }
        }
    }

}

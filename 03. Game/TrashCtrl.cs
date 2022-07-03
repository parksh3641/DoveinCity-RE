using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCtrl : MonoBehaviour
{
    private Transform Player;
    public int Trash_Default;
    private int Object_Trash_Hp;

    private int DoveChoice;

    private bool Trash_Value;

    private SpriteRenderer sprite;

    public Sprite Trash_1_Full;
    public Sprite Trash_1_Empty;

    public Sprite Trash_2_Full;
    public Sprite Trash_2_Empty;

    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Trash_Value = true;
    }

    void Start()
    {
        DoveChoice = SystemManager.instance.DoveChoice;
        Object_Trash_Hp = SystemManager.instance.Object_Trash_Hp;
    }

    void OnEnable()
    {
        if (Trash_Default == 1)
        {
            sprite.sprite = Trash_1_Full;
        }
        else
        {
            sprite.sprite = Trash_2_Full;
        }

        Trash_Value = true;

        StartCoroutine(Player_Distance());
    }

    void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator Player_Distance()
    {
        if (transform.position.y < Player.position.y - 2.5f)
        {
            transform.rotation = Quaternion.identity;
            gameObject.SetActive(false);
        }
        yield return new WaitForSeconds(1f);
        StartCoroutine(Player_Distance());
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Wall" || coll.gameObject.tag == "Building" || coll.gameObject.tag == "Building2" || coll.gameObject.tag == "CastleWall" || coll.gameObject.tag == "OliveTree"
            || coll.gameObject.tag == "Ship")
        {
            Debug.Log("우왁");
            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Wall" || coll.gameObject.tag == "Building" || coll.gameObject.tag == "Building2" || coll.gameObject.tag == "CastleWall" || coll.gameObject.tag == "OliveTree"
            || coll.gameObject.tag == "Ship")
        {
            gameObject.SetActive(false);
        }

        if (coll.gameObject.tag == "Player2")
        {
            if (DoveChoice == 1)
            {
                if (Trash_Value == true)
                {
                    Trash_Value = false;
                    GameManager.instance.Hp_Plus(Object_Trash_Hp);
                    Trash_Check();
                }
            }
        }
    }

    void Trash_Check()
    {
        if(Trash_Default == 1)
        {
            sprite.sprite = Trash_1_Empty;
        }
        else
        {
            sprite.sprite = Trash_2_Empty;
        }
    }

}

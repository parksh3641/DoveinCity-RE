using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialDove : MonoBehaviour
{
    public static TutorialDove instance;

    private Animator anim;
    public Animator Shadow_anim;

    public GameObject Branch;

    private SpriteRenderer sprite;
    public SpriteRenderer Shadow_sprite;

    private CapsuleCollider2D box;

    public Sprite Black_Start;
    public Sprite Black_Skill;
    public Sprite Black_Die;


    public float x = 0.45f;
    private float Dove_Size;
    private float Shadow_Size;

    private float Skill_Time;
    private bool Skill_Value;


    void Awake()
    {
        instance = this;

        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        box = GetComponent<CapsuleCollider2D>();

        Branch.SetActive(false);
    }

    void Start()
    {
        StartCoroutine(Start_Wait());
    }

    public void Player_Die()
    {
        StopAllCoroutines();

        anim.enabled = false;
        Shadow_anim.enabled = false;

        sprite.sprite = Black_Die;
        Shadow_sprite.sprite = Black_Die;

        box.enabled = false;

        sprite.color = new Color(1, 1, 1, 1);
        Shadow_sprite.color = new Color(0, 0, 0, 0.5f);

        Shadow_sprite.GetComponent<Transform>().localPosition = new Vector3(0.1f, -0.2f, 1);
        transform.localScale = new Vector3(0.095f, 0.095f, 1);

    }
    public void Player_Alive()
    {
        anim.enabled = true;
        Shadow_anim.enabled = true;

        Shadow_sprite.GetComponent<Transform>().localPosition = new Vector3(0.3f, -0.4f, 1);
        transform.localScale = new Vector3(0.13f, 0.13f, 1);

        box.enabled = true;
    }

    public void Hit()
    {
        StartCoroutine(Invincibel_Wait(sprite, Shadow_sprite));
    }

    public void Skill_On()
    {
        anim.enabled = false;
        Shadow_anim.enabled = false;

        box.enabled = false;

        sprite.sprite = Black_Skill;
        Shadow_sprite.sprite = Black_Skill;

        Skill_Value = true;
        Dove_Size = 0.13f;
        Shadow_Size = 0.7f;
        Skill_Time = 5;
        StartCoroutine(Size_Up());
        StartCoroutine(Size_Wait());
    }

    public void Skill_Off()
    {
        anim.enabled = true;
        Shadow_anim.enabled = true;

        box.enabled = true;
    }

    public void Weather_Sun()
    {
        gameObject.tag = "Sun";
    }

    public void Weather_Moon()
    {
        gameObject.tag = "Moon";
    }

    IEnumerator Size_Wait()
    {
        yield return new WaitForSeconds(Skill_Time / 2);
        Skill_Value = false;
    }
    IEnumerator Size_Up()
    {
        if (Skill_Value == true)
        {
            if (Dove_Size <= 0.26f)
            {
                Dove_Size += 0.00039f;
                Shadow_Size -= 0.00105f;
            }
        }
        else
        {
            StartCoroutine(Size_Down());
            yield break;
        }
        sprite.transform.localScale = new Vector3(Dove_Size, Dove_Size, 1);
        Shadow_sprite.transform.localScale = new Vector3(Shadow_Size, Shadow_Size, 1);
        yield return new WaitForSeconds(0.01f);
        StartCoroutine(Size_Up());
    }
    IEnumerator Size_Down()
    {
        if (Dove_Size >= 0.13f)
        {
            Dove_Size -= 0.00039f;
            Shadow_Size += 0.00105f;
        }
        else
        {
            Dove_Size = 0.13f;
            Shadow_Size = 0.7f;
            sprite.transform.localScale = new Vector3(Dove_Size, Dove_Size, 1);
            Shadow_sprite.transform.localScale = new Vector3(Shadow_Size, Shadow_Size, 1);

            yield break;
        }
        sprite.transform.localScale = new Vector3(Dove_Size, Dove_Size, 1);
        Shadow_sprite.transform.localScale = new Vector3(Shadow_Size, Shadow_Size, 1);
        yield return new WaitForSeconds(0.01f);
        StartCoroutine(Size_Down());
    }


    IEnumerator Start_Wait()
    {
        anim.enabled = false;
        Shadow_anim.enabled = false;
        sprite.sprite = Black_Start;
        Shadow_sprite.sprite = Black_Start;
        yield return new WaitForSeconds(6f);
        anim.enabled = true;
        Shadow_anim.enabled = true;
    }

    IEnumerator Invincibel_Wait(SpriteRenderer Main_sp, SpriteRenderer Shadow_sp)
    {
        for (int i = 0; i < 4; i++)
        {
            Main_sp.color = new Color(1, 1, 1, 0.5f);
            Shadow_sp.color = new Color(0, 0, 0, 0.25f);
            yield return new WaitForSeconds(0.15f);
            Main_sp.color = new Color(1, 1, 1, 1);
            Shadow_sp.color = new Color(0, 0, 0, 0.5f);
            yield return new WaitForSeconds(0.15f);
        }
    }

    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -x, x), transform.position.y, transform.position.z);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Building")
        {
            TutorialManager.instance.InGame_Hp_Minus(100);
        }
    }
}
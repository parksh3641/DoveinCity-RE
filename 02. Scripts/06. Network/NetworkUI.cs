using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkUI : MonoBehaviour
{
    public static NetworkUI instance;

    public Transform Player;
    private Vector3 Player_Which;

    private Transform Player_Hp_Notion;
    public UILabel Nickname_txt;
    public UISprite Filter;

    //체력
    public float Player_Hp;



    void Awake()
    {
        instance = this;

        Player_Hp_Notion = GetComponent<Transform>();
    }

    public void Player_Search()
    {
        Nickname_txt.text = PhotonNetwork.LocalPlayer.NickName;
    }


    void Update()
    {
#if UNITY_ANDROID || UNITY_IPHONE
        if (Player != null)
        {
            Player_Which = Camera.main.WorldToScreenPoint(Player.transform.localPosition) + new Vector3(-534.0f, -576.0f, 0);
            Player_Hp_Notion.localPosition = new Vector3(Player_Which.x * 1, Player_Which.y * 1, 0) + new Vector3(0f, -280f, 0);
        }
#endif
#if UNITY_EDITOR
        if (Player != null)
        {
            Player_Which = Camera.main.WorldToScreenPoint(Player.transform.localPosition) + new Vector3(-248f, -273.3f, 0);
            Player_Hp_Notion.localPosition = new Vector3(Player_Which.x * 2.13f, Player_Which.y * 2.13f, 0) + new Vector3(0f, -280f, 0);
        }
#endif
    }
}
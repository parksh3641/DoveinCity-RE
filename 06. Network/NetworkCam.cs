using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkCam : MonoBehaviour
{
    public static NetworkCam instance;

    public Transform Player;

    public float x = 0;
    public float y = 0;
    public float Player_Width = 0;


    void Awake()
    {
        instance = this;
    }

    void LateUpdate()
    {
        if(Player != null)
        {
            transform.position = new Vector3(Mathf.Clamp(Player.position.x, -x, x), Mathf.Clamp((Player.position.y - Player_Width), -y, y), -10);
        }
    }
    
}

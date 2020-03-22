using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkPlayer : MonoBehaviourPunCallbacks
{
    public static NetworkPlayer instance;

    public float x = 0;
    public float y = 0;

    private CapsuleCollider2D box;
    public CapsuleCollider2D Shadow_box;

    private PhotonView PV;

    void Awake()
    {
        instance = this;

        x = 4.85f;
        y = 4.7f;

        box = GetComponent<CapsuleCollider2D>();
    }

    void Start()
    {
        if(photonView.IsMine)
        {
            Camera.main.GetComponent<NetworkCam>().Player = transform;
            NetworkUI.instance.GetComponent<NetworkUI>().Player = transform;
            NetworkUI.instance.Player_Search();

            NetworkJoystick.instance.GetComponent<NetworkJoystick>().Player = gameObject;
            NetworkJoystick.instance.GetComponent<NetworkJoystick>().PV = GetComponent<PhotonView>();

            NetworkGameManager.instance.GetComponent<NetworkGameManager>().Player = transform;
        }
    }


    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -x, x), Mathf.Clamp(transform.position.y, -y, y), transform.position.z);
    }
}

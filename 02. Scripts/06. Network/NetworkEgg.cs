using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkEgg : MonoBehaviourPunCallbacks
{
    public static NetworkEgg instance;

    private PhotonView PV;
    public float Speed = 3f;


    void Awake()
    {
        instance = this;

        PV = GetComponent<PhotonView>();
    }

    void Start()
    {
        Destroy(gameObject, 1f);
    }

    void Update()
    {
        transform.Translate(0, Speed * Time.deltaTime, 0);
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Boss")
        {
            EffectManager.instance.Bang();
            Destroy(gameObject);
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OliveMainCtrl : MonoBehaviour
{
    public GameObject Olive;


    void Awake()
    {

    }

    void OnEnable()
    {
        if(Olive.activeSelf == false)
        {
            Olive.SetActive(true);
        }
    }
}

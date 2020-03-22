using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credit : MonoBehaviour
{
    public float speed = 0.12f;
    public float Delete_Time = 40f;
    public GameObject Label;
    public UILabel Main_txt;

    private Vector3 a;

    void OnEnable()
    {
        a = Label.transform.position;

        StartCoroutine(Count());
    }
    void OnDisable()
    {
        Label.transform.position = a;

        StopAllCoroutines();
    }

    IEnumerator Count()
    {
        yield return new WaitForSeconds(Delete_Time);
        SelectManager.instance.Exit();
    }

    void Update()
    {
        Label.transform.Translate(0, speed * Time.deltaTime, 0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCam : MonoBehaviour
{
    public static TutorialCam instance;

    public Transform Dove;

    public float x = 0;
    public float y = 99;
    public float DoveWidth = 0;

    public float ShakeAmount;
    public float ShakeTime;

    private bool Shaking;

    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        ShakeAmount = SystemManager.instance.ShakeAmount;
        ShakeTime = SystemManager.instance.ShakeTime;
    }

    public void Hp_Minus(int number)
    {
        Shaking = true;
        StartCoroutine(Shake(ShakeAmount * number, ShakeTime));
    }

    IEnumerator Shake(float ShakeAmount, float ShakeTime)
    {
        float timer = 0;
        while (timer <= ShakeTime)
        {
            Vector2 ShakePos = Random.insideUnitCircle * ShakeAmount;

            transform.position += new Vector3(ShakePos.x, ShakePos.y, 0);
            timer += Time.deltaTime;
            yield return null;
        }
        Shaking = false;
    }

    void LateUpdate()
    {
        if (Shaking == false)
        {
            transform.position = new Vector3(Mathf.Clamp(Dove.position.x, -x, x), Mathf.Clamp((Dove.position.y - DoveWidth), -y, y), -10);
        }
    }
}

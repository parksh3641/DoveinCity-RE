using UnityEngine;
using System.Collections;

public class Window : MonoBehaviour {

    float duration = 0.15f;
    float startDelay = 0.0f;
    Vector3 scaleTo = new Vector3(1f, 1f, 1f);

    AnimationCurve animationCurve = new AnimationCurve(
    new Keyframe(0f, 0f, 0f, 1f),
    new Keyframe(0.95f, 1.05f, 1f, 1f),
    new Keyframe(1f, 1f, 1f, 0f));

    // 초기화
    void init()
    {
        TweenScale tween = TweenScale.Begin(gameObject, duration, scaleTo);
        tween.duration = duration;
        tween.delay = startDelay;
        //tween.method = UITweener.Method.BounceIn;
        tween.animationCurve = animationCurve;

    }

    void Awake()
    {
        setDisable();
    }
    void OnEnable()
    {
        Open();
    }
    void OnDisable()
    {
        close();
    }

    void Open()
    {
        init();
    }

    public void close()
    {
        setDisable();
    }

    void setDisable()
    {
        gameObject.transform.localScale = new Vector3(0, 0, 0);
        //gameObject.SetActive(false);
    }
}


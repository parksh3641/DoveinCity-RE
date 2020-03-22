using UnityEngine;
using System.Collections;

public class Btn : MonoBehaviour {

    Transform trans;
    UISprite sprite;

    float a;
    Vector3 b;

	void Awake () {
        sprite = GetComponent<UISprite>();
        trans = GetComponent<Transform>();
        a = trans.localScale.x * 0.95f;
        b = new Vector3(trans.localScale.x, trans.localScale.y, trans.localScale.z);
	
	}
    void OnPress(bool isOver)
    {
        sprite.cachedTransform.localScale = (isOver) ? Vector3.one * a : b;
    }
}

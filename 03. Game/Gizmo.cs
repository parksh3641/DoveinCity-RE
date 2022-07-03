using UnityEngine;
using System.Collections;

public class Gizmo : MonoBehaviour{
    public Color _color = Color.yellow;
    public float _radius = 0.1f;

    void OnDrawGizmos() {
        Gizmos.color = _color;
        Gizmos.DrawSphere(transform.position, _radius);

    }
}
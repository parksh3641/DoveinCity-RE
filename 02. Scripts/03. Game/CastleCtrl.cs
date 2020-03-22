using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleCtrl : MonoBehaviour
{
    public SpriteRenderer Map_1;
    public SpriteRenderer Map_2;

    public Sprite A;
    public Sprite B;
    public Sprite C;
    public Sprite D;
    public Sprite E;

    public List<Sprite> Map_sprite = new List<Sprite>();

    public Transform[] Coin_Points;

    private Vector3 hor;

    void OnEnable()
    {
        Map_sprite.Add(A);
        Map_sprite.Add(B);
        Map_sprite.Add(C);
        Map_sprite.Add(D);
        Map_sprite.Add(E);

        StartCoroutine(Random_Map());

        Create_Points(-0.825f, -17.5f, 12, 23, 0.15f, 0.15f); /// 시작 좌표 / 가로 개수/ 반복 횟수/ 가로 간격 / 세로 간격
    }
    void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator Random_Map()
    {
        for(int i =0;i<5;i++)
        {
            Map_1.sprite = Map_sprite[i];
            Map_2.sprite = Map_sprite[i];
            yield return new WaitForSeconds(0.5f);
        }
        StartCoroutine(Random_Map());
    }
    void Create_Points(float Pos_x, float Pos_y, int Hor_Number, int Ver_Number, float Hor_Distance, float Ver_Distance)
    {
        float y = Pos_y;
        for (int j = 0; j < Ver_Number; j++)
        {
            float x = Pos_x;
            for (int k = 0; k < Hor_Number; k++)
            {
                hor = new Vector3(x, y, 0);
                GameManager.instance.Object_Create_Hidden_Coin(hor, 2);
                x += Hor_Distance;
            }
            y += Ver_Distance;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro; 

public class rift : MonoBehaviour
{
    Transform myTransform; // transform 情報を格納する変数
    Vector3 position_start; // 物体の初期位置を格納する変数
    Vector3 position_now; // 物体の現在位置を格納する変
    private bool PlayerON; //プレイヤーが載っているかどうか
    private bool Lift;
    private float Lift_time;


    // Start is called before the first frame update
    void Start()
    {
        myTransform = this.transform; // 物体の transform 情報をリンクする
        position_start = myTransform.position; //初期位置を取り出す
        position_now = position_start; // 最初は同じ場所
        PlayerON = false;
        Lift = false;
        Lift_time = 0.0F;
    }

    // Update is called once per frame
    void Update()
{
    if (PlayerON)
    {
        GameObject[] buttons = GameObject.FindGameObjectsWithTag("Item");

        int totalPush = 0;

        foreach (GameObject button in buttons)
        {
            pushButton btn = button.GetComponent<pushButton>();
            totalPush += btn.isPush;
        }
        Debug.Log(totalPush);
        if (totalPush >= 5)
        {
            Lift_time += Time.deltaTime;

            if (Lift_time >= 1.0f && position_now.y <= 3.5f)
            {
                position_now.y += 0.01f;
                Lift = true;
            }
            else
            {
                Lift = false;
                if (position_now.y >= 3.5f)
                {
                    Lift_time = 0.0F;
                }
            }
        }
    }

    if (!PlayerON && position_now.y > position_start.y)
    {
        position_now.y -= 0.01f;
    }

    myTransform.position = position_now;
}


    
    void OnCollisionEnter(Collision other) // 衝突を判定する関数を呼ぶ
    {
    if (other.gameObject.name == "プレイヤー") // 衝突した物体が「プレイヤー」なら
    {
        PlayerON = true;
    }
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.name == "プレイヤー") // 衝突した物体が「プレイヤー」なら
    {
        PlayerON = false;
    }
    }
}

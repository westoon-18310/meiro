using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class npc : MonoBehaviour
{
    private float vel; // NPCの移動速度
    private System.Random rnd; //乱数生成用
    private int npc_select;
    private int start;
    private float freeze_time;
    private float position_y;
    private double range;
    GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        vel = 0.06F;
        Player = GameObject.Find ("プレイヤー");
        start = 0;
        freeze_time = 0.0F;
        range = 22.0;
        Application.targetFrameRate = 60;   // ← FPSを60に設定
    }
    // Update is called once per frame
    void Update()
    {   
        if(start == 1 && time.gameover == 0){ 
            //プレイヤーが範囲内ならストーカーなり
            if(Player.transform.position.x - transform.position.x < range && Player.transform.position.x - transform.position.x >= 0.0){
                transform.position -= transform.right * vel; 
            }
            else if(Player.transform.position.x - transform.position.x > -range && Player.transform.position.x - transform.position.x <= 0.0){
                transform.position += transform.right * vel; 
            }
            if(Player.transform.position.z - transform.position.z < range && Player.transform.position.z - transform.position.z >= 0.0){
                transform.position -= transform.forward * vel; 
            }
            else if(Player.transform.position.z - transform.position.z > -range && Player.transform.position.z - transform.position.z <= 0.0){
                transform.position += transform.forward * vel; 
            }
            else{
                rnd = new System.Random();
                npc_select = rnd.Next(0,2);
                while(freeze_time < 600.0F){
                    if(npc_select == 0){
                        InvokeRepeating("Forward_Move", 0f, 3f);
                    }
                    else{
                        InvokeRepeating("Back_Move", 0f, 3f);
                    }
                    freeze_time += 0.1F;
                }
                freeze_time = 0.0F;
            }
            if(Math.Abs(transform.eulerAngles.x) > 0f){
                transform.Rotate(0f, 0f,-Math.Abs(transform.eulerAngles.x)); 
            }
            if(Math.Abs(transform.eulerAngles.z) > 0f){
                transform.Rotate(0f, 0f,-Math.Abs(transform.eulerAngles.z)); 
            }
            transform.LookAt(Player.transform);
            this.transform.rotation = Quaternion.Euler(0.0f, this.transform.rotation.eulerAngles.y, 0.0f);
            this.transform.Rotate(0.0f, -40.0f, 0.0f);
        }
    }
    void OnCollisionEnter(Collision other){   // 衝突を判定する関数を呼ぶ
        if (other.gameObject.name == "床"){  // 衝突した物体が「床」なら（※） 
            start = 1;  // スタートフラグを上げる 
        }
        else if (other.gameObject.name != "ゴール" && other.gameObject.name != "床"){  // 衝突した物体が「壁」なら（※） 
            vel = -vel;  // 速度を逆方向に
        }
    }
    void Forward_Move(){
        transform.position += transform.forward * vel; 
    }
    void Back_Move(){
        transform.position -= transform.forward * vel; 
    }
}
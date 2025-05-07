using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
using System;
 
public class move_wall : MonoBehaviour 
{ 
    Transform myTransform;  // transform情報を格納する変数 
    Vector3 position_start; // 物体の初期位置を格納する変数
    Vector3 position_now;   // 物体の現在位置を格納する変数 
    public int direction;   // 物体の移動方向
    public float freeze_time; // 物体の停止時間
 
    // Start is called before the first frame update 
    void Start() 
    { 
        myTransform = this.transform;      // 物体のtransform情報をリンクする 
        position_start = myTransform.position;       // 初期位置を取り出す 
        position_now = position_start;  // 最初は同じ場所
        direction = -1;                 // 最初は負方向から
        freeze_time = 0.0F;             // 最初は0秒から
    } 
 
    // Update is called once per frame 
    void Update() 
    { 
        position_now.z += direction * 0.05f;    // １ステップごとにZを-0.05する 
        if (Math.Abs(position_start.z - position_now.z) > 10){  // Z方向に10移動したら，  
            direction *= -1; // 逆方向にする
            position_start = position_now;
            while(freeze_time < 600.0){
                freeze_time += 0.1F;
            }
            freeze_time = 0.0F;
        }
        myTransform.position = position_now; 
    } 
}
 
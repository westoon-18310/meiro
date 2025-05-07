using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // この２行を追加する． 
using TMPro;       // この２行を追加する． 
 
public class contact : MonoBehaviour
{ 
    // Textを外部に出力するための変数を定義する 
  // […]をつけることで，内部変数がインスペクターから操作できるようになる． 
    // private を public にしても操作可能になる． 
    [SerializeField] private TextMeshProUGUI TextWallHit;  

    private int wall_hit;   // 壁に衝突した回数の定義

    // Start is called before the first frame update 
    void Start() 
    { 
        wall_hit = 0;    // 壁に衝突した回数を初期化する  
    } 
 
    // Update is called once per frame 
    void Update() 
    { 
        TextWallHit.text = string.Format("Hit Wall : {0} ", wall_hit);  
    } 
    
    // 衝突を判定する処理を追加する 
    void OnCollisionEnter(Collision other)  // 衝突を判定する関数を呼ぶ 
    { 
        if (other.gameObject.name != "ゴール" && other.gameObject.name != "床")  // 衝突した物体が「ゴール」「床」以外なら（※） 
        { 
            wall_hit += 1;  // 衝突フラグを上げる 
        }
    }
} 
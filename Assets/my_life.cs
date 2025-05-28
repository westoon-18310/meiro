using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // この２行を追加する． 
using TMPro;       // この２行を追加する． 
 
public class my_life : MonoBehaviour
{ 
    // Textを外部に出力するための変数を定義する 
  // […]をつけることで，内部変数がインスペクターから操作できるようになる． 
    // private を public にしても操作可能になる． 
    [SerializeField] private TextMeshProUGUI TextMyLife;  

    public static int life = 3;   // 残機数定義
    public GameObject[] lifeArray = new GameObject[3];// ライフバー

    // Start is called before the first frame update 
    void Start() 
    { 
        life = 3;    // 残機数を初期化する  
    } 
 
    // Update is called once per frame 
    void Update() 
    { 
        TextMyLife.text = string.Format("- Life -");  
    } 
    
    // 衝突を判定する処理を追加する 
    void OnCollisionEnter(Collision other)  // 衝突を判定する関数を呼ぶ 
    { 
        if (other.gameObject.name == "NPC" && life > 0)  // 衝突した物体が「NPC」なら（※） 
        { 
            lifeArray[life - 1].SetActive(false);
            life -= 1;  // 敵に衝突したら残機減少
        }
    }
} 
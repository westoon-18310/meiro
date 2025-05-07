using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // この２行を追加する． 
using TMPro;       // この２行を追加する． 
 
public class time : MonoBehaviour
{ 
    // Textを外部に出力するための変数を定義する 
  // […]をつけることで，内部変数がインスペクターから操作できるようになる． 
    // private を public にしても操作可能になる． 
    [SerializeField] private TextMeshProUGUI TextTime;  
    [SerializeField] private TextMeshProUGUI GoalMesseage;  
    [SerializeField] private TextMeshProUGUI OperationText;  
 
    // 経過時間を格納する変数 ここに開始からの時間が格納される． 
    private float elapsedTime; 
 
    private int f_Goal;      // ゴールに到達した時に１となるフラグを追加する

    // Start is called before the first frame update 
    void Start() 
    { 
        elapsedTime = 0.0F;   // 時間を初期化する
        f_Goal = 0;           // 停止フラグを初期化する  
     } 
 
    // Update is called once per frame 
    void Update() 
    { 
        // 前のフレームからの経過時間（秒）を加算する 
        if (f_Goal == 0)  // ゴールに到達していない場合だけ時間を加算する 
        {
            elapsedTime += Time.deltaTime; 
            // 経過時間を表示するために，経過時間を秒にしたストリングを作成する． 
            TextTime.text = string.Format("Time :  {0:f2} sec", elapsedTime);  
            OperationText.text = "Up:Forward Down:Back Right/Left:Rotate";
        }
        else
        {   // ゴール 
            GoalMesseage.text = "Goal!";  
        }
    } 
    // 衝突を判定する処理を追加する 
    void OnCollisionEnter(Collision other)  // 衝突を判定する関数を呼ぶ 
    { 
        if (other.gameObject.name == "ゴール")  // 衝突した物体が「ゴール」なら（※） 
        { 
            f_Goal = 1;  // 衝突フラグを上げる 
        }
    }
} 
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
    private int injured; //ダメージ判定定義
    [SerializeField] private Renderer _target;
    [SerializeField] private float _cycle;
    private double _time;

    // Start is called before the first frame update 
    void Start() 
    { 
        life = 3;    // 残機数を初期化する  
        injured = 0;
        _cycle = 0.3F;
        _time = 0.0;
    } 
 
    // Update is called once per frame 
    void Update() 
    { 
        TextMyLife.text = string.Format("- Life -");  
        if(injured == 1) {
            _time += Time.deltaTime;
            var repeatValue = Mathf.Repeat((float)_time, _cycle);
            _target.enabled = repeatValue >= _cycle * 0.5F;
        }
        else{
            _target.enabled = true;
        }
    } 
    
    // 衝突を判定する処理を追加する 
    void OnCollisionEnter(Collision other)  // 衝突を判定する関数を呼ぶ 
    { 
        if ((other.gameObject.name == "NPC" || other.gameObject.name == "NPC_02") && life > 0 && injured == 0)  // 自身がダメージ判定でないかつ衝突した物体が「NPC」なら（※） 
        { 
            lifeArray[life - 1].SetActive(false);
            life -= 1;  // 敵に衝突したら残機減少
            injured = 1;
            StartCoroutine(Injured());
        }
    }
    public IEnumerator Injured() {

        yield return new WaitForSeconds(2.0f); // 約2秒間だけ無敵
        
        injured = 0;
    }
} 
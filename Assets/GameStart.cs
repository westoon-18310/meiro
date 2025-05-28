using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour {	
    // 始まった時に実行する関数	
    void Start () { // ボタンが押された時、StartGame関数を実行 
        gameObject.GetComponent<Button>().onClick.AddListener(StartGame);	
    }
    void StartGame() { 
        SceneManager.LoadScene("Labylinth_01"); 
    }
}
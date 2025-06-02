using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class 移動用 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;   // ← FPSを60に設定
    }

    // Update is called once per frame
    void Update()
    {
        if(time.gameover == 0){
            if (Input.GetKey("up")) // ↑なら前（Z方向）に0.1だけ進む 
            { 
                transform.position += transform.forward * 0.1f; 
            } 
            if (Input.GetKey("down"))  // ↓なら-Z方向に0.1だけ進む 
            { 
                transform.position -= transform.forward * 0.1f; 
            } 
            if (Input.GetKey ("right"))   // ←ならY軸に3度回転する 
            { 
                transform.Rotate(0f,3.0f,0f); 
            } 
            if (Input.GetKey ("left"))   // →ならY軸に-3度回転する 
            { 
                transform.Rotate(0f, -3.0f, 0f); 
            }
            if(Math.Abs(transform.eulerAngles.x) > 0f){
                transform.Rotate(0f, 0f,-Math.Abs(transform.eulerAngles.x)); 
            }
            if(Math.Abs(transform.eulerAngles.z) > 0f){
                transform.Rotate(0f, 0f,-Math.Abs(transform.eulerAngles.z)); 
            }
        }
        else{
            if (Input.GetKey ("r"))   // リセット
            { 
                Time.timeScale = 1;
                time.gameover = 0;
                my_life.life = 3;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            } 
        }
    }
}

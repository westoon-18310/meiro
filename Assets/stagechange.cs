using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class stagechange : MonoBehaviour
{
    public int f_goal = 0;
    public int isTouch = 0;

    void Update()
    {
        if (f_goal == 1)
        {
            SceneManager.LoadScene("scene_saya");
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "プレイヤー")
        {
            isTouch = 1;
        }
    }
}

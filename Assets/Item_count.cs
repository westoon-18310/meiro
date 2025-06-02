using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Item_count : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ButtonNum;
    [SerializeField] private TextMeshProUGUI Passnum;

    private int pass_1;
    private int pass_2;
    private int pass_3;
    private int pass_4;
    private int flag;

    void Start()
    {
        pass_1 = Random.Range(1, 10);
        pass_2 = Random.Range(1, 10);
        pass_3 = Random.Range(1, 10);
        pass_4 = Random.Range(1, 10);
        flag = 0;

        // 初期表示を空白にしておく
        Passnum.text = "number: ? ? ? ?";
    }

    void Update()
    {
        GameObject[] buttons = GameObject.FindGameObjectsWithTag("Item");
        int totalPush = 0;

        foreach (GameObject button in buttons)
        {
            pushButton btn = button.GetComponent<pushButton>();
            totalPush += btn.isPush;
        }

        ButtonNum.text = string.Format("Button: {0}/5", totalPush);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("num") && flag < 4)
        {
            flag++;

            string display = "number: ";

            if (flag >= 1) display += pass_1.ToString() + " ";
            if (flag >= 2) display += pass_2.ToString() + " ";
            if (flag >= 3) display += pass_3.ToString() + " ";
            if (flag >= 4) display += pass_4.ToString();
            if (flag < 4) display += new string('?', 4 - flag).Replace("?", " ?");

            Passnum.text = display;
            Destroy(other.gameObject);
        }
    }
}

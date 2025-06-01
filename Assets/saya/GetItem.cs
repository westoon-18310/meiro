using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // ‚±‚Ì‚Qs‚ð’Ç‰Á‚·‚éD 
using TMPro;       // ‚±‚Ì‚Qs‚ð’Ç‰Á‚·‚éD

public class GetItem : MonoBehaviour
{
    public static int get_coin;
    public static GameObject goal;
    [SerializeField] private TextMeshProUGUI ItemText;


    // Start is called before the first frame update
    void Start()
    {
        get_coin = 0;
        goal = GameObject.Find("ƒS[ƒ‹");
        goal.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (get_coin > 9)
        {
            goal.SetActive(true);
            ItemText.text = string.Format("The goal post has appeared!");
        }
        else
        {
            ItemText.text = string.Format("Coin : {0}/10", get_coin);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            Item item = other.gameObject.GetComponent<Item>();
            item.ObtainCoin();
            get_coin++;
        }
    }
}

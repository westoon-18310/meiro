using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItem : MonoBehaviour
{
    public static int get_coin;
    public static GameObject goal;
    
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

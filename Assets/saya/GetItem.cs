using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // Ç±ÇÃÇQçsÇí«â¡Ç∑ÇÈÅD 
using TMPro;       // Ç±ÇÃÇQçsÇí«â¡Ç∑ÇÈÅD

[RequireComponent(typeof(AudioSource))]

public class GetItem : MonoBehaviour
{
    public static int get_coin;
    public static GameObject goal;
    int soundFlag;
    [SerializeField] private TextMeshProUGUI ItemText;

    public AudioClip sound2;
    public AudioClip sound3;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        get_coin = 0;
        soundFlag = 0;
        goal = GameObject.Find("ÉSÅ[Éã");
        goal.SetActive(false);
        audioSource = GetComponents<AudioSource>()[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (get_coin > 9)
        {
            goal.SetActive(true);
            ItemText.text = string.Format("The goal post has appeared!");
            if (soundFlag == 0)
            {
                audioSource.PlayOneShot(sound2, 0.1F);
                soundFlag = 1;
            }
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
            audioSource.PlayOneShot(sound3, 0.1F);
        }
    }
}

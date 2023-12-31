using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    int coins = 0;

    [SerializeField] Text coinsText;
    [SerializeField] AudioSource collectSound;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            collectSound.Play();
            Destroy(other.gameObject);
            coins++;
            coinsText.text = "Coins : " + coins;
        }
    }
}

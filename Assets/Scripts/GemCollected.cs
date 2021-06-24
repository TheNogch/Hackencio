using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemCollected : MonoBehaviour
{
    //Hacemos desaparecer la gema
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().enabled = false;

            collision.GetComponent<PlayerIventory>().grayGems += 1;

            InventoryOfPlayer.gems += 1;

            Destroy(gameObject);
        }
    }

}

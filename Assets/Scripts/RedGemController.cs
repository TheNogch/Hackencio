using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedGemController : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            Debug.Log(collision.gameObject.GetComponent<PlayerIventory>().grayGems);
            //Debug.Log(InventoryOfPlayer.gems);
        }
    }
}

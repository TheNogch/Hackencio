using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMinigame : MonoBehaviour
{
    private bool canStartMinigame = false;
    public GameObject miniGame;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && canStartMinigame)
        {
            gameObject.GetComponent<PlayerMovement>().canMove = false;
            miniGame.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("miniGame") && gameObject.GetComponent<PlayerIventory>().grayGems == 4) 
        {
            canStartMinigame = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("miniGame"))
        {
            canStartMinigame = false;
        }
    }
}

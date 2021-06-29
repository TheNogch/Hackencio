using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject openDoor;
    private void OnDestroy()
    {
        openDoor.SetActive(true);
    }
}

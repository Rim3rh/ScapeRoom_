using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room2Manager : MonoBehaviour
{
    public RoomManager _roomManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = new Vector3(-42f, 6.6f, -3.5f);
        }

        if (other.CompareTag("GreenCube") || other.CompareTag("BlueCube"))
        {
            _roomManager._room2Counter++;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCollider : MonoBehaviour
{
    public DoorsScript _door;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
          //  Debug.Log("Bro no entiendo anda");
            _door.CloseDoor();
        }
    }
}

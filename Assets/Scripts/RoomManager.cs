using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{

    public GameObject _doorOne, _doorTwo, _doorThree;
    private int _contOne, _contTwo, _contThree;
    public int _room2Counter;
    public AudioSource _roomCompleted;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance._firstRoomComplete && _contOne < 1)
        {
            _roomCompleted.Play();
            _doorOne.GetComponent<DoorsScript>().OpenDoor();
            _contOne++;
        }


        //Room2

        if (_room2Counter > 5) GameManager.Instance._secondRoomComplete = true;
        if (GameManager.Instance._secondRoomComplete && _contTwo < 1)
        {
            Debug.Log("DENTRO");
            _roomCompleted.Play();
            _doorTwo.GetComponent<DoorsScript>().OpenDoor();
            _contTwo++;
        }
    }
}

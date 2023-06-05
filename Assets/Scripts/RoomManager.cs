using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{

    public GameObject _doorOne, _doorTwo, _doorThree, _doorFour, _finalDoor;
    private int _contOne, _contTwo, _contThree, _contFour, _contFive;
    public int _room2Counter, _room3Counter;
    public AudioSource _roomCompleted;
    //lights
    public Renderer _roomOneLight, _roomTwoLight, _roomThreeLight, _roomFourLight, _finalRoomLight;
    public Material _green;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance._firstRoomComplete && _contOne < 1)
        {
            _roomCompleted.Play();
            _doorOne.GetComponent<DoorsScript>().OpenDoor();
            _roomOneLight.material = _green;
            _contOne++;

        }


        //Room2

        if (_room2Counter > 5) GameManager.Instance._secondRoomComplete = true;
  
        if (GameManager.Instance._secondRoomComplete && _contTwo < 1)
        {
            _roomCompleted.Play();
            _doorTwo.GetComponent<DoorsScript>().OpenDoor();
            _roomTwoLight.material = _green;
            _contTwo++;
        }

        //ROOM 3
        if (_room3Counter > 5) GameManager.Instance._thirdRoomComplete = true;
        if(GameManager.Instance._thirdRoomComplete && _contThree < 1)
        {
            _roomCompleted.Play();
            _doorThree.GetComponent<DoorsScript>().OpenDoor();
            _roomThreeLight.material = _green;
            _contThree++;
        }

        //Room4
        if (GameManager.Instance._pressurePlates > 1) GameManager.Instance._fourthRoomComplete = true;
        if (GameManager.Instance._fourthRoomComplete && _contFour < 1)
        {
            _roomCompleted.Play();
            _doorFour.GetComponent<DoorsScript>().OpenDoor();
            _roomFourLight.material = _green;
            _contFour++;
        }


        //FinalRoom

        if (GameManager.Instance._hitCount > 14) GameManager.Instance._finalRoomComplete = true;
        if (GameManager.Instance._finalRoomComplete && _contFive < 1)
        {
            _roomCompleted.Play();
            _doorFour.GetComponent<DoorsScript>().OpenDoor();
            _finalRoomLight.material = _green;
            _contFive++;
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room2Manager : MonoBehaviour
{
    public RoomManager _roomManager;
    public GameObject _takeGun;

    private void OnTriggerEnter(Collider other)
    {
        //Para q no te puedas ir sin la pistola
        if (!this.CompareTag("RoomCollider") && other.CompareTag("Player") && !GameManager.Instance._holdingGun)
        {
            StartCoroutine(TakeGunBeforeYouLeave(other));
        }

        //PARA CUNADO TIRAS LOS CUBOS AL VACIO(Room2)
        if (this.CompareTag("RoomCollider") && other.CompareTag("Player"))
        {
            //Para q no te puedas tirar tu
            other.transform.position = new Vector3(-42f, 6.6f, -3.5f);
        }
        if (this.CompareTag("RoomCollider") &&  other.CompareTag("GreenCube") || other.CompareTag("BlueCube"))
        {
            _roomManager._room2Counter++;
            other.transform.GetComponentInChildren<ParticleSystem>().Play();
            other.GetComponent<BoxCollider>().enabled = false;
            other.GetComponent<MeshRenderer>().enabled = false;
            other.GetComponent<Rigidbody>().useGravity = false;
            other.GetComponent<Rigidbody>().velocity = Vector3.zero;
            other.GetComponent<AudioSource>().Play();
            Destroy(other.gameObject, 1.0f);
        }
        //PARA CUNADO TIRAS LOS CUBOS AL VACIO(Room3)
        if (GameManager.Instance._secondRoomComplete && this.CompareTag("RoomCollider") && other.CompareTag("GreenCube") || other.CompareTag("BlueCube"))
        {
            _roomManager._room3Counter++;
            other.transform.GetComponentInChildren<ParticleSystem>().Play();
            other.GetComponent<BoxCollider>().enabled = false;
            other.GetComponent<MeshRenderer>().enabled = false;
            other.GetComponent<Rigidbody>().useGravity = false;
            other.GetComponent<Rigidbody>().velocity = Vector3.zero;
            other.GetComponent<AudioSource>().Play();
            Destroy(other.gameObject, 3.0f);
        }
    }




    private IEnumerator TakeGunBeforeYouLeave(Collider other)
    {
        other.transform.position = new Vector3(-42f, 6.6f, -3.5f);
        _takeGun.SetActive(true);
        yield return new WaitForSeconds(1f);
        _takeGun.SetActive(false);
    }
}

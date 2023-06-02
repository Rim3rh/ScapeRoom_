using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room4Manager : MonoBehaviour
{

    public GameObject _greenCube, _blueCube, _this;
    private bool _blueCubeActive, _greenCubeActive, _greenInPressure, _blueInPressure, _completed;
    public Transform _greenCubeSpawn, _blueCubeSpawn;
    public Material _green;

    void Start()
    {
        _blueCubeActive = true;
        _greenCubeActive = true;
        this.tag = "PressurePlate1";
        _this = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(this.CompareTag("DeathZone") && other.CompareTag("GreenCube") || other.CompareTag("BlueCube"))
        {
           // DestroyCube(other);
            Debug.Log(this.tag);
        }


        if (this.CompareTag("PressurePlate1") && other.CompareTag("GreenCube") || other.CompareTag("BlueCube"))
        {
           
            if (_completed)
            {
                DestroyCube(other);
                //Debug.Log("ASDASDASD");
                return;
            }
            Debug.Log("AÑGO");
            StartCoroutine(PressurePlate(other));
            if (other.CompareTag("GreenCube")) _greenInPressure = true;
            else _blueInPressure = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (this.CompareTag("PressurePlate1") && other.CompareTag("GreenCube") || other.CompareTag("BlueCube"))
        {
            StopCoroutine(PressurePlate(other));

            if (other.CompareTag("GreenCube")) _greenInPressure = false;
            else _blueInPressure = false;

        }
    }

    private IEnumerator PressurePlate(Collider other)
    {
        yield return new WaitForSeconds(3f);
        if(_greenInPressure || _blueInPressure)
        {
            this.transform.GetChild(0).GetComponent<Renderer>().material = _green;
            _completed = true;
            GameManager.Instance._pressurePlates++;
            Debug.Log("COMPLETED");
        }

    }


    private void DestroyCube(Collider other)
    {
        other.transform.GetComponentInChildren<ParticleSystem>().Play();
        other.GetComponent<BoxCollider>().enabled = false;
        other.GetComponent<MeshRenderer>().enabled = false;
        other.GetComponent<Rigidbody>().useGravity = false;
        other.GetComponent<Rigidbody>().velocity = Vector3.zero;
        other.GetComponent<AudioSource>().Play();
        if (other.CompareTag("GreenCube")) _greenCubeActive = false;
        else _blueCubeActive = false;
        Destroy(other.gameObject, 1.0f);
        StartCoroutine(SpawnCube());
    }
    private IEnumerator SpawnCube()
    {
        yield return new WaitForSeconds(1f);
        if (!_greenCubeActive)
        {
            _greenCubeSpawn.transform.GetComponentInChildren<ParticleSystem>().Play();
            yield return new WaitForSeconds(0.7f);
            Instantiate(_greenCube, _greenCubeSpawn.transform.position, Quaternion.identity);
            _greenCubeActive = true;
        }
        else
        {
            _blueCubeSpawn.transform.GetComponentInChildren<ParticleSystem>().Play();
            yield return new WaitForSeconds(0.7f);
            Instantiate(_blueCube, _blueCubeSpawn.transform.position, Quaternion.identity);
            _blueCubeActive = true;
        }
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalBScript : MonoBehaviour
{
    private GameObject _portalA;
    private GameObject _portalAExit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CanPass"))
        {
            _portalA = GameObject.Find("Portal_A(Clone)");
            _portalAExit = _portalA.transform.GetChild(0).gameObject;
            

            Rigidbody _rb = other.GetComponent<Rigidbody>();
            other.transform.position = _portalAExit.transform.position;
            _rb.velocity = _portalA.transform.forward * _rb.velocity.y;
        }
    }
}

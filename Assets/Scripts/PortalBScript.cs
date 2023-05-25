using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalBScript : MonoBehaviour
{
    public GameObject _portalA;
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
            Rigidbody _rb = other.GetComponent<Rigidbody>();
            other.transform.position = _portalA.transform.position;
            _rb.velocity = _portalA.transform.forward * _rb.velocity.y;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalAScript : MonoBehaviour
{
    private GameObject _portalB;
    void Start()
    {
        _portalB = GameObject.Find("Portal_B(Clone)");
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CanPass"))
        {
            Rigidbody _rb =  other.GetComponent<Rigidbody>();
            other.transform.position = _portalB.transform.position;
            _rb.velocity = _portalB.transform.forward * _rb.velocity.y;
        }
    }
}

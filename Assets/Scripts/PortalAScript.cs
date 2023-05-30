using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalAScript : MonoBehaviour
{
    private GameObject _portalB;
    private GameObject _portalBExit;
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            _portalB = GameObject.Find("Portal_B(Clone)");
            _portalBExit = _portalB.transform.GetChild(0).gameObject;
            
            Rigidbody _rb =  other.GetComponent<Rigidbody>();
            other.transform.position = _portalBExit.transform.position;
            _rb.velocity = _portalB.transform.forward * _rb.velocity.y;
        }
    }
}

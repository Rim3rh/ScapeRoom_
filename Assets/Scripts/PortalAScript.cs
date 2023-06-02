using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalAScript : MonoBehaviour
{
    private GameObject _portalB;
    private GameObject _portalBExit;
    public Renderer _body;
    public Material _green, _gray;
    private bool _greenAS;
    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if (GameManager.Instance._portalAlone)
        {
            _body.material = _gray;
        } else _body.material = _green;
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            _portalB = GameObject.Find("Portal_B(Clone)");
            if (_portalB != null)
            {
                _portalBExit = _portalB.transform.GetChild(0).gameObject;
                Rigidbody _rb = other.GetComponent<Rigidbody>();
                other.transform.position = _portalBExit.transform.position;
                _rb.velocity = _portalB.transform.forward * _rb.velocity.y;
            }


        }
    }


}

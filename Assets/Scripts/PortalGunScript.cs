using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PortalGunScript : MonoBehaviour
{
    public GameObject _shootPos;
    public LineRenderer _lineRenderer;
    public GameObject _portalA, _portalB, _leftHand, _righHand, _gunStand;
    public XRInteractorLineVisual _lineRenderer_L, _lineRenderer_R;
    public AudioSource _gunShot;
    void Start()
    {
        _lineRenderer.enabled = enabled;
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(Shoot);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Shoot(ActivateEventArgs args)
    {
        _gunShot.Play();
        _lineRenderer.SetPosition(0, _shootPos.transform.position);
        RaycastHit hit;
        Physics.Raycast(_shootPos.transform.position, _shootPos.transform.forward, out hit);
        _lineRenderer.SetPosition(1, hit.point);
        StartCoroutine(ShootLaser());
        InstanciatePortal(hit); 
        
    }
    private void InstanciatePortal(RaycastHit hit)
    {
        if (hit.transform.CompareTag("CanSpawn"))
        {
           
            switch (GameManager.Instance._potalsSpawned)
            {
                case 1:
                    
                    Instantiate(_portalA, hit.point, hit.transform.rotation);
                    GameManager.Instance._potalsSpawned = 2;
                    break;

                case 2:
                    
                    Instantiate(_portalB, hit.point, hit.transform.rotation);
                    GameManager.Instance._potalsSpawned = 3;
                    GameManager.Instance._firstRoomComplete = true;
                    
                    break;
                case 3:
                    
                    Destroy(GameObject.Find("Portal_A(Clone)"));
                    Destroy(GameObject.Find("Portal_B(Clone)"));
                    GameManager.Instance._potalsSpawned = 1;
                    break;
            }
        }
    }

    private IEnumerator ShootLaser()
    {
        _lineRenderer.enabled = true;
        yield return new WaitForSeconds(0.1f);
        _lineRenderer.enabled = false;
        
    }


    public void TurnOffLineRenderer()
    {
        //This determines if the object is closer to the left hand
        if (Vector3.Distance(a: this.transform.position, b: _leftHand.transform.position) < Vector3.Distance(a: this.transform.position, b: _righHand.transform.position))
        {
            _lineRenderer_R.enabled = false;
           // Debug.Log("Left hand");
        }
        else
        {
          //  Debug.Log("Right hand");
            _lineRenderer_R.enabled = false;
        }
            
            
    }
    public void TurnOnLineRenderer()
    {
        if (Vector3.Distance(a: this.transform.position, b: _leftHand.transform.position) < Vector3.Distance(a: this.transform.position, b: _righHand.transform.position)) _lineRenderer_R.enabled = true;
        else _lineRenderer_R.enabled = true;
    }
    public void RemoveGunStand()
    {
        LeanTween.moveY(_gunStand, 1, 2f);
    }


}

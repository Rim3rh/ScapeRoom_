using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PortalGunScript : MonoBehaviour
{
    public GameObject _shootPos;
    public LineRenderer _lineRenderer;
    public GameObject _portalA, _portalB, _leftHand, _righHand, _gunStand, _attatchPoint;
    public XRInteractorLineVisual _lineRenderer_L, _lineRenderer_R;
    public AudioSource _gunShot, _gunShotFail;
    public ParticleSystem _onShoot;


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
        SootDummy(hit);
        InstanciatePortal(hit);
        StartCoroutine(ShootFail(hit));
        Instantiate(_onShoot, hit.point, hit.transform.rotation);


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
                    GameManager.Instance._portalAlone = true;
                    break;

                case 2:


                    Instantiate(_portalB, hit.point, hit.transform.rotation);
                    GameManager.Instance._potalsSpawned = 3;
                    GameManager.Instance._firstRoomComplete = true;
                    GameManager.Instance._portalAlone = false;

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

        StartCoroutine(TurnOffLineRendererC());
            
    }

    private IEnumerator TurnOffLineRendererC()
    {
        
        yield return new WaitForSeconds(0.05f);
        GameManager.Instance._holdingGun = true;
        if (Vector3.Distance(a: this.transform.position, b: _leftHand.transform.position) < Vector3.Distance(a: this.transform.position, b: _righHand.transform.position))
        {
           // _attatchPoint.transform.position = new Vector3(_attatchPoint.transform.position.x + 0.2f, _attatchPoint.transform.position.y, _attatchPoint.transform.position.z);
            _lineRenderer_L.enabled = false;
            
           // Debug.Log("Left hand");
        }
        else
        {
           // Debug.Log("Right hand");
            _lineRenderer_R.enabled = false;
            //_attatchPoint.transform.position = _attatchPoint.transform.position;
        }
    }
    public void TurnOnLineRenderer()
    {
        GameManager.Instance._holdingGun = false;
        if (Vector3.Distance(a: this.transform.position, b: _leftHand.transform.position) < Vector3.Distance(a: this.transform.position, b: _righHand.transform.position)) _lineRenderer_L.enabled = true;
        else _lineRenderer_R.enabled = true;
    }
    public void RemoveGunStand()
    {
        StartCoroutine(RemoveGunStandC());
    }
    public IEnumerator RemoveGunStandC()
    {
        yield return new WaitForSeconds(1f);
        LeanTween.moveY(_gunStand, 1, 2f);
    }

    private IEnumerator ShootFail(RaycastHit hit)
    {
        yield return new WaitForSeconds(0.01f);
        if (!hit.transform.CompareTag("CanSpawn") || !hit.transform.CompareTag("Shooteable")) _gunShotFail.Play();
    }
    private void SootDummy(RaycastHit hit)
    {
        if (hit.transform.CompareTag("Shooteable"))
        {
            hit.transform.GetComponent<DummyManager>().Hit();
        }
    }

}

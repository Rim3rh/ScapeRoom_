using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalGunScript : MonoBehaviour
{
    public GameObject _shootPos;
    public LineRenderer _lineRenderer;
    public GameObject _portalA, _portalB;
    void Start()
    {
        _lineRenderer.enabled = enabled;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
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
            Debug.Log("AGOLA");
            switch (GameManager.Instance._potalsSpawned)
            {
                case 1:
                    Instantiate(_portalA, hit.point, Quaternion.identity);
                    GameManager.Instance._potalsSpawned = 2;
                    break;

                case 2:
                    Instantiate(_portalB, hit.point, Quaternion.identity);
                    GameManager.Instance._potalsSpawned = 3;
                    break;
                case 3:
                    Debug.Log("fASFD");
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
        Debug.Log("cor");
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalGunScript : MonoBehaviour
{
    public GameObject _shootPos;
    public LineRenderer _lineRenderer;
    public GameObject _portal1;
    void Start()
    {
        _lineRenderer.enabled = enabled;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("asd");
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
            Instantiate(_portal1, hit.point, Quaternion.identity);
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

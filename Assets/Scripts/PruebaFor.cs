using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebaFor : MonoBehaviour
{
    public GameObject _oryea;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _oryea.SetActive(true);
        }
    }
}

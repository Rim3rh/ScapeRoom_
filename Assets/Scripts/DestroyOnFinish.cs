using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnFinish : MonoBehaviour
{
    private ParticleSystem _onShoot;
    [System.Obsolete]
    void Start()
    {
        _onShoot = GetComponent<ParticleSystem>();
        float duration = _onShoot.duration + _onShoot.startLifetime;
        Destroy(this.gameObject, duration);
    }

}

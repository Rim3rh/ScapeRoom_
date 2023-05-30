using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandAnimations : MonoBehaviour
{
    public InputActionProperty _pinchAnimation, _gripAnimation;
    public Animator _handAnim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float _pinchValue = _pinchAnimation.action.ReadValue<float>();
        _handAnim.SetFloat("Trigger", _pinchValue);
        float _gripValue = _gripAnimation.action.ReadValue<float>();
        _handAnim.SetFloat("Grip", _gripValue);
    }
}

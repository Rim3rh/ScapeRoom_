using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresurePlate_A_1 : MonoBehaviour
{
    private bool _canMove;
    public Transform _limitPosD, _limitPosU;
    private int _states, _cont;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_canMove)
        {
            transform.Translate(0, -0.004f, 0);
        }

        if(transform.position.y < _limitPosD.transform.position.y)
        {
            _canMove = false;
        }

        switch (_states)
        {

            case 1:
                transform.Translate(0, -0.004f, 0);
                if (transform.position.y < _limitPosD.transform.position.y) _states = 2;

                break;

            case 2:
                
                if (_cont < 1)
                {
                   // FirstDoorScript._doorState++;
                    _cont++;
                }
                break;
            case 3:
                transform.Translate(0, 0.004f, 0);
                if (transform.position.y > _limitPosU.transform.position.y) _states = 2;
                break;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("GreenCube"))
        {
            _states = 1;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("GreenCube"))
        {
            _states = 3;
        }
    }

}

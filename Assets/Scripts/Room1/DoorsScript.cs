using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsScript : MonoBehaviour
{
    //public static int _doorState;
    private int _cont1, _cont1B, _cont2, _cont3;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      //  Debug.Log((GameManager.Instance._firstRoomComplete, _cont1B));
    }
    public void OpenDoor()
    {
        
        if (gameObject.CompareTag("FirstDoor") && GameManager.Instance._firstRoomComplete && _cont1 < 1)
        {
            LeanTween.moveY(this.gameObject, 3.8f, 2f);
            _cont1++;
        }
        Debug.Log(_cont2);
        Debug.Log(gameObject.tag);
        Debug.Log(GameManager.Instance._secondRoomComplete);
        if (gameObject.CompareTag("SecondDoor") && GameManager.Instance._secondRoomComplete && _cont2 < 1)
        {
            Debug.Log("AbreSegundaPûerta");
            LeanTween.moveY(this.gameObject, 3.8f, 3f);
            _cont2++;
        }
    }
    public void CloseDoor()
    {

      //  Debug.Log("LOLOLOL");
        LeanTween.moveY(this.gameObject, 6.784f, 2f);
        _cont1B++;
        if (gameObject.CompareTag("FirstDoor") && _cont1B < 1)
        {

        }
    }




}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsScript : MonoBehaviour
{
   
    public void OpenDoor()
    {
        StartCoroutine(OpenDoorC());
    }
    public void CloseDoor()
    {
        GetComponent<AudioSource>().Play();
        LeanTween.moveY(this.gameObject, 6.784f, 1.5f);
    }

    private IEnumerator OpenDoorC()
    {
        yield return new WaitForSeconds(2f);
        GetComponent<AudioSource>().Play();
        LeanTween.moveY(this.gameObject, 3.8f, 1.5f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyManager : MonoBehaviour
{
    private Animator _anim;
    private Collider _colider;
    void Start()
    {
        _anim = GetComponent<Animator>();
        _colider = GetComponent<Collider>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K) && CompareTag("Shooteable"))
        {
            Hit();
        }
    }

    public void StartShootC()
    {
       StartCoroutine(CanShootMe());
    }

    private IEnumerator CanShootMe()
    {
        _anim.Play("Upp");
        yield return new WaitForSeconds(0.3f);
        GetComponent<AudioSource>().Play();
        
        yield return new WaitForSeconds(3);

        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.1f);
        _anim.Play("NoHit");
    }


    public void Hit()
    {
        this.transform.GetChild(0).GetComponent<AudioSource>().Play();
        GameManager.Instance._hitCount++;
        StopAllCoroutines();
        _anim.Play("Hit");
        
    }


    public void TagToShoteable()
    {
        tag = "Shooteable";
    }
    public void TagToNotShoteable()
    {
        tag = "NotShooteable";
    }
}

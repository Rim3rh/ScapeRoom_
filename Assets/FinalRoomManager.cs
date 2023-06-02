using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalRoomManager : MonoBehaviour
{
    public GameObject[] ShootingDummies;
    private int _easy, _med, _hard;
    void Start()
    {
        StartGame();
        _easy = 5;
        _med = 3;
        _hard = 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void StartGame()
    {
        InvokeRepeating("Game", 3f, 5f);
    }

    private void Game()
    {
        if(GameManager.Instance._enemiesSpawned < 19)
        {
            int dummy;
            dummy = 0; //Random.Range(0, 20);
            ShootingDummies[dummy].GetComponent<DummyManager>().StartShootC();
            GameManager.Instance._enemiesSpawned++;
        }
    }
}

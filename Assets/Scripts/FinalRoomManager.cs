using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalRoomManager : MonoBehaviour
{
    public GameObject[] ShootingDummies;
    public TextMeshPro _score, _enemies;
    int _difficultyLev;
    void Start()
    {
        _enemies.text = GameManager.Instance._enemiesSpawned.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        _score.text = GameManager.Instance._hitCount.ToString();
    }


    public void StartGame()
    {
        if (!GameManager.Instance._finalRoomGamePlaying)
        {
            switch (GameManager.Instance._difficultyLev)
            {
                case 1:
                    _difficultyLev = 5;
                    break;
                case 2:
                    _difficultyLev = 3;
                    break;
                case 3:
                    _difficultyLev = 2;
                    break;
            }

            InvokeRepeating("Game", 2f, _difficultyLev);
            GameManager.Instance._finalRoomGamePlaying = true;
        }

       
         
        
    }

    private void Game()
    {
        if(GameManager.Instance._enemiesSpawned < 20)
        {
            int dummy;
            dummy = (int)Random.Range(0f, 17f);
            if (!ShootingDummies[dummy].GetComponent<DummyManager>()._during)
            {
                ShootingDummies[dummy].GetComponent<DummyManager>().StartShootC();
            }
            else
            {
                Game();
                return;
            }
            GameManager.Instance._enemiesSpawned++;
            _enemies.text = GameManager.Instance._enemiesSpawned.ToString();
        }
        else
        {
            CancelInvoke();
            
            
        }
    }
}


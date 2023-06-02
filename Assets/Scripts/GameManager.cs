using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    //1 = PortalA spawned, 2 = both, 3= delete, 
    public float _potalsSpawned, _pressurePlates;
    public bool _firstRoomComplete, _secondRoomComplete, _thirdRoomComplete, _fourthRoomComplete;
    public bool _holdingGun;
    public bool _portalAlone;
    public int _hitCount, _enemiesSpawned;

    private void Awake()
    {
        Instance = this;
        _potalsSpawned = 1;
    }
}

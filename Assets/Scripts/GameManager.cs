using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    //1 = PortalA spawned, 2 = both, 3= delete, 
    public float _potalsSpawned;
    private void Awake()
    {
        Instance = this;
        _potalsSpawned = 1;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreator : MonoBehaviour {

    public GameObject terrainPre;
    public GameObject playerSpawnerPre;
    public GameObject nodeSpawnerPre;
    public GameObject enemySpawnerpre;

    public void Awake()
    {
        Instantiate(terrainPre, null);
        Instantiate(playerSpawnerPre, null);
    }

    private void Start()
    {
        
        Instantiate(nodeSpawnerPre, null);
        Instantiate(enemySpawnerpre, null);
    }
}

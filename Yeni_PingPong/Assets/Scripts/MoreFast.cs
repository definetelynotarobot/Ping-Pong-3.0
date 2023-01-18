using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreFast : MonoBehaviour
{

    public GameObject spawn;
    public bool _stopSpawning = false;
    public float _spawnTİme = 1f;
    public float _spawnDelay = 10f;

    

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObject", _spawnTİme, _spawnDelay);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnObject(){
        Instantiate(spawn, transform.position, transform.rotation);
        if(_stopSpawning) 
        {
            CancelInvoke("SpawnObject");
        }
    }

    
}

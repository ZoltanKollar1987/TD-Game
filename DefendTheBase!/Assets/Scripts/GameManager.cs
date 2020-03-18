using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    
    public GameObject towerPrefab;

    public GameObject TowerPrefab 
    {
        get
        {
            return towerPrefab;
        }
            
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

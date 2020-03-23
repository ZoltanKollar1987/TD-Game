using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerButton : MonoBehaviour
{
    [SerializeField]
    private GameObject towerPrefab;

    [SerializeField]
    private Sprite sprite;

    public Sprite Sprite
    {
        get
        {
            return sprite;
        }
        
    }

    public GameObject TowerPrefab {
        get
        {
            return towerPrefab;
        }
       
    }
}

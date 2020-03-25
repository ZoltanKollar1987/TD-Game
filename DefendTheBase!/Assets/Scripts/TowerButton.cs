﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    [SerializeField]
    private int price;

    public int Price
    {
        get
        {
            return price;
        }
    }


    [SerializeField]
    private Text priceText;

    private void Start()
    {
        priceText.text = price + "$";
    }
}

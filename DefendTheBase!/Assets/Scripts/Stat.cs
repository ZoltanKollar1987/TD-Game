using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Stat
{
    
    [SerializeField]
    private BarScript bar;

    [SerializeField]
    private float maxVal;

    [SerializeField]
    private float currentValue;

    public float CurrentValue
    { 
        get
        {
            return currentValue;
        }

        set
        {
            this.currentValue = value;
            bar.Value = currentValue;
        }
    }

    public float MaxVal
    {
        get
        {
            return maxVal;
        }
        set
        {
            
            this.maxVal = value;
            bar.MaxValue = maxVal;


        }
    }

    public void Initialize()
    {
        this.MaxVal = maxVal;
        this.CurrentValue = currentValue;
    }
    
}

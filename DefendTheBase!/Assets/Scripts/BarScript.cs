using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarScript : MonoBehaviour
{

    private float fillAmaont;

    [SerializeField]
    private Image content;

    public float MaxValue { get; set; }

    public float Value
    {
        set
        {
            fillAmaont = Map(value,0,MaxValue,1,0);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleBar();
    }

    private void HandleBar()
    {
        
        if (fillAmaont != content.fillAmount)
        {
            content.fillAmount = fillAmaont;
            
        }
       
    }

    private float Map(float value,float inMin,float inMax,float outMax,float outMin)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;

        
    }
}

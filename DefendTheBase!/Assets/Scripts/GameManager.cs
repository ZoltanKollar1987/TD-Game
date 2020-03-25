using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{

    
    public TowerButton ClickBtn { get; set; }

    private int currency;

    [SerializeField]
    private Text currencyTxt;

    public int Currency
    {
        get
        {
            return currency;
        }
        set
        {
           this.currency = value;
           this.currencyTxt.text = value.ToString() + " <color=lime>$</color>";
        } 
    }


    // Start is called before the first frame update
    void Start()
    {
        Currency = 5;
    }

    // Update is called once per frame
    void Update()
    {
        HandleEcape();
    }

    public void PickTower(TowerButton towerBtn)
    {
        if (Currency >= towerBtn.Price)
        {
            this.ClickBtn = towerBtn;
            Hover.Instance.Activate(towerBtn.Sprite);
        }
     
    }

    public void BuyTower()
    {
        if (Currency >= ClickBtn.Price)
        {
            Currency -= ClickBtn.Price;
            Hover.Instance.DeActivate();
        }

            
    }
    private void HandleEcape()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Hover.Instance.DeActivate();
        }
    }
}

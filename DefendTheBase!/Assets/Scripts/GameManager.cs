using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
     
    public TowerButton ClickBtn { get; set; }

    [SerializeField]
    private GameObject WaveBtn;

    private int currency;

    private int wave = 0;

    [SerializeField]
    private Text waveText;

    [SerializeField]
    private Text currencyTxt;

    public ObjectPool Pool { get; set; }
 
    public Portal portal;

   private List<Monster> activeMonster = new List<Monster>();
 
    public bool WaveActive
    {
        get
        {
            return activeMonster.Count > 0;
        }
    }

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


    private void Awake()
    {
        
        Pool = GetComponent<ObjectPool>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
        Currency = 100;
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

    public void StartWave()
    {
        wave++;

        waveText.text = string.Format("Wave:<color=lime>{0}</color>", wave);

        StartCoroutine(SpawnWave());

        WaveBtn.SetActive(false);
    }

    
    private IEnumerator SpawnWave()
    {

        for (int i = 0; i < wave; i++)
        {
            //int monsterIndex = Random.Range(0, 4);
            int monsterIndex = 0;
            string type = string.Empty;

            switch (monsterIndex)
            {
                case 0:
                    type = "Zombie";
                    break;
                default:
                    break;
            }

            Monster monster = Pool.GetObject(type).GetComponent<Monster>();

            activeMonster.Add(monster);

            monster.Spawn();

            yield return new WaitForSeconds(2.5f);
        }
       
    }
    
    public void RemoveMonster(Monster monster)
    {
        activeMonster.Remove(monster);

        if (!WaveActive)
        {
            WaveBtn.SetActive(true);
        }
    }
}

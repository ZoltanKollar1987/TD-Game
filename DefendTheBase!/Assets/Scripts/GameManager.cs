using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{

    private int beginingMonsterHp = 10;
    public TowerButton ClickBtn { get; set; }

    [SerializeField]
    private GameObject WaveBtn;

    private int currency;

    private int wave = 0;

    [SerializeField]
    private Text waveText;

    [SerializeField]
    private Text currencyTxt;

    [SerializeField]
    private Text scoreTxt;

    private int score;

    public ObjectPool Pool { get; set; }

    public Portal portal;

    private List<Monster> activeMonster = new List<Monster>();

    private int healt;

    [SerializeField]
    private Text healtTxt;

    private bool gameOver = false;

    [SerializeField]
    private GameObject gameOverMenu;

    private Tower selectedTower;

    [SerializeField]
    private GameObject menu;

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

    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            this.score = value;
            this.scoreTxt.text = string.Format("Score:<color=lime>{0}</color>", score);

        }
    }

    public int Healt
    {
        get
        {
            return healt;
        }
        set
        {
            this.healt = value;

            if (healt <= 0)
            {
                this.healt = 0;
                GameOver();
            }


            this.healtTxt.text = healt.ToString();
        }
    }

    private void Awake()
    {

        Pool = GetComponent<ObjectPool>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Healt = 5;
        Currency = 4;
    }

    // Update is called once per frame
    void Update()
    {
        HandleEcape();
    }

    public void PickTower(TowerButton towerBtn)
    {
        if (Currency >= towerBtn.Price && !WaveActive && !gameOver)
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

    public void SelectTower(Tower tower)
    {

        if (selectedTower != null)
        {
            selectedTower.Select();
        }

        selectedTower = tower;
        selectedTower.Select();
    }

    public void DeselectTower()
    {
        if (selectedTower != null)
        {
            selectedTower.Select();
        }

        selectedTower = null;
    }

    private void HandleEcape()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Hover.Instance.DeActivate();

            if (selectedTower == null && !Hover.Instance.IsVisible)
            {
                ShowMenu();
            }
            else if (Hover.Instance.IsVisible)
            {
                DropTower();
            }
            else if (selectedTower != null)
            {
                DeselectTower();
            }


            

            if (Hover.Instance.IsVisible)
            {
                DropTower();
            }
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

            monster.Spawn(beginingMonsterHp);

            
            if (wave % 3 == 0)
            {
               beginingMonsterHp += 5;
            }
            
            yield return new WaitForSeconds(2.5f);
        }
       
    }
    
    public void RemoveMonster(Monster monster)
    {
       
        activeMonster.Remove(monster);
        

        if (!WaveActive && !gameOver)
        {
            WaveBtn.SetActive(true);
        }
    }

    public void GameOver()
    {
        if (!gameOver)
        {
            gameOver = true;
            gameOverMenu.SetActive(true);
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Restart()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ShowMenu()
    {
        menu.SetActive(!menu.activeSelf);

        if (!menu.activeSelf)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
    }

    private void DropTower()
    {
        ClickBtn = null;
        Hover.Instance.DeActivate();
    }
}

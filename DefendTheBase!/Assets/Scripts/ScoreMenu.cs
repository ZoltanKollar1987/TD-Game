using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreMenu : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private GameObject scoreMenu;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleEcape();
    }

    public void ShowScoreMenu()
    {
        scoreMenu.SetActive(!scoreMenu.activeSelf);
       
    }

    private void HandleEcape()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {      
          ShowScoreMenu();                       
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void MainScene()
    {
        SceneManager.LoadScene(0);
    }
}

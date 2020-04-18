using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TileScript : MonoBehaviour
{

    public Point GridPosition { get; set; }

    private Color32 fullColor = new Color32(255, 118, 118, 255);

    private Color32 emptyColor = new Color32(96, 255, 90, 255);

    public bool IsEmpty { get; private set; }

    private Tower myTower;

    private SpriteRenderer spriteRenderer;

    public SpriteRenderer SpriteRenderer { get; set; }


    public Vector2 WorldPosition
    {
        get
        {
            return new Vector2(transform.position.x + (GetComponent<SpriteRenderer>().bounds.size.x / 2), transform.position.y - (GetComponent<SpriteRenderer>().bounds.size.y / 2));
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        IsEmpty = true;
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    /*
    public void Setup(Point gridPos,Vector3 worldPos,Transform parent)
    {
        //IsEmpty = true;
        this.GridPosition = gridPos;
        transform.position = worldPos;
        transform.SetParent(parent);
        
    }
    */
    private void OnMouseOver()
    {

        if (!EventSystem.current.IsPointerOverGameObject() && GameManager.Instance.ClickBtn != null)
        {
            if (IsEmpty)
            {
                ColorTile(emptyColor);
            }
            if (!IsEmpty)
            {
                ColorTile(fullColor);
            }
            else if (Input.GetMouseButtonDown(0))
            {
                PlaceTower();
            }

        }
        else if (!EventSystem.current.IsPointerOverGameObject() && GameManager.Instance.ClickBtn == null && Input.GetMouseButtonDown(0))
        {
            if (myTower !=null)
            {
                GameManager.Instance.SelectTower(myTower);
            }
            else
            {
                GameManager.Instance.DeselectTower();
            }
        }
        
    }

    private void OnMouseExit()
    {
        
            ColorTile(Color.white);
             
    }

    private void PlaceTower()
    {
        
        GameObject tower = (GameObject)Instantiate(GameManager.Instance.ClickBtn.TowerPrefab, transform.position, Quaternion.identity);
        tower.transform.SetParent(transform);

        this.myTower = tower.transform.GetChild(0).GetComponent<Tower>();

        IsEmpty = false;

        GameManager.Instance.BuyTower();

        ColorTile(Color.white);

    }

    private void ColorTile(Color newColor)
    {
        SpriteRenderer.color = newColor;
    } 
}

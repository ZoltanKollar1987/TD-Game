using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TileScript : MonoBehaviour
{

    public Point GridPosition { get; private set; }
    public Vector2 WorldPosition
    {
        get
        {
            return new Vector2(transform.position.x + (GetComponent<SpriteRenderer>().bounds.size.x/2), transform.position.y - (GetComponent<SpriteRenderer>().bounds.size.y/2));
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

    public void Setup(Point gridPos,Vector3 worldPos,Transform parent)
    {
        this.GridPosition = gridPos;
        transform.position = worldPos;
        transform.SetParent(parent);
        LevelManager.Instance.Tiles.Add(gridPos, this);
    }

    private void OnMouseOver()
    {

        if (!EventSystem.current.IsPointerOverGameObject() && GameManager.Instance.ClickBtn != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                PlaceTower();
            }
        }
  
    }
    private void PlaceTower()
    {
       
       GameObject tower = (GameObject)Instantiate(GameManager.Instance.ClickBtn.TowerPrefab, transform.position, Quaternion.identity);
        tower.GetComponent<SpriteRenderer>().sortingOrder = GridPosition.Y;

        tower.transform.SetParent(transform);

        Hover.Instance.DeActivate();

        GameManager.Instance.BuyTower();
    }
}

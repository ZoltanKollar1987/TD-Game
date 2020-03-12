using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] tilePrefabs;

    
    private Point portalSpawn;
  
    private Point baseSpawn;

    [SerializeField]
    private GameObject portalPrefab;

    [SerializeField]
    private GameObject basePrefab;

    public Dictionary<Point,TileScript> Tiles { get; set; }

    public float TileSize
    {
        get {return tilePrefabs[0].GetComponent<SpriteRenderer>().sprite.bounds.size.x; }
    }

    // Start is called before the first frame update
    void Start()
    {
        CreateLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreateLevel()
    {
        Tiles = new Dictionary<Point, TileScript>();

        string[] mapData = ReadLevelText();

        int mapX = mapData[0].ToCharArray().Length;
        int mapY = mapData.Length;

        Vector3 worldStart = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height));

        for (int y = 0; y < mapY; y++)
        {
            char[] newTiles = mapData[y].ToCharArray();

            for (int x = 0; x < mapX; x++)
            {
                PlaceTile(newTiles[x].ToString(),x,y,worldStart);
            }
        }

        SpawnPortal();
        SpawnBase();
    }

    private void PlaceTile(string tileType,int x, int y,Vector3 worldStart)
    {

        int tileIndex = int.Parse(tileType);

        TileScript newTile = Instantiate(tilePrefabs[tileIndex]).GetComponent<TileScript>();

        newTile.Setup(new Point(x, y),new Vector3(worldStart.x + (TileSize * x), worldStart.y - (TileSize * y),0));

        Tiles.Add(new Point(x, y), newTile);

    }

    private string[] ReadLevelText()
    {
        TextAsset bindData = Resources.Load("Level") as TextAsset;
        string data = bindData.text.Replace(Environment.NewLine, string.Empty);
        return data.Split('-');
    }


    private void SpawnPortal()
    {
        portalSpawn = new Point(0,0);

        Instantiate(portalPrefab, Tiles[portalSpawn].GetComponent<TileScript>().WorldPosition, Quaternion.identity);
    }
    
    private void SpawnBase()
    {
        baseSpawn = new Point(8,3);

        Instantiate(basePrefab, Tiles[baseSpawn].GetComponent<TileScript>().WorldPosition, Quaternion.identity);
    }
}

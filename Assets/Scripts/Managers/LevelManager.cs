using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] private GameObject tilePrefab;

    [SerializeField] private CameraMovement cameraMovement;
    [SerializeField] private Transform Map;

    public Dictionary<Point,Tile> Tiles { get; set; }
    public List<Building> Buildings;
    [SerializeField]
    private  int mapSizeX=40;
    [SerializeField]
    private  int mapSizeY=40;
    
    

    public float TileSize
    {
        get {return tilePrefab.GetComponent<SpriteRenderer>().sprite.bounds.size.x;}
    }
	// Use this for initialization
	void Start () {
        
		CreateLevel();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void CreateLevel()
    {
        Tiles=new Dictionary<Point, Tile>();

        Vector3 tileStartPoint = Camera.main.ScreenToWorldPoint(new Vector3(0,0));
        Vector3 LastTilePos = Vector3.zero;
        for (int y = 0; y <mapSizeY; y++)
        {
            for (int x = 0; x <mapSizeX; x++)
            {
                PlaceTile(x, y, tileStartPoint);
            }
        }

        LastTilePos = Tiles[new Point(mapSizeX-1, mapSizeY-1)].transform.position;
        cameraMovement.SetLimits(new Vector3(LastTilePos.x+TileSize,LastTilePos.y));
    }

    private void PlaceTile(int x,int y,Vector3 tileStartPoint)
    {
        Tile newTile = Instantiate(tilePrefab).GetComponent<Tile>();
        newTile.Init(new Point(x,y), new Vector3(tileStartPoint.x + (TileSize * x), tileStartPoint.y + (TileSize * y), 0),Map);

    }

    public bool InBounds(Point point)
    {
        return point.X >= 0 && point.Y >= 0 && point.X<mapSizeX && point.Y<mapSizeY;
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour {

    public Point GridPosition { get; private set; }
    public bool isAvailableToBuild { get; set; }
    public bool isAvailableToWalk { get; set; }

    private SpriteRenderer spriteRenderer;
    private Color32 defaultColor;
    private readonly Color32 notAvailableColor =new Color32(255,118,118,255);
    private readonly Color32 availableColor=new Color32(96,255,90,255);
    public Vector2 WorldPosCenter
    {
        get
        {
            return new Vector2(transform.position.x+(GetComponent<SpriteRenderer>().bounds.size.x/2),
                transform.position.y- (GetComponent<SpriteRenderer>().bounds.size.y / 2));
        }
    }

    private void Start()
    {
        isAvailableToWalk = true;
        isAvailableToBuild = true;
    }
    public void Init(Point gridPos,Vector3 worldPos,Transform parent)
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        defaultColor = spriteRenderer.color;
        this.GridPosition = gridPos;
        transform.position = worldPos;
        LevelManager.Instance.Tiles.Add(gridPos,this);
        this.transform.SetParent(parent);
    }
    private void OnMouseOver()
    {

        Debug.Log(GridPosition.X + ", " + GridPosition.Y);
        if (!EventSystem.current.IsPointerOverGameObject() && GameManager.Instance.ClickedBuildButton != null)
        {
            Building building = GameManager.Instance.ClickedBuildButton.BuildPrefab.GetComponent<Building>();
            if (GetAvailabilityToBuild(building.SizeX,building.SizeY))
            {
                spriteRenderer.color = availableColor;
            }
            if(!GetAvailabilityToBuild(building.SizeX, building.SizeY))
            {
                spriteRenderer.color = notAvailableColor;
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    PlaceBuilding();
                    spriteRenderer.color = defaultColor;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse1) && GameManager.Instance.SelectedSoldier!=null)
        {
            GameManager.Instance.SelectDestination(this.GridPosition);
        }
    }

    private void OnMouseExit()
    {
        if(GameManager.Instance.ClickedBuildButton!=null)
        {
            spriteRenderer.color = defaultColor;
        }
    }
    private void PlaceBuilding()
    {
        Debug.Log("Placed a building here: " + GridPosition.X + ", " + GridPosition.Y);
        GameObject building= Instantiate(GameManager.Instance.ClickedBuildButton.BuildPrefab, transform.position, Quaternion.identity);
        building.transform.SetParent(this.transform);
        GameManager.Instance.StopBuilding();
        
        int x= building.GetComponent<Building>().SizeX;
        int y = building.GetComponent<Building>().SizeY;
        building.GetComponent<Building>().GridPosition = GridPosition;
        //sending boolean : there could be an option to destroy buildings so its for open the tiles to build again.
        SetAvailability(x,y,false);    
    }
    public void SetAvailability(int _x,int _y, bool availability)
    {
        for (int y = 0; y< _y; y++)
        {
            for (int x = 0; x< _x; x++)
            {
                Point currentPoint=new Point(GridPosition.X+x,GridPosition.Y-y);
                if (LevelManager.Instance.InBounds(currentPoint))
                {
                    LevelManager.Instance.Tiles[currentPoint].isAvailableToBuild = availability;
                    LevelManager.Instance.Tiles[currentPoint].isAvailableToWalk = availability;
                }
           
            }
        }
        
    }

    public bool GetAvailabilityToBuild(int _x,int _y)
    {
        for (int y = 0; y < _y; y++)
        {
            for (int x = 0; x < _x; x++)
            {
                Point currentPoint = new Point(GridPosition.X + x, GridPosition.Y - y);
                if (LevelManager.Instance.InBounds(currentPoint))
                {
                    if (!LevelManager.Instance.Tiles[currentPoint].isAvailableToBuild)
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }

            }
        }

        return true;
    }
}

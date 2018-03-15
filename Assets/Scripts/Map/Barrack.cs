using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Barrack :Building
{
    [SerializeField]
    private GameObject soldierPrefab;

    public GameObject SoldierPrefab
    {
        get { return soldierPrefab;}
    }

    
    private Point SpawnPoint;
    private Vector2 SpawnPosition;

	// Use this for initialization
	void Awake ()
	{
	    this.Name = "Barrack";
	    this.Type =  Building.StructureType.Military;
	}

    void Start()
    {
        SpawnPoint = new Point(GridPosition.X + 1, GridPosition.Y + 1);
        
        
    }
	// Update is called once per frame
	void Update () {
		
	}
    //public Barrack(string name, StructureType type, Size size)
    //{
    //    this.Name = name;
    //    this.Type = type;
    //    this.BuildingSize = size;
    //}
    public void SpawnSoldier(GameObject soldier)
    {

        SpawnPosition = LevelManager.Instance.Tiles[SpawnPoint].transform.position;
        soldier.transform.position = SpawnPosition;
        soldier.GetComponent<ISoldier>().CurrentPoint = SpawnPoint;
        LevelManager.Instance.Tiles[SpawnPoint].SetAvailability(1,1,false);


    }

    public bool GetAvailableSpawnPoint()
    {
        
        for (int y = -SizeY; y <= 1; y++)
        {
            for (int x = -1; x < SizeX + 1; x++)
            {
               Point point = new Point(GridPosition.X+x,GridPosition.Y+y);
                if (LevelManager.Instance.Tiles[point].isAvailableToWalk)
                {
                    SpawnPoint=point;
                    return true;
                }
                
            }
        }

        return false;

    }
}

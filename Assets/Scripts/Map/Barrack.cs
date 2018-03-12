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
        SpawnPosition = LevelManager.Instance.Tiles[SpawnPoint].transform.position;
        
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
    public void SpawnSoldier()
    {
        GameObject soldier= Instantiate(soldierPrefab, SpawnPosition, Quaternion.identity);
        soldier.GetComponent<ISoldier>().CurrentPoint = SpawnPoint;
    }
 
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    public BuildButtonUI ClickedBuildButton { get;private set; }
    public ISoldier SelectedSoldier { get; private set; }
    public Point StartPoint { get; private set; }
    public Point EndPoint { get; private set; }
    
	// Use this for initialization
	void Start ()
	{
	    EventManager.OnTrainSoldier += TrainSoldier;
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.Mouse1) || Input.GetKeyDown(KeyCode.Escape) && this.ClickedBuildButton!=null)
	    {
	        StopBuilding();
	    }
    }
    
    public void PickBuilding(BuildButtonUI buildButton)
    {
        this.ClickedBuildButton = buildButton;
        MouseHover.Instance.Activate(buildButton.GetComponent<Button>().image.sprite);

    }

    //Sets the last clicked button to null just for now
    public void StopBuilding()
    {
        this.ClickedBuildButton = null;
        MouseHover.Instance.Deactivate();
    }

    private void TrainSoldier(Building building)
    {
        building.GetComponent<Barrack>().SpawnSoldier();
    }

    public void SelectSoldier(ISoldier soldier)
    {
        SelectedSoldier = soldier;
        StartPoint = soldier.CurrentPoint;
    }

    public void SelectDestination(Point endPoint)
    {
        EndPoint = endPoint;
        AStar.GetPath(StartPoint,EndPoint);
    }
}
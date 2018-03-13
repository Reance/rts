using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager
{

    public delegate void InfoEventHandler(Building building);

   
    public static event InfoEventHandler OnBuildingSelected;
    //public static event InfoEventHandler OnTrainSoldier;

    public static void SelectBuilding(Building building)
    {
        OnBuildingSelected(building);
    }

    //public static void TrainSoldier(Building building,string soldierType)
    //{
    //    OnTrainSoldier(building,soldierType);
    //}

   
}

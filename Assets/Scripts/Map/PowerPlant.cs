using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPlant : Building
{ 
    // Use this for initialization
    void Start ()
	{
	    this.Name = "Power Plant";
	    this.Type = Building.StructureType.Production;
       
	}

}

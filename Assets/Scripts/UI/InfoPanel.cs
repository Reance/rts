using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoPanel : MonoBehaviour
{
    [SerializeField]
    private Image BuildingImage;
    [SerializeField]
    private Button ProductionButton;
    [SerializeField]
    private Text BuildingName;
    [SerializeField]
    private Text ProductName;
    [SerializeField]
    private GameObject View;

    private Building LastShownBuilding;
	// Use this for initialization
	void Start ()
	{
	    EventManager.OnBuildingSelected += ShowBuildingInfo;
        ProductionButton.onClick.AddListener(OnProduceButtonClicked);
        View.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void ShowBuildingInfo(Building building)
    {
        View.SetActive(true);

        BuildingImage.sprite = building.GetComponent<SpriteRenderer>().sprite;
        BuildingName.text = building.Name;
        if ( building.Type==Building.StructureType.Military)
        {
            ProductionButton.gameObject.SetActive(true);

            ProductionButton.image.sprite = building.transform.GetComponent<Barrack>().SoldierPrefab.GetComponent<SpriteRenderer>().sprite;
            
        }
        else
        {
            ProductionButton.gameObject.SetActive(false);
        }

        LastShownBuilding = building;
    }

    void OnProduceButtonClicked()
    {

       // EventManager.TrainSoldier(LastShownBuilding);
        GameManager.Instance.TrainSoldier(LastShownBuilding,ProductName.text);//need refactoring!
    }
}

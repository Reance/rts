using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Building:MonoBehaviour
{
    public enum StructureType
    {
        Military,
        Production,
        Storage
    };
    
    public string Name{ get; set; }
    public StructureType Type { get; set; }
    public int SizeX;
    public int SizeY;
    public Point GridPosition;
    
    //int Cost { get; set; }//TODO need currency system  
    private SpriteRenderer spriteRenderer;
    IEnumerator Wait()
    {
        // suspend execution for  seconds
        yield return new WaitForSeconds(2);
        
    }
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        EventManager.OnBuildingSelected += TurnOffHighlight;
    }

    private void OnMouseOver()
    {
        if (!EventSystem.current.IsPointerOverGameObject()&&Input.GetKeyDown(KeyCode.Mouse0))
        {
            EventManager.SelectBuilding(this);
            TurnOnHighlight();
        }
    }
    //TODO make this work
    private void TurnOffHighlight(Building building)
    {
        spriteRenderer.color = Color.white;
    }

    IEnumerator TurnOnHighlight()
    {
        yield return StartCoroutine("Wait");
        spriteRenderer.color = Color.yellow;
    }
}

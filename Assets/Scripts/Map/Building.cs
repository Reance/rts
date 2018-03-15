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
    

  

    private void OnMouseOver()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                
                EventManager.SelectBuilding(this);
                GameManager.Instance.DeselectBuilding();
                StartCoroutine(HighlightBuildingCoroutine());

            }
        }
    }

    public IEnumerator HighlightBuildingCoroutine()
    {
        yield return new WaitForEndOfFrame();
        GetComponent<SpriteRenderer>().color=Color.yellow;
    }
}

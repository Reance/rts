using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildButtonUI : MonoBehaviour
{
    [SerializeField]
    private GameObject buildPrefab;

    public GameObject BuildPrefab
    {
        get { return buildPrefab; }
    }

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(SetPickedBuilding);
    }

    void SetPickedBuilding()
    {
        GameManager.Instance.PickBuilding(this);
    }
}

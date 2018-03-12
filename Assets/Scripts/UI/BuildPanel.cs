using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BuildPanel : MonoBehaviour
{
    [SerializeField]
    private List<Button> buildButtonsToInstantiate;
    [SerializeField]
    private Transform parent;
    [SerializeField]
    private Scrollbar scrollbar;

	// Use this for initialization
	void Start () {
	    for (int i = 0; i < 10; i++)
	    {
            AddButtons();
	    }
	}
	
	// Update is called once per frame
	void Update () {
	    if (scrollbar.value < 0.1)
	    {
	        for (int i = 0; i < 2; i++)
	        {
                AddButtons();
	        }
	    }
	}

    void AddButtons()
    {
        foreach (var button in buildButtonsToInstantiate)
        {
            Instantiate(button, parent.position, Quaternion.identity, parent);
        }
    }
}

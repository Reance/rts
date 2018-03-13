using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField]
    private GameObject[] objectPrefab;

    public GameObject getObject(string type)
    {
        for (int i = 0; i < objectPrefab.Length; i++)
        {
            if (objectPrefab[i].name == type)
            {
                GameObject newObject = Instantiate(objectPrefab[i]);
                //newObject.name = type;
                return newObject;
            }
        }

        return null;
    }

}

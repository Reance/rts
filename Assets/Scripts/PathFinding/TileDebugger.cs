using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class TileDebugger : MonoBehaviour
{

    [SerializeField]
    private Text F;
    [SerializeField]
    private Text G;
    [SerializeField]
    private Text H;

    public Text Ftext
    {
        get
        {
            F.gameObject.SetActive(true);
            return F;
        }
        set { this.F = value; }
    }
    public Text Gtext
    {
        get
        {
            G.gameObject.SetActive(true);
            return G;
        }
        set { this.G = value; }
    }
    public Text Htext
    {
        get
        {
            H.gameObject.SetActive(true);
            return H;
        }
        set { this.H = value; }
    }

}

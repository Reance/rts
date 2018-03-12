using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Graphs;
using UnityEngine;
using UnityEngine.UI;

public class AStarDebugger : MonoBehaviour
{
    [SerializeField]
    private GameObject arrowPrefab;
    [SerializeField]
    private GameObject DebuggingTilePrefab;
   
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DebugPath(HashSet<Node> openList,HashSet<Node> closedList, Node startNode,Node endNode,Stack<Node> path)
    {
        CreateDebuggingTile(startNode.TileRef.WorldPosCenter,Color.green);
        CreateDebuggingTile(endNode.TileRef.WorldPosCenter,Color.red);
        foreach (Node node in openList)
        {
            if (node != startNode && node != endNode)
            {
                CreateDebuggingTile(node.TileRef.WorldPosCenter, Color.cyan,node);
            }
            
            PointToParent(node);
        }
        foreach (Node node in closedList)
        {
            if (node != endNode && node!=startNode)
            {
                CreateDebuggingTile(node.TileRef.WorldPosCenter, Color.blue,node);

            }
            PointToParent(node);
        }

        foreach (Node node in path)
        {
            if (node != endNode && node != startNode)
            {
                CreateDebuggingTile(node.TileRef.WorldPosCenter, Color.yellow, node);

            }
            PointToParent(node);
        }
    }

    private void PointToParent(Node node)
    {
        

        if (node.Parent != null)
        {
            GameObject arrow = Instantiate(arrowPrefab, node.TileRef.WorldPosCenter, Quaternion.identity);
            //if parent right side of the node
            if (node.GridPosition.X < node.Parent.GridPosition.X && node.GridPosition.Y == node.Parent.GridPosition.Y)
            {
                arrow.transform.eulerAngles = new Vector3(0, 0, 180);
            }//top right
            else if (node.GridPosition.X < node.Parent.GridPosition.X && node.GridPosition.Y < node.Parent.GridPosition.Y)
            {
                arrow.transform.eulerAngles = new Vector3(0, 0, 225);
            }//top left
            else if (node.GridPosition.X > node.Parent.GridPosition.X && node.GridPosition.Y < node.Parent.GridPosition.Y)
            {
                arrow.transform.eulerAngles = new Vector3(0, 0, -45);
            }//left
            else if (node.GridPosition.X > node.Parent.GridPosition.X && node.GridPosition.Y == node.Parent.GridPosition.Y)
            {
                arrow.transform.eulerAngles = new Vector3(0, 0, 0);
            }//top
            else if (node.GridPosition.X == node.Parent.GridPosition.X && node.GridPosition.Y < node.Parent.GridPosition.Y)
            {
                arrow.transform.eulerAngles = new Vector3(0, 0, -90);
            }//bottom
            else if (node.GridPosition.X == node.Parent.GridPosition.X && node.GridPosition.Y > node.Parent.GridPosition.Y)
            {
                arrow.transform.eulerAngles = new Vector3(0, 0, 90);
            }//bottom left
            else if (node.GridPosition.X > node.Parent.GridPosition.X && node.GridPosition.Y > node.Parent.GridPosition.Y)
            {
                arrow.transform.eulerAngles = new Vector3(0, 0, 45);
            }//bottom right
            else if (node.GridPosition.X < node.Parent.GridPosition.X && node.GridPosition.Y > node.Parent.GridPosition.Y)
            {
                arrow.transform.eulerAngles = new Vector3(0, 0, 125);
            }
            else
            {
                return;
            }
        }
      
    }

    void CreateDebuggingTile(Vector3 worldPos, Color color, Node node = null)
    {
        GameObject debuggingTile = Instantiate(DebuggingTilePrefab, worldPos, Quaternion.identity);
        debuggingTile.transform.position = worldPos;
        if (node != null)
        {
            TileDebugger tileDebugger= debuggingTile.GetComponent<TileDebugger>();
            tileDebugger.Gtext.text += node.G.ToString();
            tileDebugger.Htext.text += node.H.ToString();
            tileDebugger.Ftext.text += node.F.ToString();
        }
        debuggingTile.GetComponent<SpriteRenderer>().color = color;
    }
}

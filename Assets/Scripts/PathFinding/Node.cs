using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{

    public Point GridPosition { get; set; }
    public Tile TileRef { get; private set; }
    public Node Parent { get; private set; }
    public int G { get; private set; }
    public int H { get; private set; }
    public int F { get; private set; }
    public Node(Tile tileRef)
    {
        this.TileRef = tileRef;
        this.GridPosition = tileRef.GridPosition;
    }

    public void CalculateValues(Node parent,Node destination,int gCost)
    {
        this.Parent = parent;

        G = gCost+parent.G;

        H = 10 * (Mathf.Abs(this.GridPosition.X - destination.GridPosition.X) +
                  Mathf.Abs(this.GridPosition.Y - destination.GridPosition.Y));

        F = G + H;
    }
}

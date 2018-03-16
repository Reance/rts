using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class AStar
{
    private static Dictionary<Point, Node> nodes;
    
    private static void CreateNodes()
    {
        nodes=new Dictionary<Point, Node>();
        foreach (Tile tile in LevelManager.Instance.Tiles.Values)
        {
            nodes.Add(tile.GridPosition,new Node(tile));
        }
    }

    public static Stack<Node> GetPath(Point StartPoint,Point EndPoint)
    {
        if (nodes == null)
        {
            CreateNodes();
        }
        HashSet<Node> openList=new HashSet<Node>();
        HashSet<Node> closedList= new HashSet<Node>();
        Stack<Node> finalPath=new Stack<Node>();

        
        Point neighbourPos = new Point();
        Node currentNode = nodes[StartPoint];
        Node startNode = nodes[StartPoint];
        Node endNode = nodes[EndPoint];
        openList.Add(currentNode);

        while (openList.Count > 0)
        {
            //run through all neighborhood
            for (int y = -1; y <= 1; y++)
            {
                for (int x = -1; x <= 1; x++)
                {
                    neighbourPos = new Point(currentNode.GridPosition.X + x, currentNode.GridPosition.Y + y);
                    Node neighbour = nodes[neighbourPos];

                    if (neighbourPos != currentNode.GridPosition && LevelManager.Instance.Tiles[neighbourPos].isAvailableToWalk && LevelManager.Instance.InBounds(neighbourPos))
                    {
                        int Gcost = 0;
                        if (Mathf.Abs(x - y) == 1)
                        {
                            Gcost = 10;
                        }
                        else
                        {
                            //
                            if (!isConnectedDiagonally(currentNode, neighbour))
                            {
                                continue;
                            }
                            Gcost = 14;
                            // continue;

                        }
                       
                        if (openList.Contains(neighbour))
                        {
                            if (currentNode.G + Gcost < neighbour.G)
                            {
                                neighbour.CalculateValues(currentNode, endNode, Gcost);//reparenting the node
                            }
                        }
                        //adds neighbour to the openlist
                        else if (!closedList.Contains(neighbour))
                        {
                            openList.Add(neighbour);
                            neighbour.CalculateValues(currentNode, endNode, Gcost);
                        }
                       
                    }
                }
            }

            openList.Remove(currentNode);
            closedList.Add(currentNode);

            if (openList.Count > 0)
            {
                currentNode = openList.OrderBy(node => node.F).First();//adding the node which have lowest cost among the neighbours
            }

            if (currentNode == endNode)
            {
                while (currentNode!=startNode)
                {
                    finalPath.Push(currentNode);
                    currentNode = currentNode.Parent;
                }
                
                break;
            }
        }
        //ONLY FOR DEBUGGING 
        //AStarDebugger aStarDebugger = GameObject.FindObjectOfType<AStarDebugger>();
        //if (aStarDebugger != null)
        //{
        //    aStarDebugger.DebugPath(openList, closedList, startNode, endNode, finalPath);
        //}

        return finalPath;

        
    }
    //checks the diagonal path for collisions 
    private static bool isConnectedDiagonally(Node currentNode, Node neighbour)
    {
        Point direction = neighbour.GridPosition - currentNode.GridPosition;
        Point first = new Point(currentNode.GridPosition.X+direction.X,currentNode.GridPosition.Y);
        Point second=new Point(currentNode.GridPosition.X,currentNode.GridPosition.Y + direction.Y);

        if (LevelManager.Instance.InBounds(first) && !LevelManager.Instance.Tiles[first].isAvailableToWalk ||
            LevelManager.Instance.InBounds(second) && !LevelManager.Instance.Tiles[second].isAvailableToWalk)
        {
            return false;
        }
        else
        {
            return true;
        }
        
    }
}

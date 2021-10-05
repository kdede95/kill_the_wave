using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Node currentSearchNode;
    Vector2Int[] directions = { Vector2Int.right, Vector2Int.left, Vector2Int.up, Vector2Int.down };


    GridManager gridManager;
    Dictionary<Vector2Int, Node> grid;
    private void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        if (gridManager!=null)
        {
            grid = gridManager.Grid;
        }
    }
    void Start()
    {
        ExploreNeighbors();
    }

    private void ExploreNeighbors()
    {
        List<Node> neighbors = new List<Node>();

        for (int i = 0; i < directions.Length; i++)
        {
            Vector2Int neighborCoords = currentSearchNode.coordinates + directions[i];
            
            if (grid.ContainsKey(neighborCoords))
            {
                neighbors.Add(grid[neighborCoords]);

                //Remove after testing
                grid[neighborCoords].isExplored = true;
                grid[currentSearchNode.coordinates].isPath = true;
            }
            
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] Tower towerPrefab;
    [SerializeField] bool isPlaceable;


    GridManager gridManager;
    Pathfinder pathfinder;
    Vector2Int coordinates = new Vector2Int();
    public bool IsPlaceable{ get { return isPlaceable; } }
    private void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        pathfinder = FindObjectOfType<Pathfinder>();
        
    }

    private void Start()
    {
        if (gridManager!=null)
        {
            coordinates = gridManager.GetCoordinatesFromPosition(transform.position);

            if (!isPlaceable)
            {
                gridManager.BlockNode(coordinates);
            }
        }
    }
    private void OnMouseDown()
    {
        if (gridManager.GetNode(coordinates).isWalkable && !pathfinder.WillBlockPath(coordinates))
        {
            bool isSuccessfull = towerPrefab.CreateTower(towerPrefab,transform.position);
            if (isSuccessfull)
            {
                gridManager.BlockNode(coordinates);
                pathfinder.NotifyReceievers();
            }
            

            

        }
        
    }
    

}

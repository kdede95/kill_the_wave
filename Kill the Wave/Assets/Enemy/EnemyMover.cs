using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    
    [SerializeField][Range(0f,5f)] float speed = 1f;
    List<Node> path = new List<Node>();
    Enemy enemy;
    GridManager gridManager;
    Pathfinder pathfinder;
   // GoldDisplayerer gd;
    public Node startLocation { get { return path[0]; } }
    // Start is called before the first frame update
    void OnEnable()
    {
        GetToStart();
        RecalculatePath(true);
        
        
        
    }
   
    private void Awake()
    {
        enemy = GetComponent<Enemy>();
        gridManager = FindObjectOfType<GridManager>();
        pathfinder = FindObjectOfType<Pathfinder>();

    }
    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }
    void GetToStart()
    {
        transform.position = gridManager.GetPositionFromCoordinates(pathfinder.StartCoordinates);
    }
   public void RecalculatePath(bool resetPath)
    {
        Vector2Int coordinates = new Vector2Int();
        if (!resetPath)
        {
            coordinates = pathfinder.StartCoordinates;
        }
        else
        {
            coordinates = gridManager.GetCoordinatesFromPosition(transform.position);
        }

        StopAllCoroutines();
        path.Clear();
        path = pathfinder.GetNewPath();

        StartCoroutine(FollowPath());
    }

    void FinishPath()
    {
        enemy.WithdrawGold();
        gameObject.SetActive(false);
    }
    IEnumerator FollowPath()
    {
        for (int i = 1; i < path.Count; i++)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = gridManager.GetPositionFromCoordinates(path[i].coordinates) ;
            float travelPercent = 0f;

            transform.LookAt(endPosition);
            while (travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }
       
        FinishPath();
        // gd.CreateTheText(enemy.GoldPenalty ,transform.position,5f);

    }
    
   
}

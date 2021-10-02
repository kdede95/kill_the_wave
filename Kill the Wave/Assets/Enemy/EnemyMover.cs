using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField][Range(0f,5f)] float speed = 1f;

    Enemy enemy;
   // GoldDisplayerer gd;
    public Waypoint startLocation { get { return path[0]; } }
    // Start is called before the first frame update
    void OnEnable()
    {
        FindPath();
        GetToStart();
        StartCoroutine(FollowPath());
        
    }
    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }
    void GetToStart()
    {
        transform.position = path[0].transform.position;
    }
    void FindPath()
    {
        path.Clear();
        GameObject pathParent = GameObject.FindGameObjectWithTag("Path");

        foreach (Transform childTile in pathParent.transform)
        {
            Waypoint waypoint = childTile.GetComponent<Waypoint>();
            if (waypoint!=null)
            {
                path.Add(waypoint);
            }
            
        }
    }

    void FinishPath()
    {
        enemy.WithdrawGold();
        gameObject.SetActive(false);
    }
    IEnumerator FollowPath()
    {
        foreach (Waypoint waypoint in path)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position;
            float travelPercent = 0f;

            transform.LookAt(endPosition);
            while (travelPercent<1f)
            {
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }
            
            
        }
        FinishPath();
        // gd.CreateTheText(enemy.GoldPenalty ,transform.position,5f);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

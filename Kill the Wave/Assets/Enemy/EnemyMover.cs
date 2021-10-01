using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField][Range(0f,5f)] float speed = 1f;

    Enemy enemy;
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
            path.Add(childTile.GetComponent<Waypoint>());
        }
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

        enemy.WithdrawGold();
        gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

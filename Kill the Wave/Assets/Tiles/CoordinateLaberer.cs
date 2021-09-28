using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[ExecuteAlways]
public class CoordinateLaberer : MonoBehaviour
{
    // Start is called before the first frame update

    TextMeshPro label;
    Vector2Int coordinates= new Vector2Int();

    private void Awake()
    {
        label = GetComponent<TextMeshPro>();
        DisplayCoordinates();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
        }
    }

    private void DisplayCoordinates()
    {
       
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);
        label.text = $"{coordinates.x },{coordinates.y }";
    }
    void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }
}

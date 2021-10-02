using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;


[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CoordinateLaberer : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.gray;

    TextMeshPro label;
    Vector2Int coordinates= new Vector2Int();
    Waypoint waypoint;
    Shader shader;
    private void Awake()
    {
        label = GetComponent<TextMeshPro>();

        label.enabled = false;
        waypoint = GetComponentInParent<Waypoint>();
        shader = label.GetComponent<Shader>();
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

        SetLabelColor();
        ToggleLabels();
    }
    void ToggleLabels()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.IsActive();
        }
    }

    private void SetLabelColor()
    {
        
       // label.GetComponent<Shader>();
        if (!waypoint.IsPlaceable)
        {
            label.color = blockedColor;
        }
        else
        {
            label.color = defaultColor;
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

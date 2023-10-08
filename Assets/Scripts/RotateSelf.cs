using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

/// <summary>
/// ÈÆ×ÔÉíÐý×ª
/// </summary>
public class RotateSelf : MonoBehaviour
{
    public float rotatespeed;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, rotatespeed * Time.deltaTime);
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///
/// </summary>

public class LifeCycle : MonoBehaviour
{

    private void Awake()
    {
        Debug.Log("awakee" + Time.time);
    }

    private void Start()
    {
        Debug.Log("start" + Time.time);
    }

    private void FixedUpdate()
    {
        //Debug.Log(Time.time);
    }

    private void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Debug.Log("down" + Time.time);
    }

    //[SerializeField]
    //private int a = 100;

    //[HideInInspector]
    //public int b = 200;

    //[Range(0, 100)]
    //public int c; 

}

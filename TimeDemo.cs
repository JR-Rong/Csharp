using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///
/// </summary>

public class TimeDemo : MonoBehaviour
{
    public float t;

    public void Update()
    {
        t = Time.time;
        //保证旋转不受机器性能影响
        this.transform.RotateAround(Vector3.zero, transform.up, 20 * Time.deltaTime);

    }

}

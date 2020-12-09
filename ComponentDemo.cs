using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///component类提供了查找组件的功能，在当前物体、后代、祖先查找组件
/// </summary>

public class ComponentDemo : MonoBehaviour
{
    private void OnGUI()
    {
        if (GUILayout.Button("点我"))
        {
            print("ok");
            this.transform.position = new Vector3(1, 2, 3);
            this.GetComponent<MeshRenderer>().material.color = Color.red;
            var allcomponent = this.GetComponents<Component>();
            var children = this.GetComponentsInChildren<MeshRenderer>(); 
            foreach(var item in children)
            {
                item.material.color = Color.green;
            }
        }
    }

}

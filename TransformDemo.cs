using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///tranform类提供了查找（爸、孩子）变换方法，改变位置角度方法
/// </summary>

public class TransformDemo : MonoBehaviour
{

    public Transform tf;
    private void OnGUI()
    {

        if(GUILayout.Button("rotate"))
        {
            //foreach(Transform item in this.transform)
            //{
            //    print(item.name);
            //}
            this.transform.Translate(0,0,1,Space.World);

            this.transform.Rotate(0, 10, 1, Space.Self);

        }

        if (GUILayout.RepeatButton("rotatearound"))
        {
            this.transform.RotateAround(Vector3.zero, Vector3.up, 5);
        }

        if (GUILayout.RepeatButton("root"))
        {
            Transform root1 = this.transform.root;
        }

        if (GUILayout.RepeatButton("parent"))
        {
            Transform parent01 = this.transform.parent;
        }

        if (GUILayout.RepeatButton("setparent"))
        {
            this.transform.SetParent(tf, false);
        }

        if (GUILayout.RepeatButton("light"))
        {
            GameObject gamelight = new GameObject();
            Light light = gamelight.AddComponent<Light>();
            light.color = Color.blue;
            light.type = LightType.Point;

        }

        if (GUILayout.RepeatButton("fineEnemy"))
        {
            Enemy enemy = new Enemy();
            enemy.HP = 100;
            Enemy[] enemys = FindObjectsOfType<Enemy>();
            foreach (Enemy item in enemys)
            {
                if (item.HP < enemy.HP)
                    enemy = item;
            }

            print(enemy.name);
        }

    }

}

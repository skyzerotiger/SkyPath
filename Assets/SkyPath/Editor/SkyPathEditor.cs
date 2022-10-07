using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace SkyPath
{
    public class SkyPathEditor : MonoBehaviour
    {
        [MenuItem("GameObject/SkyPath/Create")]
        static void Create()
        {
            GameObject skyPathObject = new GameObject("SkyPath");
            skyPathObject.AddComponent<SkyPath>();

            GameObject p1 = new GameObject("p1");
            p1.AddComponent<SkyPathPoint>();
            p1.transform.parent = skyPathObject.transform;
            p1.transform.position = Vector3.zero;

            GameObject p2 = new GameObject("p2");
            p2.AddComponent<SkyPathPoint>();
            p2.transform.parent = skyPathObject.transform;
            p2.transform.position = new Vector3(1, 0, 0);
        }
    }
}
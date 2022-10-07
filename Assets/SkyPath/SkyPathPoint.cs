using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SkyPath
{
    public class SkyPathPoint : MonoBehaviour
    {
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(transform.position, 0.1f);
        }
    }
}
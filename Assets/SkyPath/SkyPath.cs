using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace SkyPath
{
    public class SkyPath : MonoBehaviour
    {
        [Range(0f, 1f)]
        public float alpha;

        SkyPathPoint[] pointList;

        private void OnDrawGizmos()
        {
            pointList = gameObject.GetComponentsInChildren<SkyPathPoint>();
            if (pointList.Length < 2)
                return;

            int i;
            for(i=1;i<pointList.Length;i++)
            {
                Gizmos.color = Color.white;
                Gizmos.DrawLine(pointList[i - 1].transform.position, pointList[i].transform.position);
            }

            Gizmos.color = Color.red;
            Gizmos.DrawSphere(GetPoint(alpha), 0.1f);
        }

        public Vector3 GetPoint(float alpha)
        {
            pointList = gameObject.GetComponentsInChildren<SkyPathPoint>();
            if (pointList.Length < 2)
                return Vector3.zero;

            if (alpha < 0)
                alpha = 0;
            if (alpha > 1)
                alpha = 1;

            //전체 거리를 구한다.
            float totalDist=0;
            List<float> distList = new List<float>();
            distList.Add(0);    // 첫포인트는 거리가 없어 0을 넣는다.

            int i;
            for(i=1;i<pointList.Length;i++)
            {
                totalDist += Vector3.Distance(pointList[i - 1].transform.position, pointList[i].transform.position);
                distList.Add(totalDist);
            }

            //Debug.Log("totalLength = " + totalDist);
            float alphaDist = totalDist * alpha;
            //Debug.Log("alphaDist = " + alphaDist);

            for (i = 1; i < pointList.Length; i++)
            {
                //Debug.Log("alphaDist = " + alphaDist + ", " + distList[i]);
                if (alphaDist <= distList[i])
                {
                    float denominator = distList[i] - distList[i - 1];
                    float numerator = alphaDist - distList[i - 1];

                    float pointAlpha = numerator / denominator;

                    //Debug.Log("denominator = " + denominator);
                    //Debug.Log("numerator = " + numerator);
                    //Debug.Log("pointAlpha = " + pointAlpha);

                    return Vector3.Lerp(pointList[i - 1].transform.position, pointList[i].transform.position, pointAlpha);
                }
            }

            return Vector3.zero;
        }
    }
}
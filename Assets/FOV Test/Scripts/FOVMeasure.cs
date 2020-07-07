using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class FOVMeasure : MonoBehaviour
{
    public float FOV = 60;

    public float circleDistance = 10f;

    public LineRenderer lineRenderer;

    public TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 360; i++)
        {
            circlePoints.Add(Vector3.zero);
        }

        if (lineRenderer == null)
            lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 360;

    }

    List<Vector3> circlePoints = new List<Vector3>(360);

    // Update is called once per frame
    void Update()
    {
        //Vector3 circleCenter = transform.position + (transform.forward * circleDistance);
        //Debug.DrawLine(transform.position, circleCenter, Color.red);

        for (int i = 0; i < 360; i++)
        {
            if (circlePoints[i] != null)
            {
                circlePoints[i] = transform.position + transform.rotation * Quaternion.Euler(0, 0, i) * Quaternion.Euler(0f, FOV / 2f, 0f) * (Vector3.forward * circleDistance);
                //Debug.DrawLine(circleCenter, circlePoints[i].transform.position, Color.blue);
            }
        }
        lineRenderer.SetPositions(circlePoints.ToArray());

        if (text != null)
        {
            text.text = FOV.ToString("F1") + "°";
        }
    }
}

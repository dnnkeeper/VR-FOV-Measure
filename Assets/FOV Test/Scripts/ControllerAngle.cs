using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerAngle : MonoBehaviour
{
    public FOVMeasure fovMeasure;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(fovMeasure.transform.position, fovMeasure.transform.forward, Color.red);
        Debug.DrawRay(fovMeasure.transform.position, transform.position - fovMeasure.transform.position, Color.yellow);

        fovMeasure.FOV = 2f * Vector3.Angle(fovMeasure.transform.forward, transform.position - fovMeasure.transform.position);
    }
}

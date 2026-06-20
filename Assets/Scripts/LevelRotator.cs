using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelRotator : MonoBehaviour
{
    private const string HorizontalAxisName = "Horizontal";
    private const string VerticalAxisName = "Vertical";

    [SerializeField] private float _rotateSpeed;

    private void Update()
    {
        ProcessRotate();
    }

    private void ProcessRotate()
    {
        float zAxisRotate = Input.GetAxisRaw(HorizontalAxisName);
        float xAxisRotate = Input.GetAxisRaw(VerticalAxisName);

        Vector3 rotate = new Vector3(xAxisRotate, 0, zAxisRotate) * _rotateSpeed * Time.deltaTime;
        transform.rotation *= Quaternion.Euler(rotate);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFollower : MonoBehaviour
{
	[SerializeField] private Transform _target;
	[SerializeField] private Vector3 _offset;

	private void LateUpdate()
	{
		transform.position = _target.transform.position + _offset;
	}
}

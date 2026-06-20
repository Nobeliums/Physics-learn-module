using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabyrinthGameController : MonoBehaviour
{
	private const string PlayerGameObjectName = "Player";
	private bool _isGameEnd;

	private void OnTriggerEnter(Collider other)
	{
		GameObject colliderObject = other.gameObject;

		if (colliderObject.name == PlayerGameObjectName)
		{
			Time.timeScale = 0.0f;
			Debug.Log("Поздравляю! Вы прошли лабиринт");
		}
	}
}

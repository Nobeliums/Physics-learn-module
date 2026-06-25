using System;
using UnityEngine;
using Random = System.Random;

public class Coin : MonoBehaviour
{
	[SerializeField] private int _maxScoreValue;

	public int ScoreValue { get; private set; }

	private void Start()
	{
		Random rnd = new Random();
		ScoreValue = rnd.Next(0, _maxScoreValue + 1);
	}

	public void Collect()
	{
		gameObject.SetActive(false);
	}
}

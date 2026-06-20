using System;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	private const float TimeStep = 1.0f; 
	
	[SerializeField] private float _startGameTimeInSeconds;
	[SerializeField] private List<Coin> _allCoins;
	
	private float _gameTimeLeft;
	private float _timeStepConter;
	
	private int _previousAvailableCoins;

	private bool _isGameEnd;

	private void Start()
	{
		_gameTimeLeft = _startGameTimeInSeconds;
		_isGameEnd = false;
		_previousAvailableCoins = _allCoins.Count;
	}

	private void Update()
	{
		if (_isGameEnd == false)
		{
			CalculateTime();
			CheckAvailableCoins();
			CheckGameEnd();
		}
	}

	private void Win()
	{
		Debug.Log($"Ура! Вы подбедили и собрали {_allCoins.Count} монет.");
		Time.timeScale = 0.0f;
	}

	private void Lose()
	{
		Debug.Log($"Вы не успели собрать {_previousAvailableCoins} монет :(");
		Time.timeScale = 0.0f;
	}

	private void CheckGameEnd()
	{
		if (_gameTimeLeft <= 0.0f)
		{
			_isGameEnd = true;
			Lose();
		}
		
		if (_previousAvailableCoins == 0)
		{
			_isGameEnd = true;
			Win();
		}
	}

	private void CalculateTime()
	{
		_gameTimeLeft -= Time.deltaTime;
		_timeStepConter += Time.deltaTime;

		if (_timeStepConter >= TimeStep)
		{
			Debug.Log($"У вас осталось {_gameTimeLeft.ToString("0")} секунд!");
			_timeStepConter = 0.0f;
		}
	}

	private void CheckAvailableCoins()
	{
		int availableCoins = 0;

		foreach (var coin in _allCoins)
		{
			if (coin.gameObject.activeSelf)
			{
				availableCoins++;
			}
		}

		if (availableCoins != _previousAvailableCoins)
		{
			int collectedCoins = _allCoins.Count - availableCoins;
			Debug.Log($"Вы собрали {collectedCoins}/{_allCoins.Count} монет, ещё осталось {availableCoins} монет");
		}

		_previousAvailableCoins = availableCoins;
	}
}
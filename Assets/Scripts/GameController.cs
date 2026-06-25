using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameController : MonoBehaviour
{
	[SerializeField] private float _startGameTimeInSeconds;
	[SerializeField] private CoinCollector _coinCollector;

	private int _previousAvailableCoins;
	private bool _isGameEnd;

	private Timer _timer;

	private void Start()
	{
		_timer = new Timer(_startGameTimeInSeconds);
		_isGameEnd = false;
	}

	private void Update()
	{
		if (_isGameEnd == false)
		{
			_timer.TimePassed(Time.deltaTime);
			_timer.ShowTimer();
			CheckAvailableCoins();
			CheckGameEnd();
		}
	}

	private void Win()
	{
		Debug.Log($"Ура! Вы подбедили и собрали {_coinCollector.CollectedCoins.Count} монет.");
		Debug.Log($"Вы заработали {_coinCollector.CollectedCoins.Sum(x => x.ScoreValue)} очков");
		Time.timeScale = 0.0f;
	}

	private void Lose()
	{
		int availableCoins = _coinCollector.LevelCoinsCount - _coinCollector.CollectedCoins.Count;

		Debug.Log($"Вы не успели собрать {availableCoins} монет :(");
		Debug.Log($"Вы заработали {_coinCollector.CollectedCoins.Sum(x => x.ScoreValue)} очков");
		Time.timeScale = 0.0f;
	}

	private void CheckGameEnd()
	{
		if (_timer.GameTimeLeft <= 0.0f)
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

	private void CheckAvailableCoins()
	{
		int availableCoins = _coinCollector.LevelCoinsCount - _coinCollector.CollectedCoins.Count;

		if (availableCoins != _previousAvailableCoins)
		{
			Debug.Log($"Вы собрали {_coinCollector.CollectedCoins.Count}/{_coinCollector.LevelCoinsCount} монет, ещё осталось {availableCoins} монет");
		}

		_previousAvailableCoins = availableCoins;
	}
}
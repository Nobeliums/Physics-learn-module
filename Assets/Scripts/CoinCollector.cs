using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
	public List<Coin> CollectedCoins { get; private set; } = new List<Coin>();
	public int LevelCoinsCount => _allCoins.Count;

	[SerializeField] private List<Coin> _allCoins;

	private void OnTriggerEnter(Collider other)
	{
		Coin collectedCoin = other.GetComponent<Coin>();

		if (collectedCoin != null)
		{
			collectedCoin.Collect();
			CollectedCoins.Add(collectedCoin);
		}
	}
}

using UnityEngine;
public class Timer
{
	private const float TimeStep = 1.0f;

	public float GameTimeLeft { get; private set; }

	private float _timeStepConter;

	public Timer(float startGameTimeInSeconds)
	{
		GameTimeLeft = startGameTimeInSeconds;
	}

	public void TimePassed(float seconds)
	{
		GameTimeLeft -= seconds;
		_timeStepConter += seconds;

		if (_timeStepConter >= TimeStep)
		{
			GameTimeLeft -= Time.deltaTime;
			_timeStepConter += Time.deltaTime;
		}
	}

	public void ShowTimer()
	{
		if (_timeStepConter >= TimeStep)
		{
			Debug.Log($"У вас осталось {GameTimeLeft.ToString("0")} секунд!");
			_timeStepConter = 0.0f;
		}
	}
}
using TMPro;
using UnityEngine;

namespace UI
{
	[RequireComponent(typeof(Canvas))]
	public class GameCanvas : MonoBehaviour
	{
		[SerializeField] private TMP_Text _scoreText;
		[SerializeField] private TMP_Text _timeText;
		[SerializeField] private TMP_Text _roundText;
		
		public void SetScore(uint score)
		{
			_scoreText.text =  score.ToString();
		}
		
		public void SetTime(uint time)
		{
			_timeText.text =  time.ToString();
		}
		
		public void SetRound(uint round)
		{
			_roundText.text =  round.ToString();
		}
	}
}
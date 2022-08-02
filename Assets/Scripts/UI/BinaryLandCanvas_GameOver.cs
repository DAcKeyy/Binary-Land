using UnityEngine;
using UnityEngine.UIElements;

namespace UI
{
	[RequireComponent(typeof(Canvas))]
	public class BinaryLandCanvas_GameOver : MonoBehaviour
	{
		public void TurnOfGame()
		{
			Application.Quit();
		}
	}
}
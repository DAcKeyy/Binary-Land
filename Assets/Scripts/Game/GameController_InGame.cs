using Actors;
using Input;
using UI;
using UnityEngine;

namespace Game
{
	public class GameController_InGame : MonoBehaviour
	{
		[SerializeField] private BinaryLandCanvas_Runtime _binaryLandCanvasRuntime;
		[SerializeField] private Player _player;
		[SerializeField] private InputHandler _inputHandler;

		private void Start()
		{
			_inputHandler._fireAction.performed += context => _player.ApplyInteraction();
			_inputHandler._moveAction.performed += context => _player.ApplyMove(context.ReadValue<Vector2>());
			_inputHandler._moveAction.canceled += context => _player.ApplyMove(Vector2.zero);
		}
	}
}
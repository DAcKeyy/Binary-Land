using System;
using Actors;
using Input;
using UI;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game
{
	public class GameController_InGame : MonoBehaviour
	{
		[SerializeField] private BinaryLandCanvas_Runtime _binaryLandCanvasRuntime;
		[SerializeField] private BinaryLandCanvas_GameOver _gameOverCanvas;
		[SerializeField] private Player _player;
		[SerializeField] private InputHandler _inputHandler;
		private Action<InputAction.CallbackContext> _interactionHandler;
		private Action<InputAction.CallbackContext> _movePerformedHandler;
		private Action<InputAction.CallbackContext> _moveCanceledHandler;

		
		private void Start()
		{
			_interactionHandler = (context) => _player.ApplyInteraction();
			_movePerformedHandler = (context) => _player.ApplyMove(context.ReadValue<Vector2>());
			_moveCanceledHandler = context =>  _player.ApplyMove(Vector2.zero);
			_player.ReachedHeart += Win;
			_inputHandler._fireAction.performed += _interactionHandler;
			_inputHandler._moveAction.performed += _movePerformedHandler;
			_inputHandler._moveAction.canceled += _moveCanceledHandler;
		}

		private void OnDisable()
		{
			_player.ReachedHeart -= Win;
			_inputHandler._fireAction.canceled -= _interactionHandler;
			_inputHandler._moveAction.performed -= _movePerformedHandler;
			_inputHandler._moveAction.canceled -= _moveCanceledHandler;
		}

		private void Win()
		{
			_gameOverCanvas.gameObject.SetActive(true);
		}
	}
}
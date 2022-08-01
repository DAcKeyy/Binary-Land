using UnityEngine;
using UnityEngine.InputSystem;

namespace Input
{
	public class InputHandler : MonoBehaviour
	{
		[SerializeField] private InputActionAsset _inputActionAsset;
		public InputAction _fireAction;
		public InputAction _moveAction;
		public InputAction _menuAction;
		
		public void Awake()
		{
			_fireAction = _inputActionAsset.FindActionMap("Game").FindAction("Fire");
			_moveAction = _inputActionAsset.FindActionMap("Game").FindAction("Move");
			_menuAction = _inputActionAsset.FindActionMap("Game").FindAction("Menu");
		}
	}
}
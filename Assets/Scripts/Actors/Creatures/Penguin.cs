using Actors.Base;
using UnityEngine;

namespace Actors.Creatures
{
	[RequireComponent(typeof(Animator))]
	public class Penguin : _2DNavMeshAgent
	{
		[SerializeField] private float _speedMultiplier;
		private Animator _thisAnimator;
		
		private void Start()
		{
			_thisAnimator = GetComponent<Animator>();
		}

		public override void MoveTo(Vector2 position)
		{
			LookVector = position;
			
			_thisAnimator.SetFloat("XAxis", position.x);
			_thisAnimator.SetFloat("YAxis", position.y);
			
			ThisAgent.Move(position * _speedMultiplier * Time.deltaTime);
		}

		public override void Interact()
		{
			_thisAnimator.SetTrigger("Interacting");
			
			base.Interact();
		}
	}
}
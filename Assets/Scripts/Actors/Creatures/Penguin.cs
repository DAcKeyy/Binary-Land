using System;
using Actors.Base;
using UnityEngine;

namespace Actors.Creatures
{
	[RequireComponent(typeof(Animator))]
	public class Penguin : _2DNavMeshAgent
	{
		public Action Died = delegate {  };
		
		
		private Animator _thisAnimator;
		
		private void Start()
		{
			_thisAnimator = GetComponent<Animator>();
		}

		protected override void SetMoveDirection(Vector2 direction)
		{
			_thisAnimator.SetFloat("XAxis", direction.x);
			_thisAnimator.SetFloat("YAxis", direction.y);

			if (Mathf.Abs(direction.x) > 0.1 || Mathf.Abs(direction.y) > 0.1)
				_thisAnimator.SetBool("IsMoveApplyed", true);
			else _thisAnimator.SetBool("IsMoveApplyed", false);
			
			base.SetMoveDirection(direction);
		}

		protected override void Interact()
		{
			_thisAnimator.SetTrigger("Interacting");
			
			base.Interact();
		}
	}
}
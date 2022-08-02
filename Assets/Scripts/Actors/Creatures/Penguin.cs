using System;
using Actors.Base;
using UnityEngine;

namespace Actors.Creatures
{
	[RequireComponent(typeof(Animator))]
	public class Penguin : _2DNavMeshAgent
	{
		public Action Died = delegate {  };
		
		[SerializeField] private float _speedMultiplier = 1;
		private Animator _thisAnimator;
		
		private void Start()
		{
			_thisAnimator = GetComponent<Animator>();
		}

		private void FixedUpdate()
		{
			ThisAgent.Move(LookVector * (_speedMultiplier * Time.deltaTime));
		}

		public override void SetMoveDirection(Vector2 direction)
		{
			Debug.Log(direction);
			LookVector = direction;
			
			_thisAnimator.SetFloat("XAxis", direction.x);
			_thisAnimator.SetFloat("YAxis", direction.y);
		}

		public override void Interact()
		{
			_thisAnimator.SetTrigger("Interacting");
			
			base.Interact();
		}
	}
}
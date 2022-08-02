using System;
using System.Collections;
using Actors.Base;
using Actors.Items;
using UnityEngine;

namespace Actors.Creatures
{
	[RequireComponent(typeof(Animator), typeof(Collider))]
	public class Penguin : _2DNavMeshAgent, ITrapVisitor
	{
		public Action Died = delegate {  };
		
		private Animator _thisAnimator;
		private bool _isStunned;
		private void Start()
		{
			_thisAnimator = GetComponent<Animator>();
		}

		protected override void SetMoveVector(Vector2 direction)
		{
			if(_isStunned) return;
			
			_thisAnimator.SetFloat("XAxis", direction.x);
			_thisAnimator.SetFloat("YAxis", direction.y);

			if (Mathf.Abs(direction.x) > 0.1 || Mathf.Abs(direction.y) > 0.1)
				_thisAnimator.SetBool("IsMoveApplyed", true);
			else _thisAnimator.SetBool("IsMoveApplyed", false);
			
			base.SetMoveVector(direction);
		}

		protected override void Interact()
		{
			if(_isStunned) return;
			
			_thisAnimator.SetTrigger("Interacting");
			
			base.Interact();
		}
		
		public void TrapVisit(SpiderWeb web)
		{
			StartCoroutine(Stun(1));
		}

		private IEnumerator Stun(float seconds)
		{
			SetMoveVector(Vector2.zero);
			_thisAnimator.SetBool("IsStuned", true);
			_isStunned = true;
			yield return new WaitForSeconds(seconds);
			
			_isStunned = false;
			_thisAnimator.SetBool("IsStuned", false);
		}
	}
}
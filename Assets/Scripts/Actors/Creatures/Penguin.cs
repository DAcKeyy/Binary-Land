using System;
using System.Collections;
using Actors.Base;
using Actors.Items;
using UnityEngine;

namespace Actors.Creatures
{
	[RequireComponent(typeof(Animator), typeof(Collider))]
	public class Penguin : _2DNavMeshAgent, ITrapVisitor, IItemVisitor
	{
		public Action Died = delegate {  };
		public Action ReachedHeart = delegate {  };
		
		private Animator _thisAnimator;
		private bool _isDisabled;
		
		private void Start()
		{
			_thisAnimator = GetComponent<Animator>();
		}

		protected override void SetMoveVector(Vector2 direction)
		{
			if(_isDisabled) return;
			
			_thisAnimator.SetFloat("XAxis", direction.x);
			_thisAnimator.SetFloat("YAxis", direction.y);

			if (Mathf.Abs(direction.x) > 0.1 || Mathf.Abs(direction.y) > 0.1)
				_thisAnimator.SetBool("IsMoveApplyed", true);
			else _thisAnimator.SetBool("IsMoveApplyed", false);
			
			base.SetMoveVector(direction);
		}

		protected override void Interact()
		{
			if(_isDisabled) return;
			
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
			_isDisabled = true;
			yield return new WaitForSeconds(seconds);
			
			_isDisabled = false;
			_thisAnimator.SetBool("IsStuned", false);
		}

		public void ItemVisit(BigHeart heart)
		{
			SetMoveVector(Vector2.zero);
			_thisAnimator.SetBool("IsWinned", true);
			_isDisabled = true;
			ReachedHeart();
		}
	}
}
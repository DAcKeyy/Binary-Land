using Actors.Base;
using UnityEngine;

namespace Actors.Items
{
	[RequireComponent(typeof(Collider))]
	public class SpiderWeb : MonoBehaviour
	{
		private void Reset()
		{
			GetComponent<Collider>().isTrigger = true;
		}

		private void OnTriggerEnter(Collider col)
		{
			if (col.transform.TryGetComponent(out ITrapVisitor trapVictim))
			{
				trapVictim.TrapVisit(this);
				
				Object.Destroy(this.gameObject);
			}
		}
	}
}
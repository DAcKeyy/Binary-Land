using System;
using UnityEngine;
using UnityEngine.AI;

namespace Actors.Base
{
    [RequireComponent(
        typeof(NavMeshAgent), 
        typeof(SpriteRenderer),
        typeof(SpriteRenderer))]
    public abstract class _2DNavMeshAgent : MonoBehaviour
    {
        public Action<GameObject> Interacted = delegate(GameObject o) {  };

        protected NavMeshAgent ThisAgent;
        protected SpriteRenderer ThisSprite;
        protected Vector2 LookVector;
        
        private void Start()
        {
            ThisAgent = GetComponent<NavMeshAgent>();
            ThisSprite = GetComponent<SpriteRenderer>();
            LookVector = transform.position;
        }

        public virtual void MoveTo(Vector2 position)
        {
            ThisAgent.Move(position);
        }

        public virtual void Interact()
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, LookVector);

            if (hit.collider != null)
            {
                Interacted(hit.collider.gameObject);
            }
        }
    }
}

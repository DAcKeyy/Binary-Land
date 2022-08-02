using System;
using UnityEngine;
using UnityEngine.AI;

namespace Actors.Base
{
    [RequireComponent(typeof(NavMeshAgent))]
    public abstract class _2DNavMeshAgent : MonoBehaviour
    {
        public Action<GameObject> Interacted = delegate(GameObject o) {  };

        protected NavMeshAgent ThisAgent;
        protected Vector2 LookVector;
        
        [SerializeField] private SpriteRenderer _thisSprite;
        
        private void Awake()
        {
            ThisAgent = GetComponent<NavMeshAgent>();
            LookVector = transform.position;
            _thisSprite.transform.Rotate(new Vector3(90, 0, 0));
        }

        public virtual void SetMoveDirection(Vector2 direction)
        {
            ThisAgent.Move(direction);
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

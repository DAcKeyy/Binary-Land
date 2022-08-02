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
            LookVector = Vector2.zero;
            _thisSprite.transform.Rotate(new Vector3(90, 0, 0));
        }

        protected virtual void SetMoveDirection(Vector2 direction)
        {
            LookVector = direction;
        }
        
        private void FixedUpdate()
        {
            if (LookVector.x == 0) LookVector.x = 0.0001f;//Если X 0 то он вообще не перемещается, хз почему
            
            ThisAgent.Move(LookVector * Time.deltaTime * ThisAgent.speed);
        }

        protected virtual void Interact()
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, LookVector);

            if (hit.collider != null)
            {
                Interacted(hit.collider.gameObject);
            }
        }
    }
}

using System;
using UnityEngine;
using UnityEngine.AI;

namespace Actors.Base
{
    [RequireComponent(typeof(NavMeshAgent), typeof(Collider))]
    public abstract class _2DNavMeshAgent : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _viewSprite;
        [SerializeField] private SpriteRenderer _emotionSprite;
        
        private Vector2 _lastLookVector;
        private Collider _thisCollider;
        private NavMeshAgent _thisAgent;
        private Vector2 _lookVector;
        
        private void Awake()
        {
            _thisCollider = GetComponent<Collider>();
            _thisAgent = GetComponent<NavMeshAgent>();
            
            _lookVector = Vector2.zero;
            
            _viewSprite.transform.Rotate(new Vector3(90, 0, 0));//Так как агент попроачивается к навмешу задом вместе с спрайтом
            _emotionSprite.transform.Rotate(new Vector3(90, 0, 0));
        }

        protected virtual void SetMoveVector(Vector2 direction)
        {
            if (direction != Vector2.zero) _lastLookVector = direction;
            
            _lookVector = direction;
        }
        
        private void FixedUpdate()
        {
            if (_lookVector.x == 0) _lookVector.x = 0.0001f;//Если X 0 то он вообще не перемещается, хз почему
            
            _thisAgent.Move(_lookVector * Time.deltaTime * _thisAgent.speed);
        }

        protected virtual void Interact()
        {
            Physics.Raycast(transform.position, 
                _lastLookVector, 
                out RaycastHit hit, 
                Mathf.Lerp(_thisCollider.bounds.size.x, _thisCollider.bounds.size.z, 0.5f) / 1.9F);
            
            Debug.DrawRay(transform.position, _lastLookVector, Color.red, 1f);
            
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.TryGetComponent(out IItem item))
                {
                    item.Interact(this);
                }
            }
        }
    }
}

using Actors.Base;
using UnityEngine;

namespace Actors.Items
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Collider), typeof(Rigidbody), typeof(SpriteRenderer))]
    public class BigHeart : MonoBehaviour, IItem
    {
        private void Reset()
        {
            GetComponent<Collider>().isTrigger = false;
            GetComponent<Rigidbody>().isKinematic = true;
        }

        public void Interact(MonoBehaviour monoObject)
        {
            if (monoObject.gameObject.TryGetComponent(out IItemVisitor itemVisitor))
            {
                itemVisitor.ItemVisit(this);
                GetComponent<Animator>().SetTrigger("Win");
            }
        }
    }
}

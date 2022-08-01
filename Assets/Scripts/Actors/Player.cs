using Actors.Creatures;
using UnityEngine;

namespace Actors
{
    public class Player : Penguin
    {
        public void ApplyMove(Vector2 direction)
        {
            Debug.Log($"direction: {direction}");
            MoveTo(direction);
        }

        public void ApplyInteraction()
        {
            Debug.Log($"Interact");
            Interact();
        }
    }
}

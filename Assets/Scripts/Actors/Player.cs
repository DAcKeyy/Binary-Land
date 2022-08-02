using Actors.Creatures;
using UnityEngine;

namespace Actors
{
    public class Player : Penguin
    {
        public void ApplyMove(Vector2 direction)
        {
            SetMoveVector(direction);
        }

        public void ApplyInteraction()
        {
            Interact();
        }
    }
}

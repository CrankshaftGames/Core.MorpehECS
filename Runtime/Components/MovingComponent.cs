using Scellecs.Morpeh;
using UnityEngine;

namespace Core.ECS.Components
{
    public struct MovingComponent : IComponent
    {
        public Vector3 Direction;
        public float StartTime;
        public float Duration;
    }
}
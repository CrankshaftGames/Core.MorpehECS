using Scellecs.Morpeh;
using UnityEngine;

namespace Core.ECS.Components
{
    public struct MoveToPositionComponent : IComponent
    {
        public Vector3 StartPosition;
        public Vector3 EndPosition;
    }
}
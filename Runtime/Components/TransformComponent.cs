using Scellecs.Morpeh;
using UnityEngine;

namespace Core.ECS.Components
{
    public struct TransformComponent : IComponent
    {
        public Vector3 Position;
        public Quaternion Rotation;
        public Vector3 Scale;
    }
}
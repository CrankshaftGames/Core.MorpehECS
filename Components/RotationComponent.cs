using Scellecs.Morpeh;
using UnityEngine;

namespace Core.ECS.Components
{
    public struct RotationComponent : IComponent
    {
        public Quaternion Value;
    }
}

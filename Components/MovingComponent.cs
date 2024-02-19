using Scellecs.Morpeh;

namespace Core.ECS.Components
{
    public struct MovingComponent : IComponent
    {
        public float StartTime;
        public float Duration;
    }
}
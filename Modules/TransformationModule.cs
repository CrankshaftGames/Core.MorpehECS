using Core.ECS.Systems;
using Scellecs.Morpeh;

namespace Core.ECS.Modules
{
    public class TransformationModule : EcsModule
    {
        private readonly TransformSystem _transformSystem;

        public TransformationModule(TransformSystem transformSystem, World world) : base(world)
        {
            AddSystem(transformSystem);
        }
    }
}
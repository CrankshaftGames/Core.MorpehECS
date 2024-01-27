using System.Collections.Generic;
using Assets.Core.ECS.Systems;
using Core.ECS;
using Scellecs.Morpeh;

namespace Assets.Core.ECS.Modules
{
    public class TransformationModule : EcsModule
    {
        public TransformationModule(World world, ISystemFactory systemFactory) : base(world, systemFactory)
        {
        }

        protected override IEnumerable<ISystem> CreateSystems()
        {
            yield return CreateSystem<TransformSystem>();
        }
    }
}

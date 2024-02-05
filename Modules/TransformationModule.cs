using System;
using System.Collections.Generic;
using Core.ECS.Systems;
using Scellecs.Morpeh;

namespace Core.ECS.Modules
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

        public override IEnumerable<Type> GetSystemTypes()
        {
            yield return typeof(TransformSystem);
        }
    }
}
using System;
using System.Collections.Generic;
using Core.Infrastructure.Features;
using Scellecs.Morpeh;

namespace Core.ECS
{
    public abstract class EcsModule : IFeatureModule
    {
        private static int _order;
        private readonly ISystemFactory _systemFactory;
        private readonly World _world;
        private bool _enabled;

        private SystemsGroup _systemsGroup;

        protected EcsModule(World world, ISystemFactory systemFactory)
        {
            _world = world;
            _systemFactory = systemFactory;
        }

        public void Enable()
        {
            var systems = CreateSystems();

            _systemsGroup = _world.CreateSystemsGroup();

            foreach (var system in systems)
            {
                _systemsGroup.AddSystem(system);
            }

            _world.AddSystemsGroup(_order++, _systemsGroup);

            _enabled = true;
        }

        public void Disable()
        {
            if (_enabled) _world.RemoveSystemsGroup(_systemsGroup);

            _enabled = false;
        }

        protected abstract IEnumerable<ISystem> CreateSystems();
        public abstract IEnumerable<Type> GetSystemTypes();

        protected ISystem CreateSystem<T>() where T : ISystem
        {
            return _systemFactory.Create<T>();
        }
    }
}
using System.Collections.Generic;
using Scellecs.Morpeh;

namespace Core.ECS
{
    public abstract class EcsModule
    {
        private readonly World _world;
        private readonly ISystemFactory _systemFactory;

        private SystemsGroup _systemsGroup;
        private bool _enabled;

        protected EcsModule(World world, ISystemFactory systemFactory)
        {
            _world = world;
            _systemFactory = systemFactory;
        }

        public void Enable(int order = 0)
        {
            var systems = CreateSystems();

            _systemsGroup = _world.CreateSystemsGroup();

            foreach (var system in systems)
            {
                _systemsGroup.AddSystem(system);
            }

            _world.AddSystemsGroup(order, _systemsGroup);

            _enabled = true;
        }

        public void Disable()
        {
            if (_enabled)
            {
                _world.RemoveSystemsGroup(_systemsGroup);
            }

            _enabled = false;
        }

        protected abstract IEnumerable<ISystem> CreateSystems();

        protected ISystem CreateSystem<T>() where T : ISystem
        {
            return _systemFactory.Create<T>();
        }
    }
}
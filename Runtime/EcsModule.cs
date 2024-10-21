using Core.Infrastructure.Features;
using Scellecs.Morpeh;

namespace Core.ECS
{
    public abstract class EcsModule
    {
        private static int _order;

        private readonly SystemsGroup _systemsGroup;
        private readonly World _world;
        private bool _enabled;

        protected EcsModule(World world)
        {
            _world = world;
            _systemsGroup = _world.CreateSystemsGroup();
        }

        public void Enable()
        {
            _world.AddSystemsGroup(_order++, _systemsGroup);

            _enabled = true;
        }

        public void Disable()
        {
            if (_enabled) _world.RemoveSystemsGroup(_systemsGroup);

            _enabled = false;
        }

        protected void AddSystem(ISystem system)
        {
            _systemsGroup.AddSystem(system);
        }
    }
}
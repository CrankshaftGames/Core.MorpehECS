using Core.ECS.Systems;
using Scellecs.Morpeh;

namespace Core.ECS.Modules
{
    public class PhysicsModule : EcsModule
    {
        private readonly ApplyForceSystem _applyForceSystem;
        private readonly ApplyTorqueSystem _applyTorqueSystem;

        public PhysicsModule(ApplyForceSystem applyForceSystem, ApplyTorqueSystem applyTorqueSystem, World world) : base(world)
        {
            AddSystem(applyForceSystem);
           AddSystem(applyTorqueSystem);
        }
    }
}
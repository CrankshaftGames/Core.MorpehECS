using Core.ECS.Components;
using Core.ECS.Components.View;
using Scellecs.Morpeh;
using UnityEngine;

namespace Core.ECS.Systems
{
    public class ApplyTorqueSystem : IFixedSystem
    {
        private Filter _filter;
        public World World { get; set; }

        public void OnAwake()
        {
            _filter = World.Filter.With<RigidbodyViewComponent>().With<TorqueComponent>().Build();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                var rigidbody = entity.GetComponent<RigidbodyViewComponent>();
                var torque = entity.GetComponent<ForceComponent>();

                rigidbody.Ref.AddTorque(torque.Val, ForceMode.Force);
            }
        }

        public void Dispose()
        {
        }
    }
}
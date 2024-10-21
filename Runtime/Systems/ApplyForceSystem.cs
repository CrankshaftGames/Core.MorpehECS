using Core.ECS.Components;
using Core.ECS.Components.View;
using Scellecs.Morpeh;
using UnityEngine;

namespace Core.ECS.Systems
{
    public class ApplyForceSystem : IFixedSystem
    {
        private Filter _filter;
        public World World { get; set; }

        public void OnAwake()
        {
            _filter = World.Filter.With<RigidbodyViewComponent>().With<ForceComponent>().Build();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach (var entity in _filter)
            {
                var rigidbody = entity.GetComponent<RigidbodyViewComponent>();
                var force = entity.GetComponent<ForceComponent>();

                rigidbody.Ref.AddForce(force.Val, ForceMode.Force);
            }
        }

        public void Dispose()
        {
        }
    }
}
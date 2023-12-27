using RedOut.Gameplay.Features.Common.Components;
using Scellecs.Morpeh;
using UnityEngine;

namespace RedOut.Gameplay.Features.Common.Systems
{
	public class ApplyForcesSystem : IFixedSystem
	{
		private Filter _filter;
		public World World { get; set; }

		public void OnAwake()
		{
			_filter = World.Filter.With<RigidbodyComponent>().With<ForceComponent>().Build();
		}

		public void OnUpdate(float deltaTime)
		{
			foreach (var entity in _filter)
			{
				var rigidbody = entity.GetComponent<RigidbodyComponent>();
				var force = entity.GetComponent<ForceComponent>();
				
				rigidbody.Ref.AddForce(force.Val, ForceMode.Force);
			}
		}

		public void Dispose()
		{
		}
	}
}
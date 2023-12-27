using Scellecs.Morpeh;

namespace RedOut.Gameplay.Features.Common.Systems
{
	public class ApplyTorqueSystem : IFixedSystem
	{
		private World _world;

		public void Dispose()
		{
		}

		public void OnAwake()
		{
		}

		public World World
		{
			get => _world;
			set => _world = value;
		}

		public void OnUpdate(float deltaTime)
		{
		}
	}
}
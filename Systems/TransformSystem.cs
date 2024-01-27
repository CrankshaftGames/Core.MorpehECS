using Core.ECS.Components;
using RedOut.Gameplay.Features.Common.Components;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Native;

namespace Assets.Core.ECS.Systems
{
	public class TransformSystem : ISystem
	{
		public World World { get; set; }
		private NativeStash<PositionComponent> _positionStash;
		private NativeStash<RotationComponent> _rotationStash;
		private NativeStash<ScaleComponent> _scaleStash;
		private Stash<TransformComponent> _transformStash;
		private NativeFilter _filter;

		public void OnAwake()
		{
			_filter = World.Filter
				.With<PositionComponent>()
				.With<RotationComponent>()
				.With<ScaleComponent>()
				.With<TransformComponent>()
				.Build()
				.AsNative();

			_positionStash = World.GetStash<PositionComponent>().AsNative();
			_rotationStash = World.GetStash<RotationComponent>().AsNative();
			_scaleStash = World.GetStash<ScaleComponent>().AsNative();
			_transformStash = World.GetStash<TransformComponent>();
		}

		public void OnUpdate(float deltaTime)
		{
			for (int i = 0; i < _filter.length; i++)
			{
				var entityId = _filter[i];
				World.TryGetEntity(entityId, out var entity);
				var pos = _positionStash.Get(entityId);
				var rot = _rotationStash.Get(entityId);
				var sca = _scaleStash.Get(entityId);
				var tr = _transformStash.Get(entity);
				tr.Reference.SetPositionAndRotation(pos.Value, rot.Value);
				tr.Reference.localScale = sca.Value;
			}
		}

		public void Dispose()
		{
			_transformStash?.Dispose();
		}
	}
}

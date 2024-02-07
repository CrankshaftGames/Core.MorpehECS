using Core.ECS.Components;
using Core.ECS.Components.View;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Native;

namespace Core.ECS.Systems
{
    public class TransformSystem : ISystem
    {
        private NativeFilter _filter;
        private NativeStash<TransformComponent> _transformStash;
        private Stash<TransformViewComponent> _transformViewStash;
        public World World { get; set; }

        public void OnAwake()
        {
            _filter = World.Filter
                .With<TransformComponent>()
                .With<TransformViewComponent>()
                .Build()
                .AsNative();

            _transformStash = World.GetStash<TransformComponent>().AsNative();
            _transformViewStash = World.GetStash<TransformViewComponent>();
        }

        public void OnUpdate(float deltaTime)
        {
            for (var i = 0; i < _filter.length; i++)
            {
                var entityId = _filter[i];
                World.TryGetEntity(entityId, out var entity);
                var tr = _transformStash.Get(entityId);
                var view = _transformViewStash.Get(entity);
                view.Reference.SetPositionAndRotation(tr.Position, tr.Rotation);
                view.Reference.localScale = tr.Scale;
            }
        }

        public void Dispose()
        {
           
        }
    }
}
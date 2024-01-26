using System;
using System.Collections.Generic;
using Scellecs.Morpeh;

namespace Core.ECS
{
	public abstract class EcsFeature : IDisposable
	{
		private readonly World _world;
		private SystemsGroup _initGroup;
		private SystemsGroup _updateGroup;

		protected EcsFeature(World world)
		{
			_world = world;
			InitializeWorld(world);
		}

		private void InitializeWorld(World world)
		{
			_initGroup = world.CreateSystemsGroup();
			foreach (var initializerSystem in GetInitializerSystems())
			{
				_initGroup.AddSystem(initializerSystem);
			}

			_updateGroup = world.CreateSystemsGroup();
			foreach (var updateSystem in GetUpdateSystems())
			{
				_updateGroup.AddSystem(updateSystem);
			}

			world.AddSystemsGroup(0, _initGroup);
			world.AddSystemsGroup(1, _updateGroup);
		}

		public void Update(float deltaTime)
		{
			_world.Update(deltaTime);
		}
		
		protected virtual IEnumerable<ISystem> GetInitializerSystems()
		{
			yield break;
		}

		protected virtual IEnumerable<ISystem> GetUpdateSystems()
		{
			yield break;
		}

		public void Dispose()
		{
			_world.RemoveSystemsGroup(_initGroup);
			_world.RemoveSystemsGroup(_updateGroup);
		}
	}
}
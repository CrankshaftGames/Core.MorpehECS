using Scellecs.Morpeh;

namespace Core.ECS.Components
{
	public struct InputComponent :IComponent
	{
		public float Horizontal;
		public float Vertical;
		public bool Space;
	}
}
using Scellecs.Morpeh;

namespace Core.ECS
{
    public interface ISystemFactory
    {
		ISystem Create<T>() where T : ISystem;
    }
}

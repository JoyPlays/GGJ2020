namespace Ugitty
{
    public interface IDispatchable<T>
    {
        void Dispatch(T listener);
    }
}
public interface IPool<T>
{
    T ActivatePoolObject();
    void DeactivatePoolObject(T poolObject);
}

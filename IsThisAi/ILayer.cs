namespace IsThisAi;

public interface ILayer<T>
{
    T[] Activate(T[] inputs);
}
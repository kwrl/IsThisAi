namespace IsThisAi;

public interface INeuron<T> where T : struct
{
    T Activate(T[] inputs);
}
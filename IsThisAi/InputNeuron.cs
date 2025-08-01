namespace IsThisAi;

public class InputNeuron<T> : INeuron<T> where T : struct
{
    public required T Value { get; set; }
    
    public T Activate(T[] inputs) => Value;
}
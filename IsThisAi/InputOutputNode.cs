namespace IsThisAi;

public class InputOutputNode<T> : INeuron<T, T> where T : struct
{
    public required T Output
    {
        get; set;
    }
    public T Input { get; set; }
    
    public void Activate()
    {
        Output = Input;
    }
}
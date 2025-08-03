namespace IsThisAi;

public interface INeuron<in TInput, out TOutput> 
{
    TOutput Output { get; }
    public TInput Input { set; }
    void Activate();
}
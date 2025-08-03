namespace IsThisAi;

public class Layer<TInput, TOutput>(INeuron<TInput, TOutput>[] neurons)
{
    public void SetInput(TInput input)
    {
        foreach (var neuron in neurons)
        {
            neuron.Input = input;
        }
    }
    
    public void ForEachNeuron(Action<INeuron<TInput, TOutput>> action)
    {
        foreach (var neuron in neurons)
        {
            action(neuron);
        }
    }
    
    public T[] CollectFromNeurons<T>(Func<INeuron<TInput, TOutput>, T> selector)
    {
        var results = new T[neurons.Length];
        for (var i = 0; i < neurons.Length; i++)
        {
            results[i] = selector(neurons[i]);
        }
        return results;
    }
  
    // TODO: We don't really want to allocate a new array every time we call GetOutputs.
    // We should consider using a preallocated array or a more efficient data structure.
    public TOutput[] GetOutputs()
    {
        var outputs = new TOutput[neurons.Length];
        for (var i = 0; i < neurons.Length; i++)
        {
            outputs[i] = neurons[i].Output;
        }
        return outputs;
    }
    
}
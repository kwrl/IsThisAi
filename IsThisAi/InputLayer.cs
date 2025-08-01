namespace IsThisAi;

public class InputLayer<T> : ILayer<T> where T : struct
{
    private readonly InputNeuron<T> [] _neurons;
    public InputLayer(int size)
    {
        _neurons = new InputNeuron<T>[size];
        for (var i = 0; i < size; i++)
        {
            _neurons[i] = new InputNeuron<T>()
            {
                Value = default
            };
        }
    }

    public T[] Activate(T[] inputs)
    {
        var output = new T[_neurons.Length];
        for (var i = 0; i < _neurons.Length; i++)
        {
            if (i < inputs.Length)
            {
                _neurons[i].Value = inputs[i];
            }
            output[i] = _neurons[i].Activate(inputs);
        }
        return output;
    }
}
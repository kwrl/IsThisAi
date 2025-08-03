namespace IsThisAi;

public class DigitRecognitionNetwork
{
    public Layer<double[], double> HiddenLayer { get; }
    public Layer<double[], double> OutputLayer { get; }
    
    private readonly int _inputSize;
    
    public DigitRecognitionNetwork(
        int inputSize,
        int hiddenSize)
    {
        _inputSize = inputSize;
        HiddenLayer = new Layer<double[], double>(
            Enumerable.Range(0, hiddenSize)
                .Select(_ => new SigmoidNeuron
                {
                    Weights = Enumerable.Repeat(0.5, inputSize).ToArray(),
                    Bias = 0.0
                }).ToArray<INeuron<double[], double>>()
        );

        OutputLayer = new Layer<double[], double>(
            Enumerable.Range(0, 10) 
                .Select(_ => new SigmoidNeuron
                {
                    Weights = Enumerable.Repeat(0.5, hiddenSize).ToArray(),
                    Bias = 0.0
                }).ToArray<INeuron<double[], double>>()
        );
    }

    public int RecognizeDigit(double[] input)
    {
        if (input.Length != _inputSize)
        {
            throw new ArgumentException($"Input size must be {_inputSize}, but was {input.Length}.");
        }
        
        HiddenLayer.ForEachNeuron(x => x.Input = input);
        HiddenLayer.ForEachNeuron(x => x.Activate());

        var hiddenOutputs = HiddenLayer.CollectFromNeurons(x => x.Output);
       
        OutputLayer.ForEachNeuron(x => x.Input = hiddenOutputs);
        OutputLayer.ForEachNeuron(x => x.Activate());

        var outputs = OutputLayer.CollectFromNeurons(x => x.Output);
        
        var maxIndex = 0;
        var maxValue = outputs[0];
        
        for (var i = 1; i < outputs.Length; i++)
        {
            if (outputs[i] > maxValue)
            {
                maxValue = outputs[i];
                maxIndex = i;
            }
        }
        
        return maxIndex;
    }
}
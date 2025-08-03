namespace IsThisAi;

public class DigitRecognitionNetwork
{
    public Layer<double, double> InputLayer { get; }
    public Layer<double[], double> HiddenLayer { get; }
    public Layer<double[], double> OutputLayer { get; }
    
    public DigitRecognitionNetwork(
        int inputSize,
        int hiddenSize)
    {
        InputLayer = new Layer<double, double>(
            Enumerable.Range(0, inputSize)
                .Select(_ => new InputOutputNode<double>()
                {
                    Output = 0
                }).ToArray<INeuron<double, double>>()
        );

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
        InputLayer.DistributeInputs(input);
        
        InputLayer.ForEachNeuron(x => x.Activate());
        
        HiddenLayer.SetInput(InputLayer.CollectFromNeurons(x => x.Output));
        HiddenLayer.ForEachNeuron(x => x.Activate());
        
        OutputLayer.SetInput(HiddenLayer.CollectFromNeurons(x => x.Output));
        
        var outputs = OutputLayer.GetOutputs();
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
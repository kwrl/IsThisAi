namespace IsThisAi;

public class SigmoidNeuron : INeuron<double[], double>
{
    public required double Bias { get; set; }
    public required double [] Weights { get; set; }
    
    public double Output { get; private set; }

    public double[] Input { private get; set; } = [];

    public void Activate()
    {
        var weightedSum = 0.0;
        
        for (var i = 0; i < Input.Length; i++)
        {
            weightedSum += Input[i] * Weights[i];
        }

        Output = 1.0 / (1.0 + Math.Exp(-weightedSum - Bias));
    }
}
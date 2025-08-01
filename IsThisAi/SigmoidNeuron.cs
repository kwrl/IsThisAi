using System.Numerics;

namespace IsThisAi;

public class SigmoidNeuron : INeuron<double>
{
    public required double Bias { get; set; }
    public required double [] Weights { get; set; }
    
    public double Activate(double[] inputs)
    {
        if (inputs.Length != Weights.Length)
        {
            throw new ArgumentException("Input length must match weights length.");
        }

        var weightedSum = 0.0;
        
        for (var i = 0; i < inputs.Length; i++)
        {
            weightedSum += inputs[i] * Weights[i];
        }

        return 1.0 / (1.0 + Math.Exp(-weightedSum - Bias));
    }
}
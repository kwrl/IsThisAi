using Shouldly;

namespace IsThisAi.Test;

public class SigmoidNeuronShould
{
    [Theory]
    [InlineData(new[] { 0.5, 0.5 }, 0.1, new [] { 0.5, 0.5 }, 0.6456)]
    [InlineData(new[] { 0.3, -0.3 }, 0.2, new [] { 1.0, -1.0 }, 0.68997)]
    [InlineData(new[] { 0.5, 0.5 }, 0.0, new [] { 0.0, 0.0 }, 0.5)]
    public void ReturnCorrectOutput__When__Activated(double[] weights, double bias, double[] inputs, double expectedOutput)
    {
        var neuron = new SigmoidNeuron
        {
            Weights = weights,
            Bias = bias
        };

        var output = neuron.Activate(inputs);

        output.ShouldBe(expectedOutput, tolerance: 0.0001);
    }
}

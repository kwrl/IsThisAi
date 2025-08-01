using Shouldly;

namespace IsThisAi.Test;

public class InputNeuronShould
{
    [Fact]
    public void ReturnValue__When__Activated()
    {
        var sut = new InputNeuron<double>
        {
            Value = 4.0
        };
        
        sut.Activate([]).ShouldBe(4.0);
    }
}
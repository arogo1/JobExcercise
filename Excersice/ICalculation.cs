namespace Excersice;

public interface ICalculation
{
    Task<Result> DoCalculation(NIC nic);
}


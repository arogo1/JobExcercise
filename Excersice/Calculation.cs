namespace Excersice;

public class Calculation : ICalculation
{
	private const int pollingRatio = 2;
    private const double pollingRatioSec = (double)1/pollingRatio;

    public Calculation()
	{
	}

	public async Task<Result> DoCalculation(NIC nic)
	{
		var result = new Result();

		result.BitrateRx = await DoCalculationForRx(double.Parse(nic.Rx));
		result.BitrateTx = await DoCalculationForTx(double.Parse(nic.Tx));

		return result;
	}

    private async Task<double> DoCalculationForTx(double Rx)
    {
		//if we suppose that RX and TX are Bytes than we need to convert it in bites
		var bites = Rx * 8;
		var result = (double)bites / pollingRatioSec;
        return result;
    }

	private async Task<double> DoCalculationForRx(double Tx)
	{
        //if we suppose that RX and TX are Bytes than we need to convert it in bites
        var bites = Tx * 8;
        var result = (double)bites / pollingRatioSec;
        return result;
    }
}


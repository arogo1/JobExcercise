namespace Excersice;

public class ResponseModel
{
	public string Device { get; set; }

	public string Model { get; set; }

	public List<NIC> NIC { get; set; }
}


//Better practice to move in separate class, but in this case will leave it here since we are not going to have extra models


public class NIC
{
    public string Descriptio { get; set; }

    public string MAC { get; set; }

    public string Timestamp { get; set; }

    public string Rx { get; set; }

    public string Tx { get; set; }
}

public class Result
{
    public double BitrateRx { get; set; }

    public double BitrateTx { get; set; }
}
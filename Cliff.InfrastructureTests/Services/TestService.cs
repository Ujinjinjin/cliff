namespace Cliff.Test.Services;

public class TestService : ITestService
{
	public void SuccessfulAction(string param)
	{
		Console.WriteLine(param);
	}

	public void FailingAction(string param)
	{
		throw new ApplicationException();
	}
}

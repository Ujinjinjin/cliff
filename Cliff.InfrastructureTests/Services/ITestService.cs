namespace Cliff.Test.Services;

public interface ITestService
{
	void SuccessfulAction(string param);

	void FailingAction(string param);
}

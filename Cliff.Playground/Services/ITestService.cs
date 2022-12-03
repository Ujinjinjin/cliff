namespace Cliff.Playground.Services;

public interface ITestService
{
    void SuccessfulAction(string param);

    void FailingAction(string param);

    void HiddenAction(string param);
}

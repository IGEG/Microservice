namespace CommandsService.EventProcess
{
    public interface IEventProcess
    {
        void ProcessEvent(string message);
    }
}
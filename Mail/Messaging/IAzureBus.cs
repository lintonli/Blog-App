namespace Mail.Messaging
{
    public interface IAzureBus
    {
        Task start();
        Task stop();
    }
}

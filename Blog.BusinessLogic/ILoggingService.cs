namespace Blog.BusinessLogic
{
    /* Very basic logging service */
    public interface ILoggingService
    {
        void Log(string message, params object[] parameters);
    }
}
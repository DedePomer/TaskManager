namespace ConsoleCs_TaskManagerLogic.Model.DataType
{
    public class AuthSettings
    {
        public string? SecretKey { get; set; }
        public TimeSpan? ExpireMinutes { get; set; }
    }
}

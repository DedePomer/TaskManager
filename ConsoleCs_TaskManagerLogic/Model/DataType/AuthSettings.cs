namespace ConsoleCs_TaskManagerLogic.Model.DataType
{
    public class AuthSettings
    {
        public required string SecretKey { get; init; }
        public required TimeSpan ExpireMinutes { get; init; }
    }
}

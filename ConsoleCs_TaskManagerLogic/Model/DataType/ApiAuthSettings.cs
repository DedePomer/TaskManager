namespace ConsoleCs_TaskManagerLogic.Model.DataType
{
    public class ApiAuthSettings
    {
        public required string Id { get; init; }
        public required byte[] Secret { get; init; }
    }
}

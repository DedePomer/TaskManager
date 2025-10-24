using ConsoleCs_TaskManagerLogic.Model.Interfaces;

namespace ConsoleCs_TaskManagerLogic.Model.DataType
{
    public class TextTask : ITask
    {
        public required int Id { get; init; }
        public required string Text { get; init; }
        public required string Discription { get; init; }
    }
}

namespace MissionImpossible.Helpers.Sort
{
    public enum SortDirection { Asc, Desc };
    public enum SortColumn { Name, Year };

    public sealed class SortHelper
    {
        public SortColumn Column { get; set; }
        public SortDirection Direction { get; set; }

        public SortHelper(SortColumn column, SortDirection direction)
        {
            Column = column;
            Direction = direction;
        }
    }
}

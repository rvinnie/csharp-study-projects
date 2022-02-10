namespace d02_ex00
{
    public enum MediaType
    {
        Book,
        Movie
    }

    public interface ISearchable
    {
        public MediaType Media { get; set; }
        public string? Title { get; set; }
    }
}

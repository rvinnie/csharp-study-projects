using System.Text.Json.Serialization;
using d02_ex00;

namespace d02_ex00.Model
{
    public class BookDetails
    {
        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("author")]
        public string? Author { get; set; }

        [JsonPropertyName("description")]
        public string? SummaryShort { get; set; }
    }

    public class Book : ISearchable
    {
        public MediaType Media { get; set; } = MediaType.Book;

        [JsonPropertyName("book_details")]
        public List<BookDetails> BookDetails { get; set; }

        public string? Title {
            get => BookDetails[0].Title;
            set => Title = value;
        }

        public string? Author
        {
            get => BookDetails[0].Author;
            set => Author = value;
        }

        public string? SummaryShort
        {
            get => BookDetails[0].SummaryShort;
            set => SummaryShort = value;
        }

        [JsonPropertyName("rank")]
        public int Rank { get; set; }

        [JsonPropertyName("list_name")]
        public string? ListName { get; set; }
        
        [JsonPropertyName("amazon_product_url")]
        public string? Url { get; set; }

        public override string ToString()
        {
            return $"- {Title} by {Author} [{Rank} on NYT's {ListName}]\n"
                            + $"{SummaryShort}\n{Url}\n";
        }
    }
}

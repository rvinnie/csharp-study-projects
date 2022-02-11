using System.Text.Json;
using System.Text.Json.Serialization;
using d02_ex00.Model;

namespace d02_ex00
{
    public class JsonResponse<T>
    {
        [JsonPropertyName("results")]
        public List<T> Results { get; set; }
    }

    public class Program
    {
        static void PrintNotFoundMsg(string search)
        {
            Console.WriteLine($"There are no “{search}” in media today.");
        }

        static void PrintFoundMedia(string target, List<ISearchable> media)
        {
            if (media.Count == 0)
            {
                PrintNotFoundMsg(target);
                return;
            }
            Console.WriteLine($"Items found: {media.Count}");

            List<Book> books = media
                                .Where(x => x.Media == MediaType.Book)
                                .Select(x => (Book)x)
                                .ToList();
            Console.WriteLine($"Book search result [{books.Count}]");
            foreach (var book in books)
            {
                Console.WriteLine(book);
            }

            List<Movie> movies = media
                                .Where(x => x.Media == MediaType.Movie)
                                .Select(x => (Movie)x)
                                .ToList();
            Console.WriteLine($"Movie search result [{movies.Count}]");
            foreach (var movie in movies)
            {
                Console.WriteLine(movie);
            }
        }

        static List<ISearchable> LaunchSearch(string target, List<ISearchable> searchableMedia)
        {
            List<ISearchable> foundElements = new List<ISearchable>();
            foreach (var media in searchableMedia)
            {
                if (string.IsNullOrEmpty(media.Title))
                    continue;
                target = target.ToLower();
                var mediaTitle = media.Title.ToLower();
                if (!string.IsNullOrEmpty(media.Title) && mediaTitle.Contains(target.ToLower()))
                    foundElements.Add(media);
            }
            return foundElements;
        }

        static List<ISearchable> ParseJsonFiles(string pathToBooks, string pathToMovies)
        {
            List<ISearchable> medias = new List<ISearchable>();

            using (var fs = new FileStream(pathToBooks, FileMode.Open))
            {
                JsonResponse<Book>? response = JsonSerializer.Deserialize<JsonResponse<Book>>(fs);
                var books = response?.Results;
                    
                if (books != null)
                {
                    foreach (var book in books)
                    {
                        medias.Add(book);
                    }
                }
            }

            using (var fs = new FileStream(pathToMovies, FileMode.Open))
            {
                JsonResponse<Movie>? response = JsonSerializer.Deserialize<JsonResponse<Movie>>(fs);
                var movies = response?.Results;
                if (movies != null)
                {
                    foreach (var movie in movies)
                    {
                        medias.Add(movie);
                    }
                }
            }
            return medias;
        }

        static void Main(string[] args)
        {
            try
            {
                var medias = ParseJsonFiles("book_reviews.json", "movie_reviews.json");
                Console.WriteLine("> Input search text:");
                string target = Console.ReadLine() ?? "";
                if (string.IsNullOrEmpty(target))
                {
                    PrintNotFoundMsg(target);
                    return;
                }
                PrintFoundMedia(target, LaunchSearch(target, medias));
            }
            catch (IOException)
            {
                Console.WriteLine("Review files not found");
                return;
            }
        }
    }
}

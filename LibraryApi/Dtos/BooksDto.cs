using LibraryApi.Data;

namespace LibraryApi.Dtos
{
    public class BooksDto
    {
        [MaxLength(250)]
        public string Title { get; set; }
        public IFormFile ? Poster { get; set; }
        public byte GenreId { get; set; }
        public int AuthorId { get; set; }

    }
}

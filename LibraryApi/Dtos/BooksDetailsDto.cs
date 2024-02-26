namespace LibraryApi.Dtos
{
    public class BooksDetailsDto
    {
        public string Title { get; set; }
        public byte[] Poster { get; set; }
        public byte GenreId { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string GenreName { get; set; }
    }
}

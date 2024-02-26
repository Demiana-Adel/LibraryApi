namespace LibraryApi.Data
{
    public class Book
    {
        public int Id { get; set; }
        [MaxLength(250)]
        public string Title { get; set; }
        public byte [] Poster { get; set; }
        public byte GenreId { get; set; }
        public Genre Genre { get; set; }
        public int AuthorId{ get; set; }

        public Author Author { get; set; }

    }
}

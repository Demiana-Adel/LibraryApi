namespace LibraryApi.Data
{
    public class Author
    {
        public int Id { get; set; }
        [MaxLength(250)]
        public string Name { get; set; }
        public string BirthDate { get; set; }
        public  byte [] Image { get; set; }
        public  byte CountryId { get; set; }
        public Country Country { get; set; }
    }
}

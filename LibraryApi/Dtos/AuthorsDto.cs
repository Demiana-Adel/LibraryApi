namespace LibraryApi.Dtos
{
    public class AuthorsDto
    {
        //public int Id { get; set; }
        [MaxLength(250)]
        public string Name { get; set; }
        public string BirthDate { get; set; }
        public IFormFile ? Image { get; set; }
        public byte CountryId { get; set; }
    
    }
}




























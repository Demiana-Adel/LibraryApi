namespace LibraryApi.Dtos
{
    public class authorsDetailsDto
    {
        public string Name { get; set; }
        public string BirthDate { get; set; }
        public byte[] Image { get; set; }
        public byte CountryId { get; set; }
        public string CountryName { get; set; }
    }
}

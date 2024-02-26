namespace LibraryApi.Dtos
{
    public class CountriesDto
    {
        [MaxLength(250)]
        public string Name { get; set; }
    }
}

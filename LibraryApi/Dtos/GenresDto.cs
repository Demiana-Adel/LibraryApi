namespace LibraryApi.Dtos
{
    public class GenresDto
    {
        [MaxLength(250)]
        public string Name { get; set; }
    }
}

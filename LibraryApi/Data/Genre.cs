

namespace LibraryApi.Data
{
    public class Genre
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }
        [MaxLength(250)]
        public string Name { get; set; }    
    }
}

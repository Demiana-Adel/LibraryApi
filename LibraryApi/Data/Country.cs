namespace LibraryApi.Data
{
    public class Country
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }
        [MaxLength(250)]
        public string Name { get; set; }
    }
}

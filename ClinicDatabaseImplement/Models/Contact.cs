namespace ClinicDatabaseImplement.Models
{
    public class Contact
    {
        public int? Id { get; set; }

        public int ClinicId { get; set; }

        public long Telephone { get; set; }
    }
}

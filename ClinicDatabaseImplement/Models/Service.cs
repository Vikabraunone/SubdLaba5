namespace ClinicDatabaseImplement.Models
{
    /// <summary>
    /// Услуги в области медицины
    /// </summary>
    public class Service
    {
        public int Id { get; set; }

        public int FieldId { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Publishing_House.Model.DatabaseModels
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfPages { get; set; }
        [ForeignKey("PublishingHouseId")]
        public int? PublishingHouseId { get; set; }
        public PublishingHouse? PublishingHouse { get; set; }
        [ForeignKey("AuthorId")]
        public int? AuthorId { get; set; }
        public Author? Author { get; set; }

    }
}

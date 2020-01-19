using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleApp.DataAccess.Entity
{
    public class Photo
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        [ForeignKey("Car")]
        public int CarId { get; set; }

        public virtual Car Car { get; set; }
    }
}

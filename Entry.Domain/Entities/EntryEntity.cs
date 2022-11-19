using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entry.Domain.Entities
{
    public class EntryEntity 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public System.Guid Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Entry { get; set; }

    }
}

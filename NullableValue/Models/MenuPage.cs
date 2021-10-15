using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NullableValue.Models
{
    [Table( "page", Schema = "menu" )]
    public partial class MenuPage
    {
        [Key]
        public Guid Id { get; set; }

        public Guid? FkGroup { get; set; }

        [ForeignKey(nameof(FkGroup))]
        [InverseProperty(nameof(MenuGroup.Pages))]
        public virtual MenuGroup FkGroupNavigation { get; set; }
    }
}

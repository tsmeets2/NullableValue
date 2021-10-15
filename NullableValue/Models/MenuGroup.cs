using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NullableValue.Models
{
    [Table( "group", Schema = "menu" )]
    public partial class MenuGroup
    {
        [Key]
        public Guid Id { get; set; }

        public Guid? FkGroup { get; set; }

        [InverseProperty(nameof(MenuPage.FkGroupNavigation))]
        public virtual ICollection<MenuPage> Pages { get; set; }

        [ForeignKey( nameof( FkGroup ) )]
        public virtual ICollection<MenuGroup> Groups { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ciuchex.Models
{
    public class Order
    {
        public int Id { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string OrderNumber { get; set; } = Guid.NewGuid().ToString();
        public decimal Total { get; set; }
        public string UserId { get; set; }
        public DateTime OrderDate { get; set; }

        [ForeignKey("UserId")]
        public IdentityUser IdentityUser { get; set; }
        public virtual List<CartItem> CartItems { get; set; }
    }
}

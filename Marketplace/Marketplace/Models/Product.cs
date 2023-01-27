using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;

namespace Marketplace.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Descrytpion of the product is required")]
        public string Descryption { get; set; }

        [Required(ErrorMessage = "Price of the product is required")]
        public double Price { get; set; }
        public byte[]? Img { get; set; }
        public int sellerId { get; set; }

        //public Nullable<byte[]> Img { get; set; }
    }
}

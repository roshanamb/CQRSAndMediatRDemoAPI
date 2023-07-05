using System.ComponentModel.DataAnnotations;
using CQRSAndMediatRDemoAPI.Data;

namespace CQRSAndMediatRDemoAPI.Models
{
    public class StudentDetails
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Student Name is required")]
        [StringLength(60)]
        public string Name { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "Incorrect Email")]
        [StringLength(100)]
        public string Email { get; set; }
        public string Address { get; set; }

        [Range(0, 100, ErrorMessage = "Age should be greater than 0 and less than 150")]
        [MaxLength(3, ErrorMessage = "Max length of age is 3")]
        public int Age { get; set; }
    }
}
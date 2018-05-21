using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Required(ErrorMessage = "The Initials cannot be Empty")]
        [StringLength(10)]
        [Display(Name = "Initials")]
        public string Initials { get; set; }
        [Required(ErrorMessage = "The  Name Denoted By Initials cannot be Empty")]
        [StringLength(20)]
        [Display(Name = "Name Denoted By Initials")]
        public string NameDenoted { get; set; }
        [Required(ErrorMessage = "The First Name cannot be Empty")]
        [StringLength(20)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [StringLength(20)]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [StringLength(20)]
        [Display(Name = "Last Name")]
        public string  LastName { get; set; }
        //[SexValidation(ErrorMessage = "Select your sex")]   //validation for sex is commented. Can find the class below
        public string sex { get; set; }
        [StringLength(10,ErrorMessage="Invalied NIC Number")]
        [Display(Name = "NIC Number")]
        public string NICNumber { get; set; }
        [Display(Name = "Address")]
        public string Address { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Joined Date")]
        public DateTime JoinedDate { get; set; }
         [DataType(DataType.Date)]
         [Display(Name = "Resignation Date")]
        public DateTime ResignationDate { get; set; }
        [Display(Name = "Active Status")]
        public int ActiveStatus { get; set; }
        [Required(ErrorMessage = "The Mobile Number cannot be Empty")]
        [DataType(DataType.PhoneNumber)]
        public int Mobile { get; set; }
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
    }
}

/*public class SexValidation : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (Convert.ToString(value) == "M" || Convert.ToString(value) == "F")
            return ValidationResult.Success;
        else
            return new ValidationResult(ErrorMessage);
    }
}*/

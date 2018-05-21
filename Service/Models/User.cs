using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "User Id")]
        public int Id { get; set; }
        [Required(ErrorMessage = "The User Name cannot be Empty")]
        [StringLength(20)]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "The Password cannot be Empty")]
        [StringLength(20)]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [Display(Name = "Employee Id")]
        public int? EmployeeId { get; set; }
        [Required(ErrorMessage = "The Created Date cannot be Empty")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        [DataType(DataType.Date)]
        [Display(Name = "Joined Date")]
        public DateTime CreatedDate { get; set; }
        [Range(0, 1)]
        [Display(Name = "Active Status")]
        public int ActiveStatus { get; set; }
        [ForeignKey("EmployeeId")]
        public virtual Employee employee { get; set; }


        //In the case if there is a many to many relationship following code can be apply

        /*protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Course>()
                .HasMany(c => c.Instructors).WithMany(i => i.Courses)
                .Map(t => t.MapLeftKey("CourseID")
                    .MapRightKey("InstructorID")
                    .ToTable("CourseInstructor"));
        }*/
    }
}

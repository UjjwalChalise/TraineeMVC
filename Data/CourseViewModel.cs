using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TraineeMVC.Models;

namespace TraineeMVC.Data
{
    public class CourseCreateViewModel
    {
        //[Key]
        //public int CourseId { get; set; }

        [Required]
        [MaxLength(150)]
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        //[ForeignKey("Instructor")]
        public int InstructorId { get; set; }

        //public DateTime CreatedDate { get; set; } = DateTime.Now;

        //// Navigation properties
        //public User? Instructor { get; set; }
    }
    public class CourseUpdateViewModel
    {
        [Key]
        public int CourseId { get; set; }

        [Required]
        [MaxLength(150)]
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }
        public int InstructorId { get; set; }

    }
    public class CourseDetailViewModel
    {
        [Key]
        public int CourseId { get; set; }
        [Required]
        [MaxLength(150)]
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        public int InstructorId { get; set; }
        public string InstructorName { get; set; }

    }
    public class CourseListViewModel
    {

        [Required]
        [MaxLength(150)]
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        public int InstructorId { get; set; }
        public string InstructorName { get; set; }

    }
    public class CourseDeleteViewModel
    {
        [Key]
        public int CourseId { get; set; }
    }

}

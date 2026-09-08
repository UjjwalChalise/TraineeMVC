public class Teacher
{
    public int Id { get; set; }

    public string TeacherName { get; set; }

    public string Email { get; set; }

    public ICollection<Course> Courses { get; set; }
}
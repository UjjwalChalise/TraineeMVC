public class Student
{
    public int Id { get; set; }

    public string StudentName { get; set; }

    public string Email { get; set; }

    public ICollection<Attendance> Attendances { get; set; }
}
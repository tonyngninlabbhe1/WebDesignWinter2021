using System.Collections.Generic;

public interface IStudentRepository
{
    List<Student> GetAllStudents();
    Student GetStudentById(long studentId);
}
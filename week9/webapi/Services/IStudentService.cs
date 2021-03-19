using System.Collections.Generic;

public interface IStudentService
{
    List<StudentModel> GetAllStudents();
    StudentModel GetStudentById(long studentId);
}
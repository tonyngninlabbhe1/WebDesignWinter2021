using System.Collections.Generic;
using Microsoft.Extensions.Logging;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRespository;
    private readonly ILogger _logger;

    public StudentService(IStudentRepository studentRepository, ILoggerFactory loggerFactory)
    {
        _studentRespository = studentRepository;
        _logger = loggerFactory.CreateLogger("Controllers.StudentService");
    }

    public List<StudentModel> GetAllStudents()
    {
        var studentViewModels = new List<StudentModel>();

        foreach(var student in _studentRespository.GetAllStudents())
        {
            studentViewModels.Add(new StudentModel {
                studentId = student.StudentId,
                email_address = student.email_address,
                special= BusinessRules.isSpecial(student),
            });
        }

        return studentViewModels;
    }

    public StudentModel GetStudentById(long studentId)
    {
        var student = _studentRespository.GetStudentById(studentId);

        return new StudentModel {
            studentId = student.StudentId,
            email_address = student.email_address,
        };
    }

}
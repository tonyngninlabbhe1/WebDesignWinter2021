using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using FakeItEasy;
using FluentAssertions;

public class StudentServiceTests
{
    private StudentService _studentService; // System Under Test (SUT)
    private IStudentRepository _studentRepository; // Mock
    public static string bestStudent = "t";


    [SetUp]
    public void Setup()
    {
        var loggerFactory = A.Fake<LoggerFactory>();
        _studentRepository = A.Fake<IStudentRepository>();

        _studentService = new StudentService(_studentRepository, loggerFactory);
    }

    [Test]
    public void ShouldNotReturnSpecialStudents()
    {
        // Arrange (Given)
        A.CallTo(() => _studentRepository.GetAllStudents()).Returns(
            new List<Student> {
                new Student {
                    StudentId = 13,
                    email_address = "PonyFouet@oit.edu"
                },
                new Student {
                    StudentId = 14,
                    email_address = "MobSmith@oit.edu"
                }
            }
        );

        // Act (When)
        var studentViewModels = _studentService.GetAllStudents();

        // Assert (NUnit Assertions) (Then)
        Assert.That(studentViewModels.Any(pdto => pdto.special), Is.EqualTo(false));

        // Assert (FluentAssertions) (Then)
        studentViewModels.Any(pdto => pdto.special).Should().BeFalse();
    }

    [Test]
    public void ShouldReturnSpecialStudents()
    {
        // Arrange (Given)
        A.CallTo(() => _studentRepository.GetAllStudents()).Returns(
            new List<Student> {
                new Student {
                    StudentId = 13,
                    email_address = "tonyFouet@oit.edu"
                },
                new Student {
                    StudentId = 14,
                    email_address = "tobSmith@oit.edu"
                }
            }
        );

        // Act (When)
        var studentViewModels = _studentService.GetAllStudents();

        // Assert (NUnit Assertions) (Then)
        Assert.That(studentViewModels.Any(pdto => pdto.special), Is.EqualTo(true));

        // Assert (FluentAssertions) (Then)
        studentViewModels.Any(pdto => pdto.special).Should().BeTrue();
    }

}
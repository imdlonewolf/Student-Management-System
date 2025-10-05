// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using DAL.Model;
using DAL.Repository;

Repository _repository = new Repository();
//Student student=new Student();
//student.StudentName = "kuddus";
//student.StudentEmail = "aihgag";
//student.StudentPhone = "456789";
//student.DOB = new DateOnly(2002, 6, 24);
//student.Courses = new List<string> {"Engineering","Spoken English" };
List<Student> students=_repository.GetStudentsList();
int id=_repository.GetStudentByName("prof paglu").StudentId;
Console.WriteLine(id);
foreach(var i in students)
{
    Console.WriteLine(i.StudentName);
}
//_repository.AddStudent(student);
//_repository.UpdateStudent(2, "3456789");
//_repository.DeleteStudent(1);

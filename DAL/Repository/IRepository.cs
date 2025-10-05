using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IRepository
    {
        public List<Student> GetStudentsList();
        public Student GetStudentById(int id);
        public bool AddStudent(Student student);
        public bool UpdateStudent(int id,string phone);
        public bool DeleteStudent(int id);
        public Student GetStudentByName(string name);
        public User ValidateUser(String EmailId, string Password);
        public bool AddUser(User user);
    }
}

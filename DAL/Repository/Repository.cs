using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class Repository : IRepository
    {
        StudentContext _context;
        public Repository() { 
            _context = new StudentContext();
        }
        public bool AddStudent(Student student)
        {
            try
            {
                _context.Students.Add(student);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public bool AddUser(User user)
        {
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex) { 
                Console.WriteLine(ex);
                return false;
            }
        }

        public bool DeleteStudent(int id)
        {
            try
            {
                Student student = GetStudentById(id);
                _context.Students.Remove(student);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
                return false;

            }
        }

        public Student GetStudentById(int id)
        {
            try
            {
                Student student = _context.Students.Find(id);
                return student;
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
                return null;
            }
        }

        public Student GetStudentByName(string name)
        {
            Student student= _context.Students.Where(n=>n.StudentName==name).FirstOrDefault();
            return student;
        }

        public List<Student> GetStudentsList()
        {
            try
            {
                return _context.Students.ToList();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public bool UpdateStudent(int id, string phone)
        {
            try
            {
                Student student = GetStudentById(id);
                student.StudentPhone=phone;
                _context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public User ValidateUser(string EmailId, string Password)
        {
            User user= null;
            user=_context.Users.Where(u=>u.EmailId==EmailId && u.Password==Password).FirstOrDefault();
            return user;
        }
    }
}

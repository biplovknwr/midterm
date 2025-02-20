using _200604735.Models;  

namespace _200604735.Services
{
    public class StudentService
    {
        private readonly List<Student> _students = new();
        private int _nextId = 1;

        public List<Student> GetAll() => _students;

        public Student? GetById(int id) => _students.FirstOrDefault(s => s.StudentId == id);

        public void Create(Student student)
        {
            student.StudentId = _nextId++;
            _students.Add(student);
        }

        public bool Update(int id, Student updatedStudent)
        {
            var existingStudent = _students.FirstOrDefault(s => s.StudentId == id);
            if (existingStudent == null) return false;

            existingStudent.FirstName = updatedStudent.FirstName;
            existingStudent.LastName = updatedStudent.LastName;
            existingStudent.Email = updatedStudent.Email; 
            return true;
        }

        public bool Delete(int id)
        {
            var student = _students.FirstOrDefault(s => s.StudentId == id);
            if (student == null) return false;

            _students.Remove(student);
            return true;
        }
    }
}

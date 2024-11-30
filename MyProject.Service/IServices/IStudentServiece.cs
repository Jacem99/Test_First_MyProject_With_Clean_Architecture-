using MyProject.Data.Entities;

namespace MyProject.Service.IServices
{
    public interface IStudentServiece
    {
        public Task<List<Student>> GetStudentsListAsync();
        public Task<Student> GetStudentByIdAsync(int Id);
        public IQueryable<Student> GetStudentQueryable();
        public IQueryable<Student> FilterGetStudentPaginatedQueryable(string search);
        public Task DeleteStudent(Student student);
    }
}

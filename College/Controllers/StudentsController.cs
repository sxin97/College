using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CollegeDataAccess;
using System.Data.Entity;

namespace StudentService.Controllers
{
    public class StudentsController : ApiController
    {
        

        public IEnumerable<Student> Get()
        {
            using (UniversityDBEntities entities = new UniversityDBEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                return entities.Students.ToList<Student>();
                //return entities.Students.Select(x => new Student
                //{
                //    StudentName = x.StudentName,
                //    StudentEmail = x.StudentEmail,
                //    GroupCode = x.GroupCode

                //}).ToList();
                
            }
        }
        public void Post([FromBody]Student student)
        {
            using(UniversityDBEntities entities = new UniversityDBEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                student.Deleted = false;
                entities.Students.Add(student);
                entities.SaveChanges();
            }
        }
        public void Put(string id, [FromBody]Student student)
        {
            using(UniversityDBEntities entities = new UniversityDBEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                var enty = entities.Students.FirstOrDefault(x => x.StudentId == id);
                enty.StudentName = student.StudentName;
                enty.StudentPass = student.StudentPass;
                enty.StudentPhone = student.StudentPhone;
                enty.StudentEmail = student.StudentEmail;
                enty.GroupCode = student.GroupCode;
                enty.Deleted = student.Deleted;
                entities.SaveChanges();
            }
        }
        public void Delete(string id)
        {
            using(UniversityDBEntities entities = new UniversityDBEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                var enty = entities.Students.FirstOrDefault(x => x.StudentId == id);
                enty.Deleted = true;
                entities.SaveChanges();
            }
        }
        public Student Get(string id)
        {
            using (UniversityDBEntities entities = new UniversityDBEntities())
            {
                return entities.Students.FirstOrDefault(e => e.StudentId == id);
            }
        }
    }
}
using Common.Lib.Core.Context;
using ItAcademyProjecteNET.Lib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItAcademyProjecteNET.Lib.Interfaces
{
    public interface IStudentRepository :IRepository<Student>
    {

        Student GetStudentByDni(string dni);

        int GetNumberStudents();

        void AddFromDb(Student entity);

    }
}

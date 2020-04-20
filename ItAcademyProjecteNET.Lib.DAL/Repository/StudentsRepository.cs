using Common.Lib.Core;
using Common.Lib.DAL.EFCore;
using Common.Lib.Infrastructure;
using ItAcademyProjecteNET.Lib.DAL.Context;
using ItAcademyProjecteNET.Lib.Interfaces;
using ItAcademyProjecteNET.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ItAcademyProjecteNET.Lib.DAL.Repository
{
    public class StudentsRepository : EfCoreRepository<Student>, IStudentRepository
    {
        static Dictionary<string, Student> StudentsByDni { get; set; } = new Dictionary<string, Student>();

        public StudentsRepository(ItAcademyDbContext dbcontext)
            : base(dbcontext)
        {
            if (GetNumberStudents() == 0)
            {
                foreach (var element in QueryAll().ToList())
                    AddFromDb(element);
            }
        }

        public override OperationResult<Student> Add(Student entity)
        {

            var output = base.Add(entity);

            if (output.IsSuccess)
                StudentsByDni.Add(output.Entity.Dni, output.Entity);

            return output;
        }

        public override OperationResult<Student> Update(Student entity)
        {
            var previousDni = string.Empty;

            using (var repoTemp = Entity.DepCon.Resolve<IStudentRepository>())
            {
                var existingStudent = repoTemp.Find(entity.Id);
                previousDni = existingStudent.Dni;
            }

            var output = base.Update(entity);

            if (output.IsSuccess)
            {
                if (previousDni != output.Entity.Dni)
                {
                    StudentsByDni.Remove(previousDni);
                    StudentsByDni.Add(output.Entity.Dni, output.Entity);
                }
                else
                    StudentsByDni[output.Entity.Dni] = output.Entity;
            }

            return output;
        }

        public override OperationResult<Student> Delete(Student entity)
        {
            var output = base.Delete(entity);

            if (output.IsSuccess == true)
                StudentsByDni.Remove(entity.Dni);

            return output;
        }

        public override Student Find(int id)
        {
            return base.Find(id);
        }


        public Student GetStudentByDni(string dni)
        {
            if (StudentsByDni.ContainsKey(dni))
            {
                var studentForUpdate = StudentsByDni[dni];
                return studentForUpdate;
            }

            return null;
        }

        public int GetNumberStudents()
        {
            return StudentsByDni.Values.Count;
        }

        public void AddFromDb(Student entity)
        {
            StudentsByDni.Add(entity.Dni, entity);
        }

    }
}

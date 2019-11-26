﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.StudentManagement
{
   public class LogicLayer
    {
       public Student GetStudent(int id)
       {
           var db = new MyDatabaseEntities();
           return db.Students.Find(id);

       }
       public Student[] GetStudents()
       {
           var db = new MyDatabaseEntities();
           return db.Students.ToArray();
       }
       public void CreateStudent(string code, string name, DateTime brithday, int class_id)
       {
           var student = new Student();
           student.Code = code;
           student.Name = name;
           student.Brithay = brithday;
           student.Class_id = class_id;
           var db = new MyDatabaseEntities();
           db.Students.Add(student);
           db.SaveChanges();


       }
       public void UpdateStudent(int id, string name, DateTime brithday,int class_id)
       {
           var db = new MyDatabaseEntities();
           var student = db.Students.Find(id);
           
           student.Name=name;
           student.Brithay = brithday;
           student.Class_id = class_id;
           db.Entry(student).State = System.Data.Entity.EntityState.Modified;
           db.SaveChanges();

       }
       public void DeleteStudent(int id)
       {
           var db = new MyDatabaseEntities();
           var student = db.Students.Find(id);
           db.Students.Remove(student);
           db.SaveChanges();
       }
       public Class[] GetClasses()
       {
           var db = new MyDatabaseEntities();
           return db.Classes.ToArray();
       }
       
    }
}

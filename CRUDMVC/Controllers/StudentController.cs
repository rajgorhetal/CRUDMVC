using CRUDMVC.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDMVC.Controllers
{
    public class StudentController : Controller
    {
        db_mvccrudEntities objdb_mvccrudEntities = new db_mvccrudEntities();

        // GET: Student
        public ActionResult Student(tbl_Student objStudent)
        {
            if (objStudent != null)
                return View(objStudent);
            return View();
        }


        [HttpPost]
        public ActionResult AddStudent(tbl_Student model)
        {
            if (ModelState.IsValid)
            {
                tbl_Student objStudent = new tbl_Student();
                objStudent.ID = model.ID;
                objStudent.FNAME = model.FNAME;
                objStudent.NAME = model.NAME;
                objStudent.EMAIL = model.EMAIL;
                objStudent.MOBILE = model.MOBILE;
                objStudent.DESCRIPTION = model.DESCRIPTION;

                //Insert operation
                if (model.ID == 0)
                {
                    objdb_mvccrudEntities.tbl_Student.Add(objStudent);
                    objdb_mvccrudEntities.SaveChanges();
                }
                //Update operation
                else
                {

                    objdb_mvccrudEntities.Entry(objStudent).State = System.Data.Entity.EntityState.Modified;
                    objdb_mvccrudEntities.SaveChanges();
                }
                
            }
            ModelState.Clear();
            return View("Student");
        }

        public ActionResult UpdateStudent()
        {
            return View();
        }
        public ActionResult GetAllStudent()
        {
            return View(objdb_mvccrudEntities.tbl_Student.ToList());
        }
        public ActionResult DeleteStudent(int id)
        {
            objdb_mvccrudEntities.tbl_Student.Remove(objdb_mvccrudEntities
                .tbl_Student.Where(x => x.ID == id).First());
            objdb_mvccrudEntities.SaveChanges();
            return View("GetAllStudent", objdb_mvccrudEntities.tbl_Student.ToList());
        }

    }
}
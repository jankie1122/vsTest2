using MvcEntity.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;

namespace MvcEntity.Controllers
{
    public class DBConnectController : Controller
    {
        private IDbConnection _IDbConnection;
      
        public DBConnectController(IDbConnection IDbConnection)
        {
            _IDbConnection = IDbConnection;
        }


        // GET: DBConnect
        public ActionResult Index()
        {
            return View();
        }

        public List<Students> QueryOneStudentsEntity()
        {
            string sql = @"
                select * from Students
                ";
            List<Students> studentsEntity = _IDbConnection.Query<Students>(sql).ToList();
            return studentsEntity;
        }

        public ActionResult ShowStudentList()
        {
            List<Students> studentsEntity = QueryOneStudentsEntity();
            return View(studentsEntity);
        }
    }
}
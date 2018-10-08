using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MiniProfilerDemo.Models;

using MVCDemo.Data;
using MVCDemo.Models.ParaModel;
namespace MVCDemo.Controllers
{
    public class HomeController : Controller
    {
        private InstallRepository aSvr = new InstallRepository();

        //对应三个View的方法
        public ActionResult Search()
        {
            return View();
        }
        public ActionResult Insert()
        {
            return View();
        }
        public ActionResult Delete()
        {
            return View();
        }

        //public ActionResult SearchData()
        //{
        //    Install i1 = new Install();
        //    Install i2 = new Install();
        //    i1.ID=1;
        //    i1.City="anhui";
        //    i1.Type="a";

        //    i2.ID=2;
        //    i2.City="shanghai";
        //    i2.Type="b";

        //    Install[] list = {i1,i2};
        //   // return Json(i1, JsonRequestBehavior.AllowGet);
        //    return Json(new {
        //        total=2,
        //        rows=list
        //    });
        //}//SearchData

        //接受输入数据
        //返回数据库查询结果
        public ActionResult SearchInstallDB(InstallPara model)
        {
            var result = aSvr.SearchInstallDB(model);
            return Json(new { rows = result.Array, total = result.Total });

        }//SearchInstallDB

        //接受输入数据
        //不返回结果
        public ActionResult InsertInstallDB(InstallPara model)
        {
            var result = aSvr.InsertInstallDB(model);
            return null;
        }//SearchInstallDB

        //接受输入数据
        //不返回结果
        public ActionResult DeleteInstallDB(InstallPara model)
        {
            var result = aSvr.DeleteInstallDB(model);
            return null;
        }//SearchInstallDB
    }
}

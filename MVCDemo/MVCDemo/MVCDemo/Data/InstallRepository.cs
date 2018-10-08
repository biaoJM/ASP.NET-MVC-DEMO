using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CN.Focusmedia.Util.DataBase.EntityFramework;
using CN.Focusmedia.Util.Transfer.Model;
using MiniProfilerDemo.Models;
using MiniProfilerDemo.DAL;
using MVCDemo.Models.ParaModel;

//using Oracle.DataAccess.resources;
//using Oracle.DataAccess;

namespace MVCDemo.Data
{
    public class InstallRepository : ContextRepository<EFDbContext>
    {
        public PageArray<Install> SearchInstallDB(InstallPara model)
        {
            using (var db = new EFDbContext())
            {
                var args = new SqlParameter[] {
                    new SqlParameter { ParameterName = "ID", Value = model.ID },
                    new SqlParameter { ParameterName = "City", Value = model.City },
                    new SqlParameter { ParameterName = "Type", Value = model.Type },
                };

                SQLPara(args);//处理空值

                db.Database.CreateIfNotExists();
                var list = db.Database.SqlQuery<Install>(
                    "Select * from Install where (@ID is null or ID=@ID) and (@City is null or City=@City) and (@Type is null or Type=@Type)",
                    args
                ).ToArray();

                return new PageArray<Install>(1, list, 0, model.rows, list.Length);
            }//DbContext
        }//SearchInstallDB

        //接收输入数据
        //按照输入的参数执行插入sql语句，保存更改
        //不返回数据
        public PageArray<Install> InsertInstallDB(InstallPara model)
        {
            using (var db = new EFDbContext())
            {
                var args = new SqlParameter[] {
                    new SqlParameter { ParameterName = "ID", Value = model.ID },
                    new SqlParameter { ParameterName = "City", Value = model.City },
                    new SqlParameter { ParameterName = "Type", Value = model.Type },
                };

                SQLPara(args);//处理空值

                db.Database.CreateIfNotExists();

                db.Database.ExecuteSqlCommand(
                    "insert into Install values(@ID,@City,@Type) ",
                    args
                );

                for (int i = 0; i < 1000;i++ )
                {
                    args = new SqlParameter[] {
                        new SqlParameter { ParameterName = "ID", Value = i },
                        new SqlParameter { ParameterName = "City", Value = RandomString() },
                        new SqlParameter { ParameterName = "Type", Value = "a" },
                    };
                    db.Database.ExecuteSqlCommand(
                        "insert into Install values(@ID,@City,@Type) ",
                        args
                    );
                }

                    //db.Install.Add(new Install(model.ID,model.City,model.Type));

                    db.SaveChanges();
            }
            return null;
        }//InsertInstallDB

        //接收输入数据
        //按照输入的参数执行插入sql语句，保存更改
        //不返回数据
        public PageArray<Install> DeleteInstallDB(InstallPara model)
        {
            using (var db = new EFDbContext())
            {
                var args = new SqlParameter[] {
                    new SqlParameter { ParameterName = "ID", Value = model.ID },
                    new SqlParameter { ParameterName = "City", Value = model.City },
                    new SqlParameter { ParameterName = "Type", Value = model.Type },
                };

                SQLPara(args);//处理空值

                db.Database.CreateIfNotExists();
                db.Database.ExecuteSqlCommand(
                    "delete from Install where (@ID is null or ID=@ID) and (@City is null or City=@City) and (@Type is null or Type=@Type) ",
                    args
                );
                db.SaveChanges();
            }
            return null;
        }//DeleteInstallDB

        //处理接收的参数
        public static void SQLPara(SqlParameter[] args)
        {
            foreach (var i in args)
            {
                i.Value = i.Value == null ? DBNull.Value : i.Value;
            }
        }//SQLPara

        string RandomString()
        {
            string result = "";

            Random rd = new Random();

            for (int i = 0; i < 100;i++ )
                result.Insert(0, ('a' + rd.Next(1, 26).ToString())); 

            return result; 
        }
    }//class InstallRepository
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CodeFirstDemo.Model;
namespace CodeFirstDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new CodeFirstContext())
            {
                context.Database.CreateIfNotExists();//如果数据库不存在时则创建
                TRoles t = new TRoles();
                t.Id = 1;
                t.RoleName = "aa";
                context.Roles.Add(t);
                context.SaveChanges();
            }
            Console.Write("DB has Created!");//提示DB创建成功
            Console.Read();
            
        }
    }
}

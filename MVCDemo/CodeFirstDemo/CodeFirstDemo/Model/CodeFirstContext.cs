using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstDemo.Model
{
    public class CodeFirstContext : DbContext
    {
        public CodeFirstContext()
            : base("name=CodeFirstDemo")//与Config中数据库连接字符串名称一样
        {
        }
        //public DbSet<TRoles> Roles { get; set; }
    }
}

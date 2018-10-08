//DbContext数据库上下文，定义了从实体对象到数据库的映射，从数据库中检索数据，就要使用它。

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MiniProfilerDemo.Models;
using MVCDemo.Mapper;
namespace MiniProfilerDemo.DAL
{
    public class EFDbContext : DbContext//继承自DbContext
    {
        //static EFDbContext()
        //{
        //    Database.SetInitializer<EFDbContext>(null);
        //}

        //构造函数： public DbContext(string nameOrConnectionString);
        //base调用基类构造函数，参数为nameOrConnectionString
        //本函数使用的是ConnectingString，位置在Web.config
        //name是指这个连接的名字
        public EFDbContext() : base("name = ASimpleDB") { }

        public ObjectContext ObjectContext()
        {
            return (this as IObjectContextAdapter).ObjectContext;
        }

        //添加实体类，表示工作空间的数据区
        #region DBSET
        public DbSet<Install> Install { get; set; }
        #endregion

        //添加Mapper类，将数据库映射到类
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new InstallMapper());//添加映射
        }//映射
    }//class
}
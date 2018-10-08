using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CN.Focusmedia.Util.DataBase.EntityFramework;
using MiniProfilerDemo.DAL;

namespace MVCDemo.Data
{
    public class InstallUok: ContextUok<EFDbContext>
    {
        public InstallUok(int? timeout = null, System.Data.IsolationLevel? isolationLevel = null)
            : base(timeout, isolationLevel)
        {
        }
    }
}
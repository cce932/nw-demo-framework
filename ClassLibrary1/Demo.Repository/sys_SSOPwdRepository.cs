using Demo.EntityFramework;
using Demo.EntityFramework.Infrastructure;
using Demo.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Repository
{
    public class sys_SSOPwdRepository : GenericRepository<int, sys_SSOPwd>, Isys_SSOPwdRepository
    {
        public sys_SSOPwdRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}

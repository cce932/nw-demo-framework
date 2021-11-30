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
    public class cont_employeeRepository : GenericRepository<int, Cont_employee>, ICont_employeeRepository
    {
        public cont_employeeRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}

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
    public class stu_StatusRepository : GenericRepository<int, Stu_Status>, Istu_StatusRepository
    {
        public stu_StatusRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}

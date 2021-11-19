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
    public class Outgoing_StuRepository : GenericRepository<int, Outgoing_Stu>, Ioutgoing_StuRepository
    {
        public Outgoing_StuRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}

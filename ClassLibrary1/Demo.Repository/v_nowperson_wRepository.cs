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
    public class v_nowperson_wRepository : GenericRepository<int, v_nowperson_w>, IV_Nowperson_WRepository
    {
        public v_nowperson_wRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}

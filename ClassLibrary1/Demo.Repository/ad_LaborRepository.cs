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
    public class ad_LaborRepository : GenericRepository<int, v_AD_Labor>, IAD_LaborRepository
    {
        public ad_LaborRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}

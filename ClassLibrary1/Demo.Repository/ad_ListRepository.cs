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
    public class ad_ListRepository : GenericRepository<int, v_AD_List>, IAD_ListRepository
    {
        public ad_ListRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}

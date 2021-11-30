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
    public class schoolmemberRepository : GenericRepository<int, v_schoolmember>, IschoolmemberRepository
    {
        public schoolmemberRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}

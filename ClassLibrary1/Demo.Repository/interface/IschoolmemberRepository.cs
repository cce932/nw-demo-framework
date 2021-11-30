using Demo.EntityFramework;
using Demo.EntityFramework.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Repository.Interface
{
    public interface IschoolmemberRepository : IRepository<int, v_schoolmember>
    {
    }
}

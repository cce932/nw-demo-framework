using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Domain
{
    public class TargetForm
    {
        /// <summary>
        /// 學號/身分證
        /// </summary>
        public string Target { get; set; }
        
        /// <summary>
        /// 使用者身分 職員/學生
        /// </summary>
        public int Identity { get; set; }
    }
}

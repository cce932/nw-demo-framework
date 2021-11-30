using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Domain
{
    public class ProjectEmpInfo
    {
        /// <summary>
        /// 專案(計畫)助理的身分證
        /// </summary>
        public String ID { get; set; }

        /// <summary>
        /// 流程是否在進行中
        /// </summary>
        public String Confirmed { get; set; }

        /// <summary>
        /// 專案(計畫)助理 聘期起日
        /// </summary>
        public String Tern_from { get; set; }

        /// <summary>
        /// 專案(計畫)助理 聘期迄日
        /// </summary>
        public String Tern_end { get; set; }
    }
}

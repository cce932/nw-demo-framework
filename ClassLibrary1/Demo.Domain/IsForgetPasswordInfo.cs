using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Domain
{
    public class IsForgetPasswordInfo
    {
        /// <summary>
        /// 是否點選過忘記密碼
        /// </summary>
        public Boolean IsForgetPassword { get; set; }

        /// <summary>
        /// 上次點選忘記密碼的時間
        /// </summary>
        public DateTime ChangeTime { get; set; }

        /// <summary>
        /// email
        /// </summary>
        public String Email { get; set; }
        
        /// <summary>
        /// 是否在校生
        /// </summary>
        public Boolean IsStudent { get; set; }

        /// <summary>
        /// 是否在職
        /// </summary>
        public Boolean IsEmployee { get; set; }

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

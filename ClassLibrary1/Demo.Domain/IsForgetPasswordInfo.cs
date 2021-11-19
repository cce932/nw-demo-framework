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
    }
}

using Demo.Domain;
using Demo.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Service.Interface
{
    public interface Ispt_monitorService
    {
        /// <summary>
        /// 檢查是否忘記密碼資訊
        /// </summary>
        /// <param name="targetForm"></param>
        /// <returns></returns>
        IsForgetPasswordInfo CheckIsForgetInfo(TargetForm targetForm);
    }
}

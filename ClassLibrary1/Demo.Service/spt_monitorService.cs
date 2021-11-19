using Demo.EntityFramework;
using Demo.EntityFramework.Infrastructure;
using Demo.Repository;
using Demo.Service.Interface;
using System.Collections.Generic;
using System.Linq;
using Demo.Repository.Interface;
using Demo.Domain;

namespace Demo.Service
{
    public class spt_monitorService : Ispt_monitorService
    {
        private readonly Ispt_monitorRepository spt_monitorRepository;

        private readonly IUnitOfWork _unitOfWork;
        public spt_monitorService(Ispt_monitorRepository spt_monitorRepository, IUnitOfWork unitOfWork)
        {
            this.spt_monitorRepository = spt_monitorRepository;
            _unitOfWork = unitOfWork;
        }

        public IsForgetPasswordInfo CheckIsForgetInfo(TargetForm targetForm)
        {
            var aaa = targetForm;
            if (targetForm.Identity == 0)
            {

            }
            else
            {


                //查在「sys_SSOPwd」中該學號(身分證號)有沒有資料，有資料到A，無資料到B
                //「sys_SSOPwd.IsForgot」等於1，表示「點過」忘記密碼
                //「sys_SSOPwd.ChangeDt
                //＠mail.ntust.edu.tw
                //Stu_Status、Outgoing_Stu
                ////B - 1 - 1.Stu_Status有值 且 Stu_Status.NowCondition等於00或01，不是的話顯示非在校生
                //B - 1 - 2.Outgoing_Stu有值 且 Outgoing_Stu.ExitDate 跟 Outgoing_Stu.NonRegister
            }

            return null;
        }
    }
}

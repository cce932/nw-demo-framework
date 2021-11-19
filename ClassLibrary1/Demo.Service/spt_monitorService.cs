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
        private readonly Isys_SSOPwdRepository sysSSOPwdRepository;
        private readonly Istu_StatusRepository stu_StatusRepository;
        private readonly Ioutgoing_StuRepository outgoing_StuRepository;

        private readonly IUnitOfWork _unitOfWork;
        public spt_monitorService(Ispt_monitorRepository spt_monitorRepository, IUnitOfWork unitOfWork, Isys_SSOPwdRepository sysSSOPwdRepository, Istu_StatusRepository stu_StatusRepository, Ioutgoing_StuRepository outgoing_StuRepository)
        {
            this.spt_monitorRepository = spt_monitorRepository;
            _unitOfWork = unitOfWork;
            this.sysSSOPwdRepository = sysSSOPwdRepository;

            this.stu_StatusRepository = stu_StatusRepository;

            this.outgoing_StuRepository = outgoing_StuRepository;
        }

        public IsForgetPasswordInfo CheckIsForgetInfo(TargetForm targetForm)
        {
            IsForgetPasswordInfo isForgetPasswordInfo = new IsForgetPasswordInfo();
            if (targetForm.Identity == 0)
            {

            }
            else
            {
                var sysSSOPwd = sysSSOPwdRepository.Where(item => item.Account == targetForm.Target).FirstOrDefault();
                if (sysSSOPwd == null)
                    return null;


                isForgetPasswordInfo.IsForgetPassword = sysSSOPwd.IsForgot;
                isForgetPasswordInfo.ChangeTime = sysSSOPwd.ChangeDt;



                //本國生 Stu_Status
                var stuStatus = stu_StatusRepository.Where(item => item.StudentNo == targetForm.Target && (item.NowCondition == "00" || item.NowCondition == "01")).FirstOrDefault();
                if (stuStatus != null)
                    isForgetPasswordInfo.Email = stuStatus.OutEmail;
                else
                {
                    //外籍生 Outgoing_Stu
                    var outgoingStu = outgoing_StuRepository.Where(item => item.StudentNo == targetForm.Target && (item.ExitDate == "" || item.NonRegister == "")).FirstOrDefault();
                    isForgetPasswordInfo.Email = outgoingStu.Email;
                }
                isForgetPasswordInfo.IsStudent = true;
                isForgetPasswordInfo.IsEmployee = false;

                return isForgetPasswordInfo;


                //查在「sys_SSOPwd」中該學號(身分證號)有沒有資料，有資料到A，無資料到B 
                //「sys_SSOPwd.IsForgot」等於1，表示「點過」忘記密碼 OK
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

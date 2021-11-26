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
        private readonly IEmployeeRepository employeeRepository;
        private readonly IschoolmemberRepository schoolmemberRepository;
        private readonly IAD_LaborRepository ad_LaborRepository;
        private readonly IAD_ListRepository ad_ListRepository;
        private readonly IV_Nowperson_WRepository v_Nowperson_WRepository;
        private readonly ICont_employeeRepository cont_employeeRepository;

        private readonly IUnitOfWork _unitOfWork;
        public spt_monitorService(
            Ispt_monitorRepository spt_monitorRepository,
            IUnitOfWork unitOfWork,
            Isys_SSOPwdRepository sysSSOPwdRepository,
            Istu_StatusRepository stu_StatusRepository,
            Ioutgoing_StuRepository outgoing_StuRepository,
            IEmployeeRepository employeeRepository,
            IschoolmemberRepository schoolmemberRepository,
            IAD_LaborRepository ad_LaborRepository,
            IAD_ListRepository ad_ListRepository,
            IV_Nowperson_WRepository v_Nowperson_WRepository,
            ICont_employeeRepository cont_employeeRepository)
        {
            _unitOfWork = unitOfWork;

            this.spt_monitorRepository = spt_monitorRepository;
            this.sysSSOPwdRepository = sysSSOPwdRepository;
            this.stu_StatusRepository = stu_StatusRepository;
            this.outgoing_StuRepository = outgoing_StuRepository;
            this.employeeRepository = employeeRepository;
            this.schoolmemberRepository = schoolmemberRepository;
            this.ad_LaborRepository = ad_LaborRepository;
            this.ad_ListRepository = ad_ListRepository;
            this.v_Nowperson_WRepository = v_Nowperson_WRepository;
            this.cont_employeeRepository = cont_employeeRepository;
        }

        public IsForgetPasswordInfo CheckIsForgetInfo(TargetForm targetForm)
        {
            IsForgetPasswordInfo isForgetPasswordInfo = new IsForgetPasswordInfo();
            var sysSSOPwd = sysSSOPwdRepository.Where(item => item.Account == targetForm.Target).FirstOrDefault();
            if (sysSSOPwd == null)
                return null;

            isForgetPasswordInfo.IsForgetPassword = sysSSOPwd.IsForgot;
            isForgetPasswordInfo.ChangeTime = sysSSOPwd.ChangeDt;

            if (targetForm.Identity == 0)
            {
                var employee = employeeRepository.Where(item => item.CIDCard == targetForm.Target && item.StopMark == "0").FirstOrDefault();
                if (employee != null) {
                    isForgetPasswordInfo.IsEmployee = true;
                    isForgetPasswordInfo.IsStudent = false;
                    isForgetPasswordInfo.Email = employee.Email;
                    isForgetPasswordInfo.Confirmed = "";
                    isForgetPasswordInfo.Tern_from = "";
                    isForgetPasswordInfo.Tern_end = "";
                }
                else
                {
                    var adList = ad_ListRepository.Where(item => item.Note != "刪除" && item.Locked == "Y");
                    var adLabor = ad_LaborRepository.Where(item => item.IDcard == targetForm.Target);
                    var v_Nowperson_W = v_Nowperson_WRepository.Where(item => item.IDcard == targetForm.Target).FirstOrDefault();

                    //v_Nowperson_W 有值代表是專案(計畫)助理
                    //v_Nowperson_W == null 代表此人不是專案(計畫)助理
                    if (v_Nowperson_W != null)
                    {
                        isForgetPasswordInfo.IsEmployee = true;
                        isForgetPasswordInfo.IsStudent = false;
                        isForgetPasswordInfo.Email = v_Nowperson_W.email2;
                        isForgetPasswordInfo.Confirmed = "true";
                        isForgetPasswordInfo.Tern_from = v_Nowperson_W.Term_start;
                        isForgetPasswordInfo.Tern_end = v_Nowperson_W.Term_end;
                    }
                    else
                    { 
                        //projectEmpInfo !=null 代表此人在聘任中
                        //projectEmpInfo ==null 代表此人甚麼都不是
                        var projectEmpInfo = (from list in adList
                                              join labor in adLabor
                                              on list.Listno equals labor.Listno
                                              select new ProjectEmpInfo
                                              {
                                                  ID = labor.IDcard,
                                                  Confirmed = list.Confirmed,
                                                  Tern_from = labor.Term_from == null ? "" : labor.Term_from.Value.ToString(),
                                                  Tern_end = labor.Term_end == null ? "" : labor.Term_end.Value.ToString()
                                              }
                        ).FirstOrDefault();

                        var cont_employee = cont_employeeRepository.Where((item) => item.CIDCard == targetForm.Target).FirstOrDefault();
                        if (cont_employee == null)
                            return null;

                        isForgetPasswordInfo.IsEmployee = true;
                        isForgetPasswordInfo.IsStudent = false;
                        isForgetPasswordInfo.Email = cont_employee.Email;
                        isForgetPasswordInfo.Tern_end = projectEmpInfo.Tern_end;
                        isForgetPasswordInfo.Tern_from = projectEmpInfo.Tern_from;
                        isForgetPasswordInfo.Confirmed = projectEmpInfo.Confirmed;
                        if (projectEmpInfo == null)
                            return null;
                    }
                }
            }
            else
            {


                var stuStatus = stu_StatusRepository.Where(item => item.StudentNo == targetForm.Target && (item.NowCondition == "00" || item.NowCondition == "01")).FirstOrDefault();
                if (stuStatus != null)
                {
                    //本國生 Stu_Status
                    isForgetPasswordInfo.Email = stuStatus.OutEmail;
                }
                else
                {
                    //外籍生 Outgoing_Stu
                    var outgoingStu = outgoing_StuRepository.Where(item => item.StudentNo == targetForm.Target && (item.ExitDate == "" || item.NonRegister == "")).FirstOrDefault();
                    if (outgoingStu == null)
                        return null;
                    isForgetPasswordInfo.Email = outgoingStu.Email;

                }
                isForgetPasswordInfo.IsStudent = true;
                isForgetPasswordInfo.IsEmployee = false;
            }

            return isForgetPasswordInfo;
        }
    }
}

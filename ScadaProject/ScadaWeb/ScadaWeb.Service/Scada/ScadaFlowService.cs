 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScadaWeb.Model;
using ScadaWeb.IService;
using ScadaWeb.Common;

namespace ScadaWeb.Service
{
    public class ScadaFlowProjectService : BaseService<ScadaFlowProjectModel>, IScadaFlowProjectService
    {
        public ScadaFlowProjectService()
        {
        }
        public dynamic GetListByFilter(ScadaFlowProjectModel filter, PageInfo pageInfo)
        {
            pageInfo.prefix = "a.";
            string _where = " ScadaFlowProject a inner join IO_SERVER b   ON a.ServerID=b.SERVER_ID";
            if (!string.IsNullOrWhiteSpace(filter.Title))
            {
                _where = " where Title like '%" + filter.Title + "%' ";
            }
            pageInfo.returnFields = string.Format("{0}Id,{0}Title,{0}Desc,{0}CreateDate,{0}ProjectId,{0}ServerID,{0}SortCode,{0}CreateTime,{0}CreateUserId,{0}UpdateTime,{0}UpdateUserId,b.SERVER_NAME as ServerName,b.SERVER_IP as ServerIP", pageInfo.prefix);
            return GetPageUnite(filter, pageInfo, _where);
        }
        /// <summary>
        /// 流程短Web登录
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public bool LoginOn(string userName, string password, string projectId,out string nickname)
        {
            nickname = "";
            ScadaFlowProjectModel scadaFlowProject = base.GetById(int.Parse(projectId));
            if (scadaFlowProject == null)
                return false;
            string[] userInfos = scadaFlowProject.FlowUser.Split(new char[2] { '{', '}' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < userInfos.Length; i++)
            {
                string[] user = userInfos[i].Split(new char[1] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                if (user.Length >= 5)
                {
                    int usernameIndex = -1;
                    int passwordIndex = -1;
                    int nicknameIndex = -1;
                    for (int j = 0; j < user.Length; j++)
                    {
                        if (usernameIndex == -1)
                            if (user[j].IndexOf("username") >= 0)
                            {
                                usernameIndex = j;
                            }
                        if (passwordIndex == -1)
                            if (user[j].IndexOf("password") >= 0)
                            {
                                passwordIndex = j;
                            }
                        if (nicknameIndex == -1)
                            if (user[j].IndexOf("nikename") >= 0)
                            {
                                nicknameIndex = j;
                            }



                    }
                    if (usernameIndex >= 0 && passwordIndex >= 0 && nicknameIndex >= 0)
                    {
                        string uname = user[usernameIndex].Split(':')[1].Replace("'", "");
                        string pwd = user[passwordIndex].Split(':')[1].Replace("'", "");
                        nickname = user[nicknameIndex].Split(':')[1].Replace("'", "");
                        if (uname.Trim() == userName.Trim() && pwd.Trim() == DESEncrypt.Encrypt(password))
                        {
                            return true;
                        }

                    }
                }

            }

            return false;
        }
    }
    public class ScadaFlowViewService : BaseService<ScadaFlowViewModel>, IScadaFlowViewService
    {
        public ScadaFlowViewService()
        {
        }
        public dynamic GetListByFilter(ScadaFlowViewModel filter, PageInfo pageInfo)
        {
            throw new NotImplementedException();
        }
    }
}

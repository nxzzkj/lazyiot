using System;

namespace ScadaWeb.Common
{
    /// <summary>
    /// 用户登录使用的类
    /// </summary>
    public class OperatorModel
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 账户
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string RealName { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string HeadIcon { get; set; }
        /// <summary>
        /// 角色Id
        /// </summary>
        public int RoleId { get; set; }
        /// <summary>
        /// 登录IP
        /// </summary>
        public string LoginIPAddress { get; set; }
        /// <summary>
        /// 登录IP城市
        /// </summary>
        public string LoginIPAddressName { get; set; }
    }
}

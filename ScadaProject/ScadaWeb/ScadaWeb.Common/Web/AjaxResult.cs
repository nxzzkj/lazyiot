namespace ScadaWeb.Common
{
    public class AjaxResult
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public object state { get; set; }
        /// <summary>
        /// 返回消息内容
        /// </summary>
        public string message { get; set; }
        /// <summary>
        /// 返回数据
        /// </summary>
        public object data { get; set; }
        public AjaxResult SetMsg(string msg)
        {
            message = msg;
            return this;
        }

    }
    /// <summary>
    /// 表示 ajax 操作结果类型的枚举
    /// </summary>
    public enum ResultType
    {
        /// <summary>
        /// 消息结果类型
        /// </summary>
        info,
        /// <summary>
        /// 成功结果类型
        /// </summary>
        success,
        /// <summary>
        /// 警告结果类型
        /// </summary>
        warning,
        /// <summary>
        /// 异常结果类型
        /// </summary>
        error
    }
}

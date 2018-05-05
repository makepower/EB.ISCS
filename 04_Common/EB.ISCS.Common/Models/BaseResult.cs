namespace EB.ISCS.Common.Models
{
    public class BaseResult
    {
        /// <summary>
        /// 执行代码
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// 执行消息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 执行结果数据
        /// </summary>
        public dynamic Data { get; set; }
    }

    public class BaseResult<T>
    {
        /// <summary>
        /// 执行代码
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// 执行消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 执行结果数据
        /// </summary>
        public T Data { get; set; }
    }
}
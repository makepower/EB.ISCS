namespace EB.ISCS.FrameworkEntity.SystemEntity
{
    /// <summary>
    /// 用户会话词典
    /// </summary>
    public class SysUserSession
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Name { get; set; }

        public string Val { get; set; }
    }
}

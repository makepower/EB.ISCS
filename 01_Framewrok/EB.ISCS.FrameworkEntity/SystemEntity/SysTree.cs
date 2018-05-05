using System;
using System.Collections.Generic;
using Dapper;

namespace EB.ISCS.FrameworkEntity.SystemEntity
{
    [Table("SysTree")]
    public partial class SysTree
    {
        /// <summary>
        /// 自增主键
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 节点Id 与具体业务关联
        /// </summary>
        public int BizId { get; set; }
        /// <summary>
        /// 节点名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 父节点Id 
        /// </summary>
        public int ParentId { get; set; }
        /// <summary>
        /// 节点Level内部排序号 从1开始
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// 节点深度 从1开始
        /// </summary>
        public int Level { get; set; }
        /// <summary>
        /// 节点状态 跟具体的业务状态相关联
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 是否可用
        /// </summary>
        public int Enabled { get; set; }
        /// <summary>
        /// 模块标识,一般存储表名 eg：Department,SysUser,SysMenu... 
        /// </summary>
        public string ModuleTag { get; set; }
        /// <summary>
        /// 节点路径
        /// </summary>
        public string TreePath { get; set; }
        /// <summary>
        /// 备注 eg：节点的描述信息....
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 扩展属性 
        /// </summary>
        public string Attribute { get; set; }
        /// <summary>
        /// 删除标记
        /// </summary>
        public int DelState { get; set; }
        /// <summary>
        /// 编辑时间
        /// </summary>
        public Nullable<DateTime> EditDate { get; set; }

        #region 扩展属性
        /// <summary>
        /// 目标Id
        /// </summary>
        [NotMapped]
        public int TargetId { get; set; }

        /// <summary>
        /// 位置
        /// </summary>
        [NotMapped]
        public string Point { get; set; }

        /// <summary>
        /// 子集
        /// </summary>
        [NotMapped]
        public List<SysTree> children { get; set; }
        /// <summary>
        /// 父标签名称
        /// </summary>
        [NotMapped]
        public string ParentName { get; set; }

        /// <summary>
        /// 修改时间格式化
        /// </summary>
        [NotMapped]
        public string EditDateName
        {
            get
            {
                return EditDate.HasValue ? EditDate.Value.ToString("yyyy-MM-dd HH:mm:ss") : "";
            }
        }


        public override int GetHashCode()
        {
            return this.Id;
        }

        public override bool Equals(object obj)
        {
            var o = obj as SysTree;
            if (o == null)
                return false;
            if (o.Id == this.Id)
                return true;
            return false;
        }

       
        #endregion
    }

    /// <summary>
    /// 节点状态枚举
    /// </summary>
    public enum EmTreeNodeStatus
    {
        正常 = 0,
        禁止删除,
        禁止上移,
        禁止下移,
        禁止上方添加,
        禁止下方添加,
        禁止添加子集,
        禁止修改名称,
        禁止拖动,
        禁止修改,
        禁止左移,
        禁止右移
    }


    public enum TreeNodeAction
    {
        Append = 0,
        Append_Top,
        Append_Bottom,
        Update,
        Delete
    }
}

using System;
using System.Collections.Generic;
using Dapper;

namespace EB.ISCS.FrameworkEntity.SystemEntity
{
    [Table("SysMenu")]
    public partial class SysMenu
    {
        [Key]
        public int Id { get; set; }

        public string MenuName { get; set; }

        public int? MenuState { get; set; }

        public int FatherId { get; set; }

        public string PageUrl { get; set; }

        public string MenuControllerKey { get; set; }

        public string MenuActionKey { get; set; }

        public string MenuDescription { get; set; }

        public int? MenuSort { get; set; }

        public int? IsShow { get; set; }

        public string PictureUrl { get; set; }

        public int? NoteLevel { get; set; }

        public int? MenuIsEvent { get; set; }

        public string IconCSS { get; set; }

        public int? InUser { get; set; }

        public DateTime? InDate { get; set; }

        public int? EditUser { get; set; }

        public DateTime? EditDate { get; set; }

        public int? DelUser { get; set; }

        public int? DelState { get; set; }

        public DateTime? DelDate { get; set; }


        #region 扩展属性

        /// <summary>
        /// 标识该行数据是否是菜单，0 功能操作，1 是菜单
        /// 由于 Dapper 不支持表中不存在的字段，所以这里使用 IsOperatingMenu 来存放是否是菜单的 IsMenu 的值
        /// 已删除，等待删除
        /// </summary>
        [NotMapped]
        public int? IsMenu { get { return 0; } set { } }

        /// <summary>
        /// 标识该行权限是否被选中 0未选中（或空心选中），已选中
        /// 由于 Dapper 不支持表中不存在的字段，所以这里使用 MenuIsEvent 来存放 表示是否已选中的 Checked 的值
        /// </summary>
        [NotMapped]
        public int? Checked { get { return MenuIsEvent; } set { } }

        /// <summary>
        /// 操作类型： edit:编辑，add:新增
        /// </summary>
        [NotMapped]
        public string ActionType { get; set; }

        /// <summary>
        /// 子集
        /// </summary>
        [NotMapped]
        public List<SysMenu> children { get; set; }

        #endregion
    }
    /// <summary>
    /// 功能模块菜单树
    /// </summary>
    public class MenuTree
    {
        /// <summary>
        /// 编号
        /// </summary>
        public int id { get; set; }

        //显示名称
        public string text { get; set; }

        /// <summary>
        /// 子集
        /// </summary>
        public List<MenuTree> children { get; set; }

        /// <summary>
        /// 自定义属性
        /// </summary>
        public object attributes { get; set; }

        //显示名称
        public int isFreeze { get; set; }

        /// <summary>
        /// 是否被勾选
        /// </summary>
        public bool @checked { get; set; }

    }

    public class MenuAllTree
    {
        /// <summary>
        /// menu Id or action Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// menu Name or action Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// menu FatherId or menu action FatherId
        /// </summary>
        public int FId { get; set; }

        /// <summary>
        /// 类型标记 1 ：menu，0：action
        /// </summary>
        public int IsMenu { get; set; }

        /// <summary>
        /// 是否被勾选
        /// </summary>
        public int CheckState { get; set; }

        /// <summary>
        /// 子集
        /// </summary>
        public List<MenuAllTree> Children { get; set; }
    }
}

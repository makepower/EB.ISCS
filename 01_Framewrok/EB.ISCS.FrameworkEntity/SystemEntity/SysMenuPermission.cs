using System;
using Dapper;

namespace EB.ISCS.FrameworkEntity.SystemEntity
{
    public partial class SysMenuPermission
    {
        public int Id { get; set; }
        public Nullable<int> MenuId { get; set; }
        public string ActionName { get; set; }
        public string ActionKey { get; set; }
        public string ControllerKey { get; set; }
        public string ActionType { get; set; }
        public string Description { get; set; }
        public string ActionCode { get; set; }
        public Nullable<int> ActionSort { get; set; }
        public Nullable<int> InUser { get; set; }
        public Nullable<System.DateTime> InDate { get; set; }
        public Nullable<int> EditUser { get; set; }
        public Nullable<System.DateTime> EditDate { get; set; }
        public Nullable<int> DelUser { get; set; }
        public Nullable<int> DelState { get; set; }
        public Nullable<System.DateTime> DelDate { get; set; }

        [NotMapped]
        public string MenuName { get; set; }
        [NotMapped]
        public int? FatherId { get; set; }
        [NotMapped]
        public string MenuControllerKey { get; set; }
        [NotMapped]
        public int? MenuSort { get; set; }
        [NotMapped]
        public int IsMenu { get; set; }
        [NotMapped]
        public string InUserName { get; set; }
        [NotMapped]
        public string EditUserName { get; set; }
        [NotMapped]
        public string InDateString => InDate?.ToString("yyyy-MM-dd hh:mm:ss");
        [NotMapped]
        public string EditDateString => EditDate?.ToString("yyyy-MM-dd hh:mm:ss");
    }
}

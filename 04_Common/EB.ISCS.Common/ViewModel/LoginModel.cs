using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EB.ISCS.Common.DataModel;

namespace EB.ISCS.Common.ViewModel
{
    public class LoginModel : BaseModel
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [Required]
        public string LoginName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required]
        public string Password { get; set; }
        /// <summary>
        /// 记住我
        /// </summary>
        public bool RememberMe { get; set; }

        public bool UserIsManage { get; set; }

        public bool IsRoot { get; set; }
    }
}

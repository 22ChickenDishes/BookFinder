using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookFinder.Models
{
    [Table("User")]
    public class User
    {
        [Column("Nmae")]
        /// <summary>
        /// 名字
        /// </summary>
        public string Nmae { get; set; }

        [Column("AccountNumber"),Key]
        /// <summary>
        /// 账号
        /// </summary>
        public string AccountNumber { get; set; }
        [Column("Password")]
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        [Column("Balance")]
        /// <summary>
        /// 余额
        /// </summary>
        public double Balance { get; set; }
        [Column("IsMember")]
        /// <summary>
        /// 是否为会员
        /// </summary>
        public bool IsMember { get; set; }
        [Column("PersonalScore")]
        /// <summary>
        /// 个人积分
        /// </summary>
        public int PersonalScore { get; set; }
        [Column("ReadabilityNumber")]
        /// <summary>
        /// 可免费试读数
        /// </summary>
        public int ReadabilityNumber { get; set; }
        [Column("Email")]
        /// <summary>
        /// 电子邮箱
        /// </summary>
        public string Email { get; set; }
        [Column("UserHeadPicture")]
        /// <summary>
        /// 用户头像
        /// </summary>
        public string UserHeadPicture { get; set; }
    }
}

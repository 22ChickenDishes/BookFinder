using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookFinder.Models
{
    [Table("OrderSheet")]
    public class OrderSheet
    {
        [Column("BookName")]
        /// <summary>
        /// 书名字
        /// </summary>
        public string BookName { get; set; }
        [Column("Pay",TypeName ="float")]
        /// <summary>
        /// 支付价格
        /// </summary>
        public float Pay { get; set; }

        [Column("Classification")]
        /// <summary>
        /// 分类
        /// </summary>
        public string Classification { get; set; }
        [Column("BookID")]
        /// <summary>
        /// 书本编号
        /// </summary>
        public string BookID { get; set; }

        [Column("PurchaseTime", TypeName = "DateTiem")]
        /// <summary>
        /// 购买时间
        /// </summary>
        public DateTime PurchaseTime { get; set; }

        [Column("UserAccount"), Key]
        /// <summary>
        /// 用户账号
        /// </summary>
        public string OrderSheetUserAccount { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookFinder.Models
{
    [Table("BorrowingSheet")]
    public class BorrowingSheet
    {
        [Column("BookName")]
        /// <summary>
        /// 书名字
        /// </summary>
        public string BookName { get; set; }
        [Column("Pay",TypeName ="float")]
        /// <summary>
        /// 价格
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

        [Column("BorrowingTime", TypeName = "DateTiem")]
        /// <summary>
        /// 借书开始时间
        /// </summary>
        public DateTime BorrowingTime { get; set; }

        [Column("EndOfBorrowingTime", TypeName = "DateTiem")]
        /// <summary>
        /// 借书结束时间
        /// </summary>
        public DateTime EndOfBorrowingTime { get; set; }

        [Column("UserAccount"),Key]
        /// <summary>
        /// 用户账号
        /// </summary>
        public string BorrowingSheetUserAccount { get; set; }
    }
}

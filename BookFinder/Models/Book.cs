using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
    [Table("Book2s")]
    public class Book
    {
       
        [Column("BookNmae")]
        /// <summary>
        /// 书本名字
        /// </summary>
        public string BookNmae { get; set; }
        
        [Column("ID"), Key]
        /// <summary>
        /// 书本编号
        /// </summary>
        public string ID { get; set; }
       
        [Column("BookWrter")]
        /// <summary>
        /// 作者
        /// </summary>
        public string BookWrter { get; set; }
        
        [Column("Title")]
        /// <summary>
        /// 书籍介绍
        /// </summary>
        public string Title { get; set; }
       
        [Column("NumberOfLoans")]
        /// <summary>
        /// 借阅数
        /// </summary>
        public int NumberOfLoans { get; set; }
       
        [Column("PurchaseNumber")]
        /// <summary>
        /// 购买数
        /// </summary>
        public int PurchaseNumber { get; set; }
       
        [Column("Inventory")]
        /// <summary>
        /// 库存
        /// </summary>
        public int Inventory { get; set; }
        
        [Column("Price",TypeName ="float")]
        /// <summary>
        /// 价格
        /// </summary>
        public float Price { get; set; }
       
        [Column("Classification")]
        /// <summary>
        /// 分类
        /// </summary>
        public string Classification { get; set; }

       
        [Column("TimeOfPublication", TypeName = "DateTiem")]
        /// <summary>
        /// 出版时间
        /// </summary>
        public DateTime TimeOfPublication { get; set; }

        //[NotMapped]
        ///// <summary>
        ///// 图书封面
        ///// </summary>
        //public Image BookCover { get; set; }
      
        [Column("BookCover2")]
        /// <summary>
        /// 图书封面
        /// </summary>
        public string BookCover2 { get; set; }
    }
}

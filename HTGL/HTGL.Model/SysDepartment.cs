using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using HTGL.Component.Tools;

namespace HTGL.Model
{
    public partial class SysDepartment : EntityBase<int>
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DeptId { get; set; }
        public string DeptName { get; set; }
        public string DeptDesc { get; set; }
        public int? ParentId { get; set; }
        public int? AddUserId { get; set; }
        public DateTime? AddDate { get; set; }
        public bool? IsVisible { get; set; }
    }
}

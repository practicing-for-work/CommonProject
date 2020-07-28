using System;
using System.Collections.Generic;
using System.Text;

namespace Practicing_For_Work.Application.Contracts.Model
{
    public class Member
    {
        public Guid MemberSeq { get; set; }
        public int Num { get; set; }
        public string Account { get; set; }
        public bool IsOpen { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Birthday { get; set; }
        public string Sex { get; set; }
        public string County { get; set; }
        public string Township { get; set; }
        public string Address { get; set; }
        public string Id { get; set; }
        public DateTime? OpenAccountTime { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediaTec.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMoths { get; set; }
        public byte DiscountRate { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class RemarkAttribute : Attribute
    {
        private string remark;
        public RemarkAttribute(string _remark)
        {
            remark = _remark;
        }
    }
}

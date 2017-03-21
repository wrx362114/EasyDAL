using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Database
{
    public static partial class DbFactory
    {
        private static TestDb1 _TestDb1;
        public static TestDb1 TestDb1
        {
            get { return _TestDb1 ?? (_TestDb1 = new TestDb1()); }
        }
    }
    public partial class TestDb1 : DbBase
    {
        protected override string DbName
        {
            get
            {
                return nameof(TestDb1);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class HasId
    {
        [ServiceStack.DataAnnotations.PrimaryKey]
        public virtual long Id { get; set; }
    }
}

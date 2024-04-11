using Core.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Model.Request
{
    public class TaskHistoryRequest : IModel
    {
        public int TaskId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime TaskDate { get; set; }
    }
}

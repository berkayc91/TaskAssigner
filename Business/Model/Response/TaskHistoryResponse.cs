using Core.Business.Abstract;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = Entity.Entities.Task;

namespace Business.Model.Response
{
    public class TaskHistoryResponse : IModel
    {
        public int TaskHistoryId { get; set; }       
        public DateTime TaskDate { get; set; }
        public TaskResponse Task { get;set; }
        public EmployeeResponse Employee { get;set; }
    }
}

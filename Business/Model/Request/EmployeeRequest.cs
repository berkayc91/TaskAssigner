using Core.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Model.Request
{
    public class EmployeeRequest : IModel
    {
        public int EmployeeId { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public int TotalScore { get; set; } = 0;
        public byte ActiveTaskId { get; set; }
    }
}

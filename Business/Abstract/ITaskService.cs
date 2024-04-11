using Business.Model.Response;
using Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITaskService
    {
        IDataResult<List<TaskResponse>> GetAll();
        IDataResult<TaskResponse> Get(int taskId);
    }
}

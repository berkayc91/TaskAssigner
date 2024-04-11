using Business.Model.Request;
using Business.Model.Response;
using Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITaskHistoryService
    {
        IDataResult<List<TaskHistoryResponse>> GetAll();
        IResult Add(List<TaskHistoryRequest> taskHistories);
        IDataResult<List<TaskHistoryResponse>> GetTodayTask();
    }
}

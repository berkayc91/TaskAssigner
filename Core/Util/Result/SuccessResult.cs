﻿using Core.Util.Enum;

namespace Core.Utils
{
    public class SuccessResult : Result
    {
        public SuccessResult(string message): base(ResultStatus.Success,message)
        {
                
        }

        public SuccessResult():base(ResultStatus.Success)
        {
                
        }
    }
}

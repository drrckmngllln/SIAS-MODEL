using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace school_management_system_model.Core.Helpers
{
    public class DataLoading
    {
        private readonly string _task;
        private readonly string _message;
        
        public DataLoading(string task, string message)
        {
            _message = message;
            _task = task;
        }

        
    }
}
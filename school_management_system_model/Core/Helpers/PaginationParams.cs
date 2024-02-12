using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_system_model.Classes.Parameters
{
    internal class PaginationParams
    {
        public int pageSize = 20;

        int _pageNumber = 1;
        public int pageNumber { get => _pageNumber; set => _pageNumber = value; }


    }
}

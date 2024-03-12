using DocumentFormat.OpenXml.Office2013.PowerPoint.Roaming;

namespace school_management_system_model.Classes.Parameters
{
    internal class PaginationParams
    {
        private int _pageSize = 30;
        public int PageSize 
        { 
            get => _pageSize; 
            set => _pageSize = value; 
        }

        int _pageNumber = 1;
        public int pageNumber { get => _pageNumber; set => _pageNumber = value; }
    }
}

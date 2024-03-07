namespace school_management_system_model.Infrastructure.Data.Parameters
{
    internal class StudentAccountsMainParameters
    {
        private int _pageSize = 20;
        public int PageNumber { get; set; }
        public int PageSize 
        { 
            get => _pageSize; 
            set => _pageSize = value; 
        }

        public int? course_id { get; set; }

        private string _search;
        public string Search 
        { 
            get => _search; 
            set => _search = value.ToLower(); 
        }
    }
}

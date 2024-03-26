namespace Core.Parameters.Settings
{
    public class CampusesParameters
    {
        private int _pageSize;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value;
        }

        private int _pageNumber;
        public int PageNumber 
        { 
            get => _pageNumber; 
            set => _pageNumber = value; 
        }

        private string _search;

        public string Search 
        { 
            get => _search; 
            set => _search = value.ToLower(); 
        }
    }
}

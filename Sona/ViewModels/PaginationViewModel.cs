using Sona.Models;

namespace Sona.ViewModels
{
    public class PaginationViewModel
    {
        public int CountPage { get; private set; }

        public List<News> ListNews { get; private set; }

        public PaginationViewModel(int countPage, List<News> listPresent)
        {
            CountPage = countPage;
            ListNews = listPresent;
        }
    }
}

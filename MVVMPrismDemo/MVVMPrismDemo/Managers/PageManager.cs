namespace MVVMPrismDemo.Managers
{
    public class PageManager
    {
        public static readonly string NavigationPage = "NavigationPage";
        public static readonly string HomePage = "HomePage";

        // Contacts pages
        public static readonly string PeopleListPage = "PeopleListPage";
        public static readonly string AddNewContactPage = "AddNewContactPage"; 
        public static readonly string DetailContactPage = "DetailContactPage";


        public static string MultiplePage(string[] pages)
        {
            string path = "";
            if (pages == null) return "";
            if (pages.Length < 1) return "";
            for (int i = 0; i < pages.Length; i++)
            {
                path += i == 0 ? pages[i] : "/" + pages[i];
            }
            return path;
        }
    }
}

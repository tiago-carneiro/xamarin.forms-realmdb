
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace forms_realmdb
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactListPage : ContentPage
    {
        public ContactListPage()
        {
            InitializeComponent();
            BindingContext = new ContactListViewModel();
        }
    }
}

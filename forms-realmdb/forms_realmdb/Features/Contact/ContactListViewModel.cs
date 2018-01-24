using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace forms_realmdb
{
    public class ContactListViewModel : BaseViewModel
    {
        readonly IAlertService _alertService;

        public ICommand SaveCommand { get => new Command(ExecuteSaveCommand); }
        public ICommand DeleteCommand { get => new Command(ExecuteDeleteCommand); }
        public ICommand ItemClickCommand { get => new Command<Contact>(ExecuteItemClickCommand); }

        private Contact _currentItem;
        public Contact CurrentItem
        {
            get => _currentItem;
            set => SetProperty(ref _currentItem, value);
        }

        private bool _canDelete;
        public bool CanDelete
        {
            get => _canDelete;
            set => SetProperty(ref _canDelete, value);
        }

        ObservableCollection<Contact> _items = new ObservableCollection<Contact>();
        public ObservableCollection<Contact> Items
        {
            get => _items;
            set => SetProperty(ref _items, value);
        }

        public ContactListViewModel() : base("Contatos")
        {
            _alertService = DependencyService.Get<IAlertService>();
            LoadItems();
        }

        void LoadItems()
        {
            CurrentItem = new Contact();
            CanDelete = false;
            Items.Clear();
            Items.AddRange(RealmInstance.All<Contact>());
        }

        async void ExecuteSaveCommand()
        {
            if (string.IsNullOrEmpty(CurrentItem.Name) || string.IsNullOrEmpty(CurrentItem.LastName))
            {
                await _alertService.Display("Dados Inválidos", "Todos os campos devem ser preenchidos.", "Voltar");
                return;
            }

            RealmInstance.Write(() =>
            {
                RealmInstance.Add(CurrentItem, true);
            });

            LoadItems();
        }

        async void ExecuteDeleteCommand()
        {
            var resultado = await _alertService.Display("Atenção", "Deseja realmente excluir", "Sim", "Não");

            if (resultado)
            {
                RealmInstance.Write(() =>
                {
                    RealmInstance.Remove(CurrentItem);
                });

                LoadItems();
            }
        }

        void ExecuteItemClickCommand(Contact item)
        {
            CurrentItem = item;
            CanDelete = true;
        }
    }
}

using Realms;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace forms_realmdb
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        private string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void SetProperty<TValue>(ref TValue prop, TValue value, [CallerMemberName] String propertyName = "")
        {
            prop = value;
            RaisePropertyChanged(propertyName);
        }

        protected void RaisePropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


        private Realm _realmInstance;
        protected Realm RealmInstance => 
            _realmInstance ?? (_realmInstance = Realm.GetInstance(Configuration.GetRealmConfiguration()));

        public BaseViewModel(string title) => Title = title;
    }
}

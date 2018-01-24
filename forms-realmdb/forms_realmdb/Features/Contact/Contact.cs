using Realms;
using System;

namespace forms_realmdb
{
    public class Contact : RealmObject
    {
        [PrimaryKey]
        public string Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        [Ignored]
        public string FullName => $"{Name} {LastName}";
        public Contact() => Id = Guid.NewGuid().ToString();
    }
}

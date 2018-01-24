using Realms;

namespace forms_realmdb
{
    public static class Configuration
    {
        public static ulong SchemaVersion = 0;
        public static RealmConfiguration GetRealmConfiguration()
        {
            var config = new RealmConfiguration { SchemaVersion = SchemaVersion };
            //config.MigrationCallback = (migration, oldSchemaVersion) =>
            //{
            //    if (oldSchemaVersion < SchemaVersion)
            //    {
            //        if (oldSchemaVersion < 1)
            //        {
            //            var newObj = migration.NewRealm.All<Class>();

            //            // Use the dynamic api for oldPeople so we can access
            //            // .FirstName and .LastName even though they no longer
            //            // exist in the class definition.
            //            var oldObj = migration.OldRealm.All("className");

            //            for (var i = 0; i < newObj.Count(); i++)
            //            {
            //                var old = oldObj.ElementAt(i);
            //                var new = newObj.ElementAt(i);
                            
            //            }
            //        }
            //    }

            //};
            config.ObjectClasses = new[] { typeof(Contact) };
            return config;
        }
    }
}

using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteCostProApp.Classes
{
    [FirestoreData]
    internal class UserData
    {
        [FirestoreProperty]
        public string email { get; set; }

        [FirestoreProperty]
        public string password { get; set; }
    }
}

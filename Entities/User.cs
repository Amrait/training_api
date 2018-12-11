using System;
using TrainingApi.Utilities;

namespace TrainingApi.Entities
{
    public class User
    {
        public Guid _id;
        public string _userName;
        public string _password {
            internal set {
                _password = AesCrypto.Encrypt(value);
            }
            get {
                return _password;
            } 
        }
        public User()
        {
            this._id = Guid.NewGuid();
        }
        public User(string name, string password) : this()
        {
            this._userName = name;
            this._password = password;
        }

        // Kinda poor decision on decryption. Ideally some sort of check should be done to ensure that
        // this user has the rights to see decrypted passwords.
        // But if memory serves NOBODY except the end user should now the true password.
        // Needs clarification
        public void DisplayUserInfo(User user, bool truePassword = false)
        {
            string passwordToDisplay = truePassword ? AesCrypto.Decrypt(user._password) : user._password;
            Console.WriteLine($"User name - {user._userName}, user password - {passwordToDisplay}");
        }
    }
}

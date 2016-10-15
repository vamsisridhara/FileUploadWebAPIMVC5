using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileUploadWebAPIMVC5
{
    public sealed class AccountRepository: IAccountRepository
    {
        private readonly List<UserAccount> _account;
        private int _nextId;

        public AccountRepository()
        {
            _account = new List<UserAccount>();
            _nextId = 1;

            Add(new UserAccount { Name = "test guy", Address = "20 Glover Avenue", Email = "test@napower.com", Postal = "06850" });
            Add(new UserAccount { Name = "John Doe", Address = "243 America Avenue", Email = "test@test.com", Postal = "07719" });
            Add(new UserAccount { Name = "Jane Doe", Address = "123 USA Avenue", Email = "test2@test.com", Postal = "06890" });
        }

        public IEnumerable<UserAccount> GetAll()
        {
            return _account;
        }

        public UserAccount GetUserAccount(int id)
        {
            return _account.FirstOrDefault(p => p.Id == id);
        }

        public UserAccount Add(UserAccount item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            item.Id = _nextId++;
            _account.Add(item);
            return item;
        }

        public void Remove(int id)
        {
            _account.RemoveAll(p => p.Id == id);
        }

        public bool Update(UserAccount item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            var index = _account.FindIndex(p => p.Id == item.Id);
            if (index == -1)
            {
                return false;
            }
            _account.RemoveAt(index);
            _account.Add(item);

            return true;
        }
    }
}

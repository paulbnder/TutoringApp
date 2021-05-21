using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TutoringAppWebAPI.Interfaces
{
    public interface IRepository<T>
    {
        Task<bool> AddItemAsync(T item);
        Task<bool> UpdateItemAsync(T item);
        void DeleteItemAsync(string id);
        Task<T> GetItemAsync(string id);
        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
        List<T> GetItems(bool forceRefresh = false);

        Task<bool> DoesTeacherExist(string id);
    }
}

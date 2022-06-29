using ItCrowdChallenge.Datacontext;
using ItCrowdChallenge.Model;

namespace ItCrowdChallenge.Services
{
    public interface IService<T,K>
    {     
        T Get(K key);
        void Delete(K key);
        List<T> GetAll();
        void Save(T value);
        void Create(T value);
    }
}

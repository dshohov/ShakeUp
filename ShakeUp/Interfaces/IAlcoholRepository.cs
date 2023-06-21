using ShakeUp.Models;

namespace ShakeUp.Interfaces
{
    public interface IAlcoholRepository
    {
        public bool Add(Alcohol alcohol);
        public bool Update(Alcohol alcohol);
        public bool Delete(Alcohol alcohol);
        public bool Save();

    }
}

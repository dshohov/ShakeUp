using ShakeUp.Data.Enum;
using ShakeUp.Models;

namespace ShakeUp.Interfaces
{
    public interface IAlcoholRepository
    {
        public IEnumerable<Alcohol> GetAllAlcohols();
        public bool Add(Alcohol alcohol);
        public bool Update(Alcohol alcohol);
        public bool Delete(Alcohol alcohol);
        public bool Save();
        public IEnumerable<Alcohol> SortNameAtoZ();
        public IEnumerable<Alcohol> SortNameZtoA();
        public DrinkStrength ChooseStrength(double degree);
    }
}

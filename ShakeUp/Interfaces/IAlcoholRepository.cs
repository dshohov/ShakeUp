using ShakeUp.Data.Enum;
using ShakeUp.Models;

namespace ShakeUp.Interfaces
{
    public interface IAlcoholRepository
    {
        //Base
        public IEnumerable<Alcohol> GetAllAlcohols();
        public Alcohol GetAlcoholById(int id);
        public bool Add(Alcohol alcohol);
        public bool Update(Alcohol alcohol);
        public bool Delete(Alcohol alcohol);
        public bool Save();
        //Filters
        public IQueryable<Alcohol> FilterType(int drinkStrength);
        //Other
        public DrinkStrength ChooseStrength(double degree);
        
    }
}

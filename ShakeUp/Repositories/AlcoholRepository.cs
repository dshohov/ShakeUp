using ShakeUp.Data;
using ShakeUp.Data.Enum;
using ShakeUp.Interfaces;
using ShakeUp.Models;

namespace ShakeUp.Repositories
{
    public class AlcoholRepository : IAlcoholRepository
    {
        private readonly ApplicationDbContext _context;
        public AlcoholRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Alcohol alcohol)
        {
            _context.Add(alcohol);
            return Save();
        }

        public bool Delete(Alcohol alcohol)
        {
            _context.Remove(alcohol);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Alcohol alcohol)
        {
            _context.Update(alcohol);
            return Save();
        }
        

        public IEnumerable<Alcohol> GetAllAlcohols() => _context.Alcohols.ToList();
        public Alcohol GetAlcoholById(int id) => _context.Alcohols.FirstOrDefault(item => item.Id == id);

        //Filter
        public IQueryable<Alcohol> FilterType(int drinkStrength) => _context.Alcohols.Where(item => (int)item.Type == drinkStrength);
        //Other
        public DrinkStrength ChooseStrength(double degree) => degree <= 10 ? DrinkStrength.Weak : degree <= 20 ? DrinkStrength.Medium : DrinkStrength.Strong;

        
    }
}

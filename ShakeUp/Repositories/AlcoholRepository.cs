using ShakeUp.Data;
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
    }
}

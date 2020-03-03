using Model;
using Model.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repositories
{
    public class ViewingRepository : IViewingRepository
    {
        public readonly MovieDbContext _context;

        public ViewingRepository(MovieDbContext context)
        {
            this._context = context;
        }
        public List<Viewing> GetAllViewing()
        {
            return _context.Viewings.ToList();
        }

        public Viewing Add(Viewing viewing)
        {
            _context.Viewings.Add(viewing);
            _context.SaveChanges();
            return viewing;
        }

        public bool Delete(int id)
        {
            _context.Viewings.Remove(_context.Viewings.Find(id));
            _context.SaveChanges();
            return true;
        }

        public Viewing Update(int id, Viewing viewing)
        {
            Viewing toUpdate = GetAllViewing().Find(x => x.ViewingId == id);
            toUpdate.UserId = id; //??
            _context.Entry(toUpdate).CurrentValues.SetValues(viewing);
            _context.SaveChanges();
            return toUpdate;
        }

        public Viewing GetById(int id)
        {
            Viewing viewing = GetAllViewing().Find(x => x.ViewingId == id);
            return viewing;
        }
    }
}

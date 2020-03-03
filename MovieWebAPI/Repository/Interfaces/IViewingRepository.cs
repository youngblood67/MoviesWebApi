using Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interfaces
{
    public interface IViewingRepository
    {
        List<Viewing> GetAllViewing();
        Viewing Add(Viewing viewing);
        bool Delete(int id);
        Viewing Update(int id, Viewing viewing);
        Viewing GetById(int id);
    }
}

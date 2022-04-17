using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public interface IRepositoryWord
    {
        void Add(Word word);
        void Delete(Word word);
        void Delete(int id);
        List<Word> List();
        void SaveChanges();
    }
}

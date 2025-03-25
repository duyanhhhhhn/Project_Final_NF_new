using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_Final_NF.Models.ModelViews;

namespace Project_Final_NF.Models.Reponsitories
{
    internal interface IRepository<T> where T : class
    {
        void Create(T entity);
        int Update(T entity);
        int Delete(T entity);
        HashSet<T> All();
        HashSet<T> findAll();
        UserView findById(int id);
        HashSet<T> FindByKeyword(string keyword);
    }
}

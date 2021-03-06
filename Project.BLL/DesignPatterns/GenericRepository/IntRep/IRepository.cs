using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DesignPatterns.GenericRepository.IntRep
{
    public interface IRepository<T> where T:BaseEntity
    {


        //List Commands
        List<T> GetAll(); //Tüm verileri listele
        List<T> GetActives(); //Aktif verileri listele
        List<T> GetPassives(); //Pasif verileri listele
        List<T> GetModifieds(); //Güncellenmiş verileri listele

        //Modify Commands
        void Add(T item); //Veri ekleme
        void AddRange(List<T> item); //Çoklu veri ekleme
        void Delete(T item); //Veri pasife çekme
        void DeleteRange(List<T> item); //Çoklu veri pasife çekme
        void Update(T item); //Veri güncelleme
        void UpdateRange(List<T> item); //Çoklu veri güncelleme
        void Destroy(T item); //Veri silme (yok etme)
        void DestroyRange(List<T> item); //Çoklu veri silme

        //Linq Expressions
        List<T> Where(Expression<Func<T, bool>> exp);
        bool Any(Expression<Func<T, bool>> exp);
        T FirstOrDefault(Expression<Func<T, bool>> exp);
        object Select(Expression<Func<T, object>> exp);

        //Find
        T Find(int id);
        T FindFirstData(); //İlk veriyi yakala
        T FindLastData(); //Son veriyi yakala


    }
}

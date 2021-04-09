using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
   public class EfEntityRepositoryBase<TEntity,TContext>:IEntitiyRepository<TEntity> where TEntity:class,IEntitiy,new() where TContext :DbContext,new()
    {


        public void Add(TEntity entity)
        {//IDisposable pattern implementation of c#
            using (TContext context = new TContext())//BELLEKTEN İŞİ BİTİNCE ATILMASI İÇİN
            {
                var addedEntitiy = context.Entry(entity);
                addedEntitiy.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())//BELLEKTEN İŞİ BİTİNCE ATILMASI İÇİN
            {
                var deletedEntitiy = context.Entry(entity);
                deletedEntitiy.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();//turnary filtre null ise tümünü getirir değilse FİLTRE OLARAK VER //Arka planda select * from pruduct yapar

            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())//BELLEKTEN İŞİ BİTİNCE ATILMASI İÇİN
            {
                var updatedEntitiy = context.Entry(entity);
                updatedEntitiy.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

    }
}

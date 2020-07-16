using System;
using System.Collections.Generic;

using System.Linq;
using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore;

namespace Demokratianweb.Data.Infraestructure
{
    public class Repository<T, TContext> : IRepository<T> where T : BaseEntity where TContext : DbContext
    {
        private readonly TContext context;

        public Repository(TContext context)
        {
            this.context = context;
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            var query = context.Set<T>().Where(predicate);
            return query;
        }

        public IQueryable<T> GetAll()
        {
            return context.Set<T>().Where(i => i.fechaEliminacion == null); ;
        }

        public bool Insert(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                entity.fechaCreacion = DateTime.Now;
                entity.fechaEliminacion = null;
                entity.fechaEdicion = DateTime.Now;
                

                context.Add(entity);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                entity.fechaEdicion = DateTime.Now;
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool Update(object id, T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                entity.fechaEdicion = DateTime.Now;

                var original = context.Set<T>().Find(id);
                var CreateDate = original.fechaCreacion;
                var EraseDate = original.fechaEliminacion;

                if (original != null)
                {
                    context.Entry(original).CurrentValues.SetValues(entity);

                    original.fechaEliminacion = EraseDate;
                    original.fechaCreacion = CreateDate;

                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public bool DeleteEntity(T entity)
        {
            try
            {
                if (entity == null) return false;

                context.Entry(entity).State = EntityState.Deleted;
                context.SaveChanges();
                return true;
            }

            catch (Exception ex)
            {
                throw;
            }
        }

        public T Get(object id)
        {
            var entity = context.Set<T>().Find(id);

            return entity == null || (entity.fechaEliminacion != null) ? null : entity;
        }

        public IQueryable<T> Table => context.Set<T>();

        public bool Delete(object id)
        {
            try
            {
                var entity = Get(id);
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }


                entity.fechaEliminacion = DateTime.Now;
                this.context.Entry(entity).State = EntityState.Modified;
                this.context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool SaveAll(List<T> list)
        {
            try
            {
                list.ForEach(i => i.fechaCreacion = DateTime.Now);
                context.Set<T>().AddRange(list);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool UpdateAll(List<T> list)
        {
            try
            {
                list.ForEach(entity =>
                {
                    entity.fechaEdicion = DateTime.Now;
                    context.Entry(entity).State = EntityState.Modified;
                });

                context.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }


}

using System;
using System.Linq;
using System.Linq.Expressions;
using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext RepositoryContext { get; set; }

        public RepositoryBase(RepositoryContext repositoryContext)
        {
            this.RepositoryContext = repositoryContext;
        }

        /// <summary>
        /// Returns a set containing all objects in the database
        /// </summary>
        /// <returns>Returns a set containing all objects in the database</returns>
        public IQueryable<T> FindAll()
        {
            return this.RepositoryContext.Set<T>().AsNoTracking();
        }

        /// <summary>
        /// Returns a set containing all objects that match the criteria defined in the expression
        /// </summary>
        /// <param name="expression">Filter criteria</param>
        /// <returns>Returns a set containing all objects that match the criteria defined in the expression</returns>
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.RepositoryContext.Set<T>().Where(expression).AsNoTracking();
        }

        /// <summary>
        /// Adds a new database entry 
        /// </summary>
        /// <param name="entity">entry to be added to the database</param>
        public void Create(T entity)
        {
            this.RepositoryContext.Set<T>().Add(entity);
        }

        /// <summary>
        /// Updates an existing database entry
        /// </summary>
        /// <param name="entity">entry to be updated</param>
        public void Update(T entity)
        {
            this.RepositoryContext.Set<T>().Update(entity);
        }

        /// <summary>
        /// Deletes a database entry
        /// </summary>
        /// <param name="entity">entry to be deleted</param>
        public void Delete(T entity)
        {
            this.RepositoryContext.Set<T>().Remove(entity);
        }
    }
}
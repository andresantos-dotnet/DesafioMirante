using Domain.Entities;
using Domain.Interfaces.Repository;
using Infra.ORM.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {

        protected readonly DataBaseContext _context;

        private DbSet<T> _dataset;
        public BaseRepository(DataBaseContext context)
        {
            _context = context;
            _dataset = _context.Set<T>();
        }

        public async Task<T> CreateAsync(T entity)
        {
            try
            {
                entity.CreateDate = DateTime.Now;
                entity.Active = true;
                _dataset.Add(entity);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex) { throw ex; }

            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {

                var result = await _dataset.SingleOrDefaultAsync(n => n.Id.Equals(id) && n.Active);
                if (result == null) return false;

                result.UpdateDate = DateTime.Now;
                result.Active = false;

                await _context.SaveChangesAsync();
                return true;

            }
            catch (Exception ex) { throw ex; }

        }

        public async Task<bool> ExistAsync(int id)
        {
            try
            {
                return await _dataset.AnyAsync(n => n.Id.Equals(id) && n.Active);

            }
            catch (Exception ex) { throw ex; }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return await _dataset.ToListAsync();
            }
            catch (Exception ex) { throw ex; }

        }

        public async Task<T> GetByIdAsync(int id)
        {
            try
            {
                return await _dataset.SingleOrDefaultAsync(n => n.Id.Equals(id) && n.Active);
            }
            catch (Exception ex) { throw ex; }

        }

        public async Task<T> UpdateAsync(T entity)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(n => n.Id.Equals(entity.Id) && n.Active);
                if (result == null) return null;

                entity.UpdateDate = DateTime.Now;
                entity.CreateDate = result.CreateDate;

                _context.Entry(result).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex) { throw ex; }

            return entity;
        }

    }
}

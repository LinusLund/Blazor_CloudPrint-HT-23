namespace API_CloudPrint_HT_23.Helpers.Repositories
{
    public abstract class Repo<TEntity> where TEntity : class
    {
        private readonly PrintContext _context;

        protected Repo(PrintContext context)
        {
            _context = context;
        }




        #region Create
        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        #endregion



        #region Get specific
        public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
        {
            var item = await _context.Set<TEntity>().FirstOrDefaultAsync(expression);
            return item!;

        }
        #endregion

        #region Get all

        //Hämtar alla 
        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            try
            {
                var items = await _context.Set<TEntity>().ToListAsync();
                return items!;
            }
            catch { return null!; }

        }

        #endregion

        #region Delete
        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
        }
        #endregion

        #region Update
        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        #endregion
    }
}

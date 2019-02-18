namespace DomainServices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    /// In-memory fake repository to be used in unit testing.
    /// </summary>
    /// <typeparam name="TEntity">The entity type.</typeparam>
    /// <typeparam name="TId">The entity ID type.</typeparam>
    public class FakeRepository<TEntity, TId> : IRepository<TEntity, TId> where TEntity : IEntity<TId>
    {
        private readonly Dictionary<TId, TEntity> _entities;

        /// <summary>
        /// Initializes a new instance of the <see cref="FakeRepository{TEntity, TId}"/> class.
        /// </summary>
        public FakeRepository()
        {
            _entities = new Dictionary<TId, TEntity>();
        }

        /// <summary>
        /// Gets the number of entities in the repository.
        /// </summary>
        /// <value>The total number of entities.</value>
        public int Count
        {
            get
            {
                return _entities.Count;
            }
        }

        /// <summary>
        /// Gets the entities.
        /// </summary>
        /// <value>The entities.</value>
        protected Dictionary<TId, TEntity> Entities
        {
            get
            {
                return _entities;
            }
        }

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Add(TEntity entity)
        {
            _entities[entity.Id] = entity;
        }

        /// <summary>
        /// Determines whether the repository contains an entity with the specified id.
        /// </summary>
        /// <param name="id">The entity id.</param>
        /// <returns><c>true</c> if the repository contains an entity with the specified id; otherwise, <c>false</c>.</returns>
        public bool Contains(TId id)
        {
            return _entities.ContainsKey(id);
        }

        /// <summary>
        /// Gets the entity with the specified id.
        /// </summary>
        /// <param name="id">The entity id.</param>
        /// <returns>The entity.</returns>
        public TEntity Get(TId id)
        {
            TEntity entity;
            _entities.TryGetValue(id, out entity);
            return entity;
        }

        /// <summary>
        /// Filters the entities based on the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>IQueryable{E}.</returns>
        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.Values.AsQueryable().Where(predicate);
        }

        /// <summary>
        /// Gets all entities.
        /// </summary>
        /// <returns>A list of entities.</returns>
        public IEnumerable<TEntity> GetAll()
        {
            return _entities.Values.ToList();
        }

        /// <summary>
        /// Removes the entity with the specified id.
        /// </summary>
        /// <param name="id">The entity id.</param>
        public void Remove(TId id)
        {
            _entities.Remove(id);
        }

        /// <summary>
        /// Updates the specified updated entity.
        /// </summary>
        /// <param name="updatedEntity">The updated entity.</param>
        public void Update(TEntity updatedEntity)
        {
            _entities[updatedEntity.Id] = updatedEntity;
        }
    }
}

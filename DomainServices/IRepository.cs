namespace DomainServices
{
    /// <summary>
    /// Generic entity repository abstraction.
    /// </summary>
    /// <typeparam name="TEntity">The entity type.</typeparam>
    /// <typeparam name="TId">The entity ID type.</typeparam>
    public interface IRepository<TEntity, in TId> : IReadOnlyRepository<TEntity, TId> where TEntity : IEntity<TId>
    {
        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Add(TEntity entity);

        /// <summary>
        /// Removes the entity with the specified id.
        /// </summary>
        /// <param name="id">The entity id.</param>
        void Remove(TId id);

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Update(TEntity entity);
    }
}

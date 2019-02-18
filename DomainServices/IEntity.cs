namespace DomainServices
{
    using System.ComponentModel;

    /// <summary>
    /// Entity abstraction.
    /// </summary>
    /// <typeparam name="TId">The entity ID type.</typeparam>
    public interface IEntity<TId> : INotifyPropertyChanged, INotifyPropertyChanging
    {
        /// <summary>
        /// Gets or sets the unique identifier.
        /// </summary>
        /// <value>The unique identifier.</value>
        TId Id { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        string Name { get; set; }
    }
}

namespace DomainServices
{
    using System.ComponentModel;
    using System.Runtime.Serialization;

    /// <summary>
    /// Abstract base class for an entity.
    /// </summary>
    /// <typeparam name="TEntity">The entity ID type.</typeparam>
    [DataContract]
    public abstract class BaseEntity<TEntity> : IEntity<TEntity>
    {
        private TEntity _id;
        private bool _isModified;
        private string _name;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseEntity{TEntity}"/> class.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="name">The name.</param>
        protected BaseEntity(TEntity id, string name)
        {
            _id = id;
            _name = name;
        }

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Occurs when a property value is changing.
        /// </summary>
        public event PropertyChangingEventHandler PropertyChanging;

        /// <summary>
        /// Gets or sets the unique identifier.
        /// </summary>
        /// <value>The unique identifier.</value>
        [DataMember]
        public TEntity Id
        {
            get
            {
                return _id;
            }

            set
            {
                if (!Equals(_id, value))
                {
                    OnPropertyChanging("Id");
                    _id = value;
                    SetModified(true);
                    OnPropertyChanged("Id");
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is modified.
        /// </summary>
        /// <value><c>true</c> if this instance is modified; otherwise, <c>false</c>.</value>
        [Browsable(false)]
        public bool IsModified
        {
            get { return _isModified; }
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [DataMember]
        public virtual string Name
        {
            get
            {
                return _name;
            }

            set
            {
                if (!Equals(_name, value))
                {
                    OnPropertyChanging("Name");
                    _name = value;
                    SetModified(true);
                    OnPropertyChanged("Name");
                }
            }
        }

        /// <summary>
        /// Sets the modified value of the entity.
        /// </summary>
        /// <param name="modified">If set to <c>true</c> [modified].</param>
        public void SetModified(bool modified)
        {
            if (_isModified != modified)
            {
                _isModified = modified;
            }
        }

        /// <summary>
        /// Raises the PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">An EventArgs that contains the event data.</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// Raises the PropertyChanging event.
        /// </summary>
        /// <param name="propertyName">An EventArgs that contains the event data.</param>
        protected virtual void OnPropertyChanging(string propertyName)
        {
            if (PropertyChanging != null)
            {
                PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
            }
        }
    }
}
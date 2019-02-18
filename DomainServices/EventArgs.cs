namespace DomainServices
{
    using System;

    /// <summary>
    /// Generic version of EventArgs.
    /// </summary>
    /// <typeparam name="T">A type.</typeparam>
    public class EventArgs<T> : EventArgs
    {
        private readonly T _item;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventArgs{T}" /> class.
        /// </summary>
        /// <param name="item">The item.</param>
        public EventArgs(T item)
        {
            _item = item;
        }

        /// <summary>
        /// Gets the item.
        /// </summary>
        /// <value>The item.</value>
        public T Item
        {
            get { return _item; }
        }
    }
}

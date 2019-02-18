namespace MyServices.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Runtime.Serialization.Formatters;
    using DomainServices;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public class JsonRepository<TEntity, TId> : IRepository<TEntity, TId> where TEntity : IEntity<TId>
    {
        private readonly Dictionary<TId, TEntity> _entities;
        private readonly string _filePath;
        private readonly JsonSerializerSettings _jsonSerializerSettings;

        public JsonRepository(string filePath)
        {
            if (filePath == null)
            {
                throw new ArgumentNullException("filePath");
            }

            _entities = new Dictionary<TId, TEntity>();
            _filePath = filePath;
            _jsonSerializerSettings = new JsonSerializerSettings();
            _jsonSerializerSettings.Converters.Add(new StringEnumConverter());
            _jsonSerializerSettings.Formatting = Formatting.Indented;
            _jsonSerializerSettings.TypeNameHandling = TypeNameHandling.Objects;
            _jsonSerializerSettings.TypeNameAssemblyFormat = FormatterAssemblyStyle.Simple;
            _jsonSerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            if (File.Exists(filePath))
            {
                using (var streamReader = new StreamReader(filePath))
                {
                    var json = streamReader.ReadToEnd();
                    _entities = JsonConvert.DeserializeObject<Dictionary<TId, TEntity>>(json, _jsonSerializerSettings);
                }
            }
        }

        public int Count
        {
            get { return _entities.Count; }
        }

        public void Add(TEntity entity)
        {
            _entities[entity.Id] = entity;
            _Persist();
        }

        public bool Contains(TId id)
        {
            return _entities.ContainsKey(id);
        }

        public TEntity Get(TId id)
        {
            return _entities[id];
        }

        public virtual IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.Values.AsQueryable().Where(predicate);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _entities.Values.ToArray();
        }

        public void Remove(TId id)
        {
            _entities.Remove(id);
            _Persist();
        }

        public void Update(TEntity updatedEntity)
        {
            _entities[updatedEntity.Id] = updatedEntity;
            _Persist();
        }

        private void _Persist()
        {
            using (var streamWriter = new StreamWriter(_filePath))
            {
                var json = JsonConvert.SerializeObject(_entities, _jsonSerializerSettings);
                streamWriter.Write(json);
            }
        }
    }
}
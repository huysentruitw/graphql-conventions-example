using System;
using System.Collections.Concurrent;
using System.Linq;

namespace GraphApp.Repositories
{
    public sealed class TodoModel
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
    }

    public interface ITodoRepository
    {
        TodoModel Add(string description);
        TodoModel Find(Guid id);
        TodoModel[] GetAll();
    }

    internal sealed class TodoRepository : ITodoRepository
    {
        private static readonly ConcurrentDictionary<Guid, TodoModel> _store = new ConcurrentDictionary<Guid, TodoModel>();

        public TodoModel Add(string description)
        {
            var todo = new TodoModel
            {
                Id = Guid.NewGuid(),
                Description = description
            };
            _store.TryAdd(todo.Id, todo);
            return todo;
        }

        public TodoModel Find(Guid id)
            => _store.TryGetValue(id, out TodoModel todo) ? todo : null;

        public TodoModel[] GetAll()
            => _store.Values.ToArray();
    }
}

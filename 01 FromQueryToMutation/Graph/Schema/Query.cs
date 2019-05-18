using System;
using System.Collections.Generic;
using System.Linq;
using GraphApp.Repositories;
using GraphQL.Conventions;

namespace GraphApp.Graph.Schema
{
    internal sealed class Query
    {
        public IEnumerable<Todo> Todos([Inject] ITodoRepository repository)
            => repository.GetAll().Select(Map);

        public Todo Todo([Inject] ITodoRepository repository, Guid id)
            => Map(repository.Find(id));

        private static Todo Map(TodoModel model)
            => model == null ? null : new Todo
            {
                Id = model.Id,
                Description = model.Description
            };
    }
}

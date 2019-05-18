using GraphApp.Repositories;
using GraphQL.Conventions;

namespace GraphApp.Graph.Schema
{
    internal sealed class Mutation
    {
        [Description("Add a TODO to the in-memory repository")]
        public Todo AddTodo([Inject] ITodoRepository repository, [Description("The TODO description")] NonNull<string> description)
        {
            var model = repository.Add(description);
            return new Todo
            {
                Id = model.Id,
                Description = model.Description
            };
        }
    }
}

using System;
using GraphQL.Conventions;

namespace GraphApp.Graph.Schema
{
    [Description("Represents a single TODO")]
    internal sealed class Todo
    {
        [Description("The unique TODO identifier")]
        public Guid Id { get; set; }
        [Description("The TODO description")]
        public string Description { get; set; }
    }
}

using GraphQL.Types;
using GraphStudy.Movies.Movies;

namespace GraphStudy.Movies.Schema
{
    public class ActorType:ObjectGraphType<Actor>
    {
        public ActorType()
        {
            Field(x => x.Id);
            Field(x => x.Name);
        }
    }
}

using GraphQL;

namespace GraphStudy.Movies.Schema
{
    public class MovieSchema:GraphQL.Types.Schema
    {
        public MovieSchema(IDependencyResolver dependencyResolver, 
            MoviesQuery moviesQuery,
            MoviesMutation moviesMutation,
            MovieSubscription movieSubscription)
        {
            DependencyResolver = dependencyResolver;
            Query = moviesQuery;
            Mutation = moviesMutation;
            Subscription = movieSubscription;
        }
    }
}

using GraphQL.Types;
using GraphStudy.Movies.Movies;

namespace GraphStudy.Movies.Schema
{
    public class MovieEventType:ObjectGraphType<MovieEvent>
    {
        public MovieEventType()
        {
            Name = "MovieEventType";

            Field(x => x.Id, type: typeof(IdGraphType));//guid有点特殊
            Field(x => x.Name);
            Field(x => x.MovieId);
            Field(x => x.TimeStamp);
            Field(x => x.MovieRating, type: typeof(MovieRatingEnum));
        }
    }
}

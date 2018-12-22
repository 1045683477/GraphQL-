using GraphQL.Resolvers;
using GraphQL.Subscription;
using GraphQL.Types;
using GraphStudy.Movies.Movies;
using GraphStudy.Movies.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;

namespace GraphStudy.Movies.Schema
{
    public class MovieSubscription:ObjectGraphType
    {
        private readonly IMovieEventService _movieEventService;

        public MovieSubscription(IMovieEventService movieEventService)
        {
            _movieEventService = movieEventService;
            Name = "Subscription";

            //这里注意。以前的field不管用,EventStreamFieldType为AddField的参数
            AddField(new EventStreamFieldType
            {
                Name = "movieEvent",
                //Arguments给AddField添加参数
                Arguments = new QueryArguments(new QueryArgument<ListGraphType<MovieRatingEnum>>
                {
                    Name = "movieRatings"
                }),
                Type = typeof(MovieEventType),//这里的类型与GraphQL文档里的类型相对应
                Resolver = new FuncFieldResolver<MovieEvent>(ResolveEvent),//传递ResolveEvent方法
                Subscriber = new EventStreamResolver<MovieEvent>(Subscribe)//传递Subscribe方法
            });

        }

        private MovieEvent ResolveEvent(ResolveFieldContext context)
        {
            var movieEvent = context.Source as MovieEvent;
            return movieEvent;
        }

        private IObservable<MovieEvent> Subscribe(ResolveEventStreamContext context)
        {
            //取得枚举的集合，这里的name应与上面的Arguments的name对应，new List<MovieRating>()给其默认值。空值
            var ratingList = context.GetArgument<IList<MovieRating>>("movieRatings", new List<MovieRating>());

            //if为过滤操作，any()确定ratingList是否含有元素
            if (ratingList.Any())
            {
                MovieRating ratings = 0;
                foreach (var rating in ratingList)
                {
                    ratings = rating | rating;
                }

                return _movieEventService.EventStream().Where(e => (e.MovieRating & ratings) == e.MovieRating);
            }
            else
            {
                return _movieEventService.EventStream();
            }
        }
 
    }
}

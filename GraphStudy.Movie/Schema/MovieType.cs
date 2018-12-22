using GraphQL.Types;
using GraphStudy.Movies.Movies;
using GraphStudy.Movies.Services;

namespace GraphStudy.Movies.Schema
{
    public class MovieType:ObjectGraphType<Movie>
    {
        //先定义下构造函数
        public MovieType(IActorService actorService)
        {
            Name = "Movie";//类型的名字
            Description = "";//类型的描述

            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.Company);
            Field(x => x.ReleaseDate);
            Field(x => x.ActorId);

            //将枚举的Graph也加入其中,这是在查询Movie中嵌套（学过sql应该懂得嵌套查询）一个MovieRatingEnum
            //取名movieRating，查询结果context.Source.MovieRating
            Field<MovieRatingEnum>("movieRating", resolve: context => context.Source.MovieRating);

            Field<ActorType>("Actor", resolve: context => actorService.GetByIdAsync(context.Source.ActorId));

            //做一个小小的测试
            Field<StringGraphType>("customString", resolve: context => "1234");
        }
    }
}

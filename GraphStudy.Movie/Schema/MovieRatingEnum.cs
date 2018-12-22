using GraphQL.Types;
using GraphStudy.Movies.Movies;

namespace GraphStudy.Movies.Schema
{
    public class MovieRatingEnum:EnumerationGraphType<MovieRating>
    {
        //先定义下构造函数,列表枚举的GraphQL
        public MovieRatingEnum()
        {
            Name = "MovieRating";//类型的名字
            Description = "";//类型的描述

            //将鼠标置于AddValue上显示name,description,value,[deprecationReason]  []的含义是可填可不填的意思
            AddValue(MovieRating.Unrated.ToString(), "Unrated",MovieRating.Unrated);
            AddValue(MovieRating.G.ToString(), "G", MovieRating.G);
            AddValue(MovieRating.PG.ToString(), "PG", MovieRating.PG);
            AddValue(MovieRating.PG13.ToString(), "PG13", MovieRating.PG13);
            AddValue(MovieRating.R.ToString(), "R", MovieRating.R);
            AddValue(MovieRating.NC17.ToString(), "NC17", MovieRating.NC17);
        }
    }
}

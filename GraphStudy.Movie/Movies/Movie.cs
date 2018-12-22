using GraphStudy.Movies.Movies;
using System;

namespace GraphStudy.Movies.Movies
{
    //电影类
    public class Movie
    {
        public int Id { get; set; }//电影编号
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }//上映时间
        public string Company { get; set; }
        public int ActorId { get; set; }//演员ID
        public MovieRating MovieRating { get; set; }//电影等级枚举
    }
}

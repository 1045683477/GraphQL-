using System;

namespace GraphStudy.Movies.Movies
{
    //添加类的模板
    public class MovieInput
    {
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }//上映时间
        public string Company { get; set; }
        public int ActorId { get; set; }//演员ID
        public MovieRating MovieRating { get; set; }//电影等级枚举
    }
}

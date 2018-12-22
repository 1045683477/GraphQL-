using System;

namespace GraphStudy.Movies.Movies
{
    [Flags]
    public enum MovieRating
    {
        //这是电影的5个等级
        Unrated = 0,
        G = 1,
        PG = 2,
        PG13 = 3,
        R = 4,
        NC17 = 5
    }
}

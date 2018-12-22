using System;

namespace GraphStudy.Movies.Movies
{
    public class MovieEvent
    {
        public MovieEvent()
        {
            //初始化系统的一个新实例。Guid结构。
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public int MovieId { get; set; }
        public string Name { get; set; }
        public DateTime TimeStamp { get; set; }
        public MovieRating MovieRating { get; set; }
    }
}

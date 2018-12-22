using GraphStudy.Movies.Movies;
using System;
using System.Collections.Concurrent;

namespace GraphStudy.Movies.Services
{
    //Service发布事件，客户端可以接受这个时间的通知
    public interface IMovieEventService
    {
        //首先需要个合集，ConcurrentStack为并发集合，与线程相关
        ConcurrentStack<MovieEvent> AllEvent { get; }

        //添加异常的方法
        void AddError(Exception ex);

        //添加MovieEvent方法
        MovieEvent AddEvent(MovieEvent e);

        //定义stream方法
        IObservable<MovieEvent> EventStream();

        //c#中的Observer和IObservable用于观察者与事件、代理
    }
}

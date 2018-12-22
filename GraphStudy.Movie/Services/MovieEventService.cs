using GraphStudy.Movies.Movies;
using System;
using System.Collections.Concurrent;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace GraphStudy.Movies.Services
{
    public class MovieEventService : IMovieEventService
    {
        //ISubject:表示既是可观察序列又是观察者的对象。
        //ReplaySubject意思为无论订阅者什么时候订阅都会将以前发布的内容发布给他，并初始化ISubject对象
        private readonly ISubject<MovieEvent> _eventStream=new ReplaySubject<MovieEvent>();

        //ConcurrentStack：后进的线程后出
        public ConcurrentStack<MovieEvent> AllEvent { get; }

        public MovieEventService()
        {
            AllEvent=new ConcurrentStack<MovieEvent>();
        }

        public void AddError(Exception ex)
        {
            _eventStream.OnError(ex);
        }

        public MovieEvent AddEvent(MovieEvent e)
        {
            //Push推送
            AllEvent.Push(e);
            //OnNext:当前消息通知
            _eventStream.OnNext(e);
            return e;
        }

        //IObservable<T>：通知程序观察者将接到消息通知
        //T：代表观察员，接收通知对象
        public IObservable<MovieEvent> EventStream()
        {
            //AsObservable:隐藏源序列身份的可观察序列
            return _eventStream.AsObservable();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace VideoGameCollectionTracker.UI.Events
{
  public class EventAggregator : IEventAggregator
  {
    private readonly SynchronizationContext _synchronizationContext;
    private readonly List<Delegate> _handlers = new List<Delegate>();

    public EventAggregator()
    {
      _synchronizationContext = SynchronizationContext.Current;
    }

    public void PostMessage<T>(T message)
    {
      if (message == null)
      {
        return;
      }

      if (_synchronizationContext != null)
      {
        _synchronizationContext.Post(m => Dispatch<T>((T)m), message);
      }
    }

    /// <summary>
    /// Register a message handler
    /// </summary>
    /// <param name="eventHandler">Message handler to add.</param>
    public Action<T> RegisterHandler<T>(Action<T> eventHandler)
    {
      if (eventHandler == null)
      {
        throw new ArgumentNullException("eventHandler");
      }

      _handlers.Add(eventHandler);
      return eventHandler;
    }

    /// <summary>
    /// Send a message instance for immediate delivery
    /// </summary>
    /// <typeparam name="T">Type of the message</typeparam>
    /// <param name="message">Message to send</param>
    public void SendMessage<T>(T message)
    {
      if (message == null)
      {
        return;
      }

      if (_synchronizationContext != null)
      {
        _synchronizationContext.Send(
            m => Dispatch<T>((T)m),
            message);
      }
      else
      {
        Dispatch(message);
      }
    }

    /// <summary>
    /// Unregister a message handler
    /// </summary>
    /// <param name="eventHandler">Message handler to remove.</param>
    public void UnregisterHandler<T>(Action<T> eventHandler)
    {
      if (eventHandler == null)
      {
        throw new ArgumentNullException("eventHandler");
      }

      _handlers.Remove(eventHandler);
    }

    /// <summary>
    /// Dispatch a message to all appropriate handlers
    /// </summary>
    /// <typeparam name="T">Type of the message</typeparam>
    /// <param name="message">Message to dispatch to registered handlers</param>
    private void Dispatch<T>(T message)
    {
      if (message == null)
      {
        throw new ArgumentNullException("message");
      }

      var compatibleHandlers
          = _handlers.OfType<Action<T>>()
              .ToList();
      foreach (var h in compatibleHandlers)
      {
        h(message);
      }
    }
  }
}

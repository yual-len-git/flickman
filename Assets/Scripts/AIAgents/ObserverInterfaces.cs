
using UnityEngine;

public interface IEventObserver
{
    public void AcceptEvent(AgentEvent e, GameObject emitter);
}

public interface IEventSubject
{
    public void Attach(IEventObserver observer);
    public void Detach(IEventObserver observer);
}
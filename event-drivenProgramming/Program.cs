using System;


public class EventPublisher
{

    public delegate void EventHandler(string message);

    public event EventHandler OnEvent;
    public void RaiseEvent(string message)
    {
   

      
        if (OnEvent != null)
        {
            OnEvent(message);
        }
    }
}


public class EventSubscriber
{
    
    public void HandleEvent(string message)
    {
        Console.WriteLine($"Assinante manipulando o evento: {message}");
    }
}
public class EventSubscriberTwo
{
    
    public void HandleEventTwo(string message)
    {
        Console.WriteLine($"Assinante manipulando o evento: \n");
    }
}
class Program
{
    static void Main()
    {
 
        EventPublisher publisher = new EventPublisher();


        EventSubscriber subscriber = new EventSubscriber();

        EventSubscriberTwo subscriberTwo = new EventSubscriberTwo();
        publisher.OnEvent += subscriber.HandleEvent;
        publisher.OnEvent += subscriberTwo.HandleEventTwo;
      
        publisher.RaiseEvent("Isso é um evento!");


        publisher.OnEvent -= subscriber.HandleEvent;
        publisher.OnEvent -= subscriberTwo.HandleEventTwo;
  
        publisher.RaiseEvent("Este evento não será manipulado.");

        Console.ReadLine();
    }
}
using System;
using System.Collections.Generic;

namespace ObserverPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var customer = new Customer();
            ProductManager productManager = new ProductManager();
            productManager.Attach(customer);
            productManager.Attach(new Employee());
            productManager.Detach(customer);
            productManager.UpdatePrice();

            Console.ReadLine();
        }
    }

    public class ProductManager
    {
        private List<Observer> _observers = new List<Observer>();
        public void UpdatePrice()
        {
            Console.WriteLine("Product price changed");
            Notify();
        }

        public void Attach(Observer observer)
        {
            _observers.Add(observer);
        }

        public void Detach(Observer observer)
        {
            _observers.Remove(observer);
        }

        private void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update();
            }
        }
    }

    public abstract class Observer
    {
        public abstract void Update();
    }

    public class Customer : Observer
    {
        public override void Update()
        {
            Console.WriteLine("Customer: Product price changed");
        }
    }

    public class Employee : Observer
    {
        public override void Update()
        {
            Console.WriteLine("Employee: Product price changed");
        }
    }
}

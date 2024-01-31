using System;
using System.Data;

namespace NDViet.UT.NSub.Delegate
{
    public interface IOrderProcessor
    {
        void ProcessOrder(int orderId, Action<IDataReader> orderProcessed);
    }

    public class OrderPlacedCommand
    {
        IOrderProcessor orderProcessor;
        public OrderPlacedCommand(IOrderProcessor orderProcessor)
        {
            this.orderProcessor = orderProcessor;
        }
        public void Execute(ICart cart)
        {
            orderProcessor.ProcessOrder(
                cart.OrderId,
                dt => {
                    if (dt.NextResult())
                    {
                        Console.WriteLine($"Order processed {cart.OrderId}");
                    }
                }
            );
        }
    }

    public interface ICart
    {
        int OrderId { get; set; }
    }

}

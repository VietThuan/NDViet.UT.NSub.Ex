using NSubstitute;
using NUnit.Framework;
using System.Data;

namespace NDViet.UT.NSub.Delegate
{
    public class OrderPlacedCommandTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Execute_AnyCart_RaiseOrderProcessed()
        {
            //Arrange
            var cart = Substitute.For<ICart>();
            var processor = Substitute.For<IOrderProcessor>();
            cart.OrderId = 3;

            var dataReader = Substitute.For<IDataReader>();
            dataReader.NextResult().Returns(true);

            processor.ProcessOrder(3, Arg.Invoke(dataReader));

            //Act
            var command = new OrderPlacedCommand(processor);
            command.Execute(cart);

            //Assert
            dataReader.Received(1).NextResult();
        }
    }
}
using System;
using NUnit.Framework;

namespace TestProject1
{
    [TestFixture]
    public class DelegateTest
    {
        delegate void Message();
        
        [Test]
        public void SumDelegateTest()
        {
            // prepare
            Message message;
            
            //act
            message = Hello;
            message += HowAreYou;
            message += HowAreYou;
            message();
            
            //test
            Assert.IsNotNull(message);
        }
        
        [Test]
        public void SubtractDelegateTest()
        {
            // prepare
            Message message;
            
            //act
            message = Hello;
            message += HowAreYou;
            message += HowAreYou;
            message -= Hello;
            message();
            
            //test
            Assert.IsNotNull(message);
        }

        public void Hello()
        {
            Console.WriteLine("Hello");
        }

        public void HowAreYou()
        {
            Console.WriteLine("How are you?");
        }
    }
}
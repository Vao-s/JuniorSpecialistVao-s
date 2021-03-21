using System;
using System.Diagnostics;
using NUnit.Framework;

namespace TestProject1
{
    [TestFixture]
    public class BoxingUnboxingTests
    {
        private const int N = 10000;
        private readonly object[] _o = new object[N];
        private readonly int[] _arr = new int[N];
        private readonly Stopwatch _sw = new();
        private readonly Random _random = new();
        
        [Test]
        public void Boxing()
        {
            // prepare
            var o = _o;    //??? все ли поля должны так инициализировать?
            var ii =123;

            // act
            Console.WriteLine("Boxing...");
            _sw.Start();
            for (var i = 0; i < N; i++)
            {
                o[i] = _random.Next(-50, 51);
            }
            _sw.Stop();
            Console.WriteLine("Boxing OK.");
            Console.WriteLine($"Общее время упаковки {N} элементов = {_sw.ElapsedTicks}");
            Console.WriteLine($"Среднее время упаковки = {(double)_sw.ElapsedTicks / N}\n");
            _sw.Reset();
            
            o[0] = ii;
            // test
            Assert.AreEqual(123,o[0]);
        }

        [Test]
        public void Unboxing()
        {
            // prepare
            var o = _o;
            var arr = _arr;
            var ii = 123;

            // act
            for (var i = 0; i < N; i++)
            {
                o[i] = _random.Next(-50, 51);
            }
            
            Console.WriteLine("Unboxing...");
            _sw.Start();
            for (var i = 0; i < N; i++)
            {
                arr[i] = (int) o[i];
            }
            _sw.Stop();
            Console.WriteLine("Unboxing OK.");
            Console.WriteLine($"Общее время распаковки {N} элементов = {_sw.ElapsedTicks}");
            Console.WriteLine($"Среднее время распаковки = {(double)_sw.ElapsedTicks / N}");
            _sw.Reset();
            
            // test
            Assert.AreEqual(arr[0], o[0]);
        }
    }
}
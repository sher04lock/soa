using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zadania1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadania1.Tests
{
    [TestClass()]
    public class CircusTests
    {
        [TestMethod()]
        public void AnimalIntroductionTest()
        {
            var Animals = new List<Animal>
            {
                new Cat(), new Giraffe()
            };
            var Circus = new Circus(Animals);

            var introduction = Circus.AnimalIntroduction();
            Console.WriteLine(introduction);
            Assert.AreEqual(introduction, "meow, girafffff");
        }
    }
}
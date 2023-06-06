namespace Design_Patterns_Test
{
    using NUnit.Framework;
    using Design_Patterns.Singleton;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class TSingleton
    {
        [Test]
        public void Instance_ShouldReturnSameInstance()
        {
            var firstInstance = Singleton.Instance;
            var secondInstance = Singleton.Instance;

            Assert.AreSame(firstInstance, secondInstance);
        }

        [Test]
        public void Instance_ShouldReturnSameInstanceInMultiThreadedScenario()
        {
            var instances = new List<Singleton>();

            Parallel.For(0, 100, _ =>
            {
                var instance = Singleton.Instance;
                instances.Add(instance);
            });

            Assert.That(1, Is.EqualTo(instances.Distinct().Count()));
        }

        [Test]
        public void GetInfo_ShouldReturnCorrectMessage()
        {
            var referenceInfo = "This is some Singleton information.";
            var info = Singleton.Instance.GetInfo();

            Assert.That(info, Is.EqualTo(referenceInfo));
        }
    }
}

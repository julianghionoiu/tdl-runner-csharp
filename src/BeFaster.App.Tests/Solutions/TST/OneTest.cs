using BeFaster.App.Solutions.TST;
using NUnit.Framework;

namespace BeFaster.App.Tests.Solutions.TST
{
    public class OneTest {
    
        [Test]
        public void RunApply() {
            Assert.That(One.apply(), Is.EqualTo(1));
        }
    }
}

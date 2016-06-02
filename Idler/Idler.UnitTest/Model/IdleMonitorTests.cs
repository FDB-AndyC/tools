namespace Idler.UnitTest.Model
{
    using System.Collections.Generic;
    using System.Threading;
    using Idler.Model;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class IdleMonitorTests
    {
        [TestMethod]
        public void WhenCreatingThenTotalIsZero()
        {
            var monitor = new IdleMonitor(null);
            Assert.AreEqual(0ul, monitor.Total, "Unexpected total - should be zero on creation.");
        }

        [TestMethod]
        public void GivenIdlingWhenCheckingThenTotalAlwaysIncreases()
        {
            var last = 10u;
            var mockReporter = new Mock<IIdlingReporter>();
            var monitor = new IdleMonitor(mockReporter.Object);

            mockReporter
                .Setup(r => r.GetIdleTime())
                .Returns(() =>
                {
                    var cached = last;
                    last += 10u;
                    return cached;
                });

            var values = RunMonitor(monitor);

            var total = 0ul;
            foreach (var reportedTotal in values)
            {
                Assert.IsTrue(reportedTotal >= total, "Total should always be increasing when idling.");
                total = reportedTotal;
            }
        }

        [TestMethod]
        public void GivenActivityWhenCheckingThenTotalShouldNotIncrease()
        {
            var mockReporter = new Mock<IIdlingReporter>();
            var monitor = new IdleMonitor(mockReporter.Object);

            mockReporter
                .Setup(r => r.GetIdleTime())
                .Returns(0u);

            var values = RunMonitor(monitor);

            foreach (var reportedTotal in values)
            {
                Assert.IsTrue(reportedTotal == 0ul, "Total should always be zero when always active.");
            }
        }

        private static IEnumerable<ulong> RunMonitor(IIdleMonitor monitor)
        {
            var returned = new List<ulong>();

            monitor.Start();
            for (var i = 0; i < 10; ++i)
            {
                returned.Add(monitor.Total);
                Thread.Sleep(300);
            }
            monitor.Stop();

            return returned;
        }
    }
}

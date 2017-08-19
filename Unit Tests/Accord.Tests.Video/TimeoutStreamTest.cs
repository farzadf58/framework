﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Accord.Video;
using System.IO;

namespace Accord.Tests.Video
{
    [TestFixture]
    public class TimeoutStreamTest
    {
        [Test]
        public void CanTimeoutTest()
        {
            MemoryStream baseStream = new MemoryStream();
            TimeoutStream timeoutStream = new TimeoutStream(baseStream);

            Assert.IsFalse(baseStream.CanTimeout);
            Assert.IsTrue(timeoutStream.CanTimeout);
        }

        [Test]
        public void CanReadTest()
        {
            MemoryStream baseStream = new MemoryStream();
            TimeoutStream timeoutStream = new TimeoutStream(baseStream);

            Assert.IsTrue(baseStream.CanRead);
            Assert.IsTrue(timeoutStream.CanRead);
        }

        [Test]
        public void SetReadTimeoutBaseStream()
        {
            MemoryStream baseStream = new MemoryStream();
            TimeoutStream timeoutStream = new TimeoutStream(baseStream);

            Assert.Throws<InvalidOperationException>(() => baseStream.ReadTimeout = 10000);
        }

        [Test]
        public void SetReadTimeoutTimeoutStream()
        {
            int expected = 10000;

            MemoryStream baseStream = new MemoryStream();
            TimeoutStream timeoutStream = new TimeoutStream(baseStream);

            timeoutStream.ReadTimeout = expected;

            Assert.AreEqual(expected, timeoutStream.ReadTimeout);
        }

        [Test]
        public void SetWriteTimeoutBaseStream()
        {
            MemoryStream baseStream = new MemoryStream();
            TimeoutStream timeoutStream = new TimeoutStream(baseStream);

            Assert.Throws<InvalidOperationException>(() => baseStream.WriteTimeout = 10000);
        }

        [Test]
        public void SetWriteTimeoutTimeoutStream()
        {
            int expected = 10000;

            MemoryStream baseStream = new MemoryStream();
            TimeoutStream timeoutStream = new TimeoutStream(baseStream);

            timeoutStream.WriteTimeout = expected;

            Assert.AreEqual(expected, timeoutStream.WriteTimeout);
        }
    }
}

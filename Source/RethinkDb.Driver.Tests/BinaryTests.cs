﻿using FluentAssertions;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RethinkDb.Driver.Net;

namespace RethinkDb.Driver.Tests
{
    [TestFixture]
    public class BinaryTests : QueryTest
    {
        [Test]
        public void binary_echo()
        {
            byte[] data = r.binary(new byte[] {1, 2, 3}).run<byte[]>(conn);
            data.Should().Equal(1, 2, 3);
        }


        [Test]
        public void can_get_raw_binary_type()
        {
            JObject reqlType = r.binary(new byte[] { 1, 2, 3 }).run<JObject>(conn);
            reqlType[Converter5.PseudoTypeKey].ToString().Should().Be("BINARY");
        }
    }
}
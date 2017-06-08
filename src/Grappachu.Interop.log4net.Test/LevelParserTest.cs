using System;
using log4net.Core;
using NUnit.Framework;
using SharpTestsEx;

namespace Grappachu.Interop.log4net.Test
{
    [TestFixture]
    public class LevelParserTest
    {
        [Test]
        public void Should_throw_When_argument_invalid()
        {
            Executing.This(() => { LevelParser.Parse("invalidlevel"); }).Should().Throw<ArgumentException>();
        }

        [Test]
        public void ShouldParseFromAString()
        {
            LevelParser.Parse("DEBUG").Should().Be.EqualTo(Level.Debug);
            LevelParser.Parse("INFO").Should().Be.EqualTo(Level.Info);
            LevelParser.Parse("WARN").Should().Be.EqualTo(Level.Warn);
            LevelParser.Parse("ERROR").Should().Be.EqualTo(Level.Error);
            LevelParser.Parse("FATAL").Should().Be.EqualTo(Level.Fatal);

            LevelParser.Parse("Debug").Should().Be.EqualTo(Level.Debug);
            LevelParser.Parse("iNfO").Should().Be.EqualTo(Level.Info);
            LevelParser.Parse("error").Should().Be.EqualTo(Level.Error);
        }
    }
}
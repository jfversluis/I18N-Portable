﻿using System;
using I18NPortable.Readers;
using NUnit.Framework;

namespace I18NPortable.UnitTests
{
    [TestFixture]
    public class LocaleReadersTests
    {
        [TearDown]
        public void Finish() =>
            I18N.Current.Dispose();

        [Test]
        public void UnknownResourceExtension_Should_Throw()
        {
            Assert.Throws<Exception>(() =>
            {
                I18N.Current
                    .AddLocaleReader(new TextKvpReader(), ".txt22222")
                    .Init(GetType().Assembly);
            });
        }

        [Test]
        public void TextKvpReader_CanBe_Added()
        {
            I18N.Current
                .AddLocaleReader(new TextKvpReader(), ".txt")
                .Init(GetType().Assembly)
                .Locale = "es";

            Assert.AreEqual("uno", I18N.Current.Translate("one"));
        }
    }
}

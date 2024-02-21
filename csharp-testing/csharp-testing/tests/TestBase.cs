using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using AccountTest;
using System.Runtime.CompilerServices;

namespace Addressbook
{
    public class TestBase : TestSuiteFixture
    {
        protected AppManager app;

        [SetUp]
        public void SetUp()
        {
            app = AppManager.GetInstance();
        }

    }
}

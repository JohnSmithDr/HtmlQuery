﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fnio.Lib.HtmlQuery.Node;
using FluentAssertions;
using System.Collections.Generic;

namespace Fnio.Lib.HtmlQuery.UnitTest.Query
{
    [TestClass]
    public class ElementsTest
    {
        public HtmlDocument Doc { get; } = HtmlParser.Parse(TestData.SimpleHtmlDoc);

        [TestMethod]
        public void TestHasAttribute()
        {
            var nav = Doc.Body.GetChildById("navigation");
            nav.HasAttribute("id").Should().BeTrue();
            nav.HasAttribute("CLASS").Should().BeTrue();
            nav.HasAttribute("Style").Should().BeFalse();
            nav.HasAttribute().Should().BeTrue();
        }

        [TestMethod]
        public void TestHasClassName()
        {
            var nav = Doc.Body.GetChildById("navigation");
            nav.HasClassName("container").Should().BeTrue();
            nav.HasClassName("navs").Should().BeTrue();
            nav.HasClassName("wrapper").Should().BeFalse();
        }

        [TestMethod]
        public void TestContainsClassNames()
        {
            var nav = Doc.Body.GetChildById("navigation");
            nav.ContainsClassNames(new List<string> { "container", "navs" }).Should().BeTrue();
            nav.ContainsClassNames(new List<string> { "wrapper", "navs" }).Should().BeFalse();
            nav.ContainsClassNames(new List<string> { }).Should().BeFalse();
        }

        [TestMethod]
        public void TestContainsClassNamesWithParams()
        {
            var nav = Doc.Body.GetChildById("navigation");
            nav.ContainsClassNames("container", "navs").Should().BeTrue();
            nav.ContainsClassNames("wrapper", "navs").Should().BeFalse();
            nav.ContainsClassNames().Should().BeFalse();
        }
        
    }
}
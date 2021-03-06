﻿using Fnio.Lib.HtmlQuery.Node;
using System.Collections.Generic;
using System.Linq;

namespace Fnio.Lib.HtmlQuery
{
    public static partial class HtmlQuery
    {
        /// <summary>
        /// Get element sequence by depth-first traversing.
        /// </summary>
        public static IEnumerable<HtmlElement> AsTraversable(this HtmlElement element)
        {
            var self = new[] { element };
            return self.Concat(element.Descendants());
        }

        /// <summary>
        /// Get element sequence by depth-first traversing.
        /// </summary>
        public static IEnumerable<HtmlElement> AsTraversable(this IEnumerable<HtmlElement> source) 
            => source.SelectMany(AsTraversable);

        /// <summary>
        /// Determines whether the element has any attribute.
        /// </summary>
        public static bool HasAttribute(this HtmlElement element) 
            => element.Attributes.Any();

        /// <summary>
        /// Determines whether the element has attribute with specific attribute name.
        /// </summary>
        public static bool HasAttribute(this HtmlElement element, string attributeName) 
            => element.Attributes.GetAttribute(attributeName) != null;

        /// <summary>
        /// Determines whether the element has a specific class name.
        /// </summary>
        public static bool HasClassName(this HtmlElement element, string className) 
            => element.ClassNames.Contains(className);

        /// <summary>
        /// Determines whether the element has specific class names.
        /// </summary>
        public static bool ContainsClassNames(this HtmlElement element, IEnumerable<string> classNames)
        {
            if (!classNames.Any()) return false;
            var classNameSet = new HashSet<string>(element.ClassNames);
            return classNames.All(name => classNameSet.Contains(name));
        }

        /// <summary>
        /// Determines whether the element has specific class names.
        /// </summary>
        public static bool ContainsClassNames(this HtmlElement element, params string[] classNames) 
            => ContainsClassNames(element, classNames.AsEnumerable());

    }
}

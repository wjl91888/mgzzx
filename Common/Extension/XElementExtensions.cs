using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace RICH.Common
{
    public static class XElementExtensions
    {
        /// <summary>
        /// Throw exception if specified element does not match the name given
        /// </summary>
        /// <param name="element">element to verify</param>
        /// <param name="expectedName">expected name</param>
        public static void VerifyElementName(this XElement element, string expectedName)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }

            if (expectedName.IsNullOrWhiteSpace())
            {
                throw new ArgumentNullException("expectedName");
            }

            if (element.Name != expectedName)
            {
                string message = "Verify XElement name: Expected element name to be <{0}>. <{1}> was encountered instead.".FormatInvariantCulture(expectedName, element.Name);
                throw new Exception(message);
            }
        }

        /// <summary>
        /// Verify if specified attribute exist in the element
        /// </summary>
        /// <param name="element">The XElement this is called against</param>
        /// <param name="expectedName">Name to verify</param>
        public static bool AttributePresent(this XElement element, string expectedName)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }

            if (expectedName.IsNullOrWhiteSpace())
            {
                throw new ArgumentNullException("expectedName");
            }

            return element.Attribute(expectedName) != null;
        }

        /// <summary>
        /// Verify if specified attribute exist in the element
        /// </summary>
        /// <param name="element">The XElement this is called against</param>
        /// <param name="expectedName">Name to verify</param>
        public static bool ElementPresent(this XElement element, string expectedName)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }
            if (expectedName.IsNullOrWhiteSpace())
            {
                throw new ArgumentNullException("expectedName");
            }
            return element.Element(expectedName) != null;
        }

        /// <summary>
        /// get specified attribute value and cast to specified type
        /// </summary>
        /// <param name="element">element src</param>
        /// <param name="attributeName">attribute name</param>
        /// <returns>int?</returns>
        public static int? GetAttributeIntNullable(this XElement element, string attributeName)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }

            if (attributeName.IsNullOrWhiteSpace())
            {
                throw new ArgumentNullException("attributeName");
            }
            return (int?)element.Attribute(attributeName);
        }

        /// <summary>
        /// get specified attribute value and cast to specified type
        /// </summary>
        /// <param name="element">element src</param>
        /// <param name="attributeName">attribute name</param>
        /// <returns>int</returns>
        public static int GetAttributeInt(this XElement element, string attributeName)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }

            if (attributeName.IsNullOrWhiteSpace())
            {
                throw new ArgumentNullException("attributeName");
            }
            return (int)element.ValidateAndGetAttribute(attributeName);
        }

        /// <summary>
        /// get specified attribute value and cast to specified type
        /// </summary>
        /// <param name="element">element src</param>
        /// <param name="attributeName">attribute name</param>
        /// <returns>long?</returns>
        public static long? GetAttributeInt64Nullable(this XElement element, string attributeName)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }

            if (attributeName.IsNullOrWhiteSpace())
            {
                throw new ArgumentNullException("attributeName");
            }
            return (long?)element.Attribute(attributeName);
        }

        /// <summary>
        /// get specified attribute value and cast to specified type
        /// </summary>
        /// <param name="element">element src</param>
        /// <param name="attributeName">attribute name</param>
        /// <returns>long</returns>
        public static long GetAttributeInt64(this XElement element, string attributeName)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }

            if (attributeName.IsNullOrWhiteSpace())
            {
                throw new ArgumentNullException("attributeName");
            }
            return (long)element.ValidateAndGetAttribute(attributeName);
        }

        /// <summary>
        /// get specified attribute value and cast to specified type
        /// </summary>
        /// <param name="element">element src</param>
        /// <param name="attributeName">attribute name</param>
        /// <returns>decimal?</returns>
        public static decimal? GetAttributeDecimalNullable(this XElement element, string attributeName)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }

            if (attributeName.IsNullOrWhiteSpace())
            {
                throw new ArgumentNullException("attributeName");
            }
            return (decimal?)element.Attribute(attributeName);
        }

        /// <summary>
        /// get specified attribute value and cast to specified type
        /// </summary>
        /// <param name="element">element src</param>
        /// <param name="attributeName">attribute name</param>
        /// <returns>decimal</returns>
        public static decimal GetAttributeDecimal(this XElement element, string attributeName)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }

            if (attributeName.IsNullOrWhiteSpace())
            {
                throw new ArgumentNullException("attributeName");
            }
            return (decimal)element.ValidateAndGetAttribute(attributeName);
        }

        /// <summary>
        /// get specified attribute value and cast to specified type
        /// </summary>
        /// <param name="element">element src</param>
        /// <param name="attributeName">attribute name</param>
        /// <returns>float?</returns>
        public static float? GetAttributeFloatNullable(this XElement element, string attributeName)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }

            if (attributeName.IsNullOrWhiteSpace())
            {
                throw new ArgumentNullException("attributeName");
            }
            return (float?)element.Attribute(attributeName);
        }

        /// <summary>
        /// get specified attribute value and cast to specified type
        /// </summary>
        /// <param name="element">element src</param>
        /// <param name="attributeName">attribute name</param>
        /// <returns>float</returns>
        public static float GetAttributeFloat(this XElement element, string attributeName)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }

            if (attributeName.IsNullOrWhiteSpace())
            {
                throw new ArgumentNullException("attributeName");
            }
            return (float)element.ValidateAndGetAttribute(attributeName);
        }

        /// <summary>
        /// get specified attribute value and cast to specified type
        /// </summary>
        /// <param name="element">element src</param>
        /// <param name="attributeName">attribute name</param>
        /// <returns>short</returns>
        public static short GetAttributeShort(this XElement element, string attributeName)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }

            if (attributeName.IsNullOrWhiteSpace())
            {
                throw new ArgumentNullException("attributeName");
            }
            return (short)element.ValidateAndGetAttribute(attributeName);
        }

        /// <summary>
        /// get specified attribute value and cast to specified type
        /// </summary>
        /// <param name="element">element src</param>
        /// <param name="attributeName">attribute name</param>
        /// <returns>Datetime?</returns>
        public static DateTime? GetAttributeDateTimeNullable(this XElement element, string attributeName)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }

            if (attributeName.IsNullOrWhiteSpace())
            {
                throw new ArgumentNullException("attributeName");
            }
            return (DateTime?)element.Attribute(attributeName);
        }

        /// <summary>
        /// get specified attribute value and cast to specified type
        /// </summary>
        /// <param name="element">element src</param>
        /// <param name="attributeName">attribute name</param>
        /// <returns>Datetime</returns>
        public static DateTime GetAttributeDateTime(this XElement element, string attributeName)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }

            if (attributeName.IsNullOrWhiteSpace())
            {
                throw new ArgumentNullException("attributeName");
            }
            return (DateTime)element.ValidateAndGetAttribute(attributeName);
        }

        /// <summary>
        /// get specified attribute value and cast to specified type
        /// </summary>
        /// <param name="element">element src</param>
        /// <param name="attributeName">attribute name</param>
        /// <returns>bool</returns>
        public static bool? GetAttributeBoolNullable(this XElement element, string attributeName)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }
            if (attributeName.IsNullOrWhiteSpace())
            {
                throw new ArgumentNullException("attributeName");
            }
            var value = (string)element.Attribute(attributeName);
            if (null == value)
            {
                return null;
            }
            return GetAttributeBool(element, attributeName);
        }

        /// <summary>
        /// get specified attribute value and cast to specified type
        /// </summary>
        /// <param name="element">element src</param>
        /// <param name="attributeName">attribute name</param>
        /// <returns>bool</returns>
        public static bool GetAttributeBool(this XElement element, string attributeName)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }

            if (attributeName.IsNullOrWhiteSpace())
            {
                throw new ArgumentNullException("attributeName");
            }

            var value = (string)element.Attribute(attributeName);

            if (value != null)
            {
                switch (value.ToLower())
                {
                    case "0":
                    case "false":
                    case "off":
                    case "no":
                        return false;

                    case "1":
                    case "true":
                    case "on":
                    case "yes":
                        return true;
                }
            }
            throw new FormatException("Failed to get bool value from specified attribute: {0}".FormatInvariantCulture(attributeName));
        }

        /// <summary>
        /// get specified attribute value and cast to specified type
        /// </summary>
        /// <param name="element">element src</param>
        /// <param name="attributeName">attribute name</param>
        /// <returns>string</returns>
        public static string GetAttributeString(this XElement element, string attributeName)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }
            if (attributeName.IsNullOrWhiteSpace())
            {
                throw new ArgumentNullException("attributeName");
            }
            return (string)element.Attribute(attributeName);
        }

        public static XAttribute ValidateAndGetAttribute(this XElement element, string attributeName)
        {
            if (attributeName.IsNullOrWhiteSpace())
            {
                throw new ArgumentNullException("attributeName");
            }
            var att = element.Attribute(attributeName);
            if (null == att)
            {
                throw new InvalidDataException("The element does not contain attribute named '{0}'".FormatInvariantCulture(attributeName));
            }
            return att;
        }

        /// <summary>
        /// Checks whether the XElement is null or contains no items.
        /// </summary>
        /// <param name="element">The instance of XElement</param>
        /// <returns>True if the element is null or empty.</returns>
        public static bool IsNullOrEmpty(this XElement element)
        {
            return ((element == null) || (element.IsEmpty) || (element.Elements().Count() == 0));
        }
    }
}

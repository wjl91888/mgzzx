using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RICH.Common
{
    public static class NullableExtensions
    {
        /// <summary>
        /// return null if input equals to specified default value, otherwise the original value
        /// </summary>
        /// <param name="inputValue">the input value</param>
        /// <param name="defaultValue">default value</param>
        /// <param name="overallCondition">return null if overall condition is not satisfied</param>
        /// <returns>null able short value</returns>
        public static short? NullIfDefault(this short inputValue, short defaultValue = default(short), bool overallCondition = true)
        {
            return overallCondition
                       ? (inputValue == defaultValue ? null : (short?)inputValue)
                       : null;
        }

        /// <summary>
        /// return null if input equals to specified default value, otherwise the original value
        /// </summary>
        /// <param name="inputValue">the input value</param>
        /// <param name="defaultValue">default value</param>
        /// <param name="overallCondition">return null if overall condition is not satisfied</param>
        /// <returns>null able int value</returns>
        public static int? NullIfDefault(this int inputValue, int defaultValue = default(int), bool overallCondition = true)
        {
            return overallCondition
                       ? (inputValue == defaultValue ? null : (int?)inputValue)
                       : null;
        }

        /// <summary>
        /// return null if input equals to specified default value, otherwise the original value
        /// </summary>
        /// <param name="inputValue">the input value</param>
        /// <param name="defaultValue">default value</param>
        /// <param name="overallCondition">return null if overall condition is not satisfied</param>
        /// <returns>null able int value</returns>
        public static int? NullIfDefault(this int? inputValue, int defaultValue = default(int), bool overallCondition = true)
        {
            return overallCondition
                       ? (inputValue == defaultValue ? null : inputValue)
                       : null;
        }

        /// <summary>
        /// return specified default value if input is null, otherwise the original value
        /// </summary>
        /// <param name="inputValue">the input value</param>
        /// <param name="defaultValue">default value</param>
        /// <param name="overallCondition">return default if overall condition is not satisfied</param>
        /// <returns>int value</returns>
        public static int DefaultIfNull(this int? inputValue, int defaultValue = default(int), bool overallCondition = true)
        {
            return overallCondition
                       ? (inputValue == null ? defaultValue : inputValue.Value)
                       : defaultValue;
        }

        /// <summary>
        /// return null if input equals to specified default value, otherwise the original value
        /// </summary>
        /// <param name="inputValue">the input value</param>
        /// <param name="defaultValue">default value</param>
        /// <param name="overallCondition">return null if overall condition is not satisfied</param>
        /// <returns>null able long value</returns>
        public static long? NullIfDefault(this long inputValue, long defaultValue = default(long), bool overallCondition = true)
        {
            return overallCondition
                       ? (inputValue == defaultValue ? null : (long?)inputValue)
                       : null;
        }

        /// <summary>
        /// return null if input equals to specified default value, otherwise the original value
        /// </summary>
        /// <param name="inputValue">the input value</param>
        /// <param name="defaultValue">default value</param>
        /// <param name="overallCondition">return null if overall condition is not satisfied</param>
        /// <returns>null able long value</returns>
        public static long? NullIfDefault(this long? inputValue, long defaultValue = default(long), bool overallCondition = true)
        {
            return overallCondition
                       ? (inputValue == defaultValue ? null : inputValue)
                       : null;
        }

        /// <summary>
        /// return specified default value if input is null, otherwise the original value
        /// </summary>
        /// <param name="inputValue">the input value</param>
        /// <param name="defaultValue">default value</param>
        /// <param name="overallCondition">return default if overall condition is not satisfied</param>
        /// <returns>long value</returns>
        public static long DefaultIfNull(this long? inputValue, long defaultValue = default(long), bool overallCondition = true)
        {
            return overallCondition
                       ? (inputValue == null ? defaultValue : inputValue.Value)
                       : defaultValue;
        }
    }
}

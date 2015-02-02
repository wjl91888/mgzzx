using System;
using System.Data;
using System.Data.Linq;
using System.Data.SqlTypes;
using System.IO;

namespace RICH.Common.DB
{
    public static class DataTableExtension
    {
        private const string ReplaceStringInNumber = @"""";
        public static Byte[] ReadBytesNullable(this DataRow dr, string name)
        {
            if (!dr.ContainsColumn(name))
            {
                return null;
            }
            var ordinal = dr[name];
            return dr.IsDBNull(ordinal) ? null : (Byte[])ordinal;
        }

        public static long ReadBigInt(this DataRow dr, string name, long valueIfNull)
        {
            dr.ValidateColumnExistance(name);
            var ordinal = dr[name];
            return dr.IsDBNull(ordinal) ? valueIfNull : Int64.Parse(ordinal.ToString().PrepareConvertToNumeric());
        }

        public static long ReadBigInt(this DataRow dr, string name)
        {
            dr.ValidateColumnExistance(name);
            var ordinal = dr[name];
            dr.ValidateNullValue(ordinal, name);
            return Int64.Parse(ordinal.ToString().PrepareConvertToNumeric());
        }

        public static SqlInt64 ReadSqlInt64(this DataRow dr, string name)
        {
            dr.ValidateColumnExistance(name);
            var ordinal = dr[name];
            return dr.IsDBNull(ordinal) ? SqlInt64.Null : Int64.Parse(ordinal.ToString().PrepareConvertToNumeric());
        }

        public static long? ReadBigIntNullable(this DataRow dr, string name)
        {
            if (!dr.ContainsColumn(name))
            {
                return null;
            }
            var ordinal = dr[name];
            return dr.IsDBNull(ordinal) ? null : (long?)Int64.Parse(ordinal.ToString().PrepareConvertToNumeric());
        }

        public static int ReadInt32(this DataRow dr, string name, int valueIfNull)
        {
            dr.ValidateColumnExistance(name);
            var ordinal = dr[name];
            return dr.IsDBNull(ordinal) ? valueIfNull : Int32.Parse(ordinal.ToString().PrepareConvertToNumeric());
        }

        public static int ReadInt32(this DataRow dr, string name)
        {
            dr.ValidateColumnExistance(name);
            var ordinal = dr[name];
            dr.ValidateNullValue(ordinal, name);
            return Int32.Parse(ordinal.ToString().PrepareConvertToNumeric());
        }

        public static SqlInt32 ReadSqlInt32(this DataRow dr, string name)
        {
            dr.ValidateColumnExistance(name);
            var ordinal = dr[name];
            return dr.IsDBNull(ordinal) ? SqlInt32.Null : Int32.Parse(ordinal.ToString().PrepareConvertToNumeric());
        }

        public static int? ReadInt32Nullable(this DataRow dr, string name)
        {
            if (!dr.ContainsColumn(name))
            {
                return null;
            }
            var ordinal = dr[name];
            return dr.IsDBNull(ordinal) ? null : (int?)Int32.Parse(ordinal.ToString().PrepareConvertToNumeric());
        }

        public static Int16 ReadInt16(this DataRow dr, string name, Int16 valueIfNull)
        {
            dr.ValidateColumnExistance(name);
            var ordinal = dr[name];
            return dr.IsDBNull(ordinal) ? valueIfNull : Int16.Parse(ordinal.ToString().PrepareConvertToNumeric());
        }

        public static Int16? ReadInt16Nullable(this DataRow dr, string name)
        {
            if (!dr.ContainsColumn(name))
            {
                return null;
            }
            var ordinal = dr[name];
            return dr.IsDBNull(ordinal) ? null : (Int16?)Int16.Parse(ordinal.ToString().PrepareConvertToNumeric());
        }

        public static Int16 ReadInt16(this DataRow dr, string name)
        {
            dr.ValidateColumnExistance(name);
            var ordinal = dr[name];
            dr.ValidateNullValue(ordinal, name);
            return Int16.Parse(ordinal.ToString());
        }

        public static SqlInt16 ReadSqlInt16(this DataRow dr, string name)
        {
            dr.ValidateColumnExistance(name);
            var ordinal = dr[name];
            return dr.IsDBNull(ordinal) ? SqlInt16.Null : Int16.Parse(ordinal.ToString().PrepareConvertToNumeric());
        }

        public static float ReadFloat(this DataRow dr, string name)
        {
            dr.ValidateColumnExistance(name);
            var ordinal = dr[name];
            dr.ValidateNullValue(ordinal, name);
            return float.Parse(ordinal.ToString());
        }

        public static SqlSingle ReadSqlFloat(this DataRow dr, string name)
        {
            dr.ValidateColumnExistance(name);
            var ordinal = dr[name];
            return dr.IsDBNull(ordinal) ? SqlSingle.Null : float.Parse(ordinal.ToString().PrepareConvertToNumeric());
        }

        public static float? ReadFloatNullable(this DataRow dr, string name)
        {
            if (!dr.ContainsColumn(name))
            {
                return null;
            }
            var ordinal = dr[name];
            return dr.IsDBNull(ordinal) ? null : (float?)float.Parse(ordinal.ToString().PrepareConvertToNumeric());
        }

        public static float ReadFolat(this DataRow dr, string name, float valueIfNull)
        {
            dr.ValidateColumnExistance(name);
            var ordinal = dr[name];
            return dr.IsDBNull(ordinal) ? valueIfNull : float.Parse(ordinal.ToString().PrepareConvertToNumeric());
        }


        public static decimal ReadDecimal(this DataRow dr, string name, decimal valueIfNull)
        {
            dr.ValidateColumnExistance(name);
            var ordinal = dr[name];
            return dr.IsDBNull(ordinal) ? valueIfNull : decimal.Parse(ordinal.ToString().PrepareConvertToNumeric());
        }

        public static decimal? ReadDecimalNullable(this DataRow dr, string name)
        {
            if (!dr.ContainsColumn(name))
            {
                return null;
            }
            var ordinal = dr[name];
            return dr.IsDBNull(ordinal) ? null : (decimal?)decimal.Parse(ordinal.ToString().PrepareConvertToNumeric());
        }

        public static decimal ReadDecimal(this DataRow dr, string name)
        {
            dr.ValidateColumnExistance(name);
            var ordinal = dr[name];
            dr.ValidateNullValue(ordinal, name);
            return decimal.Parse(ordinal.ToString().PrepareConvertToNumeric());
        }

        public static SqlDecimal ReadSqlDecimal(this DataRow dr, string name)
        {
            dr.ValidateColumnExistance(name);
            var ordinal = dr[name];
            return dr.IsDBNull(ordinal) ? SqlDecimal.Null : decimal.Parse(ordinal.ToString().PrepareConvertToNumeric());
        }

        public static DateTime ReadDateTime(this DataRow dr, string name, DateTime valueIfNull)
        {
            dr.ValidateColumnExistance(name);
            var ordinal = dr[name];
            return dr.IsDBNull(ordinal) ? valueIfNull : DateTime.Parse(ordinal.ToString());
        }

        public static DateTime? ReadDateTimeNullable(this DataRow dr, string name)
        {
            if (!dr.ContainsColumn(name))
            {
                return null;
            }
            var ordinal = dr[name];
            return dr.IsDBNull(ordinal) ? null : (DateTime?)DateTime.Parse(ordinal.ToString());
        }

        public static DateTime ReadDateTime(this DataRow dr, string name)
        {
            dr.ValidateColumnExistance(name);
            var ordinal = dr[name];
            dr.ValidateNullValue(ordinal, name);
            return DateTime.Parse(ordinal.ToString());
        }

        public static SqlDateTime ReadSqlDateTime(this DataRow dr, string name)
        {
            if (!dr.ContainsColumn(name))
            {
                return SqlDateTime.Null;
            }
            var ordinal = dr[name];
            return dr.IsDBNull(ordinal) ? SqlDateTime.Null : DateTime.Parse(ordinal.ToString());
        }

        public static string ReadString(this DataRow dr, string name, string valueIfNull)
        {
            if (!dr.ContainsColumn(name))
            {
                return valueIfNull;
            }
            var ordinal = dr[name];
            return dr.IsDBNull(ordinal) ? valueIfNull : ordinal.ToString();
        }

        public static string ReadString(this DataRow dr, string name)
        {
            if (!dr.ContainsColumn(name))
            {
                return null;
            }
            var ordinal = dr[name];
            return dr.IsDBNull(ordinal) ? null : ordinal.ToString();
        }

        public static SqlString ReadSqlString(this DataRow dr, string name)
        {
            if (!dr.ContainsColumn(name))
            {
                return null;
            }
            var ordinal = dr[name];
            return dr.IsDBNull(ordinal) ? SqlString.Null : ordinal.ToString();
        }

        public static string SafeReadString(this DataRow dr, string name)
        {
            if (!dr.ContainsColumn(name))
            {
                return null;
            }
            var ordinal = dr[name];
            if (dr.IsDBNull(ordinal))
            {
                return null;
            }
            var target = ordinal;
            return target != null ? target.ToString() : null;
        }

        public static Guid ReadGuid(this DataRow dr, string name, Guid valueIfNull)
        {
            dr.ValidateColumnExistance(name);
            var ordinal = dr[name];
            return dr.IsDBNull(ordinal) ? valueIfNull : Guid.Parse(ordinal.ToString());
        }

        public static Guid ReadGuid(this DataRow dr, string name)
        {
            dr.ValidateColumnExistance(name);
            var ordinal = dr[name];
            dr.ValidateNullValue(ordinal, name);
            return Guid.Parse(ordinal.ToString());
        }

        public static SqlGuid ReadSqlGuid(this DataRow dr, string name)
        {
            dr.ValidateColumnExistance(name);
            var ordinal = dr[name];
            return dr.IsDBNull(ordinal) ? SqlGuid.Null : Guid.Parse(ordinal.ToString());
        }

        public static Guid? ReadGuidNullable(this DataRow dr, string name)
        {
            if (!dr.ContainsColumn(name))
            {
                return null;
            }
            var ordinal = dr[name];
            return dr.IsDBNull(ordinal) ? null : (Guid?)Guid.Parse(ordinal.ToString());
        }

        public static bool? ReadBooleanNullable(this DataRow dr, string name)
        {
            if (!dr.ContainsColumn(name))
            {
                return null;
            }
            var ordinal = dr[name];
            return dr.IsDBNull(ordinal) ? (bool?)null : bool.Parse(ordinal.ToString());
        }

        public static bool ReadBoolean(this DataRow dr, string name, bool valueIfNull)
        {
            if (!dr.ContainsColumn(name))
            {
                return valueIfNull;
            }
            var ordinal = dr[name];
            return dr.IsDBNull(ordinal) ? valueIfNull : bool.Parse(ordinal.ToString());
        }

        public static bool ReadBoolean(this DataRow dr, string name)
        {
            dr.ValidateColumnExistance(name);
            var ordinal = dr[name];
            dr.ValidateNullValue(ordinal, name);
            return bool.Parse(ordinal.ToString());
        }

        public static SqlBoolean ReadSqlBoolean(this DataRow dr, string name)
        {
            dr.ValidateColumnExistance(name);
            var ordinal = dr[name];
            return dr.IsDBNull(ordinal) ? SqlBoolean.Null : bool.Parse(ordinal.ToString());
        }

        public static double ReadDouble(this DataRow dr, string name, double valueIfNull)
        {
            dr.ValidateColumnExistance(name);
            var ordinal = dr[name];
            return dr.IsDBNull(ordinal) ? valueIfNull : double.Parse(ordinal.ToString().PrepareConvertToNumeric());
        }

        public static double ReadDouble(this DataRow dr, string name)
        {
            dr.ValidateColumnExistance(name);
            var ordinal = dr[name];
            dr.ValidateNullValue(ordinal, name);
            return double.Parse(ordinal.ToString().PrepareConvertToNumeric());
        }

        public static SqlDouble ReadSqlDouble(this DataRow dr, string name)
        {
            dr.ValidateColumnExistance(name);
            var ordinal = dr[name];
            return dr.IsDBNull(ordinal) ? SqlDouble.Null : double.Parse(ordinal.ToString().PrepareConvertToNumeric());
        }

        public static double? ReadDoubleNullable(this DataRow dr, string name)
        {
            if (!dr.ContainsColumn(name))
            {
                return null;
            }
            var ordinal = dr[name];
            return dr.IsDBNull(ordinal) ? null : (double?)double.Parse(ordinal.ToString().PrepareConvertToNumeric());
        }

        public static object ReadValue(this DataRow dr, string name)
        {
            if (!dr.ContainsColumn(name))
            {
                return null;
            }
            var ordinal = dr[name];
            return dr.IsDBNull(ordinal) ? null : ordinal;
        }

        public static SqlBinary ReadSqlBinary(this DataRow dr, string name)
        {
            dr.ValidateColumnExistance(name);
            return (SqlBinary)ReadValue(dr, name);
        }

        public static TEnum ReadEnum<TEnum>(this DataRow dr, string name)
        {
            var val = dr.ReadInt32(name);
            var values = Enum.GetValues(typeof(TEnum));
            foreach (var item in values)
            {
                if (val.CompareTo((int)item) == 0)
                {
                    return (TEnum)item;
                }
            }
            throw new NotSupportedException("cannot convert source value");
        }

        public static bool ContainsColumn(this DataRow dr, string name)
        {
            try
            {
                var value = dr[name];
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static void ValidateColumnExistance(this DataRow dr, string name)
        {
            if (!dr.ContainsColumn(name))
            {
                throw new InvalidDataException("The result set does not contain a column named '{0}'".FormatInvariantCulture(name));
            }
        }

        public static void ValidateNullValue(this DataRow dr, object ordinal, string columnName)
        {
            if (dr.IsDBNull(ordinal))
            {
                throw new InvalidDataException("The result data of column named '{0}' is null".FormatInvariantCulture(columnName));
            }
        }

        public static bool IsDBNull(this DataRow dr, object ordinal)
        {
            if (ordinal == null)
            {
                return true;
            }
            else if (ordinal == DBNull.Value)
            {
                return true;
            }
            else if (ordinal.ToString().IsHtmlNullOrWiteSpace())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

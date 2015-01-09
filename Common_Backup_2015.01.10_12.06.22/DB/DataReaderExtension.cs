using System;
using System.Data;
using System.Data.Linq;
using System.Data.SqlTypes;
using System.IO;

namespace RICH.Common.DB
{
    public static class DataReaderExtension
    {

        public static Byte[] ReadBytesNullable(this IDataReader reader, string name)
        {
            if (!reader.ContainsColumn(name))
            {
                return null;
            }
            var ordinal = reader.GetOrdinal(name);
            return reader.IsDBNull(ordinal) ? null : (Byte[])reader.GetValue(ordinal);
        }

        public static long ReadBigInt(this IDataReader reader, string name, long valueIfNull)
        {
            reader.ValidateColumnExistance(name);
            var ordinal = reader.GetOrdinal(name);
            return reader.IsDBNull(ordinal) ? valueIfNull : reader.GetInt64(ordinal);
        }

        public static long ReadBigInt(this IDataReader reader, string name)
        {
            reader.ValidateColumnExistance(name);
            var ordinal = reader.GetOrdinal(name);
            reader.ValidateNullValue(ordinal, name);
            return reader.GetInt64(ordinal);
        }

        public static SqlInt64 ReadSqlInt64(this IDataReader reader, string name)
        {
            reader.ValidateColumnExistance(name);
            var ordinal = reader.GetOrdinal(name);
            return reader.IsDBNull(ordinal) ? SqlInt64.Null : reader.GetInt64(ordinal);
        }

        public static long? ReadBigIntNullable(this IDataReader reader, string name)
        {
            if (!reader.ContainsColumn(name))
            {
                return null;
            }
            var ordinal = reader.GetOrdinal(name);
            return reader.IsDBNull(ordinal) ? null : (long?)reader.GetInt64(ordinal);
        }

        public static int ReadInt32(this IDataReader reader, string name, int valueIfNull)
        {
            reader.ValidateColumnExistance(name);
            var ordinal = reader.GetOrdinal(name);
            return reader.IsDBNull(ordinal) ? valueIfNull : reader.GetInt32(ordinal);
        }

        public static int ReadInt32(this IDataReader reader, string name)
        {
            reader.ValidateColumnExistance(name);
            var ordinal = reader.GetOrdinal(name);
            reader.ValidateNullValue(ordinal, name);
            return reader.GetInt32(ordinal);
        }

        public static SqlInt32 ReadSqlInt32(this IDataReader reader, string name)
        {
            reader.ValidateColumnExistance(name);
            var ordinal = reader.GetOrdinal(name);
            return reader.IsDBNull(ordinal) ? SqlInt32.Null : reader.GetInt32(ordinal);
        }

        public static int? ReadInt32Nullable(this IDataReader reader, string name)
        {
            if (!reader.ContainsColumn(name))
            {
                return null;
            }
            var ordinal = reader.GetOrdinal(name);
            return reader.IsDBNull(ordinal) ? null : (int?)reader.GetInt32(ordinal);
        }

        public static Int16 ReadInt16(this IDataReader reader, string name, Int16 valueIfNull)
        {
            reader.ValidateColumnExistance(name);
            var ordinal = reader.GetOrdinal(name);
            return reader.IsDBNull(ordinal) ? valueIfNull : reader.GetInt16(ordinal);
        }

        public static Int16? ReadInt16Nullable(this IDataReader reader, string name)
        {
            if (!reader.ContainsColumn(name))
            {
                return null;
            }
            var ordinal = reader.GetOrdinal(name);
            return reader.IsDBNull(ordinal) ? null : (Int16?)reader.GetInt16(ordinal);
        }

        public static Int16 ReadInt16(this IDataReader reader, string name)
        {
            reader.ValidateColumnExistance(name);
            var ordinal = reader.GetOrdinal(name);
            reader.ValidateNullValue(ordinal, name);
            return reader.GetInt16(ordinal);
        }

        public static SqlInt16 ReadSqlInt16(this IDataReader reader, string name)
        {
            reader.ValidateColumnExistance(name);
            var ordinal = reader.GetOrdinal(name);
            return reader.IsDBNull(ordinal) ? SqlInt16.Null : reader.GetInt16(ordinal);
        }

        public static float ReadFloat(this IDataReader reader, string name)
        {
            reader.ValidateColumnExistance(name);
            var ordinal = reader.GetOrdinal(name);
            reader.ValidateNullValue(ordinal, name);
            return reader.GetFloat(ordinal);
        }

        public static SqlSingle ReadSqlFloat(this IDataReader reader, string name)
        {
            reader.ValidateColumnExistance(name);
            var ordinal = reader.GetOrdinal(name);
            return reader.IsDBNull(ordinal) ? SqlSingle.Null : reader.GetFloat(ordinal);
        }

        public static float? ReadFloatNullable(this IDataReader reader, string name)
        {
            if (!reader.ContainsColumn(name))
            {
                return null;
            }
            var ordinal = reader.GetOrdinal(name);
            return reader.IsDBNull(ordinal) ? null : (float?)reader.GetFloat(ordinal);
        }

        public static float ReadFolat(this IDataReader reader, string name, float valueIfNull)
        {
            reader.ValidateColumnExistance(name);
            var ordinal = reader.GetOrdinal(name);
            return reader.IsDBNull(ordinal) ? valueIfNull : reader.GetFloat(ordinal);
        }


        public static decimal ReadDecimal(this IDataReader reader, string name, decimal valueIfNull)
        {
            reader.ValidateColumnExistance(name);
            var ordinal = reader.GetOrdinal(name);
            return reader.IsDBNull(ordinal) ? valueIfNull : reader.GetDecimal(ordinal);
        }

        public static decimal? ReadDecimalNullable(this IDataReader reader, string name)
        {
            if (!reader.ContainsColumn(name))
            {
                return null;
            }
            var ordinal = reader.GetOrdinal(name);
            return reader.IsDBNull(ordinal) ? null : (decimal?)reader.GetDecimal(ordinal);
        }

        public static decimal ReadDecimal(this IDataReader reader, string name)
        {
            reader.ValidateColumnExistance(name);
            var ordinal = reader.GetOrdinal(name);
            reader.ValidateNullValue(ordinal, name);
            return reader.GetDecimal(ordinal);
        }

        public static SqlDecimal ReadSqlDecimal(this IDataReader reader, string name)
        {
            reader.ValidateColumnExistance(name);
            var ordinal = reader.GetOrdinal(name);
            return reader.IsDBNull(ordinal) ? SqlDecimal.Null : reader.GetDecimal(ordinal);
        }

        public static DateTime ReadDateTime(this IDataReader reader, string name, DateTime valueIfNull)
        {
            reader.ValidateColumnExistance(name);
            var ordinal = reader.GetOrdinal(name);
            return reader.IsDBNull(ordinal) ? valueIfNull : reader.GetDateTime(ordinal);
        }

        public static DateTime? ReadDateTimeNullable(this IDataReader reader, string name)
        {
            if (!reader.ContainsColumn(name))
            {
                return null;
            }
            var ordinal = reader.GetOrdinal(name);
            return reader.IsDBNull(ordinal) ? null : (DateTime?)reader.GetDateTime(ordinal);
        }

        public static DateTime ReadDateTime(this IDataReader reader, string name)
        {
            reader.ValidateColumnExistance(name);
            var ordinal = reader.GetOrdinal(name);
            reader.ValidateNullValue(ordinal, name);
            return reader.GetDateTime(ordinal);
        }

        public static SqlDateTime ReadSqlDateTime(this IDataReader reader, string name)
        {
            if (!reader.ContainsColumn(name))
            {
                return SqlDateTime.Null;
            }
            var ordinal = reader.GetOrdinal(name);
            return reader.IsDBNull(ordinal) ? SqlDateTime.Null : reader.GetDateTime(ordinal);
        }

        public static string ReadString(this IDataReader reader, string name, string valueIfNull)
        {
            if (!reader.ContainsColumn(name))
            {
                return valueIfNull;
            }
            var ordinal = reader.GetOrdinal(name);
            return reader.IsDBNull(ordinal) ? valueIfNull : reader.GetString(ordinal);
        }

        public static string ReadString(this IDataReader reader, string name)
        {
            if (!reader.ContainsColumn(name))
            {
                return null;
            }
            var ordinal = reader.GetOrdinal(name);
            return reader.IsDBNull(ordinal) ? null : reader.GetString(ordinal);
        }

        public static SqlString ReadSqlString(this IDataReader reader, string name)
        {
            if (!reader.ContainsColumn(name))
            {
                return null;
            }
            var ordinal = reader.GetOrdinal(name);
            return reader.IsDBNull(ordinal) ? SqlString.Null : reader.GetString(ordinal);
        }

        public static string SafeReadString(this IDataReader reader, string name)
        {
            if (!reader.ContainsColumn(name))
            {
                return null;
            }
            var ordinal = reader.GetOrdinal(name);
            if (reader.IsDBNull(ordinal))
            {
                return null;
            }
            var target = reader.GetValue(ordinal);
            return target != null ? target.ToString() : null;
        }

        public static Guid ReadGuid(this IDataReader reader, string name, Guid valueIfNull)
        {
            reader.ValidateColumnExistance(name);
            var ordinal = reader.GetOrdinal(name);
            return reader.IsDBNull(ordinal) ? valueIfNull : reader.GetGuid(ordinal);
        }

        public static Guid ReadGuid(this IDataReader reader, string name)
        {
            reader.ValidateColumnExistance(name);
            var ordinal = reader.GetOrdinal(name);
            reader.ValidateNullValue(ordinal, name);
            return reader.GetGuid(ordinal);
        }

        public static SqlGuid ReadSqlGuid(this IDataReader reader, string name)
        {
            reader.ValidateColumnExistance(name);
            var ordinal = reader.GetOrdinal(name);
            return reader.IsDBNull(ordinal) ? SqlGuid.Null : reader.GetGuid(ordinal);
        }

        public static Guid? ReadGuidNullable(this IDataReader reader, string name)
        {
            if (!reader.ContainsColumn(name))
            {
                return null;
            }
            var ordinal = reader.GetOrdinal(name);
            return reader.IsDBNull(ordinal) ? null : (Guid?)reader.GetGuid(ordinal);
        }

        public static bool? ReadBooleanNullable(this IDataReader reader, string name)
        {
            if (!reader.ContainsColumn(name))
            {
                return null;
            }
            var ordinal = reader.GetOrdinal(name);
            return reader.IsDBNull(ordinal) ? (bool?) null : reader.GetBoolean(ordinal);
        }

        public static bool ReadBoolean(this IDataReader reader, string name, bool valueIfNull)
        {
            if (!reader.ContainsColumn(name))
            {
                return valueIfNull;
            }
            var ordinal = reader.GetOrdinal(name);
            return reader.IsDBNull(ordinal) ? valueIfNull : reader.GetBoolean(ordinal);
        }

        public static bool ReadBoolean(this IDataReader reader, string name)
        {
            reader.ValidateColumnExistance(name);
            var ordinal = reader.GetOrdinal(name);
            reader.ValidateNullValue(ordinal, name);
            return reader.GetBoolean(ordinal);
        }

        public static SqlBoolean ReadSqlBoolean(this IDataReader reader, string name)
        {
            reader.ValidateColumnExistance(name);
            var ordinal = reader.GetOrdinal(name);
            return reader.IsDBNull(ordinal) ? SqlBoolean.Null : reader.GetBoolean(ordinal);
        }

        public static double ReadDouble(this IDataReader reader, string name, double valueIfNull)
        {
            reader.ValidateColumnExistance(name);
            var ordinal = reader.GetOrdinal(name);
            return reader.IsDBNull(ordinal) ? valueIfNull : reader.GetDouble(ordinal);
        }

        public static double ReadDouble(this IDataReader reader, string name)
        {
            reader.ValidateColumnExistance(name);
            var ordinal = reader.GetOrdinal(name);
            reader.ValidateNullValue(ordinal, name);
            return reader.GetDouble(ordinal);
        }

        public static SqlDouble ReadSqlDouble(this IDataReader reader, string name)
        {
            reader.ValidateColumnExistance(name);
            var ordinal = reader.GetOrdinal(name);
            return reader.IsDBNull(ordinal) ? SqlDouble.Null : reader.GetDouble(ordinal);
        }

        public static double? ReadDoubleNullable(this IDataReader reader, string name)
        {
            if (!reader.ContainsColumn(name))
            {
                return null;
            }
            var ordinal = reader.GetOrdinal(name);
            return reader.IsDBNull(ordinal) ? null : (double?)reader.GetDouble(ordinal);
        }

        public static object ReadValue(this IDataReader reader, string name)
        {
            if (!reader.ContainsColumn(name))
            {
                return null;
            }
            var ordinal = reader.GetOrdinal(name);
            return reader.IsDBNull(ordinal) ? null : reader.GetValue(ordinal);
        }

        public static SqlBinary ReadSqlBinary(this IDataReader reader, string name)
        {
            reader.ValidateColumnExistance(name);
            var ordinal = reader.GetOrdinal(name);
            return (SqlBinary)ReadValue(reader, name);
        }

        public static TEnum ReadEnum<TEnum>(this IDataReader reader, string name)
        {
            var val = reader.ReadInt32(name);
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

        public static bool ContainsColumn(this IDataReader reader, string name)
        {
            for (var i = 0; i < reader.FieldCount; i++)
            {
                if (reader.GetName(i).Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        public static void ValidateColumnExistance(this IDataReader reader, string name)
        {
            if (!reader.ContainsColumn(name))
            {
                throw new InvalidDataException("The result set does not contain a column named '{0}'".FormatInvariantCulture(name));
            }
        }

        public static void ValidateNullValue(this IDataReader reader, int ordinal, string columnName)
        {
            if (reader.IsDBNull(ordinal))
            {
                throw new InvalidDataException("The result data of column named '{0}' is null".FormatInvariantCulture(columnName));
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.Helpers
{
    /// <summary>
    /// The System Types Converter
    /// </summary>
    public static class SystemTypesConvert
    {
        /// <summary>
        /// To the SQL database type string.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        /// ConvertToDbType
        public static string ConvertToDbType(this Type type)
        {
            string stringType = null;

            if (type.GetType() == typeof(long) || type.GetType() == typeof(long?)) stringType = "bigint";
            if (type.GetType() == typeof(int) || type.GetType() == typeof(int?)) stringType = "int";
            if (type.GetType() == typeof(short) || type.GetType() == typeof(short?)) stringType = "smallint";
            if (type.GetType() == typeof(byte) || type.GetType() == typeof(byte?)) stringType = "tinyint";
            if (type.GetType() == typeof(decimal) || type.GetType() == typeof(decimal?)) stringType = "decimal";
            if (type.GetType() == typeof(float) || type.GetType() == typeof(float?)) stringType = "real";
            if (type.GetType() == typeof(bool) || type.GetType() == typeof(bool?)) stringType = "bit";
            if (type.GetType() == typeof(string)) stringType = "nvarchar";
            if (type.GetType() == typeof(char)) stringType = "char";
            if (type.GetType() == typeof(Guid) || type.GetType() == typeof(Guid?)) stringType = "uniqueidentifier";
            if (type.GetType() == typeof(DateTimeOffset) || type.GetType() == typeof(DateTimeOffset?)) stringType = "datetimeoffset";
            if (type.GetType() == typeof(DateTime) || type.GetType() == typeof(DateTime?)) stringType = "datetime";

            return stringType;
        }

        /// <summary>
        /// To the SQL database type string.
        /// </summary>
        /// <param name="sqlDbType">Type of the SQL database.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static string ConvertToDbType(this SqlDbType sqlDbType)
        {
            string stringType = null;

            switch (sqlDbType)
            {
                case SqlDbType.BigInt: stringType = "bigint"; break;
                case SqlDbType.Binary: stringType = "binary"; break;
                case SqlDbType.Bit: stringType = "bit"; break;
                case SqlDbType.Char: stringType = "char"; break;
                case SqlDbType.Date: stringType = "date"; break;
                case SqlDbType.DateTime: stringType = "datetime"; break;
                case SqlDbType.DateTime2: stringType = "datetime2"; break;
                case SqlDbType.DateTimeOffset: stringType = "datetimeoffset"; break;
                case SqlDbType.Decimal: stringType = "decimal"; break;
                case SqlDbType.Float: stringType = "float"; break;
                case SqlDbType.Image: stringType = "image"; break;
                case SqlDbType.Int: stringType = "int"; break;
                case SqlDbType.Money: stringType = "money"; break;
                case SqlDbType.NChar: stringType = "nchar"; break;
                case SqlDbType.NText: stringType = "ntext"; break;
                case SqlDbType.NVarChar: stringType = "nvarchar"; break;
                case SqlDbType.Real: stringType = "real"; break;
                case SqlDbType.SmallDateTime: stringType = "smalldatetime"; break;
                case SqlDbType.SmallInt: stringType = "smallint"; break;
                case SqlDbType.SmallMoney: stringType = "smallmoney"; break;
                case SqlDbType.Structured: stringType = "structured"; break;
                case SqlDbType.Text: stringType = "text"; break;
                case SqlDbType.Time: stringType = "time"; break;
                case SqlDbType.Timestamp: stringType = "timestamp"; break;
                case SqlDbType.TinyInt: stringType = "tinyint"; break;
                case SqlDbType.Udt: stringType = "udt"; break;
                case SqlDbType.UniqueIdentifier: stringType = "uniqueidentifier"; break;
                case SqlDbType.VarBinary: stringType = "varbinary"; break;
                case SqlDbType.VarChar: stringType = "varchar"; break;
                case SqlDbType.Variant: stringType = "variant"; break;
                case SqlDbType.Xml: stringType = "xml"; break;

                default:
                    stringType = null;
                    throw new ArgumentException();

            }
            return stringType;
        }
    }
}

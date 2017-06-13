using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PNGSample
{
    /// <summary>
    /// 指定したエンディアンでバイト列と基本データ型の変換ができるクラス
    /// </summary>
    public static class BitConverterEx
    {
        /// <summary>
        /// バイト配列内の指定位置にある1バイトから変換されたBooleanを返す
        /// </summary>
        /// <param name="value">バイト配列</param>
        /// <param name="startIndex">value 内の開始位置</param>
        /// <param name="endian">エンディアン</param>
        /// <returns></returns>
        public static bool ToBoolean(byte[] value, uint startIndex = 0)
        {
            byte[] sub = GetSubArray(value, startIndex, sizeof(bool));
            return BitConverter.ToBoolean(Reverse(sub), 0);
        }
        /// <summary>
        /// バイト配列内の指定位置にある2バイトから変換されたUnicode文字を返す
        /// </summary>
        /// <param name="value">バイト配列</param>
        /// <param name="startIndex">value 内の開始位置</param>
        /// <param name="endian">エンディアン</param>
        /// <returns></returns>
        public static char ToChar(byte[] value, uint startIndex = 0)
        {
            byte[] sub = GetSubArray(value, startIndex, sizeof(char));
            return BitConverter.ToChar(Reverse(sub), 0);
        }
        /// <summary>
        /// バイト配列内の指定位置にある2バイトから変換された16ビット符号付き整数を返す
        /// </summary>
        /// <param name="value">バイト配列</param>
        /// <param name="startIndex">value 内の開始位置</param>
        /// <param name="endian">エンディアン</param>
        /// <returns></returns>
        public static short ToInt16(byte[] value, uint startIndex = 0)
        {
            byte[] sub = GetSubArray(value, startIndex, sizeof(short));
            return BitConverter.ToInt16(Reverse(sub), 0);
        }
        /// <summary>
        /// バイト配列内の指定位置にある8バイトから変換された16ビット符号無し整数を返す
        /// </summary>
        /// <param name="value">バイト配列</param>
        /// <param name="startIndex">value 内の開始位置</param>
        /// <param name="endian">エンディアン</param>
        /// <returns></returns>
        public static ushort ToUInt16(byte[] value, uint startIndex = 0)
        {
            byte[] sub = GetSubArray(value, startIndex, sizeof(ushort));
            return BitConverter.ToUInt16(Reverse(sub), 0);
        }
        /// <summary>
        /// バイト配列内の指定位置にある4バイトから変換された32ビット符号付き整数を返す
        /// </summary>
        /// <param name="value">バイト配列</param>
        /// <param name="startIndex">value 内の開始位置</param>
        /// <param name="endian">エンディアン</param>
        /// <returns></returns>
        public static int ToInt32(byte[] value, uint startIndex = 0)
        {
            byte[] sub = GetSubArray(value, startIndex, sizeof(int));
            return BitConverter.ToInt32(Reverse(sub), 0);
        }
        /// <summary>
        /// バイト配列内の指定位置にある4バイトから変換された32ビット符号無し整数を返す
        /// </summary>
        /// <param name="value">バイト配列</param>
        /// <param name="startIndex">value 内の開始位置</param>
        /// <param name="endian">エンディアン</param>
        /// <returns></returns>
        public static uint ToUInt32(byte[] value, uint startIndex = 0)
        {
            byte[] sub = GetSubArray(value, startIndex, sizeof(uint));
            return BitConverter.ToUInt32(Reverse(sub), 0);
        }
        /// <summary>
        /// バイト配列内の指定位置にある8バイトから変換された64ビット符号付き整数を返す
        /// </summary>
        /// <param name="value">バイト配列</param>
        /// <param name="startIndex">value 内の開始位置</param>
        /// <param name="endian">エンディアン</param>
        /// <returns></returns>
        public static long ToInt64(byte[] value, uint startIndex = 0)
        {
            byte[] sub = GetSubArray(value, startIndex, sizeof(long));
            return BitConverter.ToInt64(Reverse(sub), 0);
        }
        /// <summary>
        /// バイト配列内の指定位置にある8バイトから変換された64ビット符号無し整数を返す
        /// </summary>
        /// <param name="value">バイト配列</param>
        /// <param name="startIndex">value 内の開始位置</param>
        /// <param name="endian">エンディアン</param>
        /// <returns></returns>
        public static ulong ToUInt64(byte[] value, uint startIndex = 0)
        {
            byte[] sub = GetSubArray(value, startIndex, sizeof(ulong));
            return BitConverter.ToUInt64(Reverse(sub), 0);
        }
        /// <summary>
        /// バイト配列内の指定位置にある4バイトから変換された32ビット浮動小数点数を返す
        /// </summary>
        /// <param name="value">バイト配列</param>
        /// <param name="startIndex">value 内の開始位置</param>
        /// <param name="endian">エンディアン</param>
        /// <returns></returns>
        public static float ToSingle(byte[] value, uint startIndex = 0)
        {
            byte[] sub = GetSubArray(value, startIndex, sizeof(float));
            return BitConverter.ToSingle(Reverse(sub), 0);
        }
        /// <summary>
        /// バイト配列内の指定位置にある8バイトから変換された64ビット浮動小数点数を返す
        /// </summary>
        /// <param name="value">バイト配列</param>
        /// <param name="startIndex">value 内の開始位置</param>
        /// <param name="endian">エンディアン</param>
        /// <returns></returns>
        public static double ToDouble(byte[] value, uint startIndex = 0)
        {
            byte[] sub = GetSubArray(value, startIndex, sizeof(double));
            return BitConverter.ToDouble(Reverse(sub), 0);
        }

        public static string ToString(byte[] value, uint count, uint startIndex = 0)
        {
            byte[] sub = GetSubArray(value, startIndex, count);
            return Encoding.ASCII.GetString(sub);
        }

        /// <summary>
        /// バイト配列内の指定位置にあるバイト列から構造体に変換する
        /// </summary>
        /// <param name="value">バイト配列</param>
        /// <param name="startIndex">value 内の開始位置</param>
        /// <param name="endian">エンディアン</param>
        /// <returns></returns>
        public static T ToStruct<T>(byte[] value, uint startIndex = 0)
            where T : struct
        {
            return (T)ToStruct(typeof(T), value, startIndex);
        }

        public static byte[] GetBytes(object obj)
        {
            byte[] bytes = null;
            if (obj.GetType().IsArray && obj.GetType().GetElementType() == typeof(byte))
            {
                bytes = (byte[])obj;
            }
            else if (obj is bool b)
            {
                bytes = BitConverter.GetBytes(b);
            }
            else if (obj is char c)
            {
                bytes = BitConverter.GetBytes(c);
            }
            else if (obj is double d)
            {
                bytes = BitConverter.GetBytes(d);
            }
            else if (obj is short s)
            {
                bytes = BitConverter.GetBytes(s);
            }
            else if (obj is int i)
            {
                bytes = BitConverter.GetBytes(i);
            }
            else if (obj is long l)
            {
                bytes = BitConverter.GetBytes(l);
            }
            else if (obj is byte by)
            {
                bytes = new byte[] { by };
            }
            else if (obj is sbyte sb)
            {
                bytes = new byte[] { (byte)sb };
            }
            else if (obj is float f)
            {
                bytes = BitConverter.GetBytes(f);
            }
            else if (obj is ushort us)
            {
                bytes = BitConverter.GetBytes(us);
            }
            else if (obj is uint ui)
            {
                bytes = BitConverter.GetBytes(ui);
            }
            else if (obj is ulong ul)
            {
                bytes = BitConverter.GetBytes(ul);
            }
            else if (obj is string str)
            {
                return Encoding.ASCII.GetBytes(str);
            }
            else
            {
                throw new ArgumentException();
            }

            return Reverse(bytes);
        }
        /// <summary>
        /// バイト配列内の指定位置にあるバイト列から構造体に変換する
        /// </summary>
        /// <param name="value">バイト配列</param>
        /// <param name="startIndex">value 内の開始位置</param>
        /// <param name="endian">エンディアン</param>
        /// <returns></returns>
        public static object ToStruct(Type type, byte[] value, uint startIndex = 0)
        {
            if (!type.IsValueType)
                throw new ArgumentException();

            // プリミティブ型は専用メソッドへ飛ばす
            TypeCode code = Type.GetTypeCode(type);
            switch (code)
            {
                case TypeCode.Boolean:
                    return ToBoolean(value, startIndex);
                case TypeCode.Byte:
                    return value[startIndex];
                case TypeCode.Char:
                    return ToChar(value, startIndex);
                case TypeCode.Double:
                    return ToDouble(value, startIndex);
                case TypeCode.Int16:
                    return ToInt16(value, startIndex);
                case TypeCode.Int32:
                    return ToInt32(value, startIndex);
                case TypeCode.Int64:
                    return ToInt64(value, startIndex);
                case TypeCode.SByte:
                    return value[startIndex];
                case TypeCode.Single:
                    return ToSingle(value, startIndex);
                case TypeCode.UInt16:
                    return ToUInt16(value, startIndex);
                case TypeCode.UInt32:
                    return ToUInt32(value, startIndex);
                case TypeCode.UInt64:
                    return ToUInt64(value, startIndex);
                default:
                    break; // 多分その他のstructなので以下処理する
            }

            // 構造体の全フィールドを取得
            FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            // 型情報から新規インスタンスを生成 (返却値)
            object obj = Activator.CreateInstance(type);
            uint offset = 0;
            foreach (FieldInfo info in fields)
            {
                // フィールドの値をバイト列から1つ取得し、objの同じフィールドに設定
                Type fieldType = info.FieldType;
                if (!fieldType.IsValueType)
                    throw new InvalidOperationException();
                object fieldValue = ToStruct(fieldType, value, startIndex + offset);
                info.SetValue(obj, fieldValue);
                // 次のフィールド値を見るためフィールドのバイトサイズ分進める
                offset += (uint)Marshal.SizeOf(fieldType);
            }

            return obj;
        }

        public static byte[] StructToByte(object obj)
        {
            var type = obj.GetType();
            var fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            var result = new List<byte>();
            foreach (FieldInfo info in fields)
            {
                if (info.FieldType.IsArray && info.FieldType.GetElementType() == typeof(byte))
                {
                    result.AddRange((byte[])info.GetValue(obj));
                }
                else
                {
                    var b = GetBytes(info.GetValue(obj));
                    result.AddRange(b);
                }
            }

            return result.ToArray();
        }

        /// <summary>
        /// バイト配列から一部分を抜き出す
        /// </summary>
        /// <param name="src">バイト配列</param>
        /// <param name="startIndex">value 内の開始位置</param>
        /// <param name="count">切り出すバイト数</param>
        /// <returns></returns>
        public static byte[] GetSubArray(byte[] src, uint startIndex, uint count)
        {
            byte[] dst = new byte[count];
            Array.Copy(src, startIndex, dst, 0, count);
            return dst;
        }

        /// <summary>
        /// エンディアンに従い適切なようにbyte[]を変換
        /// </summary>
        /// <param name="bytes">バイト配列</param>
        /// <param name="endian">エンディアン</param>
        /// <returns></returns>
        private static byte[] Reverse(byte[] bytes)
        {
            if (BitConverter.IsLittleEndian)
                return bytes.Reverse().ToArray();
            else
                return bytes;
        }

        public static uint CalcCrc32(params object[] objs)
        {
            var bytes = new List<byte>();
            foreach (var obj in objs)
            {
                bytes.AddRange(GetBytes(obj));
            }

            return new CRC32().Calc(bytes.ToArray());
        }

    }
}
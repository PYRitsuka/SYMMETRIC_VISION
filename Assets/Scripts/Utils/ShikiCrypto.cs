using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Utils
{
    public static unsafe class ShikiCrypto
    {
        public class ShikiResult
        {
            internal ShikiResult(byte[] a, string b)
            {
                result = a;
                md5 = b;
            }

            private byte[] result;
            private string md5;

            public byte[] Result => result;
            public string MD5 => md5;
            public string StringResult => ByteToString(result);
        }

        public static ShikiResult Encrypt(byte[] origin, byte[] password)
        {
            uint length = (uint)origin.Length;
            IntPtr a = Marshal.UnsafeAddrOfPinnedArrayElement(origin, 0);
            IntPtr b = Marshal.UnsafeAddrOfPinnedArrayElement(password, 0);
            var ret = Encrypt(a, b, length);
            byte[] t = new byte[length];
            Marshal.Copy(ret.result, t, 0, (int)length);
            return new ShikiResult(t, Marshal.PtrToStringAnsi(ret.md5));
        }

        public static ShikiResult Decrypt(byte[] origin, byte[] password)
        {
            uint length = (uint)origin.Length;
            IntPtr a = Marshal.UnsafeAddrOfPinnedArrayElement(origin, 0);
            IntPtr b = Marshal.UnsafeAddrOfPinnedArrayElement(password, 0);
            var ret = Decrypt(a, b, length);
            byte[] t = new byte[length];
            Marshal.Copy(ret.result, t, 0, (int)length);
            return new ShikiResult(t, Marshal.PtrToStringAnsi(ret.md5));
        }

        public static ShikiResult Encrypt(string origin, byte[] password)
        {
            return Encrypt(Encoding.Default.GetBytes(origin), password);
        }

        [Obsolete("NEVER decrypt a string!")]
        public static ShikiResult Decrypt(string origin, byte[] password)
        {
            throw new InvalidOperationException("NEVER decrypt a string!");
            return Decrypt(Encoding.Default.GetBytes(origin), password);
        }

        private static string ByteToString(byte[] bytes)
        {
            return Encoding.Default.GetString(bytes);
        }


        [StructLayout(LayoutKind.Sequential)]
        private struct ShikiReturn
        {
            public IntPtr result;
            public IntPtr md5;
        }
        
#if UNITY_ANDROID && !UNITY_EDITOR
        private const string LIBRARY_NAME = "libShikiCrypto"; 
#else
        private const string LIBRARY_NAME = "ShikiCrypto"; 
#endif

        [DllImport(LIBRARY_NAME, EntryPoint = "Encrypt", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern ShikiReturn Encrypt(IntPtr originCodes, IntPtr password, uint len);
        [DllImport(LIBRARY_NAME, EntryPoint = "Decrypt", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        private static extern ShikiReturn Decrypt(IntPtr originCodes, IntPtr password, uint len);
    }

    public static class FileUtils
    {
        /// <summary>
        /// byte[]转换成Stream
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        private static Stream BytesToStream(byte[] bytes)
        {
            Stream stream = new MemoryStream(bytes);
            return stream;
        }

        /// <summary>
        /// Stream转换成byte[]
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        private static byte[] StreamToBytes(Stream stream)
        {
            byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);
            stream.Seek(0, SeekOrigin.Begin); // 设置当前流的位置为流的开始
            return bytes;
        }

        /// <summary>
        /// 从文件读取Stream，     思路=文件-字节-流
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private static Stream FileToStream(string path)
        {
            FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read); // 打开文件
            byte[] bytes = new byte[fileStream.Length]; // 读取文件的byte[]
            fileStream.Read(bytes, 0, bytes.Length);
            fileStream.Close();
            Stream stream = new MemoryStream(bytes); // 把byte[]转换成Stream
            return stream;
        }

        /// <summary>
        /// 将Stream写入文件    思路=流-字节，文件-写字节
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="path"></param>
        private static void StreamToFile(Stream stream, string path)
        {
            byte[] bytes = new byte[stream.Length]; // 把Stream转换成byte[]
            stream.Read(bytes, 0, bytes.Length);
            stream.Seek(0, SeekOrigin.Begin); // 设置当前流的位置为流的开始
            FileStream fs = new FileStream(path, FileMode.Create); // 把byte[]写入文件
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(bytes);
            bw.Close();
            fs.Close();
        }

        public static byte[] ReadBytes(string path)
        {
            return StreamToBytes(FileToStream(path));
        }

        public static void WriteBytes(string path, byte[] bytes)
        {
            StreamToFile(BytesToStream(bytes), path);
        }
    }
}
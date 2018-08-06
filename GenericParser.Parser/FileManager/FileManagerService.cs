using System;
using System.Collections.Generic;
using System.IO;

namespace GenericParser.FileManager
{
    public static class FileManagerService
    {
        public static IEnumerable<string> ReadAllLinesWithBuffer(string path)
        {
            using (var buffer = new StreamReader(path, System.Text.Encoding.Default))
            {
                while (!buffer.EndOfStream) yield return buffer.ReadLine();

            }
        }

        public static void WriteLineTextWithBuffer(string path, Action<StreamWriter> writeFn)
        {
            using (var bufferWrite = new StreamWriter(path, false, System.Text.Encoding.Default))
                writeFn(bufferWrite);
        }

        public static void ReadLineTextWithBuffer(string path, Action<StreamReader> readFn)
        {
            using (var bufferRead = new StreamReader(path, System.Text.Encoding.Default))
                readFn(bufferRead);
        }
    }
}

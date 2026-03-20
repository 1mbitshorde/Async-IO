using System.IO;
using UnityEngine;

namespace OneM.AsyncIO
{
    /// <summary>
    /// Interface used on objects able to streaming a sequence of bytes.
    /// </summary>
    public interface IStream
    {
        Awaitable WriteAsync(string path, string content);
        Awaitable WriteAsync(Stream stream, string content);
        Awaitable WriteAsync(Stream stream, byte[] bytes);

        Awaitable<string> ReadAsync(string path);
        Awaitable<string> ReadAsync(Stream stream);
        Awaitable<string> ReadAsync(StreamReader reader);
    }
}
using System.IO;
using UnityEngine;

namespace OneM.AsyncIO
{
    /// <summary>
    /// Asynchronously streaming a sequence of bytes.
    /// </summary>
    public sealed class AsynchronousStream : IStream
    {
        public async Awaitable<string> ReadAsync(string path)
        {
            using var reader = new StreamReader(path);
            return await ReadAsync(reader);
        }

        public async Awaitable<string> ReadAsync(Stream stream)
        {
            using var reader = new StreamReader(stream);
            return await ReadAsync(reader);
        }

        public async Awaitable<string> ReadAsync(StreamReader reader) =>
            await reader.ReadToEndAsync();

        public async Awaitable WriteAsync(string path, string content)
        {
            await using var writer = new StreamWriter(path);
            await writer.WriteAsync(content);
        }

        public async Awaitable WriteAsync(Stream stream, string content)
        {
            await using var writer = new StreamWriter(stream);
            await writer.WriteAsync(content);
        }

        public async Awaitable WriteAsync(Stream stream, byte[] bytes) =>
            await stream.WriteAsync(bytes, 0, bytes.Length);
    }
}
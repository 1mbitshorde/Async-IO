using System.IO;
using UnityEngine;

namespace ActionCode.AsyncIO
{
    /// <summary>
    /// Synchronously streaming a sequence of bytes.
    /// </summary>
    public sealed class SynchronousStream : IStream
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

        public async Awaitable<string> ReadAsync(StreamReader reader)
        {
            await Awaitable.NextFrameAsync();
            return reader.ReadToEnd();
        }

        public async Awaitable WriteAsync(string path, string content)
        {
            await Awaitable.NextFrameAsync();
            using var writer = new StreamWriter(path);
            writer.Write(content);
        }

        public async Awaitable WriteAsync(Stream stream, string content)
        {
            await Awaitable.NextFrameAsync();
            using var writer = new StreamWriter(stream);
            writer.Write(content);
        }

        public async Awaitable WriteAsync(Stream stream, byte[] bytes)
        {
            await Awaitable.NextFrameAsync();
            stream.Write(bytes, 0, bytes.Length);
        }
    }
}
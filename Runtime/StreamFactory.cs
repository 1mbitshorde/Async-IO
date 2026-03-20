#if !UNITY_WEBGL || UNITY_EDITOR
#define ASYNCHRONOUS_PLATFORM
#endif

namespace OneM.AsyncIO
{
    /// <summary>
    /// Static factory class for <see cref="IStream"/>.
    /// </summary>
    public static class StreamFactory
    {
        /// <summary>
        /// Creates an <see cref="IStream"/> instance based on the current platform.
        /// <para>
        /// If current platform is <b>WebGL</b>, a <see cref="SynchronousStream"/> 
        /// instance will be returned since it does not support to read/write files 
        /// asynchronously.
        /// </para>
        /// </summary>
        /// <returns>An <see cref="IStream"/> instance</returns>
        public static IStream Create()
        {
#if ASYNCHRONOUS_PLATFORM
            return new AsynchronousStream();
#else
            return new SynchronousStream();
#endif
        }

    }
}
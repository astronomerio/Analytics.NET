using System;
using System.Collections.Generic;
using System.Text;

namespace Segment
{
    public class Analytics
    {
		// REMINDER: don't forget to set Properties.AssemblyInfo.AssemblyVersion as well
		public static string VERSION = "3.0.0";

        /// <summary>
        /// Lock for thread-safety
        /// </summary>
        static readonly object padlock = new object();

        public static Client Client { get; private set; }

        /// <summary>
        /// Initialized the default Segment.io client with your Astronomer app id.
        /// </summary>
        /// <param name="appId"></param>
        public static void Initialize(string appId)
        {
            // avoiding double locking as recommended:
            // http://www.yoda.arachsys.com/csharp/singleton.html
            lock (padlock)
            {
                if (Client == null)
                {
                    Client = new Client(appId);
                }
            }
        }

        /// <summary>
        /// Initialized the default Segment.io client with your Astronomer app id.
        /// </summary>
        /// <param name="appId"></param>
		public static void Initialize(string appId, Config config)
        {
            lock (padlock)
            {
                if (Client == null)
                {
                    Client = new Client(appId, config);
                }
            }
        }

        /// <summary>
        /// Disposes of the current client and allows the creation of a new one
        /// </summary>
        public static void Dispose()
        {
            lock (padlock)
            {
                if (Client != null)
                {
                    Client.Dispose();
                    Client = null;
                }
            }
        }

    }
}

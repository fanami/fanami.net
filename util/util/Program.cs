using System;
using Topshelf;
using System.Configuration;

namespace util
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<Something>(y =>
                {
                    y.ConstructUsing(() => new Something());
                    y.WhenStarted(s => s.Start());
                    y.WhenStopped(s => s.Stop());
                });

                x.RunAsLocalService();
            });
        }
    }

    class Something
    {
        public void Start()
        {
            Show("Yahooooooooo!");
            Show("Starting...{0} - Error: {1}" , DateTime.Now, 1999);
            var testFlag = ConfigurationManager.AppSettings["TestFlag"];
            var log = ConfigurationManager.AppSettings["LogSuccess"];

            CallApi();

            Show("testFlag - " + testFlag);
            Show("log - " + log);
        }

        public void Stop()
        {
            Console.WriteLine("Stopping..." + DateTime.Now);
        }

        private void Show(string msg, params object[] args)
        {
            Console.WriteLine(string.Format(msg, args));
        }

        private string CallApi()
        {

            using (var api = new ExtendedWebClient())
            {
                api.Timeout = 90;
                return api.UploadString("url","json data");
            }
        }
    }
}

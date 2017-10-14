using Newtonsoft.Json;
using System.Net;

namespace SSDeliveries.INET
{
    public class Networker
    {
        private static Networker _instance;
        private static DatabaseHandler _dbHandler;
        private static FTPHandler _ftpHandler;
        private string _contentType;

        public static Networker Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Networker("application/json; charset=utf-8");
                }
                return _instance;
            }

            private set { }
        }

        public DatabaseHandler DBHandler
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new Networker("application/json; charset=utf-8");
                }
                return _dbHandler;
            }
            private set { }
        }

        public FTPHandler FTPHandler
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Networker("application/json; charset=utf-8");
                }
                return _ftpHandler;
            }
            private set { }
        }

        private Networker(string contentType, string ftpHost = "", string ftpUserName = "", string ftpUserPassword = "", string downloadDirectory = "")
        {
            _contentType = contentType;
            _dbHandler = new DatabaseHandler(contentType);
            _ftpHandler = new FTPHandler(ftpHost, ftpUserName, ftpUserPassword, downloadDirectory);
        }

        public bool CheckForInternetConnection()
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    using (client.OpenRead("http://clients3.google.com/generate_204"))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }
    }
}

using Renci.SshNet;
using System.IO;
using System.Threading.Tasks;

namespace SSDeliveries.INET
{
    public class FTPHandler
    {
        private  string _downloadDirectory;

        private string _hostName;
        private string _userName;
        private string _password;

        public FTPHandler(string hostName, string userName, string password, string downloadFileDirectory)
        {
            _hostName = hostName;
            _userName = userName;
            _password = password;
            _downloadDirectory = downloadFileDirectory;
        }

        public async void UploadFile(string filePath, string serverFilePath)
        {
            SftpClient client = new SftpClient(_hostName, _userName, _password);
            client.Connect();
            client.ChangeDirectory(serverFilePath);

            string path = Path.GetFullPath(filePath);

            FileStream sourceStream = new FileStream(filePath, FileMode.Open);
            client.UploadFile(sourceStream, Path.GetFileName(filePath));
            sourceStream.Close();
        }

        public async Task<string> DownloadFile(string serverFilePath, string serverFileName)
        {

            SftpClient client = new SftpClient(_hostName, _userName, _password);
            client.Connect();
            client.ChangeDirectory(serverFilePath);

            if(!Directory.Exists(_downloadDirectory))
            {
                Directory.CreateDirectory(_downloadDirectory);
            }

            using (Stream serverOrderPDF = File.OpenWrite(_downloadDirectory + serverFileName))
            {
                client.DownloadFile(serverFileName, serverOrderPDF);
            }

            return _downloadDirectory + serverFileName;
        }
    }
}

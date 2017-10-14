using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Web;

namespace SSDeliveries.INET
{
    public class DatabaseHandler 
    {
        private string _contentType = "";
        public DatabaseHandler(string contentType)
        {
            _contentType = contentType;
        }

        private WebRequest _insertRequest;
        public void ExecuteInsertStatement(string insertStatementScriptURL, Object itemToInsert)
        {
            string objectAsJSON = JsonConvert.SerializeObject(itemToInsert);
            string objectJSONEncoded = HttpUtility.UrlEncode(objectAsJSON, System.Text.Encoding.UTF8);

            _insertRequest = WebRequest.Create(insertStatementScriptURL + objectJSONEncoded);
            _insertRequest.ContentType = _contentType;
            _insertRequest.BeginGetResponse(new AsyncCallback(FinishInsertWebRequest), null);

        }

        private WebRequest _updateRequest;
        public void ExecuteUpdateStatement(string updateDeliveryStatementScriptURL, Object itemToUpdate)
        {
            string objectAsJson = JsonConvert.SerializeObject(itemToUpdate);
            string objectJSONEncoded = HttpUtility.UrlEncode(objectAsJson, System.Text.Encoding.UTF8);

            _updateRequest = WebRequest.Create(updateDeliveryStatementScriptURL + objectJSONEncoded);
            _updateRequest.ContentType = _contentType;
            _updateRequest.BeginGetResponse(new AsyncCallback(FinishUpdateWebRequest), null);
        }

        private void FinishInsertWebRequest(IAsyncResult result)
        {
            string jsonResponse;
            HttpWebResponse response = (HttpWebResponse)_insertRequest.GetResponse();

            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                jsonResponse = reader.ReadToEnd();
            }
            _insertRequest.EndGetResponse(result);
        }

        private void FinishUpdateWebRequest(IAsyncResult result)
        {
            string jsonResponse;
            HttpWebResponse response = (HttpWebResponse)_updateRequest.GetResponse();

            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                jsonResponse = reader.ReadToEnd();
            }
            _updateRequest.EndGetResponse(result);
        }

        //Delete statement
        public void ExectuteDelete()
        {
        }
    }
}

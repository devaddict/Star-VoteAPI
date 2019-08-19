using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Utilities
{
     public class CustomJson<TEntity>
{
    public int StatusCode { get; set; }
    public string StatusMessage { get; set; }
    public DateTime DateStamp { get; set; }
    public TEntity Result { get; set; }


    public CustomJson() //default contsructor
    {
        //Result = new TEntity();
        StatusCode = (int)HttpStatusCode.PartialContent;
        StatusMessage = "No results";
    }
    public CustomJson(TEntity results) // When data set is available
    {
        if (results != null)
        {
            Result = results;
            StatusCode = 0;
            DateStamp = DateTime.UtcNow;
            StatusMessage = "Saved successfully";
        }
        else
        {
            //Result = null;
            StatusCode = 0;
            DateStamp = DateTime.UtcNow;
            StatusMessage = "Call successful";
        }
    }
    public CustomJson(TEntity results, JsonSTatus jsonStatus) // When data set is available
    {

        Result = results;
        StatusCode = 0;
        DateStamp = DateTime.UtcNow;
        switch (jsonStatus)
        {
            case JsonSTatus.Load:
                StatusMessage = "Loaded successfully";
                break;
            case JsonSTatus.Save:
                StatusMessage = "Saved successfully";
                break;
            case JsonSTatus.Add:
                StatusMessage = "Added successfully";
                break;
            case JsonSTatus.Update:
                StatusMessage = "Saved successfully";
                break;
            case JsonSTatus.Delete:
                StatusMessage = "Deleted successfully";
                break;
            case JsonSTatus.Error:
                StatusMessage = "Error occured";
                StatusCode = -1;
                break;
            case JsonSTatus.NoRecord:
                StatusMessage = "No Record found";
                break;
            case JsonSTatus.GeneratingDocument:
                StatusMessage = "Generating document download";
                break;
            default:
                StatusMessage = "Successful";
                break;
        }

    }

    public CustomJson(string errorMessage) // with error message
    {
        //Result = null;
        StatusCode = -1;
        DateStamp = DateTime.UtcNow;
        StatusMessage = errorMessage;
        StatusMessage = errorMessage;
    }

}

public enum JsonSTatus
{
    Load = 1, Save, Add, Update, Delete, Error, NoRecord, Successful, GeneratingDocument
}
}

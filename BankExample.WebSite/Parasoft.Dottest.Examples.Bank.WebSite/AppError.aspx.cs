using System;
using System.Web;
using System.Web.UI;

public partial class AppError : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpContext context = HttpContext.Current;
        Exception lastError = context.Server.GetLastError();
        if(lastError == null)
        {
            return;
        }
        Exception objErr = lastError.GetBaseException();
        
        string errorMessage = "<b>Error Caught in Page_Error event</b><hr><br>" +
                "<br><b>Error in: </b>"       + Request.Url.ToString() +
                "<br><b>Error Message: </b>"  + objErr.Message.ToString() +
                "<br><b>Stack Trace:</b><br>" + objErr.StackTrace.ToString();
        Response.Write(errorMessage.ToString());
        Server.ClearError();
    }
}
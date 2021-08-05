using System;
using System.Web.Security;
using Parasoft.Dottest.Examples.Bank;
using System.Text;
using System.Text.RegularExpressions;

public partial class Login : System.Web.UI.Page 
{
    private const string LOGIN_REGEX = "[A-Za-z{5,10}";

    protected void Page_Load(object sender, EventArgs e)
    {
        this.LoginBox.Authenticate += LoginBox_Authenticate;
    }

    void LoginBox_Authenticate(object sender, System.Web.UI.WebControls.AuthenticateEventArgs e)
    {
        e.Authenticated = FormsAuthentication.Authenticate(this.LoginBox.UserName, this.LoginBox.Password);
        if (!e.Authenticated)
        {
            
        }
    }

    private bool Validate(string login)
    {
        if (Regex.IsMatch(login, LOGIN_REGEX))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

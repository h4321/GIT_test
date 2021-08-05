<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Examples Bank - Login</title>
    <link rel="stylesheet" type="text/css" href="StyleSheet.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <p style="font-size: 12pt; font-weight: bold; text-align: center;">
        Welcome to Example Bank<br />
        </p>
        
        <table style="margin-left: auto; margin-right: auto;">
            <tr>
                <td>
                    <asp:Login ID="LoginBox" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <p style="font-size: 8pt; font-style:italic;">
                        Example users:<br/>
                        user: jwhite pass: jwhite<br/>
                        user: asmith pass: asmith<br/>
                        user: ksuzuki pass: ksuzuki<br/>
                    </p>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>

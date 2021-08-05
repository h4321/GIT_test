using Parasoft.Dottest.Examples.Bank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for IBankProvider
/// </summary>
public interface IBankProvider
{
    Bank GetBank(HttpApplicationState application, bool createNew, bool readOnly);
}
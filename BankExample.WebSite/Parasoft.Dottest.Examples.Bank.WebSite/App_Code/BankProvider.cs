using System.Web;
using Parasoft.Dottest.Examples.Bank;

/// <summary>
/// Summary description for BankProvider
/// </summary>
public class BankProvider : IBankProvider
{
    private static BankProvider _instance = new BankProvider();

    public static BankProvider Instance { get { return _instance; }}

    public Bank GetBank(HttpApplicationState application, bool readOnly, bool createNew)
    {
        const string key = "bank";
        Bank bank = application.Get(key) as Bank;
        if (bank == null && createNew)
        {
            bank = ExampleBank.CreateExampleBank();
            application.Set(key, bank);
        }
        
        // TODO: implement read only access
        
        return bank;
    }
}

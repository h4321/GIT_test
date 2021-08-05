using System;
using System.Collections.Generic;
using System.Threading;
using Parasoft.Dottest.Examples.Bank;

public partial class Account : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Bank bank = BankProvider.Instance.GetBank(this.Application, true, true);
        BankUser user = bank.GetUserByLogin(Page.User.Identity.Name);

        string accountNumber = Request["account"];
        if (accountNumber != null)
        {
            IList<BankAccount> accounts = bank.GetAccounts(user);
            foreach (BankAccount account in accounts)
            {
                if (account.Number.ToString() == accountNumber)
                {
                    this.AccountNumberLabel.Text = account.Number.ToString(); // parasoft-suppress  BD.SECURITY.SENS "displaying account number"
                    this.BalanceValueLabel.Text = account.Balance.GetValueWithSign(Thread.CurrentThread.CurrentCulture);
                }
            }                
        }
        else
        {
            Server.Transfer("Home.aspx");
        }
    }

    protected void TransferButton_Click(object sender, EventArgs e)
    {
        Server.Transfer("Transfer.aspx?account=" + Request["account"]);
    }
    protected void HistoryButton_Click(object sender, EventArgs e)
    {
        Server.Transfer("History.aspx?account=" + Request["account"]);
    }
}

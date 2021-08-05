using System;
using System.Collections.Generic;
using Parasoft.Dottest.Examples.Bank;
using System.Threading;

public partial class Remove : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
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
                        this.BalanceValueLabel.Text =
                            account.Balance.GetValueWithSign(Thread.CurrentThread.CurrentCulture);
                    }
                    else
                    {
                        rblAccounts.Items.Add(account.Number.ToString());
                    }
                }
            }
            else
            {
                Server.Transfer("Default.aspx");
            }
        }
    }

    protected void RemoveButton_Click(object sender, EventArgs e)
    {
        Bank bank = BankProvider.Instance.GetBank(this.Application, true, true);
        BankUser user = bank.GetUserByLogin(Page.User.Identity.Name);
        IList<BankAccount> accounts = bank.GetAccounts(user);
        foreach (BankAccount account in accounts)
        {
            if (account.Number.ToString() == rblAccounts.SelectedValue)
            {
                ProceedRemove(AccountNumberLabel.Text, account, accounts, bank);
            }
        }
    }

    private void ProceedRemove(string accountNumberToRemove, BankAccount target, IList<BankAccount> accounts, Bank bank)
    {
        BankAccount accountToRemove = null;
        foreach (BankAccount bankAccount in accounts)
        {
            if (bankAccount.Number.ToString() == accountNumberToRemove)
            {
                accountToRemove = bankAccount;
                break;
            }
        }
        if (accountToRemove != null)
            bank.Transfer(accountToRemove, target.Number, accountToRemove.Balance);

        accounts.Remove(accountToRemove);
    }
}
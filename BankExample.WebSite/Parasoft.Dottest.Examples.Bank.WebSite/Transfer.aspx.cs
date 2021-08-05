using System;
using System.Collections.Generic;
using System.Threading;
using System.Web.UI.WebControls;
using Parasoft.Dottest.Examples.Bank;
using Parasoft.Dottest.Examples.Bank.Money;

public partial class Transfer : System.Web.UI.Page
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
                        this.AccountNumberLabel.Text = account.Number.ToString();
                        this.BalanceValueLabel.Text =
                            account.Balance.GetValueWithSign(Thread.CurrentThread.CurrentCulture);

                        this.AmountTextBox.Text =
                            CurrencyProvider.GetZero(account.CurrencyInfo).GetValue(
                                Thread.CurrentThread.CurrentCulture);
                    }
                    else
                    {
                        TableRow row = new TableRow();

                        TableCell numberCell = new TableCell();
                        Label accountLabel = new Label();
                        
                        accountLabel.Text = account.Number.ToString(); // parasoft-suppress  BD.SECURITY.SENS "displaying account number"
                        numberCell.Controls.Add(accountLabel);
                        row.Cells.Add(numberCell);

                        TableCell balanceCell = new TableCell();
                        Label balanceLabel = new Label();
                        balanceLabel.Text = account.Balance.GetValueWithSign(Thread.CurrentThread.CurrentCulture);
                        balanceCell.Controls.Add(balanceLabel);
                        row.Cells.Add(balanceCell);

                        TableCell useCell = new TableCell();
                        Button button = new Button();
                        button.Text = "Use";
                        button.OnClientClick = this.TargetAccountTextBox.ClientID + ".value = '" + account.Number.ToString() + "'; return false;"; // parasoft-suppress  BD.SECURITY.SENS "using account number"
                        
                        useCell.Controls.Add(button);
                        row.Cells.Add(useCell);

                        UsersAccountsTable.Rows.Add(row);
                    }
                }
            }
            else
            {
                Server.Transfer("Default.aspx");
            }
        }
    }

    protected void TransferButton_Click(object sender, EventArgs e)
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
                    TransferAmount(bank, account);
                    return;
                }
            }
        }
    }

    private void TransferAmount(Bank bank, BankAccount account)
    {
        Currency amount = CurrencyProvider.GetCurrency(this.AmountTextBox.Text, 
                                                       account.CurrencyInfo, Thread.CurrentThread.CurrentCulture);
        AccountNumber target = AccountNumber.Create(this.TargetAccountTextBox.Text);
        bank.Transfer(account, target, amount);
                    
        Server.Transfer("Home.aspx");
    }
}

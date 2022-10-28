using System;
using System.Collections.Generic;
using System.Threading;
using System.Web.UI.WebControls;
using Parasoft.Dottest.Examples.Bank;
using Parasoft.Dottest.Examples.Bank.Transactions;

public partial class History : System.Web.UI.Page
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

                    IEnumerable<TransactionBase> history = account.History;
                    foreach (TransactionBase transaction in history)
                    {
                        TableRow row = new TableRow();

                        TableCell dateCell = new TableCell();
                        Label dateLabel = new Label();
                        dateLabel.Text = transaction.Date.ToShortDateString();
                        dateCell.Controls.Add(dateLabel);
                        row.Cells.Add(dateCell);

                        TableCell kindCell = new TableCell();
                        Label kindLabel = new Label();
                        kindLabel.Text = transaction.GetKind();
                        kindCell.Controls.Add(kindLabel);
                        row.Cells.Add(kindCell);

                        TableCell amountCell = new TableCell();
                        Label amountLabel = new Label();

                        amountLabel.Text = transaction.GetAmount().GetValueWithSign(Thread.CurrentThread.CurrentCulture);
                        if (transaction.GetConvertedAmount() != null)
                        {

                            amountLabel.Text += string.Format("({0})", transaction.GetConvertedAmount().GetValue(Thread.CurrentThread.CurrentCulture), transaction.GetConvertedAmount().CurrencyInfo.Notation);
                        }

                        amountCell.Controls.Add(amountLabel);
                        row.Cells.Add(amountCell);

                        TableCell feeCell = new TableCell();
                        Label feeLabel = new Label();

                        if (transaction.Fee != null)
                        feeLabel.Text = transaction.Fee.GetValueWithSign(Thread.CurrentThread.CurrentCulture);
                        feeCell.Controls.Add(feeLabel);
                        row.Cells.Add(feeCell);

                        this.HistoryTable.Rows.Add(row);
                    }
                }
            }
        }
        else
        {
            Server.Transfer("Home.aspx");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Threading;
using System.Web.UI.WebControls;
using Parasoft.Dottest.Examples.Bank;

public partial class Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Bank bank = BankProvider.Instance.GetBank(this.Application, true, true);

        BankUser user = bank.GetUserByLogin(Page.User.Identity.Name);

        IList<BankAccount> accounts = bank.GetAccounts(user);
        foreach (BankAccount account in accounts)
        {
            TableRow row = new TableRow();
            
            TableCell numberCell = new TableCell();
            LinkButton linkButton = new LinkButton();
            linkButton.Text = account.Number.ToString(); // parasoft-suppress  BD.SECURITY.SENS "displaying account number"
            linkButton.PostBackUrl = "Account.aspx?account=" + account.Number.ToString(); // parasoft-suppress  BD.SECURITY.SENS "using account number"
            numberCell.Controls.Add(linkButton);
            row.Cells.Add(numberCell);

            TableCell balanceCell = new TableCell();
            Label balanceLabel = new Label();
            balanceLabel.Text = account.Balance.GetValueWithSign(Thread.CurrentThread.CurrentCulture);
            balanceCell.Controls.Add(balanceLabel);
            row.Cells.Add(balanceCell);

            TableCell removeCell = new TableCell();
            Button removeButton = new Button();
            removeButton.Text = "Remove";
            removeButton.PostBackUrl += "Remove.aspx?account=" + account.Number.ToString(); // parasoft-suppress  BD.SECURITY.SENS "using account number"
            removeCell.Controls.Add(removeButton);
            row.Cells.Add(removeCell);

            AccountsTable.Rows.Add(row);
        }
    }

}

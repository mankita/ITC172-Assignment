using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string[] percents = { "10%", "15%", "20%", "Other" };
            TipPercentRadioButtonList.DataSource = percents;
            TipPercentRadioButtonList.DataBind();
        }
    }

    protected void SubmitButton_Click(object sender, EventArgs e)
    {
        GetTotals();
    }

    private void GetTotals()
    {
        double amount;
        Tip tip=null;
        bool goodAmount = double.TryParse(MealTextBox.Text, out amount);
        if (goodAmount)
        {
            double percent = 0;
            if (TipPercentRadioButtonList.SelectedItem.Text != "Other")
            {
                if (TipPercentRadioButtonList.SelectedItem.Text.Equals("10%"))
                    percent = .1;
                if (TipPercentRadioButtonList.SelectedItem.Text.Equals("15%"))
                    percent = .15;
                if (TipPercentRadioButtonList.SelectedItem.Text.Equals("20%"))
                    percent = .2;

            }
            else
            {
                percent = double.Parse(OtherTextBox.Text);
                percent /= 100; //percent = percent /100
            }

           tip =  new Tip(amount, percent);

        }
        else
        {
            Response.Write("<script>alert('Enter a valid amount');</script>");

        }
        //Display Result

        ResultLabel.Text = "Amount: " + amount.ToString("$ #,##0.00") + "</br>" + "Tax: " + tip.CalculateTax().ToString("$ #,##0.00") + "<br/>"
            + "tip :" + tip.CalculateTip().ToString("$ #,##0.00") + "<br/>" + "Total: " + tip.Total().ToString("$ #,##0.00");
    }
}
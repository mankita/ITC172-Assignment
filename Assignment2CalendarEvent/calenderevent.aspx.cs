using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class calenderevent : System.Web.UI.Page
{
    String[,] Calendar = new string[5, 2];
    protected void Page_Load(object sender, EventArgs e)
    {
        Calendar[0, 0] = "4/1/2017";
        Calendar[0, 1] = "Worker's Day";
        Calendar[1, 0] = "6/12/2017";
        Calendar[1, 1] = "Mom's Birthday";
        Calendar[2, 0] = "7/16/2017";
        Calendar[2, 1] = "Work Anniversary";
        Calendar[3, 0] = "8/31/2017";
        Calendar[3, 1] = "Tarun BirthDay";
        Calendar[4, 0] = "8/31/2017";
        Calendar[4, 1] = "Travel Day";
    }

    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        showevent.Text = "";
        DateTime selectedDate = Calendar1.SelectedDate;
        for (int i = 0; i < 5; i++)
        {
            DateTime eventDate = Convert.ToDateTime(Calendar[i, 0]);
            if (selectedDate.CompareTo(eventDate) == 0)
            {
                showevent.Text += Calendar[i, 1] + "<br/>";
            }
           
        }
        if (showevent.Text.Equals(""))
        {
            showevent.Text = selectedDate.ToShortDateString();
        }
    }
}









﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RegisterForm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void RegisterNewUserButton_Click(object sender, EventArgs e)
    {
        Login loginObject = new Login();

        loginObject.RegisterPerson(LastNameTextBox.Text, FirstNameTextBox.Text, EmailTextBox.Text, PasswordTextBox.Text,
            ApartmentNumberTextBox.Text, StreetTextBox.Text, CityTextBox.Text, StateTextBox.Text, ZipCodeTextBox.Text,
            HomePhoneTextBox.Text, WorkPhoneTextBox.Text);
   
        Response.Redirect("Default.aspx");
    }
}
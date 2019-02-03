﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class VerficationPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

            var zarinpal = ZarinPal.ZarinPal.Get();
            String MerchantID = "71c705f8-bd37-11e6-aa0c-000c295eb8fc";
            String Authority = HttpUtility.ParseQueryString(this.ClientQueryString)["Authority"];
            long Amount = 100;


            var verificationRequest = new ZarinPal.VerificationRequest(MerchantID , Amount , Authority);

            var verificationResponse = zarinpal.InvokeVerificationPayment(verificationRequest);
            if (verificationResponse.IsSuccess)
            {
                Response.Write(String.Format("<script>alert('Purchase successfully with ref transaction {0}')</script>", verificationResponse.RefID));
            }
            else {

                Response.Write(String.Format("<script>alert('Purchase unsuccessfully Error code is: {0}')</script>",verificationResponse.Status));

            }


    }
}
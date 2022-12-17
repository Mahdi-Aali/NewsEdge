namespace NewsEdge.Utilities.Email.Body;

public class EmailBody
{
    public static string ConfirmEmailBody(string congirmLink)
    {
        return @$"
<table width=""100%"" align=""center"" border=""0"" cellspacing=""0"" cellpadding=""0"" mc:repeatable=""Select"" mc:variant=""Announced title (layout-9)"">
    <tbody><tr>
       <td align=""center"" valign=""top"" class=""fix-box"">
   
        <!-- start layout-9 container width 600px --> 
        <table width=""600"" align=""center"" border=""0"" cellspacing=""0"" cellpadding=""0"" class=""container"" bgcolor=""#ffffff"" style=""background-color: #ffffff; border-bottom:2px solid #c7c7c7; "">
          <tbody><tr>
            <td valign=""top"">
   
              <!-- start layout-9 container width 560px --> 
              <table width=""560"" align=""center"" border=""0"" cellspacing=""0"" cellpadding=""0"" class=""full-width"" bgcolor=""#ffffff"" style=""background-color:#ffffff;"">
   
                <!--start space height --> 
                <tbody><tr>
                  <td height=""20""></td>
                </tr>
                <!--end space height --> 
   
   
              <!-- start heading -->               
              <tr>     
                <td valign=""top"">
                  <table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""left"">
                    <tbody><tr>
                      <td align=""left"" valign=""top"" width=""29"" style=""padding-right:10px;"">
                        <table width=""29"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""left"">
                          <tbody><tr valign=""top"">
                            <td align=""left"" valign=""middle"">
                              <img mc:edit=""image (layout-9)"" src=""/images/megaphone.png"" width=""29"" alt=""megaphone"" style=""max-width:29px; diaplay:block;"" border=""0"" hspace=""0"" vspace=""0"">             
                            </td>
                          </tr>
                        </tbody></table>
                      </td>
                   
                      <td mc:edit=""heading (layout-9)"" align=""right;"" style=""font-size: 18px; line-height: 22px; font-family: BYekan,'BYekan',tahoma; color:#555555; font-weight:bold; text-align:right;"">
                        <span style=""color: #555555; font-weight:bold;"">
                          <a href=""#"" style=""text-decoration: none; color: #555555; font-weight: bold;""><span style=""color: #f05e5e; "">NewsEdge</span> تائید ایمیل شما در </a>
                        </span>
                      </td>
   
                    </tr>
                  </tbody></table>
                </td>
              </tr>
              <!-- end heading -->  
   
              <!--start space height --> 
              <tr>
                <td height=""15""></td>
              </tr>
              <!--end space height -->              
               
               <!-- start text content -->
                <tr>
                  <td valign=""top"">
                    <table border=""0"" cellspacing=""0"" cellpadding=""0"" align=""right"">
                      
   
                      <tbody><tr>
                        <td mc:edit=""content (layout-9)"" style=""font-size: 13px; line-height: 22px;font-family: BYekan,'BYekan',tahoma; color:#a3a2a2; font-weight:normal; text-align:right;direction:rtl; "">
                            برای تائید ایمیل خود در سایت NewsEdge روی دکمه زیر کلیک کنید.
                        </td>
                      </tr>
   
                     <!--start space height --> 
                      <tr>
                        <td height=""15""></td>
                      </tr>
                      <!--end space height --> 
   
                     <!-- start button text -->
                     <tr>
                       <td>
                         <table align=""left"" border=""0"" cellspacing=""0"" cellpadding=""0"">
                           <tbody><tr>
                            <td mc:edit=""button (layout-4)"" width=""auto"" id=""mail-color"" align=""center"" valign=""middle"" height=""32"" style="" background-color:#f05e5e;  border-radius:24px; background-clip: padding-box;font-size:13px; font-family: BYekan,'BYekan',tahoma; text-align:center;  color:#ffffff; font-weight: normal; padding-left:18px; padding-right:18px; "">

                                <span style=""color: #ffffff; font-weight: normal;"">
                                  <a href=""{congirmLink}"" style=""text-decoration: none; color: #ffffff; font-weight: normal;"">تائید ایمیل</a>
                                </span>
                              </td>
                           </tr>
                         </tbody></table>
                       </td>
                     </tr>
                     <!-- end button text -->
   
   
                    </tbody></table>
                  </td>
                  
                </tr>
   
                <!-- end text content -->
                
   
                <!--start space height --> 
                <tr>
                  <td height=""20""></td>
                </tr>
                <!--end space height --> 
              </tbody></table>
              <!-- end layout-9 container width 560px --> 
            </td>
          </tr>
        </tbody></table>
        <!-- end layout-9 container width 600px --> 
      </td>
    </tr>
   
    <!-- END LAYOUT 9 --> 
   </tbody></table>
";
    }

    public static string ForgotPasswordEmailBody(string resetLink)
    {
        return @$"
<table width=""100%"" align=""center"" border=""0"" cellspacing=""0"" cellpadding=""0"" mc:repeatable=""Select"" mc:variant=""2 col content-left image-circle-rigth (layout-7)"">
  





    <!-- START LAYOUT-7 --> 
   
    <tbody><tr>
       <td align=""center"" valign=""top"" class=""fix-box"">
   
      <!-- start layout-7 container width 600px --> 
      <table width=""600"" align=""center"" border=""0"" cellspacing=""0"" cellpadding=""0"" class=""container"" bgcolor=""#ffffff"" style=""background-color: #ffffff; border-bottom:2px solid #c7c7c7;"">
        <tbody><tr>
          <td valign=""top"">
   
            <!-- start layout-7 container width 560px --> 
            <table width=""560"" align=""center"" border=""0"" cellspacing=""0"" cellpadding=""0"" class=""full-width"" bgcolor=""#ffffff"" style=""background-color:#ffffff;"">
   
   
              <!--start space height --> 
              <tbody><tr>
                <td height=""20""></td>
              </tr>
              <!--end space height --> 
   
              <!-- start image content --> 
              <tr>
                <td valign=""top"" width=""100%"">
   
                                     
   
                  <!-- start content right --> 
                  <table width=""185"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""right"" class=""full-width"">
   
                   <tbody><tr>
                      <td valign=""top"">
   
                        <table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""left"" class=""clear-align"">
                          <tbody><tr>
                             <td valign=""top"" align=""center"" class=""image-185px"">
                                <a href=""#"">
                                  <img mc:edit=""image (layout-7)"" src=""https://pic.onlinewebfonts.com/svg/img_398183.png"" width=""185"" alt=""image_280x280"" style=""display:block; max-width:185px; width:100% !important;"" border=""0"" hspace=""0"" vspace=""0""> 
                                </a>
                              </td>
   
                          </tr>
                        </tbody></table>
   
                      </td>
                    </tr>
   
                    <!--start space height --> 
                    <tr>
                      <td height=""20""></td>
                    </tr>
                    <!--end space height --> 
   
   
                  </tbody></table>
                  <!-- end content right --> 
   
   
                   <!-- start space width --> 
                  <table class=""remove"" width=""1"" border=""0"" cellpadding=""0"" cellspacing=""0"" align=""right"" style=""font-size: 0;line-height: 0;border-collapse: collapse;"">
                    <tbody><tr>
                      <td width=""0"" height=""2"" style=""font-size: 0;line-height: 0;border-collapse: collapse;"">
                        <p style=""padding-left: 20px;"">&nbsp;</p>
                      </td>
                    </tr>
                  </tbody></table>
                  <!-- end space width --> 
   
   
   
                    <!-- start content left --> 
                  <table width=""350"" border=""0"" cellspacing=""0"" cellpadding=""0"" align=""left"" class=""full-width"">
                    
   
                    <!-- start text content -->                       
                    <tbody><tr>
                      <td valign=""top"">
                        <table border=""0"" cellspacing=""0"" cellpadding=""0"" align=""left"">
                          <tbody><tr>
                            <td mc:edit=""heading (layout-7)"" style=""font-size: 18px; line-height: 22px; font-family: BYekan,'BYekan',tahoma; color:#555555; font-weight:bold; text-align:right;"">
                              <span style=""color: #555555; font-weight: bold;"">
                                <a href=""#"" style=""text-decoration: none; color: #555555; font-weight: bold;"">بازیابی رمز عبور</a>
                              </span>
                            </td>
                          </tr>
   
                          <!--start space height -->                       
                          <tr>
                            <td height=""15""></td>
                          </tr>
                          <!--end space height -->                       
   
                          <tr>
                            <td mc:edit=""content (layout-7)"" style=""font-size: 13px; line-height: 22px; font-family: BYekan,'BYekan',tahoma; color:#a3a2a2; font-weight:normal; text-align:justify;direction:rtl; "">
                                کاربر گرامی درخواست بازیابی رمز عبور شما با موفقیت ثبت شد. برای بازیابی رمز عبور خود بر روی دکمه زبر کلیک کنید.
                            </td>
                          </tr>
   
                          <!--start space height -->                       
                          <tr>
                            <td height=""15""></td>
                          </tr>
                          <!--end space height -->    
   
   
                            <!-- start button text -->
                             <tr>
                               <td>
                                 <table align=""left"" border=""0"" cellspacing=""0"" cellpadding=""0"">
                                   <tbody><tr>
                                    <td mc:edit=""button (layout-4)"" width=""auto"" id=""mail-color"" align=""center"" valign=""middle"" height=""32"" style="" background-color:#f05e5e;  border-radius:24px; background-clip: padding-box;font-size:13px; font-family: BYekan,'BYekan',tahoma; text-align:center;  color:#ffffff; font-weight: normal; padding-left:18px; padding-right:18px; "">

                                        <span style=""color: #ffffff; font-weight: normal;"">
                                          <a href=""{resetLink}"" style=""text-decoration: none; color: #ffffff; font-weight: normal;"">بازیابی رمز عبور</a>
                                        </span>
                                      </td>
                                   </tr>
                                 </tbody></table>
                               </td>
                             </tr>
                             <!-- end button text -->
   
                          <!--start space height -->                       
                          <tr>
                            <td height=""20""></td>
                          </tr>
                          <!--end space height --> 
                        </tbody></table>
                      </td>
                    </tr>
                    <!-- end text content --> 
                  </tbody></table>
                  <!-- end content left -->   
   
   
                </td>
              </tr>
              <!-- end image content --> 
             
            </tbody></table>
            <!-- end layout-7 container width 560px --> 
          </td>
        </tr>
      </tbody></table>
      <!-- end layout-7 container width 600px --> 
    </td>
   </tr>
   
    <!-- END LAYOUT-7 -->
   
   
   
   </tbody></table>
";
    }
}

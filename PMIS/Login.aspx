<%@ Page Title="" Language="C#" MasterPageFile="~/PMIS/WebsiteMaster.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="RCDPMISNEW_Login_Page" %>
<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <style>
        /* Full-width input fields */
        input[type=text], input[type=password] {
            width: 100%;
            padding: 12px 20px;
            margin: 8px 0;
            display: inline-block;
            border: 1px solid #ccc;
            box-sizing: border-box;
        }

        /* Set a style for all buttons */
        button {
            background-color: #4CAF50;
            color: white;
            padding: 14px 20px;
            margin: 8px 0;
            border: none;
            cursor: pointer;
            width: 100%;
        }

            button:hover {
                opacity: 0.8;
            }

        /* Extra styles for the cancel button */
        .cancelbtn {
            width: auto;
            padding: 10px 18px;
            background-color: #f44336;
        }

        /* Center the image and position the close button */
        .imgcontainer {
            text-align: center;
            margin: 24px 0 12px 0;
            position: relative;
        }

        img.avatar {
            width: 40%;
            border-radius: 50%;
        }




        /* The Close Button (x) */
        .close {
            position: absolute;
            right: 25px;
            top: 0;
            color: #000;
            font-size: 35px;
            font-weight: bold;
        }

            .close:hover,
            .close:focus {
                color: red;
                cursor: pointer;
            }

        /* Add Zoom Animation */
        .animate {
            -webkit-animation: animatezoom 0.6s;
            animation: animatezoom 0.6s;
        }


        @keyframes animatezoom {
            from {
                transform: scale(0);
            }

            to {
                transform: scale(1);
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   
    <div style="padding:2em;">
        <div class="col-md-12">
        <div class="col-md-4"></div>
        <div class="col-md-4" style="border: 1px solid black; padding:1em;">
            <div class=" animate">
                <div class="imgcontainer">
                    <%--<span onclick="document.getElementById('id01').style.display='none'" class="close" title="Close Modal">&times;</span>--%>
                    <img src="images/loginimage.png" alt="Avatar" class="avatar">
                </div>

               
                    <label for="uname"><b>Username</b></label>
                   <%-- <input type="text" placeholder="Enter Username" name="uname" required>--%>
                      <asp:TextBox ID="txtUserName"  runat="server" placeholder="User Id"
                                required=""></asp:TextBox>

                    <label for="psw"><b>Password</b></label>
                   <%-- <input type="password" placeholder="Enter Password" name="psw" required>--%>
                    <asp:TextBox ID="txtPassword"  runat="server" TextMode="Password"
                                placeholder="Password" required=""></asp:TextBox><br />
                   <%-- <cc1:CaptchaControl ID="ccJoin" runat="server" CaptchaBackgroundNoise="Low" CaptchaLength="5"
                                CaptchaHeight="40" CaptchaWidth="200" CaptchaLineNoise="None" CaptchaMinTimeout="5"
                                CaptchaMaxTimeout="240" FontColor="#529E00" CssClass="form-control" /><br />--%>
                <cc1:CaptchaControl ID="ccJoin" runat="server" CaptchaBackgroundNoise="None" CaptchaLength="5"
                                            CaptchaHeight="35" CaptchaWidth="200" CaptchaLineNoise="None" CaptchaMinTimeout="5"
                                            CaptchaMaxTimeout="240" FontColor="#529E00" CssClass="form-control" BorderColor="Black" BorderStyle="Solid"
                                            BorderWidth="1px"  BackColor="White" /><br />
                    <label for="psw"><b>Enter Captcha </b></label>
                   <%-- <input type="password" placeholder="Enter Password" name="psw" required>--%>
                    <asp:TextBox ID="txtCaptha" runat="server" CssClass="form-control" placeholder="Enter Above Captcha" required=""></asp:TextBox>

                  <%--  <button type="submit">Login</button>--%>
                    <asp:Button ID="btn_save" runat="server" Text="Login" CssClass="btn  form-control" OnClick="btn_save_Click" BackColor="#12477f" ForeColor="#ffffff" />
                    <asp:Label ID="lblMsg" runat="server"></asp:Label>                                   
            </div>
        </div>
       </div>
    </div><br />
</asp:Content>


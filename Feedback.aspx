<%@ page title="" language="C#" masterpagefile="~/User.master" autoeventwireup="true" codefile="Feedback.aspx.cs" inherits="Feedback" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1 {
            width: 303px;
            border: solid 1px #ccc;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="tbl">
        <tr>
            <td class="tblhead">FeedBack Form</td>
        </tr>

        <tr>
            <td>
               <table align="center" class="style1" style="width: 50%; height: 300px; margin: 20px auto; background-color: #f0f0f0;">


                    <tr>
                        <td>&nbsp;</td>
                    </tr>

                    <tr>
                        <td class="lbl">Enter Name :</td>
                        <td>
                            <asp:TextBox ID="txtemail" runat="server" CssClass="txt"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="lbl">Contact :
                        </td>
                        <td>
                            <asp:TextBox ID="txtcont" runat="server" CssClass="txt"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="lbl">Feddback :</td>
                        <td>
                            <asp:TextBox ID="txtfeed" runat="server" CssClass="txt" Height="40px"
                                TextMode="MultiLine" Width="160px">
                            </asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>
                            <asp:Button ID="Button9" runat="server" CssClass="btn" Text="Send Feedback"
                                Width="120px" onclick="Button9_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>
                            <asp:Label ID="lbl" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>


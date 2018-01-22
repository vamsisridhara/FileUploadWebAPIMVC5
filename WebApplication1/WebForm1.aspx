<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="sm1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="panel1" runat="server"
                UpdateMode="Conditional" ChildrenAsTriggers="false">
                <ContentTemplate>
                    <p>Update panel1 <%= Convert.ToString(((int)Application["PagerequestCount"])) %></p>
                    <asp:UpdatePanel ID="panel2" runat="server"
                        UpdateMode="Conditional">
                        <ContentTemplate>
                            <p>Update panel2 <%= Convert.ToString(((int)Application["PagerequestCount"])) %></p>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                </ContentTemplate>
            </asp:UpdatePanel>

            <asp:UpdatePanel ID="panel3" runat="server"
                UpdateMode="Conditional">
                <ContentTemplate>
                    <p>Update panel3 <%= Convert.ToString(((int)Application["PagerequestCount"])) %></p>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:Button ID="button1" runat="server" OnClick="button1_Click" />
        </div>
    </form>
</body>
</html>

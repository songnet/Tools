<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebUploader.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <label>收件人：</label>
        <input type="text" runat="server" id="txt_Reciver" />
        <label>内容：</label>
        <input type="text" runat="server" id="rtxt_Content" />
    <input type="button" id="BtnSend" value="发送" runat="server" onserverclick="BtnSend_ServerClick" />
    </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateCsFile.aspx.cs" Inherits="SDWxPro.Web.CreateCsFile" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>创建Cs文件</title>
    <script src="js/jquery.min.js"></script>
</head>
<body>
    <br />
    <br />
    <form id="myform" method="post" action="CreateCsFile.aspx?action=doCreate">
        <table border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td width="50" height="35" style="border: solid 1px #000;" align="center">
                    <input type="checkbox" id="checkAll" onclick="CheckOthers(myform)" /></td>
                <td width="300" style="border-bottom: solid 1px #000; border-top: solid 1px #000; border-right: solid 1px #000;">&nbsp;<b>表名</b></td>
            </tr>
            <asp:Repeater runat="server" ID="RepTable">
                <ItemTemplate>
                    <tr onmouseover="javascript:this.bgColor='#fff7d2'" onmouseout="javascript:this.bgColor='#fff'">
                        <td height="30" style="border-bottom: solid 1px #000; border-left: solid 1px #000; border-right: solid 1px #000;" align="center">
                            <input type="checkbox" name="idstr" value="<%#Eval("name") %>" /></td>
                        <td style="border-bottom: solid 1px #000; border-right: solid 1px #000;" align="left">&nbsp;<%#Eval("name") %></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <tr>
                <td height="35">&nbsp;</td>
                <td>
                    <input type="button" value="生成代码" onclick="CheckForm('idstr')" /></td>
            </tr>
        </table>
    </form>
    <script type="text/javascript" src="js/jquery-1.4.2.js"></script>
    <script type="text/javascript">
        function CheckOthers(form) {
            for (var i = 0; i < form.elements.length; i++) {
                var e = form.elements[i];
                if (e.checked == false) {
                    e.checked = true; // form.chkall.checked;
                } else {
                    e.checked = false;
                }
            }
        }

        function CheckForm(checkName) {
            var tempn = document.getElementsByName(checkName);
            var isSeln = false; //判断是否有选中项，默认为无
            //检测基本配置
            for (n = 0; n < tempn.length; n++) {
                //遍历Radio
                if (tempn[n].checked == true) {
                    isSeln = true;
                    break;
                }
            }
            if (isSeln == false) {
                alert("请选择要执行的复选框！");
                return false;
            } else {
                $("#myform").submit();
            }
        }
    </script>
</body>
</html>

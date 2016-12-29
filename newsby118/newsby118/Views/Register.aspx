<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="newsby118.Views.Register" %>

<!DOCTYPE html>

<html>
<head runat ="server">
  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <title>AdminLTE 2 | Registration Page</title>
  <!-- Tell the browser to be responsive to screen width -->
  <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport">
  <!-- Bootstrap 3.3.6 -->
  <link rel="stylesheet" href="css/bootstrap.min.css">
  <!-- Font Awesome -->
  <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.5.0/css/font-awesome.min.css">
  <!-- Ionicons -->
  <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/ionicons/2.0.1/css/ionicons.min.css">
  <!-- Theme style -->
  <link rel="stylesheet" href="css/AdminLTE.min.css">
</head>
<body class="hold-transition register-page">
<div class="register-box">
  <div class="register-logo">
    <a href="../../index2.html"><b>118新闻</b>早知道</a>
  </div>

  <div class="register-box-body">
    <p class="login-box-msg">新用户注册</p>

<form id="form1" runat="server" class="form-signin" role="form">

      <div class="form-group has-feedback">
         <asp:TextBox ID="txb_username" OnChange="Added()" runat="server" class="form-control" placeholder="用户名"></asp:TextBox>
        <span class="glyphicon glyphicon-user form-control-feedback"></span>
      </div>
      <div class="form-group has-feedback">

        <asp:TextBox ID="txb_email" OnChange="Added1()" runat="server" class="form-control" placeholder="邮箱"></asp:TextBox>

        <span class="glyphicon glyphicon-envelope form-control-feedback"></span>

      </div>
      <div class="form-group has-feedback">

          <asp:TextBox ID="txb_password" OnChange="Added()" runat="server" class="form-control" placeholder="请输入密码" TextMode="Password" ></asp:TextBox>

        <span class="glyphicon glyphicon-lock form-control-feedback"></span>
      </div>
      <div class="form-group has-feedback">
          <asp:TextBox ID="txb_re_password" OnChange="Added2()" runat="server" class="form-control" placeholder="再输入一次密码" TextMode="Password"  ></asp:TextBox>
        <span class="glyphicon glyphicon-log-in form-control-feedback"></span>
      </div>
      <div class="row">
        <div class="col-xs-8">
          <div class="checkbox icheck">
            <label id="msg" style="color:red"></label>
          </div>
            
        </div>
        <!-- /.col -->
        <div class="col-xs-4">
          <asp:Button ID="btn_register" runat="server" Text="注册" class="btn btn-primary btn-block btn-flat" OnClick="btn_register_Click"/>
        </div>
        <!-- /.col -->
          
      </div>
</form>

    <a href="login.aspx" class="text-center">我已经有账号了，直接登录</a>
  </div>
  <!-- /.form-box -->
</div>
<!-- /.register-box -->

<!-- jQuery 2.2.3 -->
<script src="js/jquery-2.2.3.min.js"></script>
<!-- Bootstrap 3.3.6 -->
<script src="js/bootstrap.min.js"></script>
    <script>
        $(function () {
            $('#btn_register').attr('disabled', true);
            $('#btn_register').click(function () {
                if ('注册成功') {
                    confirm('申请成功,等待管理员审核....');
                }
            });
        });
        function checkEmail(szMail) {
            var szReg = /^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$/;
            var bChk = szReg.test(szMail);
            return bChk;
        }
        function Added() {
            var text1 = document.getElementById("<%=txb_username.ClientID%>").value;
            var text2 = document.getElementById("<%=txb_email.ClientID%>").value;
            var text3 = document.getElementById("<%=txb_password.ClientID%>").value;
            var text4 = document.getElementById("<%=txb_re_password.ClientID%>").value;

            if (text1 != "" && text2 != "" && text3 != "" && text4 != "") {
                $('#btn_register').attr('disabled', false);
            }
        }
        function Added1() {
            var email = $('#txb_email').val();
            if (!checkEmail(email)) {
                //提示邮箱格式不正确
                $('#msg').text('请输入正确的邮箱！');
            } else {
                $('#msg').text('');
                Added();
            }
        }
        function Added2() {
            var text3 = document.getElementById("<%=txb_password.ClientID%>").value;
            var text4 = document.getElementById("<%=txb_re_password.ClientID%>").value;
            if (text3 != text4) {
                $('#msg').text('密码不一致！');
            } else {
                $('#msg').text('');
                Added();
            }
        }

    </script>

</body>
</html>
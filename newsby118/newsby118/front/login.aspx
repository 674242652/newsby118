﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WebApplication4.front.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <title>新闻发布系统登入</title>
  <meta charset="utf-8">
  <link rel="stylesheet" href="css/bootstrap.min.css">
  <style type="text/css" media="screen">
    body {
      padding-top: 40px;
      padding-bottom: 40px;
      background-color: #eee;
    }

    .form-signin {
      max-width: 330px;
      padding: 15px;
      margin: 0 auto;
    }
    .form-signin .form-signin-heading,
    .form-signin .checkbox {
      margin-bottom: 10px;
    }
    .form-signin .checkbox {
      font-weight: normal;
    }
    .form-signin .form-control {
      position: relative;
      height: auto;
      -webkit-box-sizing: border-box;
         -moz-box-sizing: border-box;
              box-sizing: border-box;
      padding: 10px;
      font-size: 16px;
    }
    .form-signin .form-control:focus {
      z-index: 2;
    }
    .form-signin input[type="text"] {
      margin-bottom: -1px;
      border-bottom-right-radius: 0;
      border-bottom-left-radius: 0;
    }
    .form-signin input[type="password"] {
      margin-bottom: 10px;
      border-top-left-radius: 0;
      border-top-right-radius: 0;
    }
  </style>
</head>
<body>
    
          
    <div class="container">

      <form id="form1" runat="server" class="form-signin" role="form">
        <h2 class="form-signin-heading">请先登录
          </h2>
          <asp:TextBox ID="txt_username" runat="server" class="form-control" placeholder="输入账号"  required autofocus></asp:TextBox>
        <asp:TextBox ID="txt_password" runat="server" class="form-control" placeholder="输入密码" TextMode="Password" required></asp:TextBox>
        <div class="checkbox">
          <label>
            <input type="checkbox" value="remember-me"> 记住我
          </label>
        </div>
        <asp:Button ID="btn_login" runat="server" Text="登录" class="btn btn-lg btn-primary btn-block" OnClick="btn_login_Click" />
      </form>

    </div> <!-- /container -->

    <script src="js/jquery-2.2.3.min.js"></script>
    <!-- Bootstrap 3.3.6 -->
    <script src="js/bootstrap.min.js"></script>
</body>
</html>

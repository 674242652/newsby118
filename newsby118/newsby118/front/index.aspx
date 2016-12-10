<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WebApplication4.front.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="css/bootstrap.min.css">
	<link rel="stylesheet" href="css/AdminLTE.min.css">
    <link rel="stylesheet" href="css/mycss/global.css" />
    <style>
        body{
	    	background-color: #eef2f6;
	    }  
	    
		.myNavWrap{
			height: 28px;width: 100%;
			background-color: #EEECEC;
            border-bottom: 1px solid #e9e9e9;
		}
		.myNav{
			height:100%;

		}
		.myNav ul{
            list-style: none;
            display:inline-block;
		}
		.myNav ul li{
            width: 60px;
            height: 28px;
            display:inline-block;
            line-height: 28px
			/*padding: 10px 10px 10px 10px;*/
		}
		.myNav ul li a{
			text-decoration: none;
            color: #5c5c5c;
		}
        .myNav ul li a:hover{
            cursor:pointer;
            color:#000;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">

    

    <div class="myNavWrap">
		<!-- <div class="row"> -->
			<div class = "col-md-6 col-center-block myNav">
				<ul>
                    <li><a>首页</a></li>
					<li><a>国外</a></li>
					<li><a>国内</a></li>
				</ul>
                <div style="float:right;display:inline-block;line-height:28px;">
                    <asp:LinkButton ID="btn_login" runat="server">登陆</asp:LinkButton>
                </div>
			</div>

        
		<!-- </div> -->
	</div>		
	<div style="clear: both;"></div>
        </form>
	<div class="row">
        
		<div class="col-md-6 col-center-block">
			
			<nav class="navbar navbar-default" style="margin-bottom: 0px; background-color: white; ">
		      <div class="container-fluid">
		        <div class="navbar-header">
		          	<button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target=".navbar-collapse">
		              <span class="sr-only"></span>
		              <span class="icon-bar"></span>
		              <span class="icon-bar"></span>
		              <span class="icon-bar"></span>
            		</button>
		          <a class="navbar-brand" href="#">118新闻早知道</a>
		        </div>
		        <div id="navbar" class="navbar-collapse collapse">
		          <form class="navbar-form navbar-right">
		            <input type="text" class="form-control" placeholder="查找关键字..">
		            <!-- <button type="submit" class="btn">查找</button> -->
		          </form>
		        </div>
		      </div>
		    </nav>

            <div class="masthead">
            <ul class="nav nav-justified">
              <li class="active"><a href="#">Home</a></li>
              <li><a href="#">选项1</a></li>
              <li><a href="#">选项2</a></li>
              <li><a href="#">选项3</a></li>
              <li><a href="#">选项4</a></li>
              <li><a href="#">选项5</a></li>
            </ul>
         </div>

            <div class="box box-primary" style="margin-bottom: 0px;">
				<div class="box-header with-border ">
		             <h6 id = "time" >2016年11月28日 20:06 衡阳 晴</h6>
		        </div>
		           <!-- 这里有很多文章-->    
		     </div>

	    </div>

        
		
	</div>
    

	<script src="js/jquery-2.2.3.min.js"></script>
	<script src="js/bootstrap.min.js"></script>
</body>
</html>

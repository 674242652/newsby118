<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WebApplication4.front.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>118新闻</title>
    <link rel="stylesheet" href="css/bootstrap.min.css"/>
	<link rel="stylesheet" href="css/AdminLTE.min.css"/>
    <link rel="stylesheet" href="css/mycss/global.css" />
    <link rel="stylesheet" href="css/font-awesome/css/font-awesome.min.css"/>
    <style>
        /*{border:1px solid !important;}*/
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
            padding-right:0px;
            /*padding:0px 0px 0px 0px;*/
		}
		.myNav ul{
            margin:0px 0px 0px 0px;
            padding:0px 0px 0px 0px;
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
    <form id="form1" runat="server" class="form-signin" role="form">
    <div class="myNavWrap">
		<!-- <div class="row"> -->
			<div class = "col-md-6 col-center-block myNav">
				<ul>
                    <li><a>首页</a></li>
					<li><a>国外</a></li>
					<li><a>国内</a></li>
				</ul>
                <div style="float:right;display:inline-block;line-height:28px;">
                    <asp:LinkButton ID="btn_registered" runat="server" onclick="btn_registered_Click">注册</asp:LinkButton>
                    <asp:LinkButton ID="btn_login" runat="server" OnClick="btn_login_Click">登录</asp:LinkButton>
                    <asp:LinkButton ID="btn_logout" runat="server" OnClick="btn_logout_Click">退出登录</asp:LinkButton>
                </div>
			</div>

        
		<!-- </div> -->
	</div>		
	<div style="clear: both;"></div>
       
	<div class="row">
        
		<div class="col-md-8 col-center-block">
			
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
		          <div  class="navbar-form navbar-right">
                    <asp:TextBox ID="txb_search" runat="server" class="form-control" placeholder="输入关键字.."></asp:TextBox>
		            <asp:Button ID ="btn_search" runat="server" Text="查找" class="btn" OnClick="btn_search_Click"/>
		          </div>
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
            <div class="box box-primary " style="margin-bottom: 0px;" >
				<div class="box-header with-border ">
		             <h6 id = "time" runat="server">2016年11月28日 20:06 衡阳 晴</h6>
		        </div>
		        <div class="box-body">
		        	
					<div class="col-md-8">
				          <div class="box box-default" style="width: 100%;">
				            <div class="box-header with-border">
				              <i class="fa fa-newspaper-o"></i>

				              <h3 class="box-title">所有新闻列表（按时间排序）</h3>
				            </div>
				            <!-- /.box-header -->
				            <div class="box-body">
                                <!-----------------------------------------表格--------------------------------------->

				                        <asp:GridView ID="gdv_newsList" runat="server" AutoGenerateColumns="False" Width="100%" AllowPaging="True"
                                             PageSize="20" OnPageIndexChanging="gdv_newsList_PageIndexChanging" OnRowCommand="gdv_newsList_RowCommand">
                                            <Columns>
                                                
                                                <asp:TemplateField HeaderText="标题">
                                                    <ItemTemplate>
                                                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("id","newsDetail.aspx?articleId={0}")%>' Text='<%# Eval("title") %>'></asp:HyperLink>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="buildTime" HeaderText="发布时间" />
                                                
                                            </Columns>
     <PagerTemplate>
        <br />
         <asp:Label ID="lblPage" runat="server" Text='<%# "第" + (((GridView)Container.NamingContainer).PageIndex + 1)  + "页/共" + (((GridView)Container.NamingContainer).PageCount) + "页" %> '></asp:Label>
         <asp:LinkButton ID="lbnFirst" runat="Server" Text="首页"  Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>' CommandName="Page" CommandArgument="First" ></asp:LinkButton>
        <asp:LinkButton ID="lbnPrev" runat="server" Text="上一页" Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>' CommandName="Page" CommandArgument="Prev"  ></asp:LinkButton>
        <asp:LinkButton ID="lbnNext" runat="Server" Text="下一页" Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != (((GridView)Container.NamingContainer).PageCount - 1) %>' CommandName="Page" CommandArgument="Next" ></asp:LinkButton>
         <asp:LinkButton ID="lbnLast" runat="Server" Text="尾页"   Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != (((GridView)Container.NamingContainer).PageCount - 1) %>' CommandName="Page" CommandArgument="Last" ></asp:LinkButton> <asp:TextBox runat="server" ID="inPageNum"></asp:TextBox>
        <asp:Button ID="Button1" CommandName="go" runat="server" Text="跳转" class="btn btn-default"/>
         <br />
     </PagerTemplate>


                                        </asp:GridView>

                                <!-----------------------------------------表格--------------------------------------->
				            </div>
				            <!-- /.box-body -->
				          </div>
				          <!-- /.box -->
				        </div>
					
					<div class="col-md-4">
				          <div class="box box-default">
				            <!-- /.box-header -->
				            <div class="box-body">
				              	<div class="box box-default">
						            <div class="box-header with-border">
						              <i class="fa fa-clock-o"></i>

						              <h3 class="box-title">最新新闻</h3>
						            </div>
						            <!-- /.box-header -->
						            <div class="box-body">
						              
						               <!-----------------------------------------表格--------------------------------------->

				                        <asp:GridView ID="gdv_newestNewsList" runat="server" AutoGenerateColumns="False" Width="100%" AllowPaging="True"
                                             PageSize="5" OnPageIndexChanging="gdv_newestNewsList_PageIndexChanging" OnRowCommand="gdv_newestNewsList_RowCommand">
                                            <Columns>
                                                <asp:TemplateField HeaderText="标题">
                                                    <ItemTemplate>
                                                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("id","newsDetail.aspx?articleId={0}")%>' Text='<%# Eval("title") %>'></asp:HyperLink>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                            </Columns>
   <PagerTemplate>
        <br />
         <asp:Label ID="lblPage" runat="server" Text='<%# "第" + (((GridView)Container.NamingContainer).PageIndex + 1)  + "页/共" + (((GridView)Container.NamingContainer).PageCount) + "页" %> '></asp:Label>
       <br/>
         <asp:LinkButton ID="lbnFirst" runat="Server" Text="首页"  Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>' CommandName="Page" CommandArgument="First" ></asp:LinkButton>
        <asp:LinkButton ID="lbnPrev" runat="server" Text="上一页" Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>' CommandName="Page" CommandArgument="Prev"  ></asp:LinkButton>
        <asp:LinkButton ID="lbnNext" runat="Server" Text="下一页" Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != (((GridView)Container.NamingContainer).PageCount - 1) %>' CommandName="Page" CommandArgument="Next" ></asp:LinkButton>
         <asp:LinkButton ID="lbnLast" runat="Server" Text="尾页"   Enabled='<%# ((GridView)Container.NamingContainer).PageIndex != (((GridView)Container.NamingContainer).PageCount - 1) %>' CommandName="Page" CommandArgument="Last" ></asp:LinkButton> <asp:TextBox runat="server" ID="inPageNum"></asp:TextBox>
        <asp:Button ID="Button1" CommandName="go" runat="server" Text="跳转"/>
         <br />
     </PagerTemplate>
                                        </asp:GridView>

                                     <!-----------------------------------------表格--------------------------------------->
						              
						            </div>
						            <!-- /.box-body -->
						          </div>


								<div class="box box-default">
						            <div class="box-header with-border">
						              <i class="fa fa-fire" aria-hidden="true"></i>

						              <h3 class="box-title">热点新闻</h3>
						            </div>
						            <!-- /.box-header -->
						            <div class="box-body">
						                   <!-----------------------------------------表格--------------------------------------->

				                            <asp:GridView ID="gdv_hotNewsList" runat="server" AutoGenerateColumns="False" Width="100%" AllowPaging="True"
                                             PageSize="5" OnPageIndexChanging="gdv_hotNewsList_PageIndexChanging">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="标题">
                                                    <ItemTemplate>
                                                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("id","newsDetail.aspx?articleId={0}")%>' Text='<%# Eval("title") %>'></asp:HyperLink>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                    <asp:BoundField DataField="pageviews" HeaderText="浏览量" />

                                                </Columns>

                                            </asp:GridView>

                                         <!-----------------------------------------表格--------------------------------------->
						            </div>
						            <!-- /.box-body -->
						          </div>

				            </div>
				            <!-- /.box-body -->
				          </div>
				          <!-- /.box -->
				    </div>
		        </div>
		     </div>


		     
	    </div>
		
	</div>
</form>

	<script src="js/jquery-2.2.3.min.js"></script>
	<script src="js/bootstrap.min.js"></script>
</body>
</html>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="newsClassification.aspx.cs" Inherits="newsby118.front.newsPreview" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link  rel="stylesheet" href="css/bootstrap.min.css"/>
  	<link rel="stylesheet" href="css/AdminLTE.min.css"/>
    <link rel="stylesheet" href="css/mycss/global.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="col-md-10 col-center-block">
		<div class="box">
        <div class="box-header">
        <h3 class="box-title">新闻类别</h3>
            
        </div>
            
            <div class="box-body no-padding">
                <!-- /.box-header
              <table class="table table-condensed">
                <tbody><tr>
                  <th width="50px">#</th><th>名称</th><th>最近发表时间</th>
                </tr>
                <tr>
                  <td>1.</td><td><a>国内新闻</a></td><td>2016/11/28</td>
                </tr>
                <tr>
                  <td>2.</td>
                  <td><a>国际新闻</a></td><td>2016/11/10</td>
                </tr>
              </tbody></table>
                    -->


                <asp:GridView ID="gdv_classif" runat="server" class="table table-condensed" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="id" HeaderText="编号" />
                        <asp:TemplateField HeaderText="类别名">
                            <ItemTemplate>
                                <asp:LinkButton runat="server" ID="ClassLink" OnClick="ClassLink_Click"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="editTime" HeaderText="最新发布时间" />
                    </Columns>

                </asp:GridView>

            </div>
            
    	</div>
	</div>


    <script src="js/jquery-2.2.3.min.js"></script>
	<script src="js/bootstrap.min.js"></script>
    </form>
</body>
</html>

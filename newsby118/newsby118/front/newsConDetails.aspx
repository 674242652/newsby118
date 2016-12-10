<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="newsConDetails.aspx.cs" Inherits="newsby118.front.newsControl" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="css/bootstrap.min.css"/>
  	<link rel="stylesheet" href="css/AdminLTE.min.css"/>
    <link rel="stylesheet" href="css/mycss/global.css" />  
</head>
<body>
    <form id="form1" runat="server">
        <div class="col-md-10 col-center-block">
		    <div class="box">

                <!--
                    <div class="box-header">
                    <h3 class="box-title" runat="server" id="pageTitle">国内新闻列表</h3>
                    </div>
                    <div class="box-body no-padding" runat="server" id="artileList">
                      <table class="table table-condensed">
                            <tbody>
                            <tr>
                              <th width="50px">#</th><th>新闻名</th><th>编辑时间</th><th>状态</th>
                            </tr>

                            <tr>
                              <td>1.</td><td><a>我是新闻标题....</a></td><td>2016/11/28</td>
                              <td>
                                  <span class="badge bg-green"><a>编辑</a></span>
                                  <span class="badge bg-red">删除</span>
                   
                                  <asp:Button ID="btn_123" runat="server" Text="删除" OnClick="Delect_Click" OnClientClick="return confirm('确定删除吗？')"/>
                                  <asp:Button ID="btn_456" runat="server" Text="编辑"/>

                              </td>
                            </tr>
                          </tbody>
                      </table>
                    </div>
               -->
    	    


                <div class="box-header">
                    <h3 id="HTMLpageTitle" class="box-title" runat="server" >国内新闻列表</h3>
                 </div>
                <div class="box-body no-padding">
                <asp:GridView ID="articleList" runat="server" AutoGenerateColumns="False" class="table table-condensed" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="id" HeaderText="编号" />
                        <asp:BoundField DataField="title" HeaderText="标题" />
                        <asp:BoundField DataField="buildtime" HeaderText="编辑日期" />
                        <asp:TemplateField HeaderText="操作">
                            <ItemTemplate>
                                <span class="badge bg-green"><asp:LinkButton runat="server" OnClick="Edit_Click" ForeColor="White">编辑</asp:LinkButton></span>
                                <span class="badge bg-red">
                                    <asp:LinkButton runat="server" OnClick="Delect_Click" OnClientClick="return confirm('确定删除吗？')"  ForeColor="White">删除</asp:LinkButton>
                                </span>
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
    	        </div>

                </div>
	    </div>
    
            
        
        
        <script src="js/jquery-2.2.3.min.js"></script>




	<script src="js/bootstrap.min.js"></script>
        
    </form>
    </body>
</html>

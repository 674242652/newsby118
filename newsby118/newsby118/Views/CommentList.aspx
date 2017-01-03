<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CommentList.aspx.cs" Inherits="newsby118.Views.CommentList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


     <div class="col-center-block">
		    <div class="box">

                <div class="box-header">
                    <h3 id="HTMLpageTitle" class="box-title" runat="server" >国内新闻列表</h3>
                 </div>
                <div class="box-body no-padding">
                <asp:GridView ID="articleList" runat="server" AutoGenerateColumns="False" class="table table-condensed" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="id" HeaderText="编号" />

                        <asp:TemplateField HeaderText="评论新闻">
                            <ItemTemplate>
                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("articleId","newsDetail.aspx?articleId={0}")%>' Text='<%# Eval("articleId") %>'></asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField DataField="content" HeaderText="内容" />
                        <asp:BoundField DataField="buildTime" HeaderText="评论日期" />
                        <asp:TemplateField HeaderText="操作">
                            <ItemTemplate>
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
    
     <script>

         $('#sidebarItem20').addClass("active");
         $('#sidebarItem23').addClass("active");
     </script>
</asp:Content>

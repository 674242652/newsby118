<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="UserWaitRegistered.aspx.cs" Inherits="newsby118.Views.UserWaitRegistered" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="col-center-block">
		    <div class="box">

                <div class="box-header">
                    <h3 id="HTMLpageTitle" class="box-title" runat="server" >国内新闻列表</h3>
                 </div>
                <div class="box-body no-padding">
                <asp:GridView ID="userList" runat="server" AutoGenerateColumns="False" class="table table-condensed" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="id" HeaderText="编号" />

                        <asp:BoundField DataField="username" HeaderText="用户名" />
                        <asp:BoundField DataField="email" HeaderText="邮箱" />
                        <asp:TemplateField HeaderText="操作">
                            <ItemTemplate>
                                <span class="badge bg-green"><asp:LinkButton runat="server" OnClick="Save_Click" ForeColor="White">允许</asp:LinkButton></span>
                                <span class="badge bg-red">
                                    <asp:LinkButton runat="server" OnClick="Delect_Click" OnClientClick="return confirm('确定删除吗？')"  ForeColor="White">驳回</asp:LinkButton>
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

         $('#sidebarItem30').addClass("active");
         $('#sidebarItem31').addClass("active");
     </script>



</asp:Content>

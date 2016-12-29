<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="NewsCategory.aspx.cs" Inherits="newsby118.Views.NewsCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <div class="col-center-block">
		<div class="box">
        <div class="box-header">
        <h3 class="box-title">新闻类别</h3>
            
        </div>
            
            <div class="box-body no-padding">


                <asp:GridView ID="gdv_classif" runat="server" class="table table-condensed" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="id" HeaderText="编号" />
                        <asp:TemplateField HeaderText="类别名">
                            <ItemTemplate>
                                <asp:LinkButton runat="server" ID="ClassLink" OnClick="ClassLink_Click" Text="mmm"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="editTime" HeaderText="最新发布时间" />
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
        $('#sidebarItem21').addClass("active");
     </script>
</asp:Content>

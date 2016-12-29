<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="newsby118.Views.Test" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


   <link rel="stylesheet" href="css/mycss/global.css" />
    <link rel="stylesheet" href="css/bootstrap-wysihtml5/bootstrap3-wysihtml5.min.css"/>
    <link rel="stylesheet" href="css/mycss/global.css" />
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-12 col-center-block">
          <div class="box box-primary">
            <div class="box-header with-border">
              <h3 class="box-title">编辑新闻</h3>
            </div>

            <!-- /.box-header -->

            <div class="box-body">
              <div class="form-group">
                  <div class="input-group"> 
			      
                 
			        <asp:TextBox ID="txb_title" class="form-control" placeholder="标题:" runat="server"></asp:TextBox> 
                  
				    <div class="input-group-btn"> 
                        <asp:DropDownList ID="ddl_articleType" runat="server" class="btn btn-default dropdown-toggle"></asp:DropDownList>
				    </div> 

		          </div> 
              </div>


              <div class="form-group">
                  <asp:TextBox ID="compose_textarea" runat="server" TextMode="MultiLine" style="width:100%;height:450px;"></asp:TextBox>
                   <!-- <asp:TextBox ID="txtarea_article" runat="server" style="display:none;" TextMode="MultiLine"></asp:TextBox> -->
              </div>
              <div class="form-group">

			  


                <div class="btn btn-default btn-file">
                  <i class="fa fa-paperclip"></i> 选择文件
                  <asp:FileUpload ID="FileUpload" runat="server" />
                </div>
                
                <asp:Label ID="lab_file" runat="server" Text="Label" class="help-block">文件最大容量. 32MB</asp:Label>
              </div>
               <div class="box-footer">
              <div class="pull-right">
                <asp:Button ID="btn_finish" runat="server" Text="确认发布" class="btn btn-primary" OnClientClick="ClientClick();"  OnClick="btn_finish_Click"/>
              </div>
              <button type="reset" class="btn btn-default"><i class="fa fa-times"></i> 撤销</button>
                
            </div>
            </div>
            <!-- /.box-body -->
           

            <!-- /.box-footer -->

          </div>
          <!-- /. box -->
        </div>
    </div>
        <script src="js/bootstrap-wysihtml5/bootstrap3-wysihtml5.all.min.js"></script>
    <script>
        $(function () {
            //Add text editor
            $("#<%=compose_textarea.ClientID%>").wysihtml5();
        });

        var fileUpload = $('#FileUpload');
        fileUpload.on('change', function (e) {
            //e.currentTarget.files 是一个数组，如果支持多个文件，则需要遍历
            var file = e.currentTarget.files[0];
            var lab_file = $('#lab_file');
            lab_file.html(file.name);
            //console.log(file.name);
        });
    </script>

</asp:Content>


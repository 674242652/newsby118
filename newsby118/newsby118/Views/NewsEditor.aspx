<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="NewsEditor.aspx.cs" Inherits="newsby118.Views.NewsEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <title></title>
    <link href="kindeditor/themes/default/default.css" rel="stylesheet" type="text/css" />
    <link href="kindeditor/plugins/code/prettify.css" rel="stylesheet" type="text/css" />
    <script src="kindeditor/plugins/code/prettify.js" type="text/javascript"></script>
    <script src="kindeditor/kindeditor-all-min.js" type="text/javascript"></script>
    <script src="kindeditor/lang/zh-CN.js" type="text/javascript"></script>

     <script type="text/javascript">
         KindEditor.ready(function (K) {
             var editor1 = K.create('#<%=compose_textarea.ClientID%>', {
                 resizeType: 1,
                 allowPreviewEmoticons: false,
                 allowImageUpload: false,
                 items: [
                     'fontname', 'fontsize', '|', 'forecolor', 'hilitecolor', 'bold', 'italic', 'underline',
                     'removeformat', '|', 'justifyleft', 'justifycenter', 'justifyright', 'insertorderedlist',
                     'insertunorderedlist', '|', 'emoticons', 'image', 'link']
             });
         });
    </script>


    

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
                  <asp:TextBox ID="compose_textarea" runat="server" TextMode="MultiLine" style="width:100%;height:500px;"></asp:TextBox>
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
              <button id="btn_revoked" class="btn btn-default" runat="server" onserverclick="Revoked_Click"><i class="fa fa-times"></i> 撤销</button>
              <button id="btn_tempSave"  class="btn btn-default" runat="server" onserverclick="TempSave_Click"><i class="fa fa-clipboard"></i> 暂存</button>
                
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
        var fileUpload = $('#FileUpload');
        fileUpload.on('change', function (e) {
            //e.currentTarget.files 是一个数组，如果支持多个文件，则需要遍历
            var file = e.currentTarget.files[0];
            var lab_file = $('#lab_file');
            lab_file.html(file.name);
            //console.log(file.name);
        });
    </script>

    <script>
        document.getElementById('sidebarItem11').className = "active";
    </script>

</asp:Content>

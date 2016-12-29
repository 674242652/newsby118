<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editnews.aspx.cs" Inherits="WebApplication4.front.editnews" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title></title>
	<meta charset="utf-8">
	<link rel="stylesheet" href="css/bootstrap.min.css"/>
  	<link rel="stylesheet" href="css/AdminLTE.min.css"/>
  	<link rel="stylesheet" href="css/bootstrap-wysihtml5/bootstrap3-wysihtml5.min.css"/>
    <link rel="stylesheet" href="css/mycss/global.css" />
    <script src="js/jquery-2.2.3.min.js"></script>
	<script src="js/bootstrap.min.js"></script>
    <script src="js/bootstrap-wysihtml5/bootstrap3-wysihtml5.all.min.js"></script>
    <script>
        $(function () {
            //Add text editor
            $("#compose_textarea").wysihtml5();
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
</head>
<body>
      <div class="row">
        <div class="col-md-9 col-center-block">
          <div class="box box-primary">
            <div class="box-header with-border">
              <h3 class="box-title">编辑新闻</h3>
            </div>

            <!-- /.box-header -->
<form id="form1" runat="server" class="form-signin" role="form">

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
                    <textarea id="compose_textarea" class="form-control" style="height: 300px" name="articleContent" runat="server">
                      
                    </textarea>
                   <!-- <asp:TextBox ID="txtarea_article" runat="server" style="display:none;" TextMode="MultiLine"></asp:TextBox> -->
              </div>
              <div class="form-group">
                <div class="btn btn-default btn-file">
                  <i class="fa fa-paperclip"></i> 选择文件
                  <asp:FileUpload ID="FileUpload" runat="server" />
                </div>
                <asp:Label ID="lab_file" runat="server" Text="Label" class="help-block">文件最大容量. 32MB</asp:Label>
              </div>
            </div>
            <!-- /.box-body -->
            <div class="box-footer">
              <div class="pull-right">
                <asp:Button ID="btn_finish" runat="server" Text="确认发布" class="btn btn-primary" OnClick="btn_finish_Click"/>
              </div>
              <button type="reset" class="btn btn-default"><i class="fa fa-times"></i> 撤销</button>
                
            </div>

            <!-- /.box-footer -->
</form>

          </div>
          <!-- /. box -->
        </div>
      </div>


    
</body>
</html>

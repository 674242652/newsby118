<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchResult.aspx.cs" Inherits="WebApplication4.front.SearchResult" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>新闻搜索</title>
    <link rel="stylesheet" href="css/bootstrap.min.css">
  	<link rel="stylesheet" href="css/AdminLTE.min.css">
</head>
<body>
    <form id="form1" runat="server">
        <!-- title-->
        <div class="col-md-4">
           

            <asp:Label ID="Label1" runat="server" Text="118新闻早知道" Font-Size="XX-Large"></asp:Label>
           

            <div class="form-group ">
                  <div class="input-group"> 
			         <asp:TextBox ID="txt_search" runat="server" class="form-control" placeholder="关键字.."></asp:TextBox>
				    <div class="input-group-btn"> 
                        <asp:DropDownList ID="ddl_newscategory"  runat="server" class="btn btn-default dropdown-toggle"></asp:DropDownList>
                        <asp:Button ID="btn_Search" runat="server" Text="查询" OnClick="btn_Search_Click" class="btn btn-default" />
				    </div> 
		          </div> 
           </div>
           
        </div>

        <div style="clear:both;"></div>

        <div style="background-color:#f5f5f5;height:20px;">
        </div>

        <div  style="width:100%;">
            <!-- left-->
            <div style="width:60%;" id="searchList" runat="server">

                <div>
                    <h3 class="news_title"><a href="newsDetail.aspx">习近平总书记会见XXX</a></h3>
                    <p class="news_summary">
                        中新社莫斯科11月30日电 (记者 王修君)针对土耳其总统埃尔多安日前所说的“土军在叙开展军事行动旨在推翻阿萨德政权”的言论，俄罗斯总统新闻秘书佩斯科夫于当地时间11月30日表示，该言论性质严...

                    </p>
                    <p class="news_summary"><a>www.baidu.com</a></p>
                </div>
                


                <nav aria-label="Page navigation" id="pageTable">
                  <ul class="pagination">
                    <li>
                      <a href="#" aria-label="Previous">
                        <span aria-hidden="true">&laquo;</span>
                      </a>
                        </li>
                        <li><a href="SearchResult.aspx?page=3">1</a></li>
                        <li><a href="#">2</a></li>
                        <li><a href="#">3</a></li>
                        <li><a href="#">4</a></li>
                        <li><a href="#">5</a></li>
                        <li>
                      <a href="#" aria-label="Next">
                        <span aria-hidden="true">&raquo;</span>
                      </a>
                    </li>
                  </ul>
                </nav>


            </div >
        </div>

    </form>



     <script src="js/jquery-2.2.3.min.js"></script>
	<script src="js/bootstrap.min.js"></script>
    <script>
        //分页
        (function (){
            var number = <%=allnumber%>;
            var apage = <%=onepage%>;

            var title = new Array();
            var summary = new Array();
            var articleId = new Array();
            if(number <= apage){
                $("#pageTable").hide();
            }
            <%for(int k=0;k<allnumber;k++){%>
            title.push("<%=title[k]%>");
            summary.push("<%=summary[k]%>");
            articleId.push("<%=articleId[k]%>")
            <%}%>  

            var listValue = "";

            for(var i=0;i<number;i++){
                var url = "http://118news/news/"+articleId[i]+".shtml"
                var hhref = "newsDetail.aspx?articleId="+articleId[i];
                listValue+="<div><h3 class=\"news_title\"><a href=\""+hhref+"\">"+title[i]+"</a></h3><p class=\"news_summary\">"+summary[i]+"...</p><p class=\"news_summary\"><a href=\""+hhref+"\">"+url+"</a> <span> 2016/02/22 10:22:22</span></p></div>";
            }
            // /alert(title[1]+"");
            $('#searchList').html(listValue);
        })();


    </script>

</body>
</html>

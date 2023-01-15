<%@ Page Title="" Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" CodeBehind="Files.aspx.cs" Inherits="WebApplication1.Files" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>




<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <!-- form -->
    <div class="row">
        <div class="col-lg-4 col-lg-offset-4 col-centered">
    <div class="input-group margin-top-30p" >

        <div class="input-group mb-3" >
             <span class="input-group-text">اسم الملف</span>
            <asp:TextBox type="text" ID="file_title" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        
        <div class="input-group mb-3">
            <label class="input-group-text" for="inputGroupFile">الملف</label>
            <asp:FileUpload onchange="readURL(this);" CssClass="form-control" ID="file_path" runat="server" />
	    </div>

        <div class="input-group mb-3" >
            <span class="input-group-text">المستخدم</span>
            <asp:DropDownList CssClass="form-select" ID="user_name" runat="server">
                <asp:ListItem Text="D1" Value="d1" />
                <asp:ListItem Text="D2" Value="d2" />
            </asp:DropDownList>
        </div>

        <div class="input-group mb-3" >
              <span class="input-group-text">ملاحظات</span>
            <asp:TextBox TextMode="MultiLine" ID="notes" runat="server" CssClass="form-control"></asp:TextBox>
        </div>   

    </div>
        <div class="alert alert-success margin-top-10p alert-dismissible fade show" role="alert" id="alert" runat="server" Visible="false">
            <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
            <asp:Label ID="lmsg" runat="server" Text="رسالة تحذير"></asp:Label>          
       </div>

</div>
</div>


    <!-- buttons -->
    <div class="mt-3 text-center">
        <asp:Button ID="bt_add" runat="server" CssClass="btn btn-primary btn-lg w-25" Text="رفع ملف" OnClick="bt_add_click" />
    </div>

    <script type="text/javascript">
            document.getElementById("files").classList.add("active");
    </script>

</asp:Content>

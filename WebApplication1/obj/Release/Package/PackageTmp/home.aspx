<%@ Page Title="" Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="WebApplication1.home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <asp:GridView ID="Files" runat="server" AutoGenerateColumns="false"
        CssClass=" text-center col-centered margin-top-30p table table-bordered table-condensed table-responsive table-hover table-light w-50"
        OnRowDataBound="Files_RowDataBound">

		 <Columns>
            <asp:BoundField DataField="FILE_ID" HeaderText ="معرف الملف" />
            <asp:BoundField DataField="TITLE" HeaderText ="اسم الملف" />
            <asp:BoundField DataField="USER_NAME" HeaderText ="اسم المستخدم" />
            <asp:BoundField DataField="UPLOAD_DATE" HeaderText ="تاريخ الرفع" />
            <asp:BoundField DataField="PATH" HeaderText ="مسار الملف" Visible="false"/>
            <asp:BoundField DataField="NOTES" HeaderText ="ملاحظات" />
            <asp:BoundField DataField="DOWNLOAD" HeaderText ="التحميلات" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton CssClass="btn btn-danger" ID="delete" Text="حذف" runat="server" CommandArgument='<%# Eval("FILE_ID") %>' OnClick="DeleteFile"/>
                </ItemTemplate>
            </asp:TemplateField>

                <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton CssClass="btn btn-secondary" ID="lnkDownload" Text="تحميل" CommandArgument='<%# Eval("PATH") %>' runat="server" OnClick="DownloadFile"/>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>

    </asp:GridView>


      <script type="text/javascript">
          document.getElementById("home").classList.add("active");
      </script>
</asp:Content>

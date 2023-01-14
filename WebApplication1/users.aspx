<%@ Page Title="" Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" CodeBehind="users.aspx.cs" Inherits="WebApplication1.users" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="container">

        <div class="alert alert-success mt-5 alert-dismissible fade show col-7 mx-auto" role="alert" id="alert_success" runat="server" Visible="false">
        <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
        <asp:Label ID="lmsg_success" runat="server" Text="رسالة تحذير بالأخضر"></asp:Label>          
       </div>

         <div class="alert alert-danger mt-5 alert-dismissible fade show col-7 mx-auto" role="alert" id="alert_danger" runat="server" Visible="false">
        <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
        <asp:Label ID="lmsg_danger" runat="server" Text="رسالة تحذير بالأحمر"></asp:Label>          
       </div>

            <asp:GridView ID="USERS_View" runat="server" AutoGenerateColumns="false" ShowFooter="true" DataKeyNames="USER_ID"
                ShowHeaderWhenEmpty="true"

                OnRowCommand="USERS_View_RowCommand" OnRowEditing="USERS_View_RowEditing" OnRowCancelingEdit="USERS_View_RowCancelingEdit"
                OnRowUpdating="USERS_View_RowUpdating" OnRowDeleting="USERS_View_RowDeleting"
                CssClass="text-center col-centered table table-bordered table-condensed table-responsive table-hover table-light w-80 mt-3">

               
                
                <Columns>

                    <asp:TemplateField HeaderText="المعرف">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("USER_ID") %>' runat="server" />
                        </ItemTemplate>
                      
                    </asp:TemplateField>




                    <asp:TemplateField HeaderText="الاسم الأول">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("FirstName") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="FirstName" Text='<%# Eval("FirstName") %>' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="FirstName" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="الاسم الثاني">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("LastName") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="LastName" Text='<%# Eval("LastName") %>' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="LastName" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>




                    <asp:TemplateField HeaderText="البريد الإلكتروني">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("EMAIL") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="EMAIL" Text='<%# Eval("EMAIL") %>' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="EMAIL" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>


                  <asp:TemplateField HeaderText="كلمة المرور">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("PASS") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="Password" Text='<%# Eval("PASS") %>' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="Password" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>




                    <asp:TemplateField HeaderText="نوع الرتبة">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("USER_TYPE") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="USERTYPE" Text='<%# Eval("USER_TYPE") %>' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="USERTYPE" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ImageUrl="~/Images/edit.png" runat="server" CommandName="Edit" ToolTip="Edit" Width="20px" Height="20px"/>
                            <asp:ImageButton ImageUrl="~/Images/delete.png" runat="server" CommandName="Delete" ToolTip="Delete" Width="20px" Height="20px"/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:ImageButton ImageUrl="~/Images/save.png" runat="server" CommandName="Update" ToolTip="Update" Width="20px" Height="20px"/>
                            <asp:ImageButton ImageUrl="~/Images/cancel.png" runat="server" CommandName="Cancel" ToolTip="Cancel" Width="20px" Height="20px"/>
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:ImageButton ImageUrl="~/Images/addnew.png" runat="server" CommandName="AddNew" ToolTip="Add New" Width="20px" Height="20px"/>
                        </FooterTemplate>
                    </asp:TemplateField>
                </Columns>


            </asp:GridView>

        </div>

        <script type="text/javascript">
            document.getElementById("users").classList.add("active");
        </script>

</asp:Content>

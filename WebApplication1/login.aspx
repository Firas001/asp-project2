<%@ Page Title="" Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WebApplication1.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">

        <div class="alert alert-danger mt-3 alert-dismissible fade show col-7 mx-auto" role="alert" id="alert" runat="server" Visible="false">
        <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
        <asp:Label ID="lmsg" runat="server" Text="رسالة تحذير"></asp:Label>          
       </div>

    <div class="row">
      <div class="col-sm-9 col-md-7 col-lg-5 mx-auto">
        <div class="card border-0 shadow rounded-3 my-5">
          <div class="card-body p-4 p-sm-5">
            <h5 class="card-title text-center mb-5 fw-light fs-5">تسجيل الدخول</h5>
              <div class="form-floating mb-3">
                 <asp:TextBox type="text" ID="user_name" runat="server" CssClass="form-control rtl" placeholder="name@example.com"></asp:TextBox>
                <asp:Label ID="email_label" runat="server" Text="أسم المستخدم" AssociatedControlId="user_name" CssClass="rtl"></asp:Label>
              </div>
              <div class="form-floating mb-3">
                 <asp:TextBox type="password" ID="password" runat="server" CssClass="form-control rtl" placeholder="Password"></asp:TextBox>
                <asp:Label ID="password_label" runat="server" Text="كلمة المرور" AssociatedControlId="password" CssClass="rtl"></asp:Label>
              </div>

              <div class="form-check mb-3">
                 <asp:CheckBox ID="loginRemember" runat="server"></asp:CheckBox>
                 <asp:Label ID="loginRememberLabel" runat="server" Text="تذكرني" AssociatedControlId="loginRemember" CssClass="form-check-label"></asp:Label>
              </div>
              <div class="d-grid mb-2">
                  <asp:Button ID="Login" runat="server" Text="تسجيل الدخول" CssClass="btn btn-primary btn-login text-uppercase fw-bold" OnClick="Login_Click"/>
              </div>
              <div class="d-grid mb-2">
                  <asp:Button ID="register" runat="server" Text="تسجيل حساب جديد" CssClass="btn btn-success btn-login text-uppercase fw-bold" OnClick="Register_Click"/>
              </div>
              <hr class="my-4">
              <div class="d-grid mb-2">
                <button class="btn btn-google btn-login text-uppercase fw-bold" type="submit">
                  <i class="fab fa-google me-2"></i> تسجيل الدخول بواسطة Google
                </button>
              </div>
              <div class="d-grid">
                <button class="btn btn-facebook btn-login text-uppercase fw-bold" type="submit">
                  <i class="fab fa-facebook-f me-2"></i> تسجيل الدخول بواسطة Facebook
                </button>
              </div>
          </div>
        </div>
      </div>
    </div>
  </div>


</asp:Content>

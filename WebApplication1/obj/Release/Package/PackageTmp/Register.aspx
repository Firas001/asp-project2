<%@ Page Title="" Language="C#" MasterPageFile="~/main.master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WebApplication1.Register" %>
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
                 <asp:TextBox type="text" ID="user_name" runat="server" CssClass="form-control rtl" placeholder="username" pattern="[A-Za-z].{3,}" title="يجب الكتابة بالحروف الإنجليزية، 4 أحرف على الأقل"></asp:TextBox>
                <asp:Label ID="user_name_label" runat="server" Text="اسم المستخدم" AssociatedControlId="user_name" CssClass="rtl"></asp:Label>
                  <asp:RequiredFieldValidator runat="server" id="user_name_Required" controltovalidate="user_name" errormessage="اسم المستخدم مطلوب!" ForeColor="Red" />
              </div>
              <div class="row g-2">


                <div class="form-floating mb-3 col-md">
                 <asp:TextBox type="text" ID="first_name" runat="server" CssClass="form-control rtl" placeholder="FirstName"></asp:TextBox>
                <asp:Label ID="first_name_label" runat="server" Text="الاسم" AssociatedControlId="first_name" CssClass="rtl"></asp:Label>
                 <asp:RequiredFieldValidator runat="server" id="first_name_Required" controltovalidate="first_name" errormessage="الاسم الأول مطلوب!" ForeColor="Red" />
              </div>

              <div class="form-floating mb-3 col-md">
                 <asp:TextBox type="text" ID="last_name" runat="server" CssClass="form-control rtl" placeholder="LastName"></asp:TextBox>
                <asp:Label ID="last_name_label" runat="server" Text="اللقب" AssociatedControlId="last_name" CssClass="rtl"></asp:Label>
              </div>

                  </div>

              <div class="form-floating mb-3">
                 <asp:TextBox type="emai" ID="email" runat="server" CssClass="form-control rtl" placeholder="Password"></asp:TextBox>
                <asp:Label ID="password_label" runat="server" Text="البريد الإلكتروني" AssociatedControlId="email" CssClass="rtl"></asp:Label>
                 <asp:RequiredFieldValidator runat="server" id="email_Required" controltovalidate="email" errormessage="البريد الإلكتروني مطلوب!" ForeColor="Red" />
              </div>

              <hr>

               <div class="form-floating mb-3">
                 <asp:TextBox type="password" ID="password" runat="server" CssClass="form-control rtl" placeholder="password" TextMode="Password" pattern="(?=.*[a-z])(?=.*[A-Z]).{4,}" title="يجب أن تكون كلمة المرور أربع حروف على الأقل وتحتوي على حرف كبير وحرف صغير"></asp:TextBox>
                <asp:Label ID="Label1" runat="server" Text="كلمة المرور" AssociatedControlId="password" CssClass="rtl"></asp:Label>
              </div>
              <div class="form-floating mb-3">
                 <asp:TextBox type="password" ID="confirm_password" runat="server" CssClass="form-control rtl" placeholder="Password"></asp:TextBox>
                <asp:Label ID="confirm_password_label" runat="server" Text="إعادة إدخال كلمة المرور" AssociatedControlId="confirm_password" CssClass="rtl"></asp:Label>


                  <!-- رسالة عدم مطابقة كلمة المرور -->
                          <asp:CompareValidator id="comparePasswords" runat="server" ControlToCompare="password" ControlToValidate="confirm_password"
                    ErrorMessage="كلمة المرور غير متطابقة." ForeColor="Red" Display="Dynamic">
                    </asp:CompareValidator>

                    <asp:RequiredFieldValidator ID="rfvUserName" runat="server" 
                ControlToValidate="confirm_password" 
                CssClass="ValidationError"
                ErrorMessage="يجب إعادة كتابة كلمة المرور"
                 ForeColor="Red">
                    </asp:RequiredFieldValidator>

              </div>



              <div class="d-grid">
                  <asp:Button ID="submit" runat="server" Text="تسجيل حساب جديد" CssClass="btn btn-primary btn-login text-uppercase fw-bold" OnClick="Submit_Click"/>
              </div>
              <hr class="my-4">
              <div class="d-grid mb-2">
                <button class="btn btn-google btn-login text-uppercase fw-bold rtl" type="submit">
                  <i class="fab fa-google me-2"></i> التسجيل بواسطة Google
                </button>
              </div>
              <div class="d-grid">
                <button class="btn btn-facebook btn-login text-uppercase fw-bold rtl" type="submit">
                  <i class="fab fa-facebook-f me-2"></i> التسجيل بواسطة Facebook
                </button>
              </div>
          </div>
        </div>
      </div>
    </div>
  </div>



</asp:Content>

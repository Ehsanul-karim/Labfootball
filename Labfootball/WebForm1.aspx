<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Labfootball.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="container text-center">
        <h1 class="mt-5">Welcome!</h1>

        <div class="row mt-4">
            <div class="col-md-3"></div>
            <div class="col-md-3"><a href="Addcourse.aspx" class="btn btn-outline-info btn-block">Add a course</a></div>
            <div class="col-md-3"><a href="ListCourse.aspx" class="btn btn-info btn-block">Show all courses</a></div>
            <div class="col-md-3"></div>
        </div>

    </div>
</asp:Content>

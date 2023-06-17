 <%@ Page Title="" Language="C#" MasterPageFile="~/Main1.Master" AutoEventWireup="true" CodeBehind="AddPlayerRecord.aspx.cs" Inherits="Labfootball.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

       <script type="text/javascript">
           $(document).ready(function () {
               $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
           });

           function readURL(input) {
               if (input.files && input.files[0]) {
                   var reader = new FileReader();

                   reader.onload = function (e) {
                       $('#imgview').attr('src', e.target.result);
                   };

                   reader.readAsDataURL(input.files[0]);
               }
           }

           function readURL2(imageUrl) {
               $('#imgview').attr('src', imageUrl);
           }
           function readURL3(imageUrl2) {
               $('#imgview2').attr('src', imageUrl2);
           }

       </script>
    <style>
    .action-buttons {
        display: flex;
          outline: none;
  border: none;
    }

    .action-button {
        font-size: 20px;
        padding: 5px 10px;
        border-radius: 5px;
        cursor: pointer;
    }

    .edit-button {
        background-color: #0298cf;
        color: white;
    }

    .delete-button {
        background-color: #f80000;
        color: white;
    }
    label{
        display:flex;
        width:auto;
        height:auto;
    }
    .peoples {
    display: flex;
    justify-content: flex-start;
    align-items: center;
    text-align: start;
    }
    .playerimg {
    width: 180px;
    height: 60px;
    object-fit: cover;
    border-radius: 50%;
    margin-right: 15px;
    }

        </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main-content" id="main-content">
    <div class="intro-wrap">
      <div class="container-fluid">
        <div class="row">
          <div class="col-md-3">
            <div class="card">

                <div class="row">
                  <div class="col">
                    <center>
                      <h4>Player Details</h4>
                    </center>
                  </div>
                </div>
                <div class="row">
                  <div class="col">
                      <center>
                        <img src="book_inventory/icon.png" id="imgview" alt="Player Image"  class="img-fluid"  style="width:100px; border-radius: 50%;"/>
                      </center>                    
                  </div>
                </div>
                <div class="row">
                  <div class="col">
                    <asp:FileUpload class="form-control" onChange="readURL(this);" ID="FileUpload1" runat="server" BackColor="#e5e4e2" Enabled="false"/>
                  </div>
                </div>
                <div class="row">
                  <div class="col-md-7">
                    <label>Player ID</label>
                    <div class="form-group">
                      <div class="input-group">
                          <asp:Label CssClass="form-control" ID="TextBox1" runat="server" placeholder="Player ID" BackColor="#e5e4e2" Enabled="false"></asp:Label>
                        <asp:LinkButton class="btn btn-primary" ID="LinkButton4" runat="server" OnClick="Button4_Click"><i class="fas fa-check-circle"></i>   </asp:LinkButton>
                      </div>
                    </div>
                  </div>
                </div>
                <div class="row">
                   <div class="col-md-10">
                    <label>Player Name</label>
                    <div class="form-group">
                      <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Name" BackColor="#e5e4e2" Enabled="false"></asp:TextBox>
                    </div>
                  </div>
                 </div>
                <div class="row">
                  <div class="col-md-6">
                    <label>Country</label>
                    <div class="form-group">
                      <asp:DropDownList class="form-control" ID="DropDownList1" runat="server" BackColor="#e5e4e2" Enabled="false">
                        <asp:ListItem Text="" Value="Country" Enabled />
                        <asp:ListItem Text="England" Value="England" />
                        <asp:ListItem Text="Brazil" Value="Brazil" />
                        <asp:ListItem Text="Spain" Value="Spain" />
                        <asp:ListItem Text="Argentina" Value="Argentina" />
                        <asp:ListItem Text="Germany" Value="Germany" />
                        <asp:ListItem Text="Others" Value="Others" />
                      </asp:DropDownList>
                    </div>
                  </div>
                  <div class="col-md-6">
                    <label>Position</label>
                    <div class="form-group">
                      <asp:DropDownList class="form-control" ID="DropDownList3" runat="server" BackColor="#e5e4e2" Enabled="false">
                        <asp:ListItem Text="" Value="Position" Enabled />
                        <asp:ListItem Text="Forward" Value="Forward" />
                        <asp:ListItem Text="Mid-Fielder" Value="Mid-Fielder" />
                        <asp:ListItem Text="Defence" Value="Defence" />
                        <asp:ListItem Text="Goal-Keeper" Value="Goal-Keeper" />
                      </asp:DropDownList>
                    </div>
                  </div>
                </div>
                  <div class="row">
                      <div class="col-md-8">
                        <label>Join Date</label>
                        <div class="form-group">
                            <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Date" TextMode="Date" BackColor="#e5e4e2" Enabled="false"></asp:TextBox>
                        </div>
                     </div>
                     <div class="col-md-4">
                        <label>Age</label>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="TextBox9" runat="server" placeholder="Age" BackColor="#e5e4e2" Enabled="false"></asp:TextBox>
                            </div>
                        </div>
                     </div>
                  <div class="row">
                       <div class="col-md-7">
                    <label>Skills</label>
                    <div class="form-group">
                      <asp:ListBox CssClass="form-control" ID="ListBox1" runat="server" SelectionMode="Multiple" Rows="5" BackColor="#e5e4e2" Enabled="false">
                        <asp:ListItem Text="Double Touch" Value="Double Touch" />
                        <asp:ListItem Text="Flip Flop" Value="Flip Flop" />
                        <asp:ListItem Text="Sombrero" Value="Sombrero" />
                        <asp:ListItem Text="Cross Over Turn" Value="Cross Over Turn" />
                        <asp:ListItem Text="Cut Behind & Turn" Value="Cut Behind & Turn" />
                        <asp:ListItem Text="Inside Bounce" Value="Inside Bounce" />
                        <asp:ListItem Text="Heading" Value="Heading" />
                        <asp:ListItem Text="Chip Shot Control" Value="Chip Shot Control" />
                        <asp:ListItem Text="Knuckle Shot" Value="Knuckle Shot" />
                        <asp:ListItem Text="Rising Shots" Value="Rising Shots" />
                        <asp:ListItem Text="Dipping Shots" Value="Dipping Shots" />
                        <asp:ListItem Text="Acrobatic Finishing" Value="Acrobatic Finishing" />
                      </asp:ListBox>
                    </div>
                  </div>
                  </div>
                <div class="row">
                  <div class="col-md-6">
                    <label>Salary($)</label>
                    <div class="form-group">
                      <asp:TextBox CssClass="form-control" ID="TextBox10" runat="server" placeholder="Salary" TextMode="Number" BackColor="#e5e4e2" Enabled="false"></asp:TextBox>
                    </div>
                  </div>
                  <div class="col-md-6">
                    <label>Market Price($)</label>
                    <div class="form-group">
                      <asp:TextBox CssClass="form-control" ID="TextBox11" runat="server" placeholder="Price" TextMode="Number" BackColor="#e5e4e2" Enabled="false"></asp:TextBox>
                    </div>
                  </div>
                </div>
                <br>
                <div class="row">
                  <div class="col-6">
                    <asp:Button ID="AddButton" class="btn btn-lg btn-block btn-success" runat="server" Text="Add" OnClick="AddButton_Click"/>
                  </div>
                  <div class="col-6">
                    <asp:Button ID="DoneButton" class="btn btn-lg btn-block btn-success" runat="server" Text="Done" OnClick="DoneButton_Click" Visible="false" />
                  </div>
                </div>
            </div>
            <a href="home_m.aspx">Back to Home</a><br>
            <br>
          </div>
          <div class="col-md-9">
            <div class="board_wrap">
                <div class="row">
                  <div class="col">
                    <center>
                      <h4>Player Inventory List for <asp:Label ID="session_club2" runat="server" Text=""></asp:Label></h4>
                    </center>
                  </div>
                </div>
                <div class="row">
                  <div class="col">
                    <hr>
                  </div>
                </div>

                <div class="row">
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:WebProjectConnectionString2 %>" ProviderName="<%$ ConnectionStrings:WebProjectConnectionString2.ProviderName %>" SelectCommand="GetPlayersByClub" SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="session_club2" PropertyName="Text" Name="ClubName" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                  <div class="col">
                    <asp:GridView class="table table-striped table-bordered content_table" width="100%" ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnRowCommand="GridView1_RowCommand" DataKeyNames="player_id">
                        <Columns>
                            <asp:BoundField DataField="player_id" HeaderText="ID" SortExpression="player_id" />
                            <asp:TemplateField HeaderText="Player Details">
                                <ItemTemplate>
                                    <div class="container-fluid">
                                        <div class="row">
                                            <div class="col-lg-2 peoples">
                                                    <asp:Image class="img-fluid playerimg" ID="Image1" runat="server" ImageUrl='<%# Eval("image") %>' />
                                            </div>
                                            <div class ="col-lg-10">
                                                <div class="row">
                                                    <div class="col-12">
                                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("player_name") %>' Font-Bold="True" Font-Size="X-Large"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-12">
                                                        &nbsp;<asp:Label ID="Label2" runat="server" Text='<%# Eval("age") %>' BackColor="#C7C7C7"></asp:Label>
                                                        &nbsp;years old, &nbsp;<asp:Label ID="Label3" runat="server" Text='<%# Eval("position") %>'></asp:Label>
                                                        &nbsp;</div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-12">
                                                        Country:
                                                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("country") %>' Font-Size="Large"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-12">
                                                        From:
                                                        <asp:Label ID="Label5" runat="server" Text='<%# Eval("join_date", "{0:D}") %>' Font-Size="Large"></asp:Label>
                                                        , Till:
                                                        <asp:Label ID="Label8" runat="server" Text="Now" Font-Size="Large"></asp:Label>
                                                    </div>
                                                </div>
                                               <div class="row">
                                                    <div class="col-6">
                                                        Market Price:
                                                        <asp:Label ID="Label6" runat="server" Text='<%# Eval("market_price") %>'></asp:Label>$
                                                    </div>
                                                    <div class="col-2">                                
                                                    </div>
                                                   <div class="col-4">
                                                       Salary:
                                                       <asp:Label ID="Label7" runat="server" Text='<%# Eval("salary") %>'></asp:Label>
                                                       &nbsp;$
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="skillStatus" HeaderText="skillStatus" SortExpression="skillStatus" />
                            <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <div class="action-buttons">
                                         <asp:LinkButton ID="EditButton" runat="server" CssClass="action-button edit-button" CommandName="upd" CommandArgument='<%# Eval("player_id") %>'>
                                             <i class="fa-solid fa-pen-to-square"></i>
                                         </asp:LinkButton>
                                         <asp:LinkButton ID="DeleteButton" runat="server" CssClass="action-button delete-button" CommandName="del" CommandArgument='<%# Eval("player_id") %>'>
                                             <i class="fa-solid fa-trash"></i>
                                         </asp:LinkButton>
                                     </div>
                                 </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                      </asp:GridView>
                  </div>
                </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
       <div class="sidebar" id="sidebar">
        <div class="club-content">
            <img src=""  id="imgview2" alt="club Image"  class="img-fluid"  style="width:100px; border-radius: 50%;" />
            <h4><asp:Label ID="session_club" runat="server" Text=""></asp:Label></h4> 
        </div>
        <ul class="nav-links">
               <li class="nav-item"> <a id="homeLink" runat="server" href="home_m.aspx"><i class="fa-solid fa-house"></i><span>Home</span></a></li>
             <li class="nav-item active"><a href="#"><i class="fa-solid fa-person-running"></i><span>Adding Player</span></a></li>
        </ul>
         <ul class="nav-links settings-menu">
            <li class="nav-item"> <a href="#"><i class="fa-solid fa-gear"></i><span>Settings</span></a></li>
            <li class="nav-item"> <a href="firstLogin.aspx"><i class="fa-solid fa-arrow-right-from-bracket"></i><span>Log out</span></a></li>
         </ul>
       </div>
</asp:Content>

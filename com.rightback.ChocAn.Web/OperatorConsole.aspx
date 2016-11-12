<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OperatorConsole.aspx.cs" Inherits="com.rightback.ChocAn.Web.OperatorConsole" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <ul id="profileTabs2" class="nav nav-tabs">
        <li class="active"><a href="#Members" aria-controls="Members" role="tab" data-toggle="tab">Members</a></li>
        <li><a href="#Providers" aria-controls="Providers" role="tab" data-toggle="tab">Providers</a></li>
    </ul>
    
    <div class="tab-content" id="myTabContent2">
        <div id="Members" class="tab-pane active">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">

                <ContentTemplate>
                    <br>
                    </br>
                    <asp:TextBox ID="TextBoxSerchMembers" runat="server" placeHolder="Search Keword" OnTextChanged="TextBoxSerchMembers_TextChanged" AutoPostBack="true"></asp:TextBox>
                     <br>
                     </br>
                    <asp:GridView class="col-lg-8 col-xs-12 col-centered" ID="GridViewMembers" runat="server" AllowPaging="True" PageSize="20"  AutoGenerateColumns="False" CellPadding="3" DataKeyNames="MemberID" ForeColor="Black" GridLines="Vertical" 
                         OnPageIndexChanging  ="GridViewMembers_PageIndexChanging" OnRowDeleting="GridViewMembers_RowDeleting" OnRowCommand="GridViewMembers_RowCommand" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" ShowHeaderWhenEmpty="true" EmptyDataText="No data found">

                        <AlternatingRowStyle BackColor="#CCCCCC" />
                        <Columns>
                            <asp:CommandField ShowDeleteButton="True" ShowSelectButton="True" ShowCancelButton="False" />
                            <asp:BoundField DataField="MemberID" HeaderText="MemberID" InsertVisible="False" ReadOnly="True" SortExpression="MemberID"  />
                            <asp:TemplateField HeaderText="Name" SortExpression="Name">                             
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="StreetAddres" SortExpression="StreetAddres">
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("StreetAddres") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="City" SortExpression="City">
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("City") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                                  <asp:TemplateField HeaderText="State" SortExpression="State">
                                <ItemTemplate>
                                    <asp:Label ID="LabelState" runat="server" Text='<%# Bind("State") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Zip" SortExpression="Zip">
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("Zip") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Email" SortExpression="Email">
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Code" SortExpression="Code">
                                <ItemTemplate>
                                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("Code") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Status" SortExpression="Status">
                                <ItemTemplate>
                                    <asp:Label ID="Label7" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#CCCCCC" />
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#808080" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#383838" />

                    </asp:GridView>

                    <div class="container">
                        <div class="row">
                            <div class="col-xs-6">
                                Selected Member Is:<asp:DetailsView ID="DetailsViewForMember" ViewStateMode="Enabled" runat="server" AutoGenerateRows="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataKeyNames="MemberID" Height="50px" Width="125px" OnItemUpdating="DetailsViewForMember_ItemUpdating" OnItemInserting="DetailsViewForMember_ItemInserting" OnModeChanging="DetailsViewForMember_ModeChanging"  ForeColor="Black" GridLines="Vertical">
                                    <AlternatingRowStyle BackColor="#CCCCCC" />
                                    <EditRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                    <Fields>
                                        <asp:BoundField DataField="MemberID" HeaderText="MemberID" InsertVisible="False" ReadOnly="True" SortExpression="MemberID" />
                                        <asp:TemplateField HeaderText="Name" SortExpression="Name">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                                                <asp:RequiredFieldValidator  ValidationGroup="member" runat="server" ID="NameValidator"
                                                    ForeColor="Red" ErrorMessage="Please enter the name" ControlToValidate="TextBox1" />
                                                <asp:RegularExpressionValidator  ValidationGroup="member" Display="Dynamic" ForeColor="Red" ControlToValidate="TextBox1" ID="RegularExpressionValidator1" ValidationExpression="^[\s\S]{5,25}$" runat="server" ErrorMessage="Minimum 5 and Maximum 25 characters required."></asp:RegularExpressionValidator>
                                            </EditItemTemplate>
                                            <InsertItemTemplate>
                                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                                                <asp:RequiredFieldValidator  ValidationGroup="member" runat="server" ID="NameValidator2"
                                                    ForeColor="Red" ErrorMessage="Please enter the name" ControlToValidate="TextBox1" />
                                                <asp:RegularExpressionValidator  ValidationGroup="member" Display="Dynamic" ForeColor="Red" ControlToValidate="TextBox1" ID="RegularExpressionValidator2" ValidationExpression="^[\s\S]{5,25}$" runat="server" ErrorMessage="Minimum 5 and Maximum 25 characters required."></asp:RegularExpressionValidator>
                                            </InsertItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="StreetAddres" SortExpression="StreetAddres">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("StreetAddres") %>'></asp:TextBox>
                                                <asp:RequiredFieldValidator  ValidationGroup="member" runat="server" ID="StreetAddresValidator"
                                                    ForeColor="Red" ErrorMessage="Please enter the street address" ControlToValidate="TextBox2" />
                                                <asp:RegularExpressionValidator  ValidationGroup="member" Display="Dynamic" ForeColor="Red" ControlToValidate="TextBox2" ID="RegularExpressionValidator3" ValidationExpression="^[\s\S]{5,25}$" runat="server" ErrorMessage="Minimum 5 and Maximum 25 characters required."></asp:RegularExpressionValidator>
                                            </EditItemTemplate>
                                            <InsertItemTemplate>
                                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("StreetAddres") %>'></asp:TextBox>
                                                <asp:RequiredFieldValidator  ValidationGroup="member" runat="server" ID="StreetAddresValidator2"
                                                    ForeColor="Red" ErrorMessage="Please enter the street address" ControlToValidate="TextBox2" />
                                                <asp:RegularExpressionValidator  ValidationGroup="member" Display="Dynamic" ForeColor="Red" ControlToValidate="TextBox2" ID="RegularExpressionValidator4" ValidationExpression="^[\s\S]{5,25}$" runat="server" ErrorMessage="Minimum 5 and Maximum 25 characters required."></asp:RegularExpressionValidator>
                                            </InsertItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("StreetAddres") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="City" SortExpression="City">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("City") %>'></asp:TextBox>
                                                <asp:RequiredFieldValidator runat="server" ID="CityValidator"
                                                    ForeColor="Red" ErrorMessage="Please enter the name" ControlToValidate="TextBox3" />
                                                <asp:RegularExpressionValidator Display="Dynamic" ForeColor="Red" ControlToValidate="TextBox3" ID="RegularExpressionValidator5" ValidationExpression="^[\s\S]{2,14}$" runat="server" ErrorMessage="Minimum 2 and Maximum 14 characters required."></asp:RegularExpressionValidator>
                                            </EditItemTemplate>
                                            <InsertItemTemplate>
                                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("City") %>'></asp:TextBox>
                                                <asp:RequiredFieldValidator  ValidationGroup="member" runat="server" ID="CityValidator2"
                                                    ForeColor="Red" ErrorMessage="Please enter the name" ControlToValidate="TextBox3" />
                                                <asp:RegularExpressionValidator  ValidationGroup="member"  Display="Dynamic" ForeColor="Red" ControlToValidate="TextBox3" ID="RegularExpressionValidator6" ValidationExpression="^[\s\S]{2,14}$" runat="server" ErrorMessage="Minimum 2 and Maximum 14 characters required."></asp:RegularExpressionValidator>
                                            </InsertItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("City") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="State" SortExpression="State">
                                            <EditItemTemplate>
                                                <asp:DropDownList ID="DdlForState" runat="server" DataSource="<%# Enum.GetNames(typeof(com.rightback.ChocAn.DAL.Entities.USState.State))%>" SelectedItem='<%# Bind("State") %>'>
                                                </asp:DropDownList>
                                           </EditItemTemplate>
                                            <InsertItemTemplate>
                                                <asp:DropDownList ID="DdlForState" runat="server" DataSource="<%# Enum.GetNames(typeof(com.rightback.ChocAn.DAL.Entities.USState.State))%>">
                                                </asp:DropDownList>
                                            </InsertItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label6" runat="server" Text='<%# Bind("State") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Zip" SortExpression="Zip">
                                            <EditItemTemplate>

                                                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Zip") %>'></asp:TextBox>
                                                <asp:RequiredFieldValidator runat="server" ID="ZipValidator"
                                                    ForeColor="Red" ErrorMessage="Please enter zip code" ControlToValidate="TextBox4" />
                                                <asp:RegularExpressionValidator Display="Dynamic" ForeColor="Red" ControlToValidate="TextBox4" ID="RegularExpressionValidator7" ValidationExpression="^[0-9]{5,5}$" runat="server" ErrorMessage="Code of 5 digits is needed"></asp:RegularExpressionValidator>

                                            </EditItemTemplate>
                                            <InsertItemTemplate>
                                                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Zip") %>'></asp:TextBox>
                                                <asp:RequiredFieldValidator  ValidationGroup="member" runat="server" ID="ZipValidator2"
                                                    ForeColor="Red" ErrorMessage="Please enter zip code" ControlToValidate="TextBox4" />
                                                <asp:RegularExpressionValidator  ValidationGroup="member" Display="Dynamic" ForeColor="Red" ControlToValidate="TextBox4" ID="RegularExpressionValidator8" ValidationExpression="^[0-9]{5,5}$" runat="server" ErrorMessage="Code of 5 digits is needed"></asp:RegularExpressionValidator>
                                            </InsertItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("Zip") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Email" SortExpression="Email">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Email") %>'></asp:TextBox>
                                                <asp:RequiredFieldValidator  ValidationGroup="member" runat="server" ID="EmailValidator"
                                                    ForeColor="Red"  ErrorMessage="Please enter Email" ControlToValidate="TextBox5" />
                                                <asp:RegularExpressionValidator  ValidationGroup="member"  Display="Dynamic" ForeColor="Red" ControlToValidate="TextBox5" ID="RegularExpressionValidator9" ValidationExpression="^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$" runat="server" ErrorMessage="Not a valid Email format"></asp:RegularExpressionValidator>
                                            </EditItemTemplate>
                                            <InsertItemTemplate>
                                                <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Email") %>'></asp:TextBox>
                                                <asp:RequiredFieldValidator  ValidationGroup="member" runat="server" ID="EmailValidator2"
                                                    ForeColor="Red" ErrorMessage="Please enter Email" ControlToValidate="TextBox5" />
                                                <asp:RegularExpressionValidator  ValidationGroup="member" Display="Dynamic" ForeColor="Red" ControlToValidate="TextBox5" ID="RegularExpressionValidator10" ValidationExpression="^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$" runat="server" ErrorMessage="Not a valid Email format"></asp:RegularExpressionValidator>

                                            </InsertItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Code" SortExpression="Code">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Code") %>'></asp:TextBox>
                                                <asp:RequiredFieldValidator  ValidationGroup="member" runat="server" ID="CodeValidator"
                                                    ForeColor="Red" ErrorMessage="Code can't be empty" ControlToValidate="TextBox6" />
                                                <asp:RegularExpressionValidator  ValidationGroup="member" Display="Dynamic" ForeColor="Red" ControlToValidate="TextBox6" ID="RegularExpressionValidator11" ValidationExpression="	^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$" runat="server" ErrorMessage="Code of 9 digits digits is needed"></asp:RegularExpressionValidator>

                                            </EditItemTemplate>
                                            <InsertItemTemplate>
                                                <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Code") %>'></asp:TextBox>
                                                <asp:RequiredFieldValidator  ValidationGroup="member" runat="server" ID="CodeValidator2"
                                                    ForeColor="Red" ErrorMessage="Code can't be empty" ControlToValidate="TextBox6" />
                                                <asp:RegularExpressionValidator  ValidationGroup="member" Display="Dynamic" ForeColor="Red" ControlToValidate="TextBox6" ID="RegularExpressionValidator12" ValidationExpression="	^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$" runat="server" ErrorMessage="Code of 9 digits digits is needed"></asp:RegularExpressionValidator>

                                            </InsertItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label6" runat="server" Text='<%# Bind("Code") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Status" SortExpression="Status">
                                            <EditItemTemplate>
                                                <asp:DropDownList ID="DdlForStatus" runat="server" DataSource="<%# Enum.GetNames(typeof(com.rightback.ChocAn.DAL.Member.MemberStatus))%>" SelectedItem='<%# Bind("Status") %>'>
                                                </asp:DropDownList>

                                            </EditItemTemplate>
                                            <InsertItemTemplate>
                                                <asp:DropDownList ID="DdlForStatus" runat="server" DataSource="<%# Enum.GetNames(typeof(com.rightback.ChocAn.DAL.Member.MemberStatus))%>">
                                                </asp:DropDownList>
                                            </InsertItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label6" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowInsertButton="True"  ValidationGroup="member" />
                                    </Fields>
                                    <FooterStyle BackColor="#CCCCCC" />
                                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle ForeColor="Black" HorizontalAlign="Center" BackColor="#999999" />
                                </asp:DetailsView>
                            </div>
                        </div>
                    </div>


                    &nbsp;

                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div id="Providers" class="tab-pane fade">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                     <br>
                     </br>
                    <asp:TextBox ID="TextBoxSearchProviders" runat="server" placeHolder="Search Keword" OnTextChanged="TextBoxSearchProviders_TextChanged" AutoPostBack="true"></asp:TextBox>
                     <br>
                     </br>
                    <asp:GridView class="col-lg-8 col-xs-12 col-centered" ID="GridViewForProviders" runat="server" AllowPaging="True" PageSize="20"  AutoGenerateColumns="False" CellPadding="3" DataKeyNames="ProviderID" ForeColor="Black" GridLines="Vertical" 
                        OnRowDeleting="GridViewForProviders_RowDeleting" OnPageIndexChanging="GridViewForProviders_PageIndexChanging" OnRowCommand="GridViewForProviders_RowCommand" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" EmptyDataText="No data found">

                        <AlternatingRowStyle BackColor="#CCCCCC" />
                        <Columns>
                            <asp:CommandField ShowDeleteButton="True" ShowSelectButton="True" ShowCancelButton="False" />
                            <asp:BoundField DataField="ProviderID" HeaderText="ProviderID" InsertVisible="False" ReadOnly="True" SortExpression="ProviderID" />
                            <asp:TemplateField HeaderText="Name" SortExpression="Name">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="StreetAddres" SortExpression="StreetAddres">
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("StreetAddres") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="City" SortExpression="City">
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("City") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                                  <asp:TemplateField HeaderText="State" SortExpression="State">
                                <ItemTemplate>
                                    <asp:Label ID="LabelState" runat="server" Text='<%# Bind("State") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Zip" SortExpression="Zip">
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("Zip") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Email" SortExpression="Email">
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                      <asp:TemplateField HeaderText="Code" SortExpression="Code">
                                <ItemTemplate>
                                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("Code") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Type" SortExpression="Type">
                                <ItemTemplate>
                                    <asp:Label ID="Label7" runat="server" Text='<%# Bind("Type") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#CCCCCC" />
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#808080" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#383838" />

                    </asp:GridView>

                    <div class="container">
                        <div class="row">
                            <div class="col-xs-6">
                                Selected Provider Is:<asp:DetailsView ID="DetailsViewForSelectedProvider" ViewStateMode="Enabled" runat="server" AutoGenerateRows="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataKeyNames="ProviderID" Height="50px" Width="125px" OnItemUpdating="DetailsViewForSelectedProvider_ItemUpdating" OnItemInserting="DetailsViewForSelectedProvider_ItemInserting" OnModeChanging="DetailsViewForSelectedProvider_ModeChanging" ForeColor="Black" GridLines="Vertical">
                                    <AlternatingRowStyle BackColor="#CCCCCC" />
                                    <EditRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                    <Fields>
                                        <asp:BoundField DataField="ProviderID" HeaderText="ProviderID" InsertVisible="False" ReadOnly="True" SortExpression="ProviderID" />
                                        <asp:TemplateField HeaderText="Name" SortExpression="Name">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                                                <asp:RequiredFieldValidator  ValidationGroup="provider"  runat="server" ID="NameValidator"
                                                    ForeColor="Red" ErrorMessage="Please enter the name" ControlToValidate="TextBox1" />
                                                <asp:RegularExpressionValidator   ValidationGroup="provider"  Display="Dynamic" ForeColor="Red" ControlToValidate="TextBox1" ID="RegularExpressionValidator1" ValidationExpression="^[\s\S]{5,25}$" runat="server" ErrorMessage="Minimum 5 and Maximum 25 characters required."></asp:RegularExpressionValidator>
                                            </EditItemTemplate>
                                            <InsertItemTemplate>
                                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                                                <asp:RequiredFieldValidator   ValidationGroup="provider"  runat="server" ID="NameValidator2"
                                                    ForeColor="Red" ErrorMessage="Please enter the name" ControlToValidate="TextBox1" />
                                                <asp:RegularExpressionValidator   ValidationGroup="provider"  Display="Dynamic" ForeColor="Red" ControlToValidate="TextBox1" ID="RegularExpressionValidator2" ValidationExpression="^[\s\S]{5,25}$" runat="server" ErrorMessage="Minimum 5 and Maximum 25 characters required."></asp:RegularExpressionValidator>
                                            </InsertItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="StreetAddres" SortExpression="StreetAddres">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("StreetAddres") %>'></asp:TextBox>
                                                <asp:RequiredFieldValidator   ValidationGroup="provider"  runat="server" ID="StreetAddresValidator"
                                                    ForeColor="Red" ErrorMessage="Please enter the street address" ControlToValidate="TextBox2" />
                                                <asp:RegularExpressionValidator   ValidationGroup="provider"  Display="Dynamic" ForeColor="Red" ControlToValidate="TextBox2" ID="RegularExpressionValidator3" ValidationExpression="^[\s\S]{5,25}$" runat="server" ErrorMessage="Minimum 5 and Maximum 25 characters required."></asp:RegularExpressionValidator>
                                            </EditItemTemplate>
                                            <InsertItemTemplate>
                                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("StreetAddres") %>'></asp:TextBox>
                                                <asp:RequiredFieldValidator   ValidationGroup="provider"  runat="server" ID="StreetAddresValidator"
                                                    ForeColor="Red" ErrorMessage="Please enter the street address" ControlToValidate="TextBox2" />
                                                <asp:RegularExpressionValidator   ValidationGroup="provider"  Display="Dynamic" ForeColor="Red" ControlToValidate="TextBox2" ID="RegularExpressionValidator4" ValidationExpression="^[\s\S]{5,25}$" runat="server" ErrorMessage="Minimum 5 and Maximum 25 characters required."></asp:RegularExpressionValidator>
                                            </InsertItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("StreetAddres") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="City" SortExpression="City">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("City") %>'></asp:TextBox>
                                                <asp:RequiredFieldValidator   ValidationGroup="provider" runat="server" ID="CityValidator"
                                                    ForeColor="Red" ErrorMessage="Please enter the name" ControlToValidate="TextBox3" />
                                                <asp:RegularExpressionValidator   ValidationGroup="provider"  Display="Dynamic" ForeColor="Red" ControlToValidate="TextBox3" ID="RegularExpressionValidator5" ValidationExpression="^[\s\S]{2,14}$" runat="server" ErrorMessage="Minimum 2 and Maximum 14 characters required."></asp:RegularExpressionValidator>
                                            </EditItemTemplate>
                                            <InsertItemTemplate>
                                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("City") %>'></asp:TextBox>
                                                <asp:RequiredFieldValidator    ValidationGroup="provider"  runat="server" ID="CityValidator2"
                                                    ForeColor="Red" ErrorMessage="Please enter the name" ControlToValidate="TextBox3" />
                                                <asp:RegularExpressionValidator   ValidationGroup="provider"  Display="Dynamic" ForeColor="Red" ControlToValidate="TextBox3" ID="RegularExpressionValidator6" ValidationExpression="^[\s\S]{2,14}$" runat="server" ErrorMessage="Minimum 2 and Maximum 14 characters required."></asp:RegularExpressionValidator>
                                            </InsertItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("City") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Zip" SortExpression="Zip">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Zip") %>'></asp:TextBox>
                                                <asp:RequiredFieldValidator   ValidationGroup="provider"  runat="server" ID="ZipValidator"
                                                    ForeColor="Red" ErrorMessage="Please enter zip code" ControlToValidate="TextBox4" />
                                                <asp:RegularExpressionValidator   ValidationGroup="provider"  Display="Dynamic" ForeColor="Red" ControlToValidate="TextBox4" ID="RegularExpressionValidator7" ValidationExpression="^[0-9]{5,5}$" runat="server" ErrorMessage="Code of 5 digits is needed"></asp:RegularExpressionValidator>

                                            </EditItemTemplate>
                                            <InsertItemTemplate>
                                                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Zip") %>'></asp:TextBox>
                                                <asp:RequiredFieldValidator   ValidationGroup="provider"  runat="server" ID="ZipValidator2"
                                                    ForeColor="Red" ErrorMessage="Please enter zip code" ControlToValidate="TextBox4" />
                                                <asp:RegularExpressionValidator   ValidationGroup="provider"  Display="Dynamic" ForeColor="Red" ControlToValidate="TextBox4" ID="RegularExpressionValidator8" ValidationExpression="^[0-9]{5,5}$" runat="server" ErrorMessage="Code of 5 digits is needed"></asp:RegularExpressionValidator>

                                            </InsertItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("Zip") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="State" SortExpression="State">
                                            <EditItemTemplate>
                                                <asp:DropDownList ID="DdlForState" runat="server" DataSource="<%# Enum.GetNames(typeof(com.rightback.ChocAn.DAL.Entities.USState.State))%>" SelectedItem='<%# Bind("State") %>'>
                                                </asp:DropDownList>
                                           </EditItemTemplate>
                                            <InsertItemTemplate>
                                                <asp:DropDownList ID="DdlForState" runat="server" DataSource="<%# Enum.GetNames(typeof(com.rightback.ChocAn.DAL.Entities.USState.State))%>">
                                                </asp:DropDownList>
                                            </InsertItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label6" runat="server" Text='<%# Bind("State") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Email" SortExpression="Email">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Email") %>'></asp:TextBox>
                                                <asp:RequiredFieldValidator   ValidationGroup="provider" runat="server" ID="EmailValidator"
                                                    ForeColor="Red" ErrorMessage="Please enter Email" ControlToValidate="TextBox5" />
                                                <asp:RegularExpressionValidator   ValidationGroup="provider"  Display="Dynamic" ForeColor="Red" ControlToValidate="TextBox5" ID="RegularExpressionValidator9" ValidationExpression="([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$"  runat="server" ErrorMessage="Not a valid Email format"></asp:RegularExpressionValidator>
                                            </EditItemTemplate>
                                            <InsertItemTemplate>
                                                <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Email") %>'></asp:TextBox>
                                                <asp:RequiredFieldValidator   ValidationGroup="provider"  runat="server" ID="EmailValidator2"
                                                    ForeColor="Red" ErrorMessage="Please enter Email" ControlToValidate="TextBox5" />
                                                <asp:RegularExpressionValidator   ValidationGroup="provider"  Display="Dynamic" ForeColor="Red" ControlToValidate="TextBox5" ID="RegularExpressionValidator10" ValidationExpression="^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$" runat="server" ErrorMessage="Not a valid Email format"></asp:RegularExpressionValidator>

                                            </InsertItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Code" SortExpression="Code">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Code") %>'></asp:TextBox>
                                                <asp:RequiredFieldValidator   ValidationGroup="provider"  runat="server" ID="CodeValidator"
                                                    ForeColor="Red" ErrorMessage="Code can't be empty" ControlToValidate="TextBox6" />
                                                <asp:RegularExpressionValidator   ValidationGroup="provider"  Display="Dynamic" ForeColor="Red" ControlToValidate="TextBox6" ID="RegularExpressionValidator11" ValidationExpression="^[0-9]{9,9}$" runat="server" ErrorMessage="Code of 9 digits digits is needed"></asp:RegularExpressionValidator>
                                            </EditItemTemplate>
                                            <InsertItemTemplate>
                                                <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Code") %>'></asp:TextBox>
                                                <asp:RequiredFieldValidator   ValidationGroup="provider"  runat="server" ID="CodeValidator2"
                                                    ForeColor="Red" ErrorMessage="Code can't be empty" ControlToValidate="TextBox6" />
                                                <asp:RegularExpressionValidator   ValidationGroup="provider"  Display="Dynamic" ForeColor="Red" ControlToValidate="TextBox6" ID="RegularExpressionValidator12" ValidationExpression="^[0-9]{9,9}$" runat="server" ErrorMessage="Code of 9 digits digits is needed"></asp:RegularExpressionValidator>

                                            </InsertItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label6" runat="server" Text='<%# Bind("Code") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Type" SortExpression="Type">
                                            <EditItemTemplate>
                                                <asp:DropDownList ID="DdlForType" runat="server" DataSource="<%# Enum.GetNames(typeof(com.rightback.ChocAn.DAL.Provider.ProviderType))%>" SelectedItem='<%# Bind("Status") %>'>
                                                </asp:DropDownList>

                                            </EditItemTemplate>
                                            <InsertItemTemplate>
                                                <asp:DropDownList ID="DdlForType" runat="server" DataSource="<%# Enum.GetNames(typeof(com.rightback.ChocAn.DAL.Provider.ProviderType))%>">
                                                </asp:DropDownList>
                                            </InsertItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label6" runat="server" Text='<%# Bind("Type") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowInsertButton="True"   ValidationGroup="provider" />
                                    </Fields>
                                    <FooterStyle BackColor="#CCCCCC" />
                                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle ForeColor="Black" HorizontalAlign="Center" BackColor="#999999" />
                                </asp:DetailsView>
                            </div>
                        </div>
                    </div>

                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="0">
            <ProgressTemplate>
                <div style=" background: #e9e9e9; position: absolute; top: 0; right: 0; bottom: 0; left: 0;">
                    <img src="http://i.stack.imgur.com/8puiO.gif" />&nbsp;
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </div>


</asp:Content>

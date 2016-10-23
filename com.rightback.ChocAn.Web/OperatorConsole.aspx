<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OperatorConsole.aspx.cs" Inherits="com.rightback.ChocAn.Web.OperatorConsole" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <ul id="profileTabs2" class="nav nav-tabs">
        <li class="active"><a href="#Members" aria-controls="Members" role="tab" data-toggle="tab">Members</a></li>
        <li><a href="#Providers" aria-controls="Providers" role="tab" data-toggle="tab">Providers</a></li>
        <li><a href="#Reports" aria-controls="Reports" role="tab" data-toggle="tab">Reports</a></li>
    </ul>
    <div class="tab-content" id="myTabContent2">
        <div id="Members" class="tab-pane active">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:GridView class="col-lg-8 col-xs-12 col-centered" ID="GridViewMembers" runat="server" AllowPaging="True" PageSize="20" AllowSorting="True" AutoGenerateColumns="False" CellPadding="3" DataKeyNames="MemberID" ForeColor="Black" GridLines="Vertical" OnRowDeleted="GridViewMembers_RowDeleted" OnPageIndexChanging="GridViewMembers_PageIndexChanging" OnSelectedIndexChanging="GridViewMembers_SelectedIndexChanging" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px">

                        <AlternatingRowStyle BackColor="#CCCCCC" />
                        <Columns>
                            <asp:CommandField ShowDeleteButton="True" ShowSelectButton="True" ShowCancelButton="False" />
                            <asp:BoundField DataField="MemberID" HeaderText="MemberID" InsertVisible="False" ReadOnly="True" SortExpression="MemberID" />
                            <asp:TemplateField HeaderText="Name" SortExpression="Name">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="StreetAddres" SortExpression="StreetAddres">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("StreetAddres") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("StreetAddres") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="City" SortExpression="City">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("City") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("City") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Zip" SortExpression="Zip">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Zip") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("Zip") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Email" SortExpression="Email">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Email") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Code" HeaderText="Code" SortExpression="Code" />
                            <asp:TemplateField HeaderText="Status" SortExpression="Status">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="DropDownList1" runat="server">
                                    </asp:DropDownList>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
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
                                Selected Member Is:<asp:DetailsView ID="DetailsViewForMember" ViewStateMode="Enabled" runat="server" AutoGenerateRows="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataKeyNames="MemberID" Height="50px" Width="125px" OnItemUpdating="DetailsViewForMember_ItemUpdating" OnItemInserting="DetailsViewForMember_ItemInserting" OnModeChanging="DetailsViewForMember_ModeChanging" ForeColor="Black" GridLines="Vertical">
                                    <AlternatingRowStyle BackColor="#CCCCCC" />
                                    <EditRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                    <Fields>
                                        <asp:BoundField DataField="MemberID" HeaderText="MemberID" InsertVisible="False" ReadOnly="True" SortExpression="MemberID" />
                                        <asp:TemplateField HeaderText="Name" SortExpression="Name">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                                                <asp:RequiredFieldValidator runat="server" ID="NameValidator"
                                                    ForeColor="Red" ErrorMessage="Please enter the name" ControlToValidate="TextBox1" />
                                                <asp:RegularExpressionValidator Display="Dynamic" ForeColor="Red" ControlToValidate="TextBox1" ID="RegularExpressionValidator1" ValidationExpression="^[\s\S]{5,25}$" runat="server" ErrorMessage="Minimum 5 and Maximum 25 characters required."></asp:RegularExpressionValidator>
                                            </EditItemTemplate>
                                            <InsertItemTemplate>
                                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                                                <asp:RequiredFieldValidator runat="server" ID="NameValidator2"
                                                    ForeColor="Red" ErrorMessage="Please enter the name" ControlToValidate="TextBox1" />
                                                <asp:RegularExpressionValidator Display="Dynamic" ForeColor="Red" ControlToValidate="TextBox1" ID="RegularExpressionValidator2" ValidationExpression="^[\s\S]{5,25}$" runat="server" ErrorMessage="Minimum 5 and Maximum 25 characters required."></asp:RegularExpressionValidator>
                                            </InsertItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="StreetAddres" SortExpression="StreetAddres">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("StreetAddres") %>'></asp:TextBox>
                                                <asp:RequiredFieldValidator runat="server" ID="StreetAddresValidator"
                                                    ForeColor="Red" ErrorMessage="Please enter the street address" ControlToValidate="TextBox2" />
                                                <asp:RegularExpressionValidator Display="Dynamic" ForeColor="Red" ControlToValidate="TextBox2" ID="RegularExpressionValidator3" ValidationExpression="^[\s\S]{5,25}$" runat="server" ErrorMessage="Minimum 5 and Maximum 25 characters required."></asp:RegularExpressionValidator>
                                            </EditItemTemplate>
                                            <InsertItemTemplate>
                                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("StreetAddres") %>'></asp:TextBox>
                                                <asp:RequiredFieldValidator runat="server" ID="StreetAddresValidator2"
                                                    ForeColor="Red" ErrorMessage="Please enter the street address" ControlToValidate="TextBox2" />
                                                <asp:RegularExpressionValidator Display="Dynamic" ForeColor="Red" ControlToValidate="TextBox2" ID="RegularExpressionValidator4" ValidationExpression="^[\s\S]{5,25}$" runat="server" ErrorMessage="Minimum 5 and Maximum 25 characters required."></asp:RegularExpressionValidator>
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
                                                <asp:RequiredFieldValidator runat="server" ID="CityValidator2"
                                                    ForeColor="Red" ErrorMessage="Please enter the name" ControlToValidate="TextBox3" />
                                                <asp:RegularExpressionValidator Display="Dynamic" ForeColor="Red" ControlToValidate="TextBox3" ID="RegularExpressionValidator6" ValidationExpression="^[\s\S]{2,14}$" runat="server" ErrorMessage="Minimum 2 and Maximum 14 characters required."></asp:RegularExpressionValidator>
                                            </InsertItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("City") %>'></asp:Label>
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
                                                <asp:RequiredFieldValidator runat="server" ID="ZipValidator2"
                                                    ForeColor="Red" ErrorMessage="Please enter zip code" ControlToValidate="TextBox4" />
                                                <asp:RegularExpressionValidator Display="Dynamic" ForeColor="Red" ControlToValidate="TextBox4" ID="RegularExpressionValidator8" ValidationExpression="^[0-9]{5,5}$" runat="server" ErrorMessage="Code of 5 digits is needed"></asp:RegularExpressionValidator>
                                            </InsertItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("Zip") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Email" SortExpression="Email">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Email") %>'></asp:TextBox>
                                                <asp:RequiredFieldValidator runat="server" ID="EmailValidator"
                                                    ForeColor="Red" ErrorMessage="Please enter Email" ControlToValidate="TextBox5" />
                                                <asp:RegularExpressionValidator Display="Dynamic" ForeColor="Red" ControlToValidate="TextBox5" ID="RegularExpressionValidator9" ValidationExpression="^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*@((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))\z" runat="server" ErrorMessage="Not a valid Email format"></asp:RegularExpressionValidator>

                                            </EditItemTemplate>
                                            <InsertItemTemplate>
                                                <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Email") %>'></asp:TextBox>
                                                <asp:RequiredFieldValidator runat="server" ID="EmailValidator2"
                                                    ForeColor="Red" ErrorMessage="Please enter Email" ControlToValidate="TextBox5" />
                                                <asp:RegularExpressionValidator Display="Dynamic" ForeColor="Red" ControlToValidate="TextBox5" ID="RegularExpressionValidator10" ValidationExpression="^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*@((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))\z" runat="server" ErrorMessage="Not a valid Email format"></asp:RegularExpressionValidator>

                                            </InsertItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Code" SortExpression="Code">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Code") %>'></asp:TextBox>
                                                <asp:RequiredFieldValidator runat="server" ID="CodeValidator"
                                                    ForeColor="Red" ErrorMessage="Code can't be empty" ControlToValidate="TextBox6" />
                                                <asp:RegularExpressionValidator Display="Dynamic" ForeColor="Red" ControlToValidate="TextBox6" ID="RegularExpressionValidator11" ValidationExpression="^[0-9]{9,9}$" runat="server" ErrorMessage="Code of 9 digits digits is needed"></asp:RegularExpressionValidator>

                                            </EditItemTemplate>
                                            <InsertItemTemplate>
                                                <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Code") %>'></asp:TextBox>
                                                <asp:RequiredFieldValidator runat="server" ID="CodeValidator2"
                                                    ForeColor="Red" ErrorMessage="Code can't be empty" ControlToValidate="TextBox6" />
                                                <asp:RegularExpressionValidator Display="Dynamic" ForeColor="Red" ControlToValidate="TextBox6" ID="RegularExpressionValidator12" ValidationExpression="^[0-9]{9,9}$" runat="server" ErrorMessage="Code of 9 digits digits is needed"></asp:RegularExpressionValidator>

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
                                        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowInsertButton="True" />
                                    </Fields>
                                    <FooterStyle BackColor="#CCCCCC" />
                                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle ForeColor="Black" HorizontalAlign="Center" BackColor="#999999" />
                                </asp:DetailsView>
                            </div>
                            <div class="col-xs-6">Claims</div>
                        </div>
                    </div>


                    &nbsp;

                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div id="Providers" class="tab-pane fade">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:GridView class="col-lg-8 col-xs-12 col-centered" ID="GridViewForProviders" runat="server" AllowPaging="True" PageSize="20" AllowSorting="True" AutoGenerateColumns="False" CellPadding="3" DataKeyNames="ProviderID" ForeColor="Black" GridLines="Vertical" OnRowDeleted="GridViewForProviders_RowDeleted" OnPageIndexChanging="GridViewForProviders_PageIndexChanging" OnSelectedIndexChanging="GridViewForProviders_SelectedIndexChanging" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px">

                        <AlternatingRowStyle BackColor="#CCCCCC" />
                        <Columns>
                            <asp:CommandField ShowDeleteButton="True" ShowSelectButton="True" ShowCancelButton="False" />
                            <asp:BoundField DataField="ProviderID" HeaderText="ProviderID" InsertVisible="False" ReadOnly="True" SortExpression="ProviderID" />
                            <asp:TemplateField HeaderText="Name" SortExpression="Name">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="StreetAddres" SortExpression="StreetAddres">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("StreetAddres") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("StreetAddres") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="City" SortExpression="City">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("City") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("City") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Zip" SortExpression="Zip">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Zip") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("Zip") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Email" SortExpression="Email">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Email") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Code" HeaderText="Code" SortExpression="Code" />
                            <asp:TemplateField HeaderText="Type" SortExpression="Type">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="DropDownList1" runat="server">
                                    </asp:DropDownList>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("Type") %>'></asp:Label>
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
                           <asp:RequiredFieldValidator runat="server" ID="NameValidator"
                                                    ForeColor="Red" ErrorMessage="Please enter the name" ControlToValidate="TextBox1" />
                                                <asp:RegularExpressionValidator Display="Dynamic" ForeColor="Red" ControlToValidate="TextBox1" ID="RegularExpressionValidator1" ValidationExpression="^[\s\S]{5,25}$" runat="server" ErrorMessage="Minimum 5 and Maximum 25 characters required."></asp:RegularExpressionValidator>
                                            </EditItemTemplate>
                                            <InsertItemTemplate>
                                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                                                <asp:RequiredFieldValidator runat="server" ID="NameValidator2"
                                                    ForeColor="Red" ErrorMessage="Please enter the name" ControlToValidate="TextBox1" />
                                                <asp:RegularExpressionValidator Display="Dynamic" ForeColor="Red" ControlToValidate="TextBox1" ID="RegularExpressionValidator2" ValidationExpression="^[\s\S]{5,25}$" runat="server" ErrorMessage="Minimum 5 and Maximum 25 characters required."></asp:RegularExpressionValidator>
                                            </InsertItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Name") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="StreetAddres" SortExpression="StreetAddres">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("StreetAddres") %>'></asp:TextBox>
                                                <asp:RequiredFieldValidator runat="server" ID="StreetAddresValidator"
                                                    ForeColor="Red" ErrorMessage="Please enter the street address" ControlToValidate="TextBox2" />
                                                <asp:RegularExpressionValidator Display="Dynamic" ForeColor="Red" ControlToValidate="TextBox2" ID="RegularExpressionValidator3" ValidationExpression="^[\s\S]{5,25}$" runat="server" ErrorMessage="Minimum 5 and Maximum 25 characters required."></asp:RegularExpressionValidator>
                                            </EditItemTemplate>
                                            <InsertItemTemplate>
                                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("StreetAddres") %>'></asp:TextBox>
                                                <asp:RequiredFieldValidator runat="server" ID="StreetAddresValidator"
                                                    ForeColor="Red" ErrorMessage="Please enter the street address" ControlToValidate="TextBox2" />
                                                <asp:RegularExpressionValidator Display="Dynamic" ForeColor="Red" ControlToValidate="TextBox2" ID="RegularExpressionValidator4" ValidationExpression="^[\s\S]{5,25}$" runat="server" ErrorMessage="Minimum 5 and Maximum 25 characters required."></asp:RegularExpressionValidator>
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
                                                                                                <asp:RequiredFieldValidator runat="server" ID="CityValidator2"
                                                    ForeColor="Red" ErrorMessage="Please enter the name" ControlToValidate="TextBox3" />
                                                <asp:RegularExpressionValidator Display="Dynamic" ForeColor="Red" ControlToValidate="TextBox3" ID="RegularExpressionValidator6" ValidationExpression="^[\s\S]{2,14}$" runat="server" ErrorMessage="Minimum 2 and Maximum 14 characters required."></asp:RegularExpressionValidator>
                                            </InsertItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("City") %>'></asp:Label>
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
                                                                                      <asp:RequiredFieldValidator runat="server" ID="ZipValidator2"
                                                    ForeColor="Red" ErrorMessage="Please enter zip code" ControlToValidate="TextBox4" />
                                                <asp:RegularExpressionValidator Display="Dynamic" ForeColor="Red" ControlToValidate="TextBox4" ID="RegularExpressionValidator8" ValidationExpression="^[0-9]{5,5}$" runat="server" ErrorMessage="Code of 5 digits is needed"></asp:RegularExpressionValidator>

                                            </InsertItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("Zip") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Email" SortExpression="Email">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Email") %>'></asp:TextBox>
                                                         <asp:RequiredFieldValidator runat="server" ID="EmailValidator"
                                                    ForeColor="Red" ErrorMessage="Please enter Email" ControlToValidate="TextBox5" />
                                                <asp:RegularExpressionValidator Display="Dynamic" ForeColor="Red" ControlToValidate="TextBox5" ID="RegularExpressionValidator9" ValidationExpression="^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*@((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))\z" runat="server" ErrorMessage="Not a valid Email format"></asp:RegularExpressionValidator>
                                            </EditItemTemplate>
                                            <InsertItemTemplate>
                                                <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Email") %>'></asp:TextBox>
                                                         <asp:RequiredFieldValidator runat="server" ID="EmailValidator2"
                                                    ForeColor="Red" ErrorMessage="Please enter Email" ControlToValidate="TextBox5" />
                                                <asp:RegularExpressionValidator Display="Dynamic" ForeColor="Red" ControlToValidate="TextBox5" ID="RegularExpressionValidator10" ValidationExpression="^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*@((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))\z" runat="server" ErrorMessage="Not a valid Email format"></asp:RegularExpressionValidator>

                                            </InsertItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label5" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Code" SortExpression="Code">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Code") %>'></asp:TextBox>
                                                     <asp:RequiredFieldValidator runat="server" ID="CodeValidator"
                                                    ForeColor="Red" ErrorMessage="Code can't be empty" ControlToValidate="TextBox6" />
                                                <asp:RegularExpressionValidator Display="Dynamic" ForeColor="Red" ControlToValidate="TextBox6" ID="RegularExpressionValidator11" ValidationExpression="^[0-9]{9,9}$" runat="server" ErrorMessage="Code of 9 digits digits is needed"></asp:RegularExpressionValidator>
                                            </EditItemTemplate>
                                            <InsertItemTemplate>
                                                <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Code") %>'></asp:TextBox>
                                                     <asp:RequiredFieldValidator runat="server" ID="CodeValidator2"
                                                    ForeColor="Red" ErrorMessage="Code can't be empty" ControlToValidate="TextBox6" />
                                                <asp:RegularExpressionValidator Display="Dynamic" ForeColor="Red" ControlToValidate="TextBox6" ID="RegularExpressionValidator12" ValidationExpression="^[0-9]{9,9}$" runat="server" ErrorMessage="Code of 9 digits digits is needed"></asp:RegularExpressionValidator>

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
                                        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowInsertButton="True" />
                                    </Fields>
                                    <FooterStyle BackColor="#CCCCCC" />
                                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle ForeColor="Black" HorizontalAlign="Center" BackColor="#999999" />
                                </asp:DetailsView>
                            </div>
                            <div class="col-xs-6">Claims</div>
                        </div>
                    </div>

                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
        <div id="Reports" class="tab-pane fade">
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>


</asp:Content>

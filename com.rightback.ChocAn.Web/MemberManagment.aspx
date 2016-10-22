<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MemberManagment.aspx.cs" Inherits="com.rightback.ChocAn.Web.MemberManagment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <ul id="profileTabs2" class="nav nav-tabs">
        <li class="active"><a href="#Members" aria-controls="Members" role="tab" data-toggle="tab">Members</a></li>
        <li><a href="#New" aria-controls="New" role="tab" data-toggle="tab">Add New Member</a></li>
        <li><a href="#Reports" aria-controls="Reports" role="tab" data-toggle="tab">Reports</a></li>
    </ul>
    <div class="tab-content" id="myTabContent2">
        <div id="Members" class="tab-pane active">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="GridViewMembers" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="MemberID" ForeColor="#333333" GridLines="None" OnRowDeleted="GridViewMembers_RowDeleted" OnSelectedIndexChanging="GridViewMembers_SelectedIndexChanging">

                        <AlternatingRowStyle BackColor="White" />
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
                        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                        <SortedAscendingCellStyle BackColor="#FDF5AC" />
                        <SortedAscendingHeaderStyle BackColor="#4D0000" />
                        <SortedDescendingCellStyle BackColor="#FCF6C0" />
                        <SortedDescendingHeaderStyle BackColor="#820000" />

                    </asp:GridView>

                    <div class="container">
                    <div class="row"><div class="col-xs-6"> Selected Member Is:<asp:DetailsView ID="DetailsView1" ViewStateMode="Enabled" runat="server" AutoGenerateRows="False" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" DataKeyNames="MemberID" Height="50px" Width="125px" OnItemUpdating="DetailsView1_ItemUpdating" OnItemInserting="DetailsView1_ItemInserting" OnModeChanging="DetailsView1_ModeChanging">
                        <EditRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                        <Fields>
                            <asp:BoundField DataField="MemberID" HeaderText="MemberID" InsertVisible="False" ReadOnly="True" SortExpression="MemberID" />
                            <asp:TemplateField HeaderText="Name" SortExpression="Name">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ID="NameValidator"
                                        ForeColor="Red" ErrorMessage="Please enter the name" ControlToValidate="TextBox1" />
                                    <asp:RegularExpressionValidator Display="Dynamic"  ForeColor="Red" ControlToValidate="TextBox1" ID="RegularExpressionValidator1" ValidationExpression="^[\s\S]{5,25}$" runat="server" ErrorMessage="Minimum 5 and Maximum 25 characters required."></asp:RegularExpressionValidator>
                                </EditItemTemplate>
                                <InsertItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ID="NameValidator2"
                                        ForeColor="Red" ErrorMessage="Please enter the name" ControlToValidate="TextBox1" />
                                    <asp:RegularExpressionValidator Display="Dynamic"  ForeColor="Red" ControlToValidate="TextBox1" ID="RegularExpressionValidator2" ValidationExpression="^[\s\S]{5,25}$" runat="server" ErrorMessage="Minimum 5 and Maximum 25 characters required."></asp:RegularExpressionValidator>
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
                                    <asp:RegularExpressionValidator Display="Dynamic"  ForeColor="Red" ControlToValidate="TextBox2" ID="RegularExpressionValidator3" ValidationExpression="^[\s\S]{5,25}$" runat="server" ErrorMessage="Minimum 5 and Maximum 25 characters required."></asp:RegularExpressionValidator>
                                </EditItemTemplate>
                                <InsertItemTemplate>
                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("StreetAddres") %>'></asp:TextBox>
                                        <asp:RequiredFieldValidator runat="server" ID="StreetAddresValidator"
                                        ForeColor="Red" ErrorMessage="Please enter the street address" ControlToValidate="TextBox2" />
                                    <asp:RegularExpressionValidator Display="Dynamic"  ForeColor="Red" ControlToValidate="TextBox2" ID="RegularExpressionValidator4" ValidationExpression="^[\s\S]{5,25}$" runat="server" ErrorMessage="Minimum 5 and Maximum 25 characters required."></asp:RegularExpressionValidator>
                                </InsertItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("StreetAddres") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="City" SortExpression="City">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("City") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <InsertItemTemplate>
                                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("City") %>'></asp:TextBox>
                                </InsertItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("City") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Zip" SortExpression="Zip">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Zip") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <InsertItemTemplate>
                                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Zip") %>'></asp:TextBox>
                                </InsertItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("Zip") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Email" SortExpression="Email">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Email") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <InsertItemTemplate>
                                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Email") %>'></asp:TextBox>
                                </InsertItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("Email") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Email" SortExpression="Email">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Code") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <InsertItemTemplate>
                                    <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("Code") %>'></asp:TextBox>
                                </InsertItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("Code") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Status" SortExpression="Status">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="DdlForStatus" runat="server" SelectedItem='<%# Bind("Status") %>'>
                                        <asp:ListItem Value="1">Active</asp:ListItem>
                                        <asp:ListItem Value="2">Suspended</asp:ListItem>
                                        <asp:ListItem Value="3">Deleted</asp:ListItem>
                                    </asp:DropDownList>

                                </EditItemTemplate>
                                <InsertItemTemplate>
                                    <asp:DropDownList ID="DdlForStatus" runat="server" Text='<%# Bind("Status") %>' SelectedValue='<%# Bind("Status") %>'>
                                        <asp:ListItem Value="1">Active</asp:ListItem>
                                        <asp:ListItem Value="2">Suspended</asp:ListItem>
                                        <asp:ListItem Value="3">Deleted</asp:ListItem>
                                    </asp:DropDownList>
                                </InsertItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("Status") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowInsertButton="True" />
                        </Fields>
                        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                    </asp:DetailsView></div><div class="col-xs-6">Claims</div></div></div>
                   

                    &nbsp;

                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div id="New" class="tab-pane fade">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
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

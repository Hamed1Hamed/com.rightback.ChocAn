<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManagerConsole.aspx.cs" Inherits="com.rightback.ChocAn.Web.ManagerConsole" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit"%>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <ul id="profileTabs2" class="nav nav-tabs">
        <li class="active"><a href="#Members" aria-controls="Members" role="tab" data-toggle="tab">Members Reports</a></li>
        <li><a href="#Providers" aria-controls="Providers" role="tab" data-toggle="tab">Providers Reports</a></li>
        <li><a href="#Summary" aria-controls="Summary" role="tab" data-toggle="tab">Summary Reports</a></li>
          <li><a href="#Other" aria-controls="Reports" role="tab" data-toggle="tab">Other</a></li>
    </ul>
    <div class="tab-content" id="myTabContent2">
        <div id="Members" class="tab-pane active">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    </br>
                    <asp:TextBox ID="TextBoxSerchMembers" runat="server" placeHolder="Search Keword" OnTextChanged="TextBoxSerchMembers_TextChanged" AutoPostBack="true"></asp:TextBox>
                     </br>
                    <asp:GridView  ID="GridViewMembers" runat="server" PageSize="20" AllowSorting="True" AutoGenerateColumns="False" CellPadding="3" DataKeyNames="MemberID" ForeColor="Black" GridLines="Vertical" OnPageIndexChanging="GridViewMembers_PageIndexChanging" OnSelectedIndexChanging="GridViewMembers_SelectedIndexChanging" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px">

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

           
                                Selected Member Claims:
                                <br />
                                <asp:GridView ID="GridViewForMemberClaims"  runat="server" AutoGenerateColumns="False" DataKeyNames="ClaimID" ShowHeaderWhenEmpty="true"  EmptyDataText="No data found">
                                    <Columns>
                                        <asp:BoundField DataField="ClaimID" HeaderText="ClaimID" InsertVisible="False" ReadOnly="True" SortExpression="ClaimID" />
                                        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                                        <asp:BoundField DataField="DateOfClaim" HeaderText="DateOfClaim" SortExpression="DateOfClaim" />
                                        <asp:BoundField DataField="Comments" HeaderText="Comments" SortExpression="Comments" />
                                        <asp:BoundField DataField="Member_MemberID" HeaderText="Member_MemberID" SortExpression="Member_MemberID" />
                                        <asp:BoundField DataField="Provider_ProviderID" HeaderText="Provider_ProviderID" SortExpression="Provider_ProviderID" />
                                        <asp:BoundField DataField="Service_ServiceID" HeaderText="Service_ServiceID" SortExpression="Service_ServiceID" />
                                    </Columns>
                                </asp:GridView>
                                


                    &nbsp;

                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div id="Providers" class="tab-pane fade">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>`  
                     </br>
                    <asp:TextBox ID="TextBoxSearchProviders" runat="server" placeHolder="Search Keword" OnTextChanged="TextBoxSearchProviders_TextChanged" AutoPostBack="true"></asp:TextBox>
                     </br>
                    <asp:GridView ID="GridViewForProviders" runat="server" PageSize="20" AllowSorting="True" AutoGenerateColumns="False" CellPadding="3" DataKeyNames="ProviderID" ForeColor="Black" GridLines="Vertical" OnPageIndexChanging="GridViewForProviders_PageIndexChanging" OnSelectedIndexChanging="GridViewForProviders_SelectedIndexChanging" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" ShowHeaderWhenEmpty="true" EmptyDataText="No data found" >

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
                        <asp:GridView ID="GridViewForProviderClaims"  runat="server" AutoGenerateColumns="False" DataKeyNames="ClaimID"  ShowHeaderWhenEmpty="true" EmptyDataText="No data found">
                                    <Columns>
                                        <asp:BoundField DataField="ClaimID" HeaderText="ClaimID" InsertVisible="False" ReadOnly="True" SortExpression="ClaimID" />
                                        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                                        <asp:BoundField DataField="DateOfClaim" HeaderText="DateOfClaim" SortExpression="DateOfClaim" />
                                        <asp:BoundField DataField="Comments" HeaderText="Comments" SortExpression="Comments" />
                                        <asp:BoundField DataField="Member_MemberID" HeaderText="Member_MemberID" SortExpression="Member_MemberID" />
                                        <asp:BoundField DataField="Provider_ProviderID" HeaderText="Provider_ProviderID" SortExpression="Provider_ProviderID" />
                                        <asp:BoundField DataField="Service_ServiceID" HeaderText="Service_ServiceID" SortExpression="Service_ServiceID" />
                                    </Columns>
                                </asp:GridView>

                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
        <div id="Summary" class="tab-pane fade">
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                    Statictics of this week:
                    <br>
                    </br>
                    Total number of providers <asp:Label ID="LabelStatProviders" runat="server" Text=""></asp:Label>
                    <br>
                    </br>
                    The total number of consultations   <asp:Label ID="LabelStatconsults" runat="server" Text=""></asp:Label>
                    <br>
                    </br>
                    overall fee  The total number of consultations   $<asp:Label ID="LabelStatFees" runat="server" Text=""></asp:Label>
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
          <div id="Other" class="tab-pane fade">
            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                    <Triggers>
       <asp:PostBackTrigger ControlID="GridViewForFiles" />
   </Triggers>
                <ContentTemplate>
                    <ajaxToolkit:AsyncFileUpload ID="AsyncFileUpload1" runat="server" 
                onuploadedcomplete="AsyncFileUpload1_UploadedComplete" />
<hr />
<asp:GridView ID="GridViewForFiles" runat="server" AutoGenerateColumns="false" EmptyDataText = "No files uploaded">
    <Columns>
        <asp:BoundField DataField="Text" HeaderText="File Name" />
        <asp:TemplateField>
            <ItemTemplate>
                <asp:LinkButton ID="lnkDownload" Text = "Download" CommandArgument = '<%# Eval("Value") %>' runat="server" OnClick = "DownloadFile"></asp:LinkButton>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:LinkButton ID = "lnkDelete" Text = "Delete" CommandArgument = '<%# Eval("Value") %>' runat = "server" OnClick = "DeleteFile" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
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

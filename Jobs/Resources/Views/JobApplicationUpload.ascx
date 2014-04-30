<%@ Control Language="C#" %>



<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="Telerik.Sitefinity" Namespace="Telerik.Sitefinity.Web.UI" TagPrefix="sitefinity" %>
<telerik:RadFormDecorator ID="FormDecorator1" runat="server" DecoratedControls="all">
</telerik:RadFormDecorator>
<sitefinity:Message runat="server" ID="message" ElementTag="div" RemoveAfter="30000"
    FadeDuration="10" />
<asp:Label ID="LabelFirstName" Text="<%$ Resources:JobsResources, FirstName %>" runat="server"
    AssociatedControlID="FirstName" Font-Bold="True" /><br />
<asp:TextBox ID="FirstName" runat="server" Width="100%" />
<asp:RequiredFieldValidator ID="FirstNameRequiredValidator" runat="server" CssClass="sfError"
    Display="Dynamic" ControlToValidate="FirstName" SetFocusOnError="true">
    <strong>
        <asp:Literal ID="fnRequired" runat="server" Text="<%$ Resources:JobsResources, FirstNameRequired %>"></asp:Literal>
    </strong>
</asp:RequiredFieldValidator>
<asp:RegularExpressionValidator runat="server" ID="FirstNameRegularExpressionValidator"
    ControlToValidate="FirstName" CssClass="sfError" Display="Dynamic" SetFocusOnError="true"
    ValidationExpression="^[\s\S]{0,40}$">
    <strong>
        <asp:Literal ID="LiteralFirstNameErrorMessage" runat="server" Text="<%$ Resources:JobsResources, TextFieldMaximumLength %>"></asp:Literal>
    </strong>
</asp:RegularExpressionValidator>
<br />
<br />
<asp:Label ID="LabelLastName" Text="<%$ Resources:JobsResources, LastName %>" runat="server"
    AssociatedControlID="LastName" Font-Bold="True" /><br />
<asp:TextBox ID="LastName" runat="server" Width="100%" />
<asp:RequiredFieldValidator ID="LastNameRequiredValidator" runat="server" CssClass="sfError"
    Display="Dynamic" ControlToValidate="LastName" SetFocusOnError="true">
    <strong>
        <asp:Literal ID="lnRequired" runat="server" Text="<%$ Resources:JobsResources, LastNameRequired %>"></asp:Literal>
    </strong>
</asp:RequiredFieldValidator>
<asp:RegularExpressionValidator runat="server" ID="LastNameRegularExpressionValidator"
    ControlToValidate="LastName" CssClass="sfError" Display="Dynamic" SetFocusOnError="true"
    ValidationExpression="^[\s\S]{0,40}$">
    <strong>
        <asp:Literal ID="LiteralLastNameErrorMessage" runat="server" Text="<%$ Resources:JobsResources, TextFieldMaximumLength %>"></asp:Literal>
    </strong>
</asp:RegularExpressionValidator>
<br />
<br />
<asp:Label ID="LabelPhoneNumber" Text="<%$ Resources:JobsResources, PhoneNumber %>"
    runat="server" AssociatedControlID="Phone" Font-Bold="True" /><br />
<asp:TextBox ID="Phone" runat="server" Width="100%" MaxLength="40" />
<asp:RequiredFieldValidator ID="PhoneRequiredValidator" runat="server" CssClass="sfError"
    Display="Dynamic" ControlToValidate="Phone" SetFocusOnError="true">
    <strong>
        <asp:Literal ID="pnRequired" runat="server" Text="<%$ Resources:JobsResources, PhoneNumberRequired %>"></asp:Literal>
    </strong>
</asp:RequiredFieldValidator>
<asp:RegularExpressionValidator runat="server" ID="PhoneRegularExpressionValidator"
    ControlToValidate="Phone" CssClass="sfError" Display="Dynamic" SetFocusOnError="true"
    ValidationExpression="^[0-9]+[.]*[0-9]*$">
    <strong>
        <asp:Literal ID="pnErrorMessage" runat="server" Text="<%$ Resources:JobsResources, InvalidPhoneNumber %>"></asp:Literal>
    </strong>
</asp:RegularExpressionValidator>
<br />
<br />
<asp:Label ID="LabelHowDidYouHear" Text="<%$ Resources:JobsResources, HowDidYouHear %>"
    runat="server" AssociatedControlID="HowDidYouHear" Font-Bold="True" /><br />
<telerik:RadComboBox ID="HowDidYouHear" runat="server">
    <items>
    <telerik:RadComboBoxItem runat="server" Value="Internet Ad" Text="<%$ Resources:JobsResources, InternetAd %>"/>
    <telerik:RadComboBoxItem runat="server" Value="Mobile Phone Ad" Text="<%$ Resources:JobsResources, MobilePhoneAd %>"/>
    <telerik:RadComboBoxItem runat="server" Value="Social Network" Text="<%$ Resources:JobsResources, SocialNetwork %>"/>
    <telerik:RadComboBoxItem runat="server" Value="Television Ad" Text="<%$ Resources:JobsResources, TelevisionAd %>"/>
    <telerik:RadComboBoxItem runat="server" Value="Web Link" Text="<%$ Resources:JobsResources, WebLink %>"/>
    <telerik:RadComboBoxItem runat="server" Value="Web Search" Text="<%$ Resources:JobsResources, WebSearch %>"/>
    <telerik:RadComboBoxItem runat="server" Value="Magazine Ad" Text="<%$ Resources:JobsResources, MagazineAd %>"/>
    <telerik:RadComboBoxItem runat="server" Value="Other" Text="<%$ Resources:JobsResources, Other %>"/>
</items>
</telerik:RadComboBox>
<br />
<br />
<asp:Label ID="LabelMotivationalText" Text="<%$ Resources:JobsResources, MotivationalText %>"
    runat="server" AssociatedControlID="MotivationalText" Font-Bold="True" />
<br />
<asp:TextBox runat="server" ID="MotivationalText" Height="150px" Width="100%" TextMode="MultiLine"></asp:TextBox>
<asp:RequiredFieldValidator ID="MotivationalRequiredValidator" runat="server" CssClass="sfError"
    Display="Dynamic" ControlToValidate="MotivationalText" SetFocusOnError="true">
    <strong>
        <asp:Literal ID="MotivationalTextRequiredMessage" runat="server" Text="<%$ Resources:JobsResources, MotivationalTextCannotBeEmpty %>"></asp:Literal>
    </strong>
</asp:RequiredFieldValidator>
<asp:RegularExpressionValidator runat="server" ID="MotivationalTextRegularExpressionValidator"
    ControlToValidate="MotivationalText" CssClass="sfError" Display="Dynamic" SetFocusOnError="true"
    ValidationExpression="^[\s\S]{0,200}$">
    <strong>
        <asp:Literal ID="MotivationalTextLengthMessage" runat="server" Text="<%$ Resources:JobsResources, TextAreaMaximumLength %>"></asp:Literal>
    </strong>
</asp:RegularExpressionValidator>
<br />
<br />
<asp:Button runat="server" ID="SubmitButton" Text="<%$ Resources:JobsResources, Submit %>"
    Width="60px" />